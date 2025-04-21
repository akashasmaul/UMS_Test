using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public class NewAdmissionPage 
    {
        private IWebDriver driver;
        private NewAdmissionElements _element;
       
        

        public NewAdmissionPage(IWebDriver driver, NewAdmissionElements newElement)
        {
            this.driver = driver;
            this._element = newElement;

        }

        public IWebElement StudentButton() => driver.FindElement(_element.StudentButton);

        public IWebElement AdmissionNav() => driver.FindElement(_element.AdmissionNav);

        public IWebElement NewAdmissionButton() => driver.FindElement(_element.NewAdmissionButton);

        public IWebElement StudentFindSubmitButton() => driver.FindElement(_element.StudentFindSubmitButton);

        public IWebElement NewStudentButton() => driver.FindElement(_element.NewStudentButton);

        //  public IWebElement NickName() => driver.FindElement(_element.NickName);

        public async Task NickName(string name)
        {
            string randomName = await GetRandomWordFromAPI();
            driver.FindElement(_element.NickName).SendKeys(name + " " + randomName);
            // driver.FindElement(NickName).SendKeys(name);
        }

        public IWebElement MobileNumber() => driver.FindElement(_element.MobileNumber);

        public SelectElement SelectGender() => new SelectElement(driver.FindElement(_element.Gender));

        public SelectElement SelectRelgion() => new SelectElement(driver.FindElement(_element.Religion));

        public SelectElement SelectClass() => new SelectElement(driver.FindElement(_element.Class));

        public void SelectProgram(string program)
        {
            new SelectElement(driver.FindElement(_element.Program)).SelectByText(program);

            var programElement = driver.FindElement(By.XPath($"//select[@id='Program']/option[text()=\"{program}\"]"));
            _element.programId = programElement.GetAttribute("value");

            Console.WriteLine($"Selected Program: {program}, Program ID: {_element.programId}");
        }

        public SelectElement SelectSession() => new SelectElement(driver.FindElement(_element.Session));

        public void LastInstitution(string lastInst)
        {
            driver.FindElement(_element.LastInstitute).SendKeys(lastInst);
            driver.FindElement(_element.SelectLastInstitute).Click();
        }

        public SelectElement SelectStudyVersion() => new SelectElement(driver.FindElement(_element.StudyVersion));

        public SelectElement SelectBranch() => new SelectElement(driver.FindElement(_element.Branch));

        public SelectElement SelectCampus() => new SelectElement(driver.FindElement(_element.Campus));

        public void SelectPhysicalBranch(string phyBranch)
        {
            if (IsElementPresentAndClickable(_element.PhysicalBranch))
            {
                SelectElement select = new SelectElement(driver.FindElement(_element.PhysicalBranch));
                select.SelectByText(phyBranch);
            }
            else Console.WriteLine("Physical Branch is Not Needed for base Program");
        }

        public void SelectSecondTimerStatus(string status)
        {
            Dictionary<string, string> statusMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "First Timer", "10" }, { "1", "10" }, { "First", "10" }, { "1st", "10" }, { "No", "10" },
                { "Second Timer", "20" }, { "2", "20" }, { "Second", "20" }, { "2nd", "20" }, { "Yes", "20" },
                { "MBBS/BDS Enrolled", "30" }, { "3", "30" }, { "Third", "30" }, { "Enrolled", "30" },
                { "3rd", "30" }, { "MBBS", "30" }, { "BDS", "30" }
        };

            string radioValue = statusMapping.ContainsKey(status) ? statusMapping[status] : "10";
            _element.SecondTimerStatus = By.XPath($"//input[@name='MbbsBdsStatus' and @value='{radioValue}']");

            if (IsElementPresentAndClickable(_element.SecondTimerStatus))
            {
                driver.FindElement(_element.SecondTimerStatus).Click();
            }
        }

        public void SelectAcademicGroup(string AcademicGroup)
        {
            string academicValue = "null";

            if (AcademicGroup == "Science")
            {
                academicValue = "10";
            }
            else if (AcademicGroup == "Humanities")
            {
                academicValue = "20";
            }
            else if (AcademicGroup == "Commerce")
            {
                academicValue = "30";
            }

            _element.academicGroup = By.XPath($"//input[@name='AcademicGroup' and @value='{academicValue}']");

            if (IsElementPresentAndClickable(_element.academicGroup))
            {
                driver.FindElement(_element.academicGroup).Click();
            }
            else Console.WriteLine("Academic Group Not Found for this Program");
        }

        public void SelectCourse(string course)
        {
            try
            {
                var courseElement = driver.FindElement(By.XPath($"//input[@data-course-name=\"{course}\"]"));
                _element.courseId = courseElement.GetAttribute("data-course-id");
                _element.Course = By.XPath($"//input[@type='checkbox' and @data-course-id='{_element.courseId}']");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                IWebElement checkbox = wait.Until(ExpectedConditions.ElementToBeClickable(_element.Course));

                if (!checkbox.Selected) // Ensure the checkbox is not already selected
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(checkbox).Click().Perform();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Course '{course}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting course '{course}': {ex.Message}");
            }
        }

        public void SelectSubject(string subjects, string course)
        {
            // XPath to find the subject checkboxes under the given course
            By courseSubjectsXPath = By.XPath($"//div[@data-bodyname=\"{course}\"]//input[@type='checkbox']");

            // Check if the course has subject selection options
            if (!IsElementPresentAndClickable(courseSubjectsXPath))
            {
                Console.WriteLine($"Course \"{course}\" does not have subject selection. Skipping...");
                return; // Exit the method early
            }

            // XPath to find the checkbox where data-course-name matches the provided course name
            string escapedCourse = course.Replace("'", "&apos;");
            By courseCheckboxXPath = By.XPath($"//input[@type='checkbox' and @data-course-name='{escapedCourse}']");

            // Wait for the checkbox to be present for the given course
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3)); // Increased timeout for better reliability
            IWebElement courseCheckbox = wait.Until(driver => driver.FindElement(courseCheckboxXPath));

            // Fetch data-total-subject and data-maximumsubject attributes
            string totalSubjects = courseCheckbox.GetAttribute("data-total-subject") ?? "N/A";
            string minSubjects = courseCheckbox.GetAttribute("data-publicminsubject") ?? "N/A";
            string maxSubjects = courseCheckbox.GetAttribute("data-maximumsubject") ?? "N/A";

            // Print total and max subjects
            Console.WriteLine($"Total Subjects: {totalSubjects}");
            Console.WriteLine($"Minimum Subjects: {minSubjects}");
            Console.WriteLine($"Maximum Subjects: {maxSubjects}");

            // Split subject names from Excel into a HashSet for faster lookup
            HashSet<string> subjectSet = new HashSet<string>(subjects.Split(',').Select(s => s.Trim()));

            // Print subjects found in the Excel parameter
            //    Console.WriteLine($"Subjects from Excel: {string.Join(", ", subjectSet)}");
            Console.WriteLine($"Total Subjects Available in Excel: {subjectSet.Count}");

            // Fetch all the subject checkboxes under the given course
            IReadOnlyCollection<IWebElement> allSubjects = driver.FindElements(courseSubjectsXPath);

            // List to store selected subjects
            List<string> selectedSubjects = new List<string>();

            // Loop through each subject and select or deselect based on the list from Excel
            foreach (IWebElement checkbox in allSubjects)
            {
                // Get the subject name from the checkbox's data attribute
                string subjectName = checkbox.GetAttribute("data-course-subject-name");

                // Check if the subject is in the list from Excel
                if (subjectSet.Contains(subjectName))
                {
                    // Add the subject to the selected list
                    selectedSubjects.Add(subjectName);

                    // Ensure the subject is selected
                    if (!checkbox.Selected)
                    {
                        // Handle the "readonly" attribute by removing it temporarily
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('readonly')", checkbox);
                        checkbox.Click();
                        Console.WriteLine($"Selected: {subjectName}");
                    }
                }
                else
                {
                    // Deselect the subject if it's not in the list
                    if (checkbox.Selected)
                    {
                        // Handle the "readonly" attribute by removing it temporarily
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('readonly')", checkbox);
                        checkbox.Click();
                        Console.WriteLine($"Deselected: {subjectName}");
                    }
                }
            }

            // Print all selected subjects
            Console.WriteLine($"Selected Subjects: {string.Join(", ", selectedSubjects)}");
        }

        public void SelectbatchType(string batchType)
        {
            int batchTypeLocal;

            if (batchType == "Sat, Mon, Wed" || batchType == "Sat" || batchType == "Saturday" || batchType == "1")
            { batchTypeLocal = 1; }
            else if (batchType == "Sun, Tue, Thu" || batchType == "Sun" || batchType == "Sunday" || batchType == "2")
            { batchTypeLocal = 2; }
            else { batchTypeLocal = 0; Console.WriteLine("Default Batch Type Selected"); }

            if (_element.programId == "82")
            { batchTypeLocal = 0; }

            _element.BatchType = By.XPath($"//select[contains(@class, 'batch-day-course') and @data-course-id='{_element.courseId}']");
            SelectElement select = new SelectElement(driver.FindElement(_element.BatchType));
            select.SelectByIndex(batchTypeLocal);
        }

        public void SelectbatchTime(string batchTime)
        {
            string batchTimeLocal = batchTime;

            if (batchTime == "1:30 PM To 4:00 PM" || batchTime == "1")
            { batchTimeLocal = "1:30 PM To 4:00 PM"; }
            else if (batchTime == "10:15 AM To 12:45 PM" || batchTime == "2")
            { batchTimeLocal = "10:15 AM To 12:45 PM"; }
            else if (batchTime == "4:15 PM To 6:45 PM" || batchTime == "3")
            { batchTimeLocal = "4:15 PM To 6:45 PM"; }
            else if (batchTime == "7:15 AM To 9:45 AM" || batchTime == "4")
            { batchTimeLocal = "7:15 AM To 9:45 AM"; }
            else { batchTimeLocal = batchTime; Console.WriteLine("Invalid Batch Type Found. Default Selected"); }

            if (_element.programId == "82") //Varsity 'Ka'
            { _element.courseId = "1445"; }

            _element.BatchTime = By.XPath($"//select[contains(@class, 'batch-time-course') and @data-course-id='{_element.courseId}']");
            SelectElement select = new SelectElement(driver.FindElement(_element.BatchTime));
            select.SelectByValue(batchTimeLocal);
            Console.WriteLine("Check");
        }

        public IWebElement NextBtn() => driver.FindElement(_element.NewAdmissionNextBtn);
        public void ClickNext()
        {
            var element = NextBtn();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public IWebElement SpecialDiscount() => driver.FindElement(_element.SpecialDiscount);

        public void DiscountBy(string approveBy)
        {
            Thread.Sleep(500);
            driver.FindElement(_element.DiscountApprovedBy).SendKeys(approveBy);
            driver.FindElement(_element.ElementToClick).Click();
        }

        public SelectElement SelectDiscountType() => new SelectElement(driver.FindElement(_element.DiscountType));

        public IWebElement SpecialDisountNote() => driver.FindElement(_element.DiscountNote);

        public void NetRecieveAmount()
        {
            var netReceivableField = driver.FindElement(By.Id("netReceivable"));
            var recievedAmount = netReceivableField.GetAttribute("value");
            _element.recievedAmountFetched = recievedAmount;
        }
        public string getRecievedAmountAutoFetched()
        {
            return _element.recievedAmountFetched;
        }

        public IWebElement RecievedAmount() => driver.FindElement(_element.RecieveAmount);

        public IWebElement SubmitBtn() => driver.FindElement(_element.SubmitBtn);

        // Utility methods
        public void ScrollDown()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown).Perform();
        }

        private bool IsElementPresentAndClickable(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return element.Displayed && element.Enabled;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        private async Task<string> GetRandomWordFromAPI()
        {
            using HttpClient client = new HttpClient();
            string apiUrl = "https://random-word-api.herokuapp.com/word";

            string response = await client.GetStringAsync(apiUrl);

            // Clean the response (since the API returns ["word"])
            return response.Trim(new char[] { '[', ']', '"' });
        }
    }
}