using UMS.UI.Test.ERP.Areas.Common;

namespace UMS.UI.Test.ERP.Areas.Administration.Bank
{
    public class ManageBankPage
    {
        private readonly IWebDriver _driver;
        public ManageBankPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public IWebDriver GetDriver() => _driver;

        public IWebElement GetManageBankPage()
        {
            _driver.FindElement(AreaCommonElement.AdministrationArea).Click();
            Thread.Sleep(500);
            _driver.FindElement(ManageBankElement.BankGroupMenu).Click();
            Thread.Sleep(500);
            return _driver.FindElement(ManageBankElement.ManageBankMenu);
        }

        public IWebElement GetBankSearchButton() => _driver.FindElement(ManageBankElement.ManageSearchButton);

        public IWebElement GetAddBankButton() => _driver.FindElement(ManageBankElement.AddBankButton);

        public IWebElement GetBankFullName() => _driver.FindElement(ManageBankElement.BankFullName);

        public IWebElement GetBankShortName() => _driver.FindElement(ManageBankElement.BankShortName);

        public IWebElement GetBankAddress() => _driver.FindElement(ManageBankElement.BankAddress);

        public IWebElement GetBankStatus() => _driver.FindElement(ManageBankElement.BankStatus);

        public IWebElement GetBankCreateButton() => _driver.FindElement(ManageBankElement.BankCreateButton);
        public IWebElement GetBankUpdateButton() => _driver.FindElement(ManageBankElement.BankUpdateButton);

    }
}
