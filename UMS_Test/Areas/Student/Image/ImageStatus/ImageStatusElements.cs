using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
        public By NonSelectedList => By.Id("bootstrap-duallistbox-nonselected-list_informationViewList");
        public By SelectedList => By.Id("bootstrap-duallistbox-selected-list_informationViewList");

        public By MoveSelectedButton => By.CssSelector(".btn.move");
        public By RemoveSelectedButton => By.CssSelector(".btn.remove");
        public By MoveAllButton => By.CssSelector(".btn.moveall");
        public By RemoveAllButton => By.CssSelector(".btn.removeall");

        public By ViewBtn => By.XPath("//input[@id='imageStatusBtn']");
        public By dataTable => By.Id("DataGrid");

        public By RegOrRollInput = By.Id("stdRollOrRegistrationNo");
        public By NickNameInput = By.Id("nickName");
        public By MobileNumberInput = By.Id("mobileNumber");
        public By PageSizeInput = By.Id("pageSize");

        public By ExpandIcon = By.CssSelector("span[style='float:right;'] > i.fa.fa-plus");
        public By ExportButton = By.Id("export");

    }
}