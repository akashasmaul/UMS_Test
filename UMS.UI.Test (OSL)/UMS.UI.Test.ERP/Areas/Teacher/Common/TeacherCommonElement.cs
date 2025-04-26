namespace UMS.UI.Test.ERP.Areas.Teacher.Common
{
    public static class TeacherCommonElement
    {
        // Teachers Group Menu
        public static By TeacherActivityGroup => By.XPath("//*[@href='#collapse_154']");
        public static By MaterialsPaymentGroup => By.XPath("//*[@href='#collapse_903']");


        // Teachers Common
        public static By TeacherPIN => By.XPath("//input[@name='teacherId'or@id='TeacherId']");
        public static By TPINCheckbox => By.XPath("//ul[@id='multiselectOptionList']//input[@type='checkbox']");
        public static By TeacherSelect(string tPin) => By.XPath($"//ul[@id='multiselectOptionList']//input[@type='checkbox' and @value=\"{tPin}\"]");

        public static By TeacherCommonOrganization => By.XPath("//select[@id='OrganizationId' or @id='organizationId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonProgram => By.XPath("//select[@id='ProgramId' or @id='programId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonSession => By.XPath("//select[@id='SessionId' or @id='sessionId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonCourse => By.XPath("//select[@id='CourseId' or @id='courseId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonBranch => By.XPath("//select[@id='BranchId' or @id='branchId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonCampus => By.XPath("//select[@id='CampusId' or @id='campusId']/following-sibling::div//button[@data-toggle='dropdown']");
        public static By TeacherCommonClassType => By.XPath("//select[@id='ClassTypeId' or @id='classTypeId']/following-sibling::div//button[@data-toggle='dropdown']");


        public static By SearchElement => By.XPath("//div[@class='btn-group open']//input[@placeholder='Search']");
        public static By DropdownOption(string item) => By.XPath($"//label[normalize-space()=\"{item}\"]");


    }
}
