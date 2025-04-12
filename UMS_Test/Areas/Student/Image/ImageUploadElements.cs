using OpenQA.Selenium;

namespace UMS.UI.Test.ERP.Areas.Student.Image
{
    public class ImageUploadElements
    {
        public static By xStudentMenu = By.LinkText("Student");
        public static By xImageNav = By.XPath("//a[normalize-space()='Image']");
        public static By xUploadImageNav = By.XPath("//a[contains(text(),'Upload Image')]");
        public static By xbrowsenSelect = By.Name("upl");
        public static By xOverWrite = By.XPath("//input[@id='overwrite']");
        public static By xUploadBtn = By.XPath("//*[@id=\"upload\"]/div[4]/input[2]");
        public static By xUploadMessages = By.CssSelector("li[id^='file_'] .message");
        public static By xUploadListItems = By.CssSelector("li[id^='file_']");
        public static By xMessageElement = By.CssSelector(".message");
        public static By xSucceedCount = By.Id("SuccessCounter");
        public static By xDuplicateCount = By.Id("DuplicateCounter");
        public static By xFailedCount = By.Id("FailedCounter");
        public static By xTotalCount = By.Id("TotalCounter");



    }
}
