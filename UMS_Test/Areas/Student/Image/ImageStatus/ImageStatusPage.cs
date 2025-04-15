using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageStatus
{
    public class ImageStatusPage
    {
        private readonly IWebDriver _driver;
        private readonly ImageStatusElements _imgStatElement;

        public ImageStatusPage(IWebDriver driver)
        {
            _driver = driver;
            _imgStatElement = new ImageStatusElements();
        }

        public IWebDriver GetDriver() => _driver;
        public IWebElement StudentMenu() => _driver.FindElement(_imgStatElement.StudentMenu);
        public IWebElement ImageNav() => _driver.FindElement(_imgStatElement.ImageNav);
        public IWebElement ImageStatusNav() => _driver.FindElement(_imgStatElement.ImageStatusNav);
        public IWebElement missingImagePanel() => _driver.FindElement(_imgStatElement.missingImagePanel);
        
        public IWebElement Organization() => _driver.FindElement(_imgStatElement.Organization);
        public IWebElement Program() => _driver.FindElement(_imgStatElement.Program);
        public IWebElement Session() => _driver.FindElement(_imgStatElement.Session);
        public IWebElement ImgStatus() => _driver.FindElement(_imgStatElement.ImgStatus);
        public IWebElement GetDropdownToggle(string dropdownId) => _driver.FindElement(_imgStatElement.DropdownToggle(dropdownId));
        public IWebElement GetOption(string dropdownId, string label) => _driver.FindElement(_imgStatElement.GetOption(dropdownId, label));

        public IWebElement ClickCountButton() => _driver.FindElement(_imgStatElement.CountButton);

        public IWebElement GetCountResult() => _driver.FindElement(_imgStatElement.CountViewField);


       



    }
}

// 9456 3336 2192 13580 