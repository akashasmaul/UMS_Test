namespace UMS.UI.Test.ERP.Areas.Teacher.TeacherActivity.OpeningBalance
{
    public class OpeningBalanceElements
    {
        public By TeacherMenu => By.XPath("//*[@href='/Teachers']");
        public By TeacherActivityGroup => By.XPath("//*[@href='#collapse_154']");
        public By OpeningBalanceMenu => By.XPath("//*[@href='/Teachers/TeacherClassOpeningBalance/OpeningBalance']");
        public By PanelTitle => By.XPath("//h3[@class='panel-title' and contains(text(),'Opening Balance')]");
        public By SelectOrganization => By.Id("OrganizationId");
        public By TPinList => By.Id("TpinList");
        public By ViewBtn => By.Id("ViewTeacher");
        public By OpeningDate => By.XPath("//input[@id='OpeningDate']");
        public By TotalTeacherCountNumber => By.XPath("//div[contains(text(), 'Total')]/strong");
        public By TeacherTableRows => By.XPath("//table[@id='openingBalanceTable']/tbody/tr");
        public By TotalClassInputByTeacherId(string teacherId) => By.XPath($"//tr[@id='teacher_{teacherId}']//input[@id='TotalClass']");
        public By SaveBtn => By.XPath("//input[@value='Save Opening Balance']");
        public By GetOpeningBalanceSuccessMessage => By.XPath("//div[@class='alert alert-success']");



    }
}