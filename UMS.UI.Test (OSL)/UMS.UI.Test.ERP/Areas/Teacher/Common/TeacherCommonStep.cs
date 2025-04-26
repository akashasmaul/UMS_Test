namespace UMS.UI.Test.ERP.Areas.Teacher.Common
{
    [Binding]
    public class TeacherCommonStep
    {
        //private IWebElement? _webElement;
        private readonly TeacherCommonPage _page;
        public TeacherCommonStep(TeacherCommonPage page)
        {
            _page = page;
        }

        [When(@"Select Teachers Area Common Organization ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonOrganization(string organization)
        {
            _page.GetTeacherCommonOrganization().Click();
            _page.MultiSelectDropdown(organization);
        }

        [When(@"Select Teachers Area Common Program ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonProgram(string program)
        {
            _page.GetTeacherCommonProgram().Click();
            _page.MultiSelectDropdown(program);
        }

        [When(@"Select Teachers Area Common Session ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonSession(string session)
        {
            _page.GetTeacherCommonSession().Click();
            _page.MultiSelectDropdown(session);
        }

        [When(@"Select Teachers Area Common Course ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonCourse(string course)
        {
            _page.GetTeacherCommonCourse().Click();
            _page.MultiSelectDropdown(course);
        }

        [When(@"Select Teachers Area Common Branch ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonBranch(string branch)
        {
            _page.GetTeacherCommonBranch().Click();
            _page.MultiSelectDropdown(branch);
        }

        [When(@"Select Teachers Area Common Campus ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonCampus(string campus)
        {
            _page.GetTeacherCommonCampus().Click();
            _page.MultiSelectDropdown(campus);
        }

        [When(@"Select Teachers Area Common ClassType ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonClassType(string classType)
        {
            _page.GetTeacherCommonClassType().Click();
            _page.MultiSelectDropdown(classType);
        }


        [When(@"Select Teachers Area Common Teacher PIN ""([^""]*)""")]
        public void WhenSelectTeachersAreaCommonTeacherPIN(string tPIN)
        {
            _page.SelectMultiTeachers(tPIN);
        }


    }
}
