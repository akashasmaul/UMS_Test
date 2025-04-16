using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public class NewAdmissionPage : NewAdmissionElements
    {
        private IWebDriver driver;
        private NewAdmissionElements newElement;

        public NewAdmissionPage(IWebDriver driver, NewAdmissionElements newElement)
        {
            this.driver = driver;
            this.newElement = newElement;

        }

        public IWebElement StudentButton() => driver.FindElement(newElement.xStudentButton);

        public IWebElement AdmissionNav() => driver.FindElement(xAdmissionNav);

        public IWebElement NewAdmissionButton() => driver.FindElement(xNewAdmissionButton);

        public IWebElement StudentFindSubmitButton() => driver.FindElement(xStudentFindSubmitButton);

        public IWebElement NewStudentButton() => driver.FindElement(xNewStudentButton);

        //  public IWebElement NickName() => driver.FindElement(xNickName);

        public async Task NickName(string name)
        {
            string randomName = await GetRandomWordFromAPI();
            driver.FindElement(xNickName).SendKeys(name + " " + randomName);
            // driver.FindElement(xNickName).SendKeys(name);
        }

        public IWebElement MobileNumber() => driver.FindElement(xMobileNumber);

        public SelectElement SelectGender() => new SelectElement(driver.FindElement(xGender));

        public SelectElement SelectRelgion() => new SelectElement(driver.FindElement(xReligion));

        public SelectElement SelectClass() => new SelectElement(driver.FindElement(xClass));

        public void SelectProgram(string program)
        {
            new SelectElement(driver.FindElement(xProgram)).SelectByText(program);

            var programElement = driver.FindElement(By.XPath($"//select[@id='Program']/option[text()=\"{program}\"]"));
            programId = programElement.GetAttribute("value");

            Console.WriteLine($"Selected Program: {program}, Program ID: {programId}");
        }

        public SelectElement SelectSession() => new SelectElement(driver.FindElement(xSession));

        public void LastInstitution(string lastInst)
        {
            driver.FindElement(xLastInstitute).SendKeys(lastInst);
            driver.FindElement(xSelectLastInstitute).Click();
        }

        public SelectElement SelectStudyVersion() => new SelectElement(driver.FindElement(xStudyVersion));

        public SelectElement SelectBranch() => new SelectElement(driver.FindElement(xBranch));

        public SelectElement SelectCampus() => new SelectElement(driver.FindElement(xCampus));

        public void SelectPhysicalBranch(string phyBranch)
        {
            if (IsElementPresentAndClickable(xPhysicalBranch))
            {
                SelectElement select = new SelectElement(driver.FindElement(xPhysicalBranch));
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
            xSecondTimerStatus = By.XPath($"//input[@name='MbbsBdsStatus' and @value='{radioValue}']");

            if (IsElementPresentAndClickable(xSecondTimerStatus))
            {
                driver.FindElement(xSecondTimerStatus).Click();
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

            xacademicGroup = By.XPath($"//input[@name='AcademicGroup' and @value='{academicValue}']");

            if (IsElementPresentAndClickable(xacademicGroup))
            {
                driver.FindElement(xacademicGroup).Click();
            }
            else Console.WriteLine("Academic Group Not Found for this Program");
        }

        public void SelectCourse(string course)
        {
            try
            {
                var courseElement = driver.FindElement(By.XPath($"//input[@data-course-name=\"{course}\"]"));
                courseId = courseElement.GetAttribute("data-course-id");
                xCourse = By.XPath($"//input[@type='checkbox' and @data-course-id='{courseId}']");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                IWebElement checkbox = wait.Until(ExpectedConditions.ElementToBeClickable(xCourse));

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

            if (programId == "82")
            { batchTypeLocal = 0; }

            xBatchType = By.XPath($"//select[contains(@class, 'batch-day-course') and @data-course-id='{courseId}']");
            SelectElement select = new SelectElement(driver.FindElement(xBatchType));
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

            if (programId == "82") //Varsity 'Ka'
            { courseId = "1445"; }

            xBatchTime = By.XPath($"//select[contains(@class, 'batch-time-course') and @data-course-id='{courseId}']");
            SelectElement select = new SelectElement(driver.FindElement(xBatchTime));
            select.SelectByValue(batchTimeLocal);
            Console.WriteLine("Check");
        }

        public IWebElement NextBtn() => driver.FindElement(xNewAdmissionNextBtn);
        public void ClickNext()
        {
            var element = NextBtn();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public IWebElement SpecialDiscount() => driver.FindElement(xSpecialDiscount);

        public void DiscountBy(string approveBy)
        {
            Thread.Sleep(500);
            driver.FindElement(xDiscountApprovedBy).SendKeys(approveBy);
            driver.FindElement(xElementToClick).Click();
        }

        public SelectElement SelectDiscountType() => new SelectElement(driver.FindElement(xDiscountType));

        public IWebElement SpecialDisountNote() => driver.FindElement(xDiscountNote);

        public void NetRecieveAmount()
        {
            var netReceivableField = driver.FindElement(By.Id("netReceivable"));
            var recievedAmount = netReceivableField.GetAttribute("value");
            recievedAmountFetched = recievedAmount;
        }

        public IWebElement RecievedAmount() => driver.FindElement(xRecieveAmount);

        public IWebElement SubmitBtn() => driver.FindElement(xSubmitBtn);

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