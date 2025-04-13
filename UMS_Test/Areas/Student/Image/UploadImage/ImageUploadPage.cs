using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace UMS.UI.Test.ERP.Areas.Student.Image.UploadImage
{
    public class ImageUploadPage
    {
        private readonly IWebDriver _driver;
        private readonly ImageUploadElements _ImgUpElement;
        public ImageUploadPage(IWebDriver driver)
        {
            _driver = driver;
            _ImgUpElement = new ImageUploadElements();
        }

        public IWebElement StudentMenu() => _driver.FindElement(_ImgUpElement.xStudentMenu);
        public IWebElement ImageNav() => _driver.FindElement(_ImgUpElement.xImageNav);
        public IWebElement UploadImageNav() => _driver.FindElement(_ImgUpElement.xUploadImageNav);
        public IWebElement browsenSelect() => _driver.FindElement(_ImgUpElement.xbrowsenSelect);
        public IWebElement OverWriteCheckbox => _driver.FindElement(_ImgUpElement.xOverWrite);

        public IWebElement UploadBtn() => _driver.FindElement(_ImgUpElement.xUploadBtn);
        public IReadOnlyCollection<IWebElement> GetUploadMessages() => _driver.FindElements(_ImgUpElement.xUploadMessages);
        public IReadOnlyCollection<IWebElement> GetUploadListItems() => _driver.FindElements(_ImgUpElement.xUploadListItems);
        public IWebElement ClearBtn() => _driver.FindElement(_ImgUpElement.clearBtn);

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
            string succeedCountValue = _driver.FindElement(_ImgUpElement.xSucceedCount).Text;
            int.TryParse(succeedCountValue, out int result);
            return result;

        }
        public int GetFailCount()
        {
            string failCountValue = _driver.FindElement(_ImgUpElement.xFailedCount).Text;
            int.TryParse(failCountValue, out int result);
            return result;
        }
        public int GetDuplicateCount()
        {
            string duplicateCountValue = _driver.FindElement(_ImgUpElement.xDuplicateCount).Text;
            int.TryParse(duplicateCountValue, out int result);
            return result;
        }
        public int GetTotalCount()
        {
            string totalCountValue = _driver.FindElement(_ImgUpElement.xTotalCount).Text;
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
