using UMS.UI.Test.BusinessModel.Helper;

namespace UMS.UI.Test.ERP.Areas.Teacher.Common
{
    public class TeacherCommonPage
    {
        private readonly IWebDriver _driver;
        public TeacherCommonPage(IWebDriver driver)
        {
            _driver = driver;
        }



        public IWebElement GetTeacherCommonOrganization() => _driver.FindElement(TeacherCommonElement.TeacherCommonOrganization);
        public IWebElement GetTeacherCommonProgram() => _driver.FindElement(TeacherCommonElement.TeacherCommonProgram);
        public IWebElement GetTeacherCommonSession() => _driver.FindElement(TeacherCommonElement.TeacherCommonSession);
        public IWebElement GetTeacherCommonCourse() => _driver.FindElement(TeacherCommonElement.TeacherCommonCourse);
        public IWebElement GetTeacherCommonBranch() => _driver.FindElement(TeacherCommonElement.TeacherCommonBranch);
        public IWebElement GetTeacherCommonCampus() => _driver.FindElement(TeacherCommonElement.TeacherCommonCampus);
        public IWebElement GetTeacherCommonClassType() => _driver.FindElement(TeacherCommonElement.TeacherCommonClassType);

        public IWebElement GetTeacherPIN() => _driver.FindElement(TeacherCommonElement.TeacherPIN);
        public IWebElement GetTPINCheckbox() => _driver.FindElement(TeacherCommonElement.TPINCheckbox);

        public void MultiSelectDropdown(string items)
        {
            TestHelper.SelectMultiItems(_driver, items);
        }

        public void SelectMultiTeachers(string teacherPin)
        {
            TestHelper.SelectMultiTeachers(_driver, teacherPin);
        }


    }
}
