using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageStatus
{
    public class ImageStatusElements
    {
        public By StudentMenu = By.LinkText("Student");
        public By ImageNav = By.XPath("//a[normalize-space()='Image']");
        public By ImageStatusNav = By.XPath("//a[contains(text(),'Image Status')]");
        public By missingImagePanel = By.XPath("//div[@class='panel-heading' and .//h4[contains(text(),'Missing Image')]]");

        public By Organization = By.XPath("//select[@id='OrganizationId']");
        public By Program = By.XPath("//select[@id='ProgramId']");
        public By Session = By.XPath("//select[@id='SessionId']");
        public By ImgStatus = By.XPath("//select[@id='statusVal']");

        public By DropdownToggle(string dropdownId) =>
            By.XPath($"//select[@id='{dropdownId}']/following-sibling::div//button[contains(@class,'multiselect dropdown-toggle')]");
        public By GetOption(string dropdownId, string labelText) =>
            By.XPath($"//select[@id='{dropdownId}']/following-sibling::div//ul[contains(@class,'multiselect-container')]//label[contains(translate(normalize-space(.), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), \"{Regex.Replace(labelText.ToLowerInvariant(), @"\s+", " ").Trim()}\")]/input");

        public By CountButton => By.Id("countBtn");
        public By CountViewField => By.Id("countView");


    }
}