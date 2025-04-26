namespace UMS.UI.Test.ERP.Areas.Administration.Bank
{
    [Binding]
    public class ManageBankStep
    {
        private IWebElement? _webElement;
        private readonly ManageBankPage _page;
        public ManageBankStep(ManageBankPage page)
        {
            _page = page;
        }


        [Given(@"Goto Manage Bank Page")]
        public void GivenGotoManageBankPage()
        {
            _page.GetManageBankPage().Click();
        }

        [When(@"Click On Bank Search Button")]
        public void WhenClickOnBankSearchButton()
        {
            _page.GetBankSearchButton().Click();
        }

        [When(@"Click On Add Bank Button")]
        public void WhenClickOnAddBankButton()
        {
            _page.GetAddBankButton().Click();
        }

        [When(@"Enter Bank Full Name ""([^""]*)""")]
        public void WhenEnterBankFullName(string fullName)
        {
            _webElement = _page.GetBankFullName();
            _webElement.Clear();
            _webElement.SendKeys(fullName);
        }

        [When(@"Enter Bank Short Name ""([^""]*)""")]
        public void WhenEnterBankShortName(string shortName)
        {
            _webElement = _page.GetBankShortName();
            _webElement.Clear();
            _webElement.SendKeys(shortName);
        }

        [When(@"Enter Bank Address ""([^""]*)""")]
        public void WhenEnterBankAddress(string address)
        {
            _webElement = _page.GetBankAddress();
            _webElement.Clear();
            _webElement.SendKeys(address);
        }

        [When(@"Click On Bank Create Button")]
        public void WhenClickOnBankCreateButton()
        {
            _page.GetBankCreateButton().Click();
        }

        [When(@"Click On Bank Update Button")]
        public void WhenClickOnBankUpdateButton()
        {
            _page.GetBankUpdateButton().Click();
        }

    }
}
