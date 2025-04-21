using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Common
{
    public static class AreaCommonElement
    {
        private static readonly int Day = DateTime.Today.AddDays(2).Day;

        // UMS Area
        public static By AdministrationArea => By.XPath("//*[@href='/Administration']");
        public static By StudentArea => By.XPath("//*[@href='/Student']");
        public static By ExamArea => By.XPath("//*[@href='/Exam']");    //a[normalize-space()='Exam']
        public static By TeacherArea => By.XPath("//*[@href='/Teachers']");


        //[@name='MaterialTypeId'or@id='MaterialsType']
        public static By Organization => By.XPath("//select[@id='OrganizationId' or @id='organizationId']");
        public static By Program => By.XPath("//select[@id='ProgramId' or @id='programId']");
        public static By Session => By.XPath("//select[@id='SessionId' or @id='sessionId']");
        public static By Course => By.XPath("//select[@id='CourseId' or @id='courseId']");
        public static By Branch => By.XPath("//select[@id='BranchId' or @id='branchId']");
        public static By Campus => By.XPath("//select[@id='CampusId' or @id='campusId']");

        public static By MultiSelectDropdown(string id) => By.XPath($"//select[@id='{id}']/parent::*//button[@type='button']");
        public static By MultiSelectSearchbox(string id) => By.XPath($"//select[@id='{id}']/parent::*//input[@placeholder='Search']");
        public static By MultiCheckboxByText(string id) => By.XPath($"//select[@id='{id}']/parent::*//label[@class='checkbox']");
        public static By MultiCheckboxByValue(string id) => By.XPath($"//select[@id='{id}']/parent::*//input[@type='checkbox']");

        public static By StartDate => By.XPath("//input[@id='StartDate']");
        public static By EndDate => By.XPath("//input[@id='EndDate']");
        public static By DateFrom(string attributeId) => By.XPath($"//input[@id='{attributeId}']");
        public static By DateTo(string attributeId) => By.XPath($"//input[@id='{attributeId}']");

        public static By SelectInfoToViewAll => By.XPath("//button[@title='Move all']");
        public static By IncreaseRow => By.XPath("//*[contains(@class,'dynamicRowGenerate')]");
        public static By DesiredTestPage => By.XPath("//div[@id='main-body-content']");

        public static By NextReceivedDate => By.XPath("//*[@id='nextRecDate']");
        public static By NextReceiveDate => By.XPath($"//td[normalize-space()='{Day}']");
        public static By EnableReceiveDay => By.XPath("//td[@class='day']");
        public static By ActiveReceiveDay => By.XPath("//*[@class='day active']");
        public static By DatePickerArrow => By.XPath("//*[@class='datetimepicker-days']//*[@class='next']");
        public static By PaymentMoneyReceipt => By.XPath("//*[@id='viewport']");

        public static By UpdateGlyphIcon => By.XPath("//a[contains(@class,'glyphicon-pencil')]");
        public static By DeleteGlyphIcon => By.XPath("//a[contains(@class,'glyphicon-trash')]");

        public static By ModalSuccessButton => By.XPath("//*[@type='button'][contains(@class,'btn-success')]");
        public static By ModalDangerButton => By.XPath("//button[@type='button'][contains(@class,'btn-danger')]");

        public static By SuccessAlertMessage => By.XPath("//*[@class='alert alert-success']");
        public static By FailureAlertMessage => By.XPath("//*[@class='alert alert-danger']");
        //h1[contains(text(), 'Processing...')]
        public static By ShowProcessing => By.XPath("//*[normalize-space()='Processing...']");

    }
}
