using UMS.UI.Test.BusinessModel;
using UMS.UI.Test.BusinessModel.Dto.Student;
using UMS.UI.Test.BusinessModel.Enum;
using UMS.UI.Test.BusinessModel.Enum.Student;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.Repository.Dao.Student;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    [Binding]
    public sealed class NewAdmissionStep
    {
        private string _courseId = null!;
        private double _totalCourseFee;
        private double _dueAmount;
        private double _paidAmount = 0;
        private double _offeredDiscount;
        private double _prevStdDiscount;
        private double _specialDiscount;
        private double _payableAmount;
        private double _minimumAmount;
        private IWebElement? _webElement;
        private SelectElement? _selectElement;
        private IList<IWebElement>? _webElements;

        private readonly StudentDao _dao;
        private readonly AdmissionDto _dto;
        private readonly IConfiguration _configuration;
        private readonly IList<(string Id, int Count)> _subjectCourses;
        private readonly IDictionary<int, string> _prerequisiteCourses;

        private readonly NewAdmissionPage _page;
        private readonly ScenarioInfo _scenarioInfo;
        public NewAdmissionStep(NewAdmissionPage page, ScenarioInfo scenarioInfo)
        {
            _page = page;
            _scenarioInfo = scenarioInfo;

            _dao = new StudentDao();
            _dto = new AdmissionDto();
            _configuration = AppHelper.GetAppSettings();
            _subjectCourses = new List<(string, int)>();
            _prerequisiteCourses = new Dictionary<int, string>();
        }

        /*
        [Given(@"I am logged in with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIAmLoggedInWithEmailAndPassword(string email, string password)
        {
        }*/

        [Given(@"Goto New Or Old Student Admission")]
        public void WhenGotoNewOrOldStudentAdmission()
        {
            _page.GetNewOrOldStudentAdmissionMenu().Click();
        }

        [When(@"Enter Student RegOrRoll Number ""([^""]*)""")]
        public void WhenEnterStudentRegOrRollNo(string number)
        {
            //db = StudentDao.GetAdmissionInfo();
            _dto.RegisterNo = TestHelper.IsValidRegOrRoll(number) ? number : _dao.GetAdmissionInfo().RegisterNo;
            _page.GetStudentRegOrRollNumber().SendKeys(_dto.RegisterNo);
        }

        [When(@"Enter Visited Student Id Number")]
        public void WhenEnterVisitedStudentIdNumber()
        {
            //db = StudentDao.GetAdmissionInfo();
            _page.GetStudentRegOrRollNumber().SendKeys(_dao.GetAdmissionInfo().RegisterNo);
        }

        [When(@"Navigate Old Student Admission")]
        public void WhenGotoOldStudentAdmission()
        {
            _page.GetOldStudentAdmissionButton().Click();
            //Assert.False(_admissionPage.GetShownErrorMessage()!.Displayed);
        }

        [Then(@"Shown Old Student Admission Page")]
        public void ThenShownOldStudentAdmissionPage()
        {
            Assert.True(_page.GetOldStudentAdmissionPage().Displayed);
            //admission.AdmissionType = AdmissionType.OldAdmission.ToString();
            _dto.ActionType = nameof(PaymentType.OldAdmission);
        }

        [Then(@"Shown Admission Status Is Visited")]
        public void ThenShownAdmissionStatusIsVisited()
        {
            var status = _page.GetVisitedAdmissionStatus();
            if (status != null)
                Assert.Contains("Visited", status.Text);
            else
                Assert.Fail("Student isn't Visited.");

            _dto.ActionType = nameof(PaymentType.VisitedAdmission);
        }

        [Given(@"Navigate New Student Admission")]
        public void GivenGotoNewStudentAdmission()
        {
            _page.GetNewStudentAdmission().Click();
        }

        [Then(@"Shown New Student Admission Page")]
        public void ThenShownNewStudentAdmissionPage()
        {
            Assert.True(_page.GetNewStudentAdmissionPage().Displayed);
            _dto.ActionType = nameof(PaymentType.NewAdmission);
        }

        [When(@"Enter The Student Nickname ""([^""]*)""")]
        public void WhenEnterStudentNickname(string nickName)
        {
            _dto.NickName = TestHelper.IsValidNickname(nickName) ? nickName : TestHelper.GetUniqueName();
            _page.GetStudentNickname().SendKeys(_dto.NickName);
        }

        [When(@"Enter The Student Mobile Number ""([^""]*)""")]
        public void WhenEnterStudentMobileNumber(string mobile)
        {
            _dto.MobileNo = TestHelper.IsValidMobileNo(mobile) ?
                mobile : UserCredential.GetAdminInfo().Mobile ?? _configuration["Admin:MobileNo"];
            _page.GetStudentMobileNumber().Clear();
            _page.GetStudentMobileNumber().SendKeys(_dto.MobileNo);
        }

        [When(@"Select Student Gender ""([^""]*)""")]
        public void WhenSelectStudentGender(string gender)
        {
            _webElement = _page.GetStudentGender();
            if (Regex.IsMatch(gender, @"^(Male|Female)$"))
                _webElement.SendKeys(gender);
            else
                TestHelper.RandomOptionSelector(_webElement);
        }

        [When(@"Select Student Religion ""([^""]*)""")]
        public void WhenSelectStudentReligion(string religion)
        {
            var pattern = @"^(Islam|Hinduism|Christianity|Buddhism|Other)$";
            if (Regex.IsMatch(religion = religion.Trim(), pattern))
            {
                _webElement = _page.GetStudentReligion();
                _selectElement = new SelectElement(_webElement);
                _selectElement.SelectByText(religion);
            }
        }

        [When(@"Select Student Class ""([^""]*)"" Type")]
        public void WhenSelectStudentClassType(string classType)
        {
            _dto.ClassType = classType.Trim();
            _webElement = _page.GetStudentClassType();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(_dto.ClassType);
        }

        [When(@"Select Student Program ""([^""]*)"" Name")]
        public void WhenSelectStudentProgramName(string program)
        {
            _dto.Program = program.Trim();
            _webElement = _page.GetStudentProgram();
            _selectElement = new SelectElement(_webElement);

            if (TestHelper.IsNumber(program))
                _selectElement.SelectByValue(_dto.Program);
            else
                _selectElement.SelectByText(_dto.Program);
        }

        [When(@"Select Session ""([^""]*)"" Of Program")]
        public void WhenSelectSessionOfProgram(string session)
        {
            _dto.Session = session.Trim();
            _webElement = _page.GetStudentSession();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(_dto.Session);
            //Assert.True(_page.GetCourseDetails().Displayed);
        }

        [When(@"Search Educational Institute Name")]
        public void WhenSearchEducationalInstituteName()
        {
            _webElement = _page.GetEducationalInstitute();
            _webElement.Clear();
            _webElement.SendKeys("108258");
            try
            {
                _page.GetSelectInstituteName().Click();
            }
            catch
            {
                WhenSearchEducationalInstituteName();
            }
        }

        [When(@"Select Study Version ""([^""]*)"" Type")]
        public void WhenSelectStudyVersionType(string version)
        {
            _dto.Version = version.Trim();
            _webElement = _page.GetStudyVersion();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(_dto.Version);
        }

        [When(@"Select Branch Name ""([^""]*)"" Of Program")]
        public void WhenSelectBranchNameOfProgram(string branch)
        {
            _dto.Branch = branch.Trim();
            _webElement = _page.GetBranchName();
            _selectElement = new SelectElement(_webElement);
            _selectElement.SelectByText(_dto.Branch);

            _webElement = _page.GetAttachedPhysicalBranch();
            if (_webElement.Displayed)
            {
                _selectElement = new SelectElement(_webElement);
                _selectElement.SelectByText(_dto.Branch);
            }
            _dto.Organization = TestHelper.GetOrganizationByBranch(branch);
        }

        [When(@"Select Campus Name ""([^""]*)"" Of Branch")]
        public void WhenSelectCampusNameOfBranch(string campus)
        {
            _dto.Campus = campus.Trim();
            _webElement = _page.GetCampusName();
            new SelectElement(_webElement).SelectByText(_dto.Campus);
        }

        [When(@"Click On Is Student Second Timer ""([^""]*)""")]
        public void WhenClickOnIsStudentSecondTimer(string timer)
        {
            _dto.Is2ndTime = timer.Trim();
            _webElement = _page.GetSecondTimer(_dto.Is2ndTime);
            if (_webElement.Displayed)
            {
                _webElement.Click();
            }
        }

        [When(@"Click On Student Academic Group ""([^""]*)""")]
        public void WhenClickOnStudentAcademicGroup(string group)
        {
            _webElement = _page.GetAcademicGroup(group);
            if (_webElement.Displayed)
            {
                _webElement.Click();
            }
        }

        [When(@"Select Course Name ""([^""]*)""")]
        public void WhenSelectCourseName(string course)
        {
            _webElement = _page.GetCourseList()
                .Single(c => c.GetAttribute("data-course-name") == course || c.GetAttribute("data-course-id") == course);

            _webElement.Click();
            _courseId = _webElement.GetAttribute("data-course-id");
            _dto.Course += string.IsNullOrEmpty(_dto.Course) ? _courseId : ',' + _courseId;
            _minimumAmount = double.Parse(_webElement.GetAttribute("data-officeminpayment"));
        }

        [When(@"Select Course Name Of This Program")]
        public void WhenSelectCourseNameOfThisProgram()
        {
            var courseWebElements = _page.GetCourseList();
            foreach (var courseWebElement in courseWebElements)
            {
                _courseId = courseWebElement.GetAttribute("data-course-id");
                _webElement = _page.GetBatchType(_courseId);
                var webElements = TestHelper.GetElementOptions(_webElement);

                var firstItem = webElements[0].Text != "Select Batch Type";
                if ((firstItem || webElements.Count > 1) && !courseWebElement.Selected)
                {
                    courseWebElement.Click();
                    _dto.Course = courseWebElement.Selected ? _courseId : null;
                }
                if (courseWebElement.Selected)
                {
                    var amount = courseWebElement.GetAttribute("data-officeminpayment");
                    _minimumAmount = double.Parse(amount); break;
                }
            }
        }

        [When(@"Select Course Name ""([^""]*)"" Of Program")]
        public void WhenSelectCourseNameOfProgram(string course)
        {
            var courses = course.Split(',', StringSplitOptions.TrimEntries).ToList();
            foreach (var item in courses)
            {
                var courseWebElement = _page.GetCourseList().Single(c =>
                    c.GetAttribute("data-course-name") == item || c.GetAttribute("data-course-id") == item);

                if (courseWebElement.Enabled && courseWebElement.Selected == false)
                {
                    courseWebElement.Click();
                    if (courseWebElement.Enabled && courseWebElement.Selected)
                    {
                        _courseId = courseWebElement.GetAttribute("data-course-id");
                        _dto.Course += string.IsNullOrEmpty(_dto.Course) ? _courseId : ',' + _courseId;

                        var batchType = _page.GetBatchType(_courseId);
                        TestHelper.BatchItemsSelector(batchType, Batch.Type);
                        var batchTime = _page.GetBatchTime(_courseId);
                        TestHelper.BatchItemsSelector(batchTime, Batch.Time);
                        var batchName = _page.GetBatchName(_courseId);
                        TestHelper.BatchItemsSelector(batchName, Batch.Name);

                        var amount = courseWebElement.GetAttribute("data-officeminpayment");
                        _minimumAmount += double.Parse(amount);

                        var maxSubCount = int.Parse(courseWebElement.GetAttribute("data-maximumsubject"));
                        var subjects = _page.GetSubjectCheckboxes(_courseId);
                        if (maxSubCount < subjects.Count)
                        {
                            var uncheckCount = subjects.Count - maxSubCount;
                            _subjectCourses.Add((_courseId, uncheckCount));
                        }

                        var isPrerequisite = courseWebElement.GetAttribute("data-has-prerequisite-course");
                        if (bool.Parse(isPrerequisite))
                        {
                            var jsonString = courseWebElement.GetAttribute("data-prerequisite-courses");
                            foreach (var id in JArray.Parse(jsonString)
                                .SelectMany(group => group["CourseIdList"]!.Select(id => (int)id)))
                            {
                                var prerequisiteCourse = _page.GetCourseList()?
                                    .FirstOrDefault(c => !c.Selected && c.Enabled && c.Displayed &&
                                    c.GetAttribute("data-course-id") == $"{id}");

                                if (prerequisiteCourse != null && _prerequisiteCourses.ContainsKey(id) == false)
                                {
                                    var courseName = prerequisiteCourse.GetAttribute("data-course-name");
                                    _prerequisiteCourses[id] = courseName;
                                }
                            }
                            /*
                            foreach (var group in JArray.Parse(jsonString))
                            {
                                foreach (var id in group["CourseIdList"]!.Select(id => (int)id))
                                {
                                    if (prerequisiteCourses.ContainsKey(id) == false)
                                    {
                                        //var prerequisiteCourseName = _admissionPage.GetCourseListThisProgram()
                                        //    .FirstOrDefault(c => c.GetAttribute("data-course-id") == $"{id}")!
                                        //    .GetAttribute("data-course-name");
                                        var prerequisiteCourse = _admissionPage.GetCourseListThisProgram()
                                            .Where(c => c.Selected == false && c.Enabled && c.Displayed)
                                            .FirstOrDefault(c => c.GetAttribute("data-course-id") == $"{id}")!;
                                        if (prerequisiteCourse is not null)
                                        {
                                            var courseName = prerequisiteCourse.GetAttribute("data-course-name");
                                            prerequisiteCourses.Add(id, courseName);
                                        }
                                        //prerequisiteCourses.Add(id, prerequisiteCourseName);
                                    }
                                }
                            }
                            */
                        }
                    }
                }
            }
        }

        [Then(@"Can Take Any Course of This Program")]
        public void ThenCanTakeAnyCourseOfThisProgram()
        {
            _webElements = _page.GetCourseList();
            foreach (var webElement in _webElements)
            {
                Assert.True(webElement.Enabled == false);
                //Assert.True(webElement.GetAttribute("disabled").Equals("true"));
                Assert.Equal("true", webElement.GetAttribute("disabled"));
            }
        }

        [When(@"Click On Complementary Course Name ""([^""]*)""")]
        public void WhenClickOnComplementaryCourse(string course)
        {
            course = course != string.Empty ? course.Trim() : string.Empty;
            _page.GetComplementaryCourseName(course).Click();
        }

        [Then(@"Shown Complementary Confirmation Modal")]
        public void ThenShownComplementaryConfirmationModal()
        {
            Assert.True(_page.GetComplementaryPopupModal().Displayed);
        }

        [When(@"Click On Confirm Button In Modal")]
        public void WhenClickOnConfirmButtonInModal()
        {
            _webElement = _page.GetComplementaryPopupModal();
            if (_webElement.Displayed)
            {
                Assert.True(_webElement.Displayed);
                _page.GetConfirmButtonInModal().Click();
            }
        }

        [Then(@"Is Show Complementary Course List")]
        public void ThenIsShowComplementaryCourses()
        {
            Assert.True(_page.GetAllCourse().Displayed);

            _webElement = _page.GetStudentProgram();
            _dto.Program = _webElement.GetAttribute("value");
            _dto.ActionType = nameof(PaymentType.Complementary);
        }

        [When(@"Click On Subject Unchecked Box")]
        public void WhenClickOnSubjectUncheckedBox()
        {
            _webElements = _page.GetSubjectCheckboxes(_courseId);
            _webElements[^1].Click();
        }


        [When(@"Select Batch Type Of This Course")]
        public void WhenSelectBatchTypeOfThisCourse()
        {
            _webElement = _page.GetBatchType(_courseId);
            TestHelper.BatchItemsSelector(_webElement, Batch.Type);
        }

        [When(@"Select Batch Time Of This Course")]
        public void WhenSelectBatchTimeOfThisCourse()
        {
            _webElement = _page.GetBatchTime(_courseId);
            TestHelper.BatchItemsSelector(_webElement, Batch.Time);
        }

        [When(@"Select Batch Name Of This Course")]
        public void WhenSelectBatchNameOfThisCourse()
        {
            _webElement = _page.GetBatchName(_courseId);
            TestHelper.BatchItemsSelector(_webElement, Batch.Name);
        }

        [When(@"Click On Admission Payment Next Button")]
        public void WhenClickOnAdmissionPaymentNextButton()
        {
            _page.GetAdmissionPaymentNextButton().Click();

            while (IsShowCourseError()) ;
        }

        private bool IsShowCourseError()
        {
            var errorText = _page.GetShownErrorMessage()?.Text;
            var isTrue = string.IsNullOrEmpty(errorText) == false;

            if (isTrue && errorText!.Contains("Maximum subject"))
            {
                foreach (var (courseId, uncheckCount) in _subjectCourses)
                {
                    var subjectWebElements = _page.GetSubjectCheckboxes(courseId);
                    for (int i = 1; i <= uncheckCount; i++)
                    {
                        subjectWebElements[subjectWebElements.Count - i].Click();
                    }
                }
                _subjectCourses.Clear();
                _page.GetAdmissionPaymentNextButton().Click();
                return true;
            }
            else if (isTrue && errorText!.Contains("Compulsary"))
            {
                var courseWebElements = _page.GetCompulsoryCourses().Where(c => c.Enabled);
                foreach (var courseWebElement in courseWebElements)
                {
                    var courseName = courseWebElement.GetAttribute("data-course-name");
                    WhenSelectCourseNameOfProgram(courseName);
                }
                _page.GetAdmissionPaymentNextButton().Click();
                return true;
            }
            else if (isTrue && errorText!.Contains("prerequisite"))
            {
                int index = 0;
                while (index < _prerequisiteCourses.Count)
                {
                    var value = _prerequisiteCourses.ElementAt(index).Key;
                    WhenSelectCourseNameOfProgram(value.ToString());
                    index++;
                }
                _prerequisiteCourses.Clear();
                _page.GetAdmissionPaymentNextButton().Click();
                return true;
            }
            return isTrue;
        }

        [Then(@"Show Admission Payment Details Section")]
        public void ThenShowAdmissionPaymentDetailsSection()
        {
            Assert.True(_page.GetPaymentDetails().Displayed);

            _webElement = _page.GetTotalCourseFee();
            _totalCourseFee = double.Parse(_webElement.GetAttribute("value"));

            _webElement = _page.GetOfferedDiscount();
            _offeredDiscount = double.Parse(_webElement.GetAttribute("value"));

            _webElement = _page.GetPrevStdDiscount();
            _prevStdDiscount = double.Parse(_webElement.GetAttribute("value"));

            _webElement = _page.GetNetReceivableAmount();
            _payableAmount = double.Parse(_webElement.GetAttribute("value"));

            Assert.True(_payableAmount == _totalCourseFee - (_prevStdDiscount + _offeredDiscount));
        }

        [When(@"Enter Special Discount ""([^""]*)"" Amount")]
        public void WhenEnterSpecialDiscountAmount(string discount)
        {
            if (string.IsNullOrEmpty(discount) == false)
            {
                _specialDiscount = Convert.ToDouble(discount);
                _page.GetSpecialDiscount().SendKeys(discount);
            }
        }

        [When(@"Enter Full Discount Amount For Top Student")]
        public void WhenEnterFullDiscountAmountForTopStudent()
        {
            _specialDiscount = _payableAmount;
            _page.GetSpecialDiscount().SendKeys(_specialDiscount.ToString());
        }

        [When(@"Select Special Discount Approved By ""([^""]*)""")]
        //[When(@"Enter Special Discount Approved By ""([^""]*)""")]
        public void WhenEnterSpecialDiscountApprovedBy(string approver)
        {
            if (_specialDiscount > 0)
            {
                _webElement = _page.GetSpDiscountApprovedBy();
                if (string.IsNullOrEmpty(approver) == false && _webElement.Enabled)
                {
                    _webElement.SendKeys(approver.Trim());
                }

                _webElement = _page.GetSpecialDiscountApprover();
                if (_webElement.Enabled && _webElement.Displayed)
                {
                    _webElement.Click();
                }
            }
        }

        [When(@"Select The Special Discount Approver")]
        public void WhenSelectTheSpecialDiscountApprover()
        {
            _webElement = _page.GetSpecialDiscountApprover();
            if (_webElement.Displayed && _webElement.Enabled)
            {
                _webElement.Click();
            }
        }

        [When(@"Select Special Discount Type ""([^""]*)""")]
        public void WhenSelectSpecialDiscountType(string discountType)
        {
            _webElement = _page.GetSpecialDiscountType();
            if (_webElement.Enabled)
            {
                _dto.SpDiscountType = discountType.Trim();
                _selectElement = new SelectElement(_webElement);
                _selectElement.SelectByText(_dto.SpDiscountType);
            }
        }

        [When(@"Select Special Discount Referred By ""([^""]*)""")]
        //[When(@"Enter Special Discount Referred By ""([^""]*)""")]
        public void WhenEnterSpecialDiscountReferredBy(string referrer)
        {
            _webElement = _page.GetSpDiscountReferredBy();
            if (_webElement.Enabled && _webElement.Displayed)
            {
                _webElement.Click();
                _webElement.SendKeys(referrer.Trim());
            }
            //element = _admissionPage.GetSpecialDiscountReferrer();
            //if (element != null && element.Displayed)
            //{
            //    try { element.Click(); } 
            //    catch { WhenEnterSpecialDiscountReferredBy(referrer); }
            //}
            try
            {
                _webElement = _page.GetSpDiscountReferrer();
                if (_webElement != null && _webElement.Displayed)
                {
                    _webElement.Click();
                }
            }
            catch { WhenEnterSpecialDiscountReferredBy(referrer); }
        }

        [When(@"Select The Special Discount Referrer")]
        public void WhenSelectTheSpecialDiscountReferrer()
        {
            _webElement = _page.GetSpDiscountReferrer();
            if (_webElement != null && _webElement.Displayed)
            {
                _webElement.Click();
            }
        }

        [When(@"Enter Admission Special Discount Note")]
        public void WhenEnterAdmissionSpecialDiscountNote()
        {
            _webElement = _page.GetSpecialDiscountNote();
            if (_webElement.Enabled)
            {
                _webElement.SendKeys(_dto.SpDiscountType);
            }
        }

        [When(@"Enter Admission Received Amount ""([^""]*)""")]
        public void WhenEnterAdmissionReceivedAmount(string receive)
        {
            var amount = receive != string.Empty ? double.Parse(receive) : byte.MinValue;
            _webElement = _page.GetNetReceivableAmount();
            _payableAmount = double.Parse(_webElement.GetAttribute("value"));

            if (amount > _minimumAmount)
                _paidAmount = _payableAmount > amount ? amount : _payableAmount;
            else
                _paidAmount = _payableAmount > _minimumAmount ? _minimumAmount : _payableAmount;

            _page.GetReceivedAmount().SendKeys(_paidAmount.ToString());

            _dueAmount = GetCurrentAvailableDueAmount();
            Assert.True(_dueAmount == _payableAmount - _paidAmount);
        }

        [When(@"Enter Full Receivable Amount ""([^""]*)""")]
        public void WhenEnterFullReceivableAmount(string receive)
        {
            var amount = receive != string.Empty ? double.Parse(receive) : byte.MinValue;
            _webElement = _page.GetNetReceivableAmount();
            _payableAmount = double.Parse(_webElement.GetAttribute("value"));

            _paidAmount = amount != _payableAmount ? _payableAmount : amount;
            _page.GetReceivedAmount().SendKeys(_paidAmount.ToString());

            _dueAmount = GetCurrentAvailableDueAmount();
            Assert.Equal(_dueAmount, _payableAmount - _paidAmount);
        }

        private double GetCurrentAvailableDueAmount()
        {
            var dueWebElement = _page.GetAvailableDueAmount();
            return Convert.ToDouble(dueWebElement.GetAttribute("value"));
        }

        [When(@"Select Next Payment Receive Date")]
        public void WhenSelectNextPaymentReceiveDate()
        {
            if (_dueAmount > 0)
            {
                var index = 1;
                var (webElement, js) = _page.GetNextPaymentReceiveDate();
                webElement.Click();
                do
                {
                    index += _page.GetEnabledReceiveDay().Count;
                    try
                    {
                        _page.GetDatePickerRightArrow().Click();
                    }
                    catch (ElementNotInteractableException) { break; }
                } while (true);

                webElement.SendKeys(Keys.Escape);
                var date = DateTime.Today.AddDays(index - DateTime.Now.Day).ToString("yyyy-MM-dd");
                js.ExecuteScript($"arguments[0].value = '{date}';", webElement);
            }
        }


        [When(@"Click On New Admission Submit Button")]
        public void WhenClickOnNewAdmissionSubmitButton()
        {
            //var jsonData = _admissionPage.GetMoneyReceiptData();
            _page.GetNewAdmissionSubmitButton().Click();

            if (IsShowMinimumCourseFeeAlert())
            {
                _page.GetNewAdmissionSubmitButton().Click();
            }
        }

        [When(@"Click On Old Admission Submit Button")]
        public void WhenClickOnOldAdmissionSubmitButton()
        {
            _page.GetOldAdmissionSubmitButton().Click();
            if (IsShowMinimumCourseFeeAlert())
            {
                _page.GetOldAdmissionSubmitButton().Click();
            }
        }

        private bool IsShowMinimumCourseFeeAlert()
        {
            var errorText = _page.GetShownErrorMessage()?.Text;
            if (string.IsNullOrEmpty(errorText) == false && Regex.IsMatch(errorText, @"\d+\.\d+"))
            {
                Match match = Regex.Match(errorText, @"\d*\.?\d+");
                //new Regex(@"\d*\.?\d+").Matches(mgs.Text);
                _webElement = _page.GetReceivedAmount();
                _webElement.Clear();
                _paidAmount = double.Parse(match.Value);
                _webElement.SendKeys(_paidAmount.ToString());
                _dueAmount = GetCurrentAvailableDueAmount();
                Assert.True(_dueAmount == _payableAmount - _paidAmount);
                return true;
            }
            return false;
        }

        [Then(@"Shown Admitted Money Receipt Page")]
        public void ThenShownAdmittedMoneyReceiptPage()
        {
            Assert.True(_page.GetAdmittedMoneyReceiptPage().Displayed);
        }

        //[Then(@"Download Admitted Money Receipt PDF")]
        [Then(@"Evaluate Admission Money Receipt Data")]
        public void ThenEvaluateAdmissionMoneyReceiptData()
        {
            var admissionInfo = _dao.GetAdmissionInfo();
            var pdfPath = AppHelper.DownloadMoneyReceiptPath(_page.GetDriver(), _scenarioInfo);
            var pdfTexts = AppHelper.ConvertPdfToText(pdfPath);

            for (int i = 0; i < pdfTexts.Length; i++)
            {
                if (Regex.IsMatch(pdfTexts[i], @"\b\d{7}\b") &&
                    string.Equals("Registration Number", pdfTexts[i - 1]))
                {
                    _dto.RegisterNo = pdfTexts[i];
                }
                else if (Regex.IsMatch(pdfTexts[i], @"\b\d{11}\b"))
                {
                    _dto.RollNumber = pdfTexts[i];
                }
                else if (string.Equals(pdfTexts[i], "Student Name"))
                {
                    Assert.Equal(_dto.NickName ?? admissionInfo.NickName, pdfTexts[i + 1]);
                }
                else if (string.Equals(pdfTexts[i], "Total Payment"))
                {
                    Assert.Equal(_totalCourseFee, double.Parse(pdfTexts[i + 1]));
                }
                else if (string.Equals(pdfTexts[i], "Offered Discount"))
                {
                    Assert.Equal(_offeredDiscount, double.Parse(pdfTexts[i + 1]));
                }
                else if (string.Equals(pdfTexts[i], "Special Discount"))
                {
                    var discount = _specialDiscount + _prevStdDiscount;
                    Assert.Equal(discount, double.Parse(pdfTexts[i + 1]));
                }
                else if (string.Equals(pdfTexts[i], "Payable Amount"))
                {
                    var amount = _payableAmount + _specialDiscount + _prevStdDiscount;
                    Assert.Equal(amount, double.Parse(pdfTexts[i + 1]));
                }
                else if (string.Equals(pdfTexts[i], "Paid Amount"))
                {
                    Assert.Equal(_paidAmount, double.Parse(pdfTexts[i + 1]));
                }
                else if (string.Equals(pdfTexts[i], "Due Amount"))
                {
                    Assert.Equal(_dueAmount, double.Parse(pdfTexts[i + 1]));
                }
            }

            _dto.NickName ??= admissionInfo.NickName;
            _dto.MobileNo ??= admissionInfo.MobileNo;
            _dto.Program ??= admissionInfo.Program;
            _dto.Session ??= admissionInfo.Session;
            _dto.ClassType ??= admissionInfo.ClassType;
            _dto.Version ??= admissionInfo.Version;
            _dto.Branch ??= admissionInfo.Branch;
            _dto.Campus ??= admissionInfo.Campus;

            _dto.TotalCourseFee ??= _totalCourseFee.ToString();
            _dto.OfferedDiscount ??= _offeredDiscount.ToString();
            _dto.PrevStdDiscount ??= _prevStdDiscount.ToString();
            _dto.SpecialDiscount ??= _specialDiscount.ToString();
            _dto.PayableAmount ??= _payableAmount.ToString();
            _dto.PaidAmount ??= _paidAmount.ToString();
            _dto.DueAmount ??= _dueAmount.ToString();

            _dao.SetAdmissionInfo(_dto, QueryType.Insert);
        }

        [When(@"Bulk Spin New Student Admission ""([^""]*)""")]
        public void WhenBulkSpinNewStudentAdmission(string count)
        {
            var dto = _dao.GetAdmissionInfo();
            for (int i = 0; i < Convert.ToInt32(count); i++)
            {
                _page.GetNewStudentAdmission().Click();
                _page.GetStudentNickname().SendKeys(TestHelper.GetUniqueName());
                _page.GetStudentMobileNumber().SendKeys(dto.MobileNo);
                TestHelper.RandomOptionSelector(_page.GetStudentGender());
                TestHelper.RandomOptionSelector(_page.GetStudentReligion());
                new SelectElement(_page.GetStudentClassType()).SelectByText(dto.ClassType!);
                Thread.Sleep(500);
                WhenSelectStudentProgramName(dto.Program!);
                WhenSelectSessionOfProgram(dto.Session!);
                Thread.Sleep(500);
                WhenSearchEducationalInstituteName();
                TestHelper.RandomOptionSelector(_page.GetStudyVersion());
                WhenSelectBranchNameOfProgram(dto.Branch!);
                WhenSelectCampusNameOfBranch(dto.Campus!);
                WhenClickOnIsStudentSecondTimer(dto.Is2ndTime!);
                _page.GetAcademicGroup("Science").Click();
                WhenSelectCourseName(dto.Course!);
                WhenSelectBatchTypeOfThisCourse();
                WhenSelectBatchTimeOfThisCourse();
                WhenSelectBatchNameOfThisCourse();
                _page.GetAdmissionPaymentNextButton().Click();
                Thread.Sleep(500);
                _page.GetReceivedAmount().SendKeys(GetCurrentAvailableDueAmount().ToString());
                _page.GetNewAdmissionSubmitButton().Click();
            }
        }

    }
}
