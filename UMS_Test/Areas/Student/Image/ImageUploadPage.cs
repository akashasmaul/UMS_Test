using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace UMS.UI.Test.ERP.Areas.Student.Image
{
    public class ImageUploadPage : ImageUploadElements
    {
        private readonly IWebDriver _driver;
        public ImageUploadPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement StudentMenu() => _driver.FindElement(xStudentMenu);
        public IWebElement ImageNav() => _driver.FindElement(xImageNav);
        public IWebElement UploadImageNav() => _driver.FindElement(xUploadImageNav);
        public IWebElement browsenSelect() => _driver.FindElement(xbrowsenSelect);
        public IWebElement OverWriteCheckbox => _driver.FindElement(xOverWrite);

        public IWebElement UploadBtn() => _driver.FindElement(xUploadBtn);
        public IReadOnlyCollection<IWebElement> GetUploadMessages() => _driver.FindElements(xUploadMessages);
        public IReadOnlyCollection<IWebElement> GetUploadListItems() => _driver.FindElements(xUploadListItems);
        
        public void SetOverwrite(bool shouldCheck)
        {
            var checkbox = OverWriteCheckbox;

            // Scroll into view
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);

            if (shouldCheck)
            {
                if (!checkbox.Selected)
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", checkbox);
                }
            }
        }
        public bool IsOverwriteChecked() => OverWriteCheckbox.Selected;

        public int GetSucceedCount()
        {
            string succeedCountValue = _driver.FindElement(xSucceedCount).Text;
            int.TryParse(succeedCountValue, out int result);
            return result;

        }
        public int GetFailCount()
        {
            string failCountValue = _driver.FindElement(xFailedCount).Text;
            int.TryParse (failCountValue, out int result);
            return result;
        }
        public int GetDuplicateCount()
        {
            string duplicateCountValue = _driver.FindElement(xDuplicateCount).Text;
            int.TryParse(duplicateCountValue, out int result);
            return result;
        }
        public int GetTotalCount()
        {
            string totalCountValue = _driver.FindElement(xTotalCount).Text;
            int.TryParse(totalCountValue, out int result);
            return result;
        }

        public void WaitForMessagesToLoad()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(driver => GetUploadListItems().All(item =>
                {
                    try
                    {
                        return !string.IsNullOrWhiteSpace(
                            item.FindElement(By.CssSelector(".message")).Text);
                    }
                    catch
                    {
                        return false;
                    }
                }));
        }


    }
}
