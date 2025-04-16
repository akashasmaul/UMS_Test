using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image.UploadImage
{
    public class ImageUploadElements
    {
        public By xStudentMenu = By.LinkText("Student");
        public By xImageNav = By.XPath("//a[normalize-space()='Image']");
        public By xUploadImageNav = By.XPath("//a[contains(text(),'Upload Image')]");
        public By xbrowsenSelect = By.Name("upl");
        public By xOverWrite = By.XPath("//input[@id='overwrite']");
        public By xUploadBtn = By.XPath("//*[@id=\"upload\"]/div[4]/input[2]");
        public By xUploadMessages = By.CssSelector("li[id^='file_'] .message");
        public By xUploadListItems = By.CssSelector("li[id^='file_']");
        public By xMessageElement = By.CssSelector(".message");
        public By xSucceedCount = By.Id("SuccessCounter");
        public By xDuplicateCount = By.Id("DuplicateCounter");
        public By xFailedCount = By.Id("FailedCounter");
        public By xTotalCount = By.Id("TotalCounter");
        public By clearBtn = By.Id("clearDiv");




    }
}
