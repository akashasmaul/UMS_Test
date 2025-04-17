using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image.Copy_Image
{
    public class CopyImageElements
    {
        public By StudentMenu = By.LinkText("Student");
        public By ImageNav = By.XPath("//a[normalize-space()='Image']");
        public By ImageCopyNav = By.XPath("//a[contains(text(),'Copy Image')]");
        public By ImageCopyPanel = By.XPath("//div[@class='panel-heading']/h4[contains(text(),'Copy Image')]");

        public By increaseRowBtn = By.Id("increaseRowBtn");
        public By getDropdowns => By.CssSelector("select[id^='Organization_'], select[id^='Program_'], select[id^='Session_']");

        public By GetOrganizationDropdown(int rowIndex) => By.Id($"Organization_{rowIndex}");

        public By GetProgramDropdown(int rowIndex) => By.Id($"Program_{rowIndex}");

        public By GetSessionDropdown(int rowIndex) => By.Id($"Session_{rowIndex}");
        public By GetDeleteButtonByRowIndex(int index) => By.CssSelector($"tr#tr{index} td:last-child input.btn-danger");

        public By GetHasImageInput(int rowIndex) => By.Id($"HasImage_{rowIndex}");

        public By GetMissingImageInput(int rowIndex) => By.Id($"MissingImage_{rowIndex}");

        public By GetTotalStudentInput(int rowIndex) => By.Id($"TotalStudent_{rowIndex}");

        public By copyMissingImageBtn = By.Id("copyMissingImageBtn");
        public By SuccessAlertMessage => By.CssSelector("div.customMessage div.alert.alert-success");
        public By DangerAlertMessage => By.CssSelector("div.customMessage div.alert.alert-danger");




    }
}