using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.ERP.Areas.Common;

namespace UMS.UI.Test.ERP.Areas.Student.Admission
{
    public sealed class NewAdmissionPage //: LoginHooks
    {
        private readonly IWebDriver _driver;
        public NewAdmissionPage(IWebDriver driver) //: base(driver)
        {
            _driver = driver;
        }


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetNewOrOldStudentAdmissionMenu()
        {
            Thread.Sleep(200);
            _driver.FindElement(AreaCommonElement.StudentArea).Click();
            Thread.Sleep(200);
            _driver.FindElement(NewAdmissionElement.AdmissionMenuGroup).Click();
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.NewAdmissionMenu);
        }

        public IWebElement GetNewStudentAdmission()
        {
            GetNewOrOldStudentAdmissionMenu().Click();
            Thread.Sleep(200);
            _driver.FindElement(NewAdmissionElement.OldAdmissionButton).Click();
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.NewAdmissionButton);
        }

        public IWebElement GetStudentRegOrRollNumber() => _driver.FindElement(NewAdmissionElement.RegOrRollField);

        public IWebElement GetOldStudentAdmissionButton() => _driver.FindElement(NewAdmissionElement.OldAdmissionButton);

        public IWebElement GetNewStudentAdmissionPage() => _driver.FindElement(NewAdmissionElement.NewAdmissionPage);

        public IWebElement GetOldStudentAdmissionPage() => _driver.FindElement(NewAdmissionElement.OldAdmissionPage);

        public IWebElement? GetVisitedAdmissionStatus()
        {
            try
            {
                return _driver.FindElement(NewAdmissionElement.AdmissionStatus);
            }
            catch { return null; }
        }

        public IWebElement GetStudentNickname() => _driver.FindElement(NewAdmissionElement.StudentNickname);

        public IWebElement GetStudentMobileNumber() => _driver.FindElement(NewAdmissionElement.StudentMobileNo);

        public IWebElement GetStudentGender() => _driver.FindElement(NewAdmissionElement.StudentGender);

        public IWebElement GetStudentReligion() => _driver.FindElement(NewAdmissionElement.StudentReligion);

        public IWebElement GetStudentClassType() => _driver.FindElement(NewAdmissionElement.StudentClassType);

        public IWebElement GetStudentProgram() => _driver.FindElement(NewAdmissionElement.StudentProgram);

        public IWebElement GetStudentSession() => _driver.FindElement(NewAdmissionElement.StudentSession);


        public IWebElement GetEducationalInstitute() => _driver.FindElement(NewAdmissionElement.SearchInstitute);

        public IWebElement GetSelectInstituteName()
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.SelectInstitute);
        }

        public IWebElement GetStudyVersion() => _driver.FindElement(NewAdmissionElement.StudyVersion);

        public IWebElement GetBranchName() => _driver.FindElement(NewAdmissionElement.BranchName);

        public IWebElement GetAttachedPhysicalBranch() => _driver.FindElement(NewAdmissionElement.AttachedPhysicalBranch);

        public IWebElement GetCampusName() => _driver.FindElement(NewAdmissionElement.CampusName);

        public IWebElement GetSecondTimer(string timer) => _driver.FindElement(NewAdmissionElement.SecondTimer(timer));

        public IWebElement GetAcademicGroup(string group) => _driver.FindElement(NewAdmissionElement.AcademicGroup(group));

        //public IWebElement GetCourseDetails() => _driver.FindElement(NewAdmissionElement.CourseDetails);
        public IList<IWebElement> GetCourseList() => _driver.FindElements(NewAdmissionElement.CourseList);

        public IWebElement GetComplementaryCourseName(string course)
        {
            return _driver.FindElement(NewAdmissionElement.ComplementaryCourse(course));
        }

        public IWebElement GetComplementaryPopupModal() => _driver.FindElement(NewAdmissionElement.ComplementaryCourseModal);

        public IWebElement GetConfirmButtonInModal()
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.ConfirmComplementaryBtn);
        }

        public IWebElement GetAllCourse()
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.ShowProcessing);
            return _driver.FindElement(NewAdmissionElement.CouseCheckList);
        }

        public IWebElement GetComplementaryCourse() => _driver.FindElement(NewAdmissionElement.SelectComplementaryCourse);

        public IList<IWebElement> GetSubjectCheckboxes(string courseId)
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.FailureAlertMessage);
            return _driver.FindElements(NewAdmissionElement.CourseSubjects(courseId));
        }

        public IWebElement GetBatchType(string courseId)
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.CourseBatchType(courseId));
        }

        public IWebElement GetBatchTime(string courseId)
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.CourseBatchTime(courseId));
        }

        public IWebElement GetBatchName(string courseId)
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.CourseBatchName(courseId));
        }

        public IWebElement? GetShownErrorMessage()
        {
            try
            {
                return _driver.FindElement(AreaCommonElement.FailureAlertMessage);
            }
            catch { return null; }
        }

        public IList<IWebElement> GetCompulsoryCourses() => _driver.FindElements(NewAdmissionElement.CompulsoryCourses);

        public IWebElement GetAdmissionPaymentNextButton()
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.FailureAlertMessage);
            return _driver.FindElement(NewAdmissionElement.NewAdmissionNextBtn);
        }

        public IWebElement GetPaymentDetails()
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.ShowProcessing);
            return _driver.FindElement(NewAdmissionElement.PaymentDetails);
        }

        public IWebElement GetTotalCourseFee() => _driver.FindElement(NewAdmissionElement.TotalCourseFee);

        public IWebElement GetOfferedDiscount() => _driver.FindElement(NewAdmissionElement.OfferedDiscount);

        public IWebElement GetPrevStdDiscount() => _driver.FindElement(NewAdmissionElement.PreStdDiscount);

        public IWebElement GetNetReceivableAmount() => _driver.FindElement(NewAdmissionElement.NetReceivableAmount);

        public IWebElement GetSpecialDiscount() => _driver.FindElement(NewAdmissionElement.SpecialDiscount);

        public IWebElement GetSpDiscountApprovedBy() => _driver.FindElement(NewAdmissionElement.SpDiscountApprovedBy);

        public IWebElement GetSpecialDiscountApprover()
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.SpDiscountApprover);
        }

        public IWebElement GetSpecialDiscountType() => _driver.FindElement(NewAdmissionElement.SpecialDiscountType);

        public IWebElement GetSpDiscountReferredBy() => _driver.FindElement(NewAdmissionElement.SpDiscountReferredBy);

        public IWebElement GetSpDiscountReferrer()
        {
            Thread.Sleep(200);
            return _driver.FindElement(NewAdmissionElement.SpDiscountReferrer);
        }

        public IWebElement GetSpecialDiscountNote() => _driver.FindElement(NewAdmissionElement.SpecialDicountNote);

        public IWebElement GetReceivedAmount() => _driver.FindElement(NewAdmissionElement.ReceivedAmount);

        public IWebElement GetAvailableDueAmount() => _driver.FindElement(NewAdmissionElement.AvailableDueAmount);


        //public IWebElement GetNextReceivePaymentDate()
        //{
        //    _driver.FindElement(NewAdmissionElement.NextReceivedDate).Click();
        //    return _driver.FindElement(NewAdmissionElement.SelectReceiveDate);
        //}

        public (IWebElement webElement, IJavaScriptExecutor js) GetNextPaymentReceiveDate()
        {
            var webElement = _driver.FindElement(NewAdmissionElement.NextReceivedDate);
            var jsExecutor = (IJavaScriptExecutor)_driver;

            return (webElement, jsExecutor);
        }

        public IList<IWebElement> GetEnabledReceiveDay() => _driver.FindElements(AreaCommonElement.EnableReceiveDay);

        public IWebElement GetDatePickerRightArrow() => _driver.FindElement(AreaCommonElement.DatePickerArrow);

        public IWebElement GetNewAdmissionSubmitButton()
        {
            //WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.FailureAlertMessage);
            return _driver.FindElement(NewAdmissionElement.NewAdmissionSubmitBtn);
        }

        public IWebElement GetOldAdmissionSubmitButton()
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.FailureAlertMessage);
            return _driver.FindElement(NewAdmissionElement.OldAdmissionSubmitBtn);
        }

        public IWebElement GetAdmittedMoneyReceiptPage()
        {
            WaitHelper.WebElementIsInvisible(_driver, 10, AreaCommonElement.ShowProcessing);
            return _driver.FindElement(NewAdmissionElement.AdmissionMoneyReceiptPage);
        }

        /*
        public dynamic GetMoneyReceiptData()
        {
            var data = TestHelper.GetMoneyReceiptData(_driver);
            return JsonConvert.DeserializeObject(data)!;
        }

        public void TakeAdmissionMoneyReceiptScreenshot()
        {
            TestHelper.TakeScreenshot(_driver);
        }

        public string[] GetReadTextFromImage(string imagePath)
        {
            return TestHelper.ReadTextFromImage(imagePath);
        }

        public IWebElement GetMoneyReceiptElement()
        {
            return _driver.FindElement(AdmissionElement.AdmissionMoneyReceiptPage);
        }

        public string GetMoneyReceiptElementScreenshot()
        {
            //admission Money Receipt
            var element = _driver.FindElement(AdmissionElement.AdmissionMoneyReceiptPage);
            return TestHelper.CaptureElementScreenshot(_driver, element);
        }
        */

    }
}
