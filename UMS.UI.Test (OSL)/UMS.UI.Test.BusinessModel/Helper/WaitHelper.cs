namespace UMS.UI.Test.BusinessModel.Helper
{
    public static class WaitHelper
    {
        private static WebDriverWait? _wait;

        private static WebDriverWait WebDriverWaitInit(IWebDriver driver, int timeoutInSeconds = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public static void WebElementToBeClickable(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new TimeoutException("Element not clickable within the timeout period.");
            }
        }

        public static void WebElementIsVisible(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new TimeoutException("Element not visible within the timeout period.");
            }
        }

        public static bool IsVisibleWebElement(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool IsExistsWebElement(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.ElementExists(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static void WebElementIsInvisible(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new TimeoutException($"Element not invisible within the {timeoutInSeconds} timeout period.");
            }
        }

        public static bool IsInvisibleWebElement(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static void WebElementWithSpinWait(IWebDriver driver, By locator, int maxRetries = 5)
        {
            int retries = 0;
            while (retries < maxRetries)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    if (element.Displayed && element.Enabled)
                    {
                        return;
                    }
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(500);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(500);
                }
                retries++;
            }
            throw new TimeoutException("Element not ready after spin wait.");
        }

        public static void WebElementToBeSelected(IWebDriver driver, int timeoutInSeconds, By locator)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                _wait.Until(ExpectedConditions.ElementToBeSelected(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new TimeoutException("Element not selected within the timeout period.");
            }
        }

        public static void WebElementToSendKeys(IWebDriver driver, int timeoutInSeconds, By locator, string text)
        {
            try
            {
                _wait = WebDriverWaitInit(driver, timeoutInSeconds);
                var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
                _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                element.SendKeys(text);
            }
            catch (WebDriverTimeoutException)
            {
                throw new TimeoutException("Element not ready for input within the timeout period.");
            }
        }
    }
}
