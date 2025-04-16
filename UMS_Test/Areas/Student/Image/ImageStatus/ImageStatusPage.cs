using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageStatus
{
    public class ImageStatusPage
    {
        private readonly IWebDriver _driver;
        private readonly ImageStatusElements _elements;

        public ImageStatusPage(IWebDriver driver)
        {
            _driver = driver;
            _elements = new ImageStatusElements();
        }

        public IWebDriver GetDriver() => _driver;
        public IWebElement StudentMenu() => _driver.FindElement(_elements.StudentMenu);
        public IWebElement ImageNav() => _driver.FindElement(_elements.ImageNav);
        public IWebElement ImageStatusNav() => _driver.FindElement(_elements.ImageStatusNav);
        public IWebElement missingImagePanel() => _driver.FindElement(_elements.missingImagePanel);

        public IWebElement Organization() => _driver.FindElement(_elements.Organization);
        public IWebElement Program() => _driver.FindElement(_elements.Program);
        public IWebElement Session() => _driver.FindElement(_elements.Session);
        public IWebElement ImgStatus() => _driver.FindElement(_elements.ImgStatus);
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

        public IWebElement NonSelectedList() => _driver.FindElement(_elements.NonSelectedList);
        public IWebElement MoveAllButton() => _driver.FindElement(_elements.MoveAllButton);
        public IWebElement MoveSelectedButton() => _driver.FindElement(_elements.MoveSelectedButton);
        public IWebElement SelectedList() => _driver.FindElement(_elements.SelectedList);

        public IWebElement ViewBtn() => _driver.FindElement(_elements.ViewBtn);
        public IWebElement RemoveAllButton() => _driver.FindElement(_elements.RemoveAllButton);
        public IWebElement RemoveSelectedButton() => _driver.FindElement(_elements.RemoveSelectedButton);
        public IWebElement dataTable() => _driver.FindElement(_elements.dataTable);

        public IWebElement RegOrRollInput() => _driver.FindElement(_elements.RegOrRollInput);
        public IWebElement NickNameInput() => _driver.FindElement(_elements.NickNameInput);
        public IWebElement MobileNumberInput() => _driver.FindElement(_elements.MobileNumberInput);
        public IWebElement PageSizeInput() => _driver.FindElement(_elements.PageSizeInput);
        public IWebElement ExpandIcon() => _driver.FindElement(_elements.ExpandIcon);
        public IWebElement ExportButton() => _driver.FindElement(_elements.ExportButton);

    }





}


// 9456 3336 2192 13580 