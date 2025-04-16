using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageDownload
{
    public class ImageDownloadPage
    {
        private readonly IWebDriver _driver;
        private readonly ImageDownloadElements _elements;

        public ImageDownloadPage(IWebDriver driver)
        {
            _driver = driver;
            _elements = new ImageDownloadElements();
        }

        public IWebDriver GetDriver() => _driver;
        public IWebElement StudentMenu() => _driver.FindElement(_elements.StudentMenu);
        public IWebElement ImageNav() => _driver.FindElement(_elements.ImageNav);
        public IWebElement ImageDownloadNav() => _driver.FindElement(_elements.ImageDownloadNav);
        public IWebElement ImageDownloadPanel() => _driver.FindElement(_elements.ImageDownloadPanel);
        public IWebElement Organization() => _driver.FindElement(_elements.Organization);
        public IWebElement Program() => _driver.FindElement(_elements.Program);
        public IWebElement Session() => _driver.FindElement(_elements.Session);

        public string CourseId() => _elements.CourseId;
        public string GenderId() => _elements.GenderId;
        public string VersionofStudy() => _elements.VersionofStudy;
        public string BranchId() => _elements.BranchId;
        public string CampusId() => _elements.CampusId;
        public string batchDays() => _elements.batchDays;
        public string batchTime() => _elements.batchTime;
        public string batchName() => _elements.batchName;

        public IWebElement GetDropdownToggle(string dropdownId) => _driver.FindElement(_elements.DropdownToggle(dropdownId));
        public IWebElement GetOption(string dropdownId, string label) => _driver.FindElement(_elements.GetOption(dropdownId, label));
        public IWebElement ClickCountButton() => _driver.FindElement(_elements.CountButton);

        public IWebElement GetCountResult() => _driver.FindElement(_elements.CountViewField);
        public IWebElement DownlaodImageBtn() => _driver.FindElement(_elements.imageDownloadBtn);

    }
}
