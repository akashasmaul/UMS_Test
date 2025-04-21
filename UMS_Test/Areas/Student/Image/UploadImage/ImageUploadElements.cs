using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image.UploadImage
{
    public class ImageUploadElements
    {
        public By StudentMenu = By.LinkText("Student");
        public By ImageNav = By.XPath("//a[normalize-space()='Image']");
        public By UploadImageNav = By.XPath("//a[contains(text(),'Upload Image')]");
        public By browsenSelect = By.Name("upl");
        public By OverWrite = By.XPath("//input[@id='overwrite']");
        public By UploadBtn = By.XPath("//*[@id=\"upload\"]/div[4]/input[2]");
        public By UploadMessages = By.CssSelector("li[id^='file_'] .message");
        public By UploadListItems = By.CssSelector("li[id^='file_']");
        public By MessageElement = By.CssSelector(".message");
        public By SucceedCount = By.Id("SuccessCounter");
        public By DuplicateCount = By.Id("DuplicateCounter");
        public By FailedCount = By.Id("FailedCounter");
        public By TotalCount = By.Id("TotalCounter");
        public By clearBtn = By.Id("clearDiv");




    }
}
