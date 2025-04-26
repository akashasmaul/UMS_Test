using Xunit.Abstractions;

namespace UMS.UI.Test.ERP.Areas.Student.Image.Copy_Image
{
    public class CopyImagePage
    {
        private readonly IWebDriver _driver;
        private readonly CopyImageElements _elements;
        private readonly ITestOutputHelper _output;

        public CopyImagePage(IWebDriver driver, ITestOutputHelper output)
        {
            _driver = driver;
            _elements = new CopyImageElements();
            _output = output;
        }

        public IWebDriver GetDriver() => _driver;

        public ITestOutputHelper Output() => _output;

        public IWebElement StudentMenu() => _driver.FindElement(_elements.StudentMenu);

        public IWebElement ImageNav() => _driver.FindElement(_elements.ImageNav);

        public IWebElement ImageCopyNav() => _driver.FindElement(_elements.ImageCopyNav);

        public IWebElement ImageCopyPanel() => _driver.FindElement(_elements.ImageCopyPanel);

        public IWebElement increaseRowBtn() => _driver.FindElement(_elements.increaseRowBtn);

        public IWebElement OrganizationDropdown(int rowIndex) => _driver.FindElement(_elements.GetOrganizationDropdown(rowIndex));

        public IWebElement ProgramDropdown(int rowIndex) => _driver.FindElement(_elements.GetProgramDropdown(rowIndex));

        public IWebElement SessionDropdown(int rowIndex) => _driver.FindElement(_elements.GetSessionDropdown(rowIndex));

        public IReadOnlyCollection<IWebElement> GetDropdowns() => _driver.FindElements(_elements.getDropdowns);

        public IWebElement GetDeleteButtonByRowIndex(int index) => _driver.FindElement(_elements.GetDeleteButtonByRowIndex(index));

        public IWebElement HasImageInput(int rowIndex) => _driver.FindElement(_elements.GetHasImageInput(rowIndex));

        public IWebElement MissingImageInput(int rowIndex) => _driver.FindElement(_elements.GetMissingImageInput(rowIndex));

        public IWebElement TotalStudentInput(int rowIndex) => _driver.FindElement(_elements.GetTotalStudentInput(rowIndex));

        public IWebElement copyMissingImageBtn() => _driver.FindElement(_elements.copyMissingImageBtn);

        public IWebElement GetSuccessAlertMessage() => _driver.FindElement(_elements.SuccessAlertMessage);

        public IWebElement DangerAlertMessage() => _driver.FindElement(_elements.DangerAlertMessage);
    }
}