using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace UMS.UI.Test.ERP.Areas.Student.Image.ImageDownload
{
    public class ImageDownloadElements
    {
        public By StudentMenu = By.LinkText("Student");
        public By ImageNav = By.XPath("//a[normalize-space()='Image']");
        public By ImageDownloadNav = By.XPath("//a[contains(text(),'Image Download')]");
        public By ImageDownloadPanel = By.XPath("//div[@class='panel-heading' and contains(text(),'Image Download')]");

        public By Organization = By.XPath("//select[@id='OrganizationId']");
        public By Program = By.XPath("//select[@id='ProgramId']");
        public By Session = By.XPath("//select[@id='SessionId']");

        public string CourseId = "CourseId";
        public string GenderId = "GenderId";
        public string VersionofStudy = "VersionofStudy";
        public string BranchId = "BranchId";
        public string CampusId = "CampusId";
        public string batchDays = "batchDays";
        public string batchTime = "batchTime";
        public string batchName = "batchName";
        public By DropdownToggle(string dropdownId) =>
             By.XPath($"//select[@id='{dropdownId}']/following-sibling::div//button[contains(@class,'multiselect dropdown-toggle')]");

        public By GetOption(string dropdownId, string labelText) =>
            By.XPath($"//select[@id='{dropdownId}']/following-sibling::div//ul[contains(@class,'multiselect-container')]//label[contains(translate(normalize-space(.), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), \"{Regex.Replace(labelText.ToLowerInvariant(), @"\s+", " ").Trim()}\")]/input");
        public By CountButton => By.Id("countBtn");
        public By CountViewField => By.Id("countView");
        public By imageDownloadBtn => By.XPath("//input[@id='imageDownloadBtn']");


    }
}
