namespace UMS.UI.Test.ERP.Areas.Administration.Bank
{
    public static class ManageBankElement
    {
        public static By AdministrationArea => By.XPath("//*[@href='/Administration']");
        public static By BankGroupMenu => By.XPath("//*[@href='#collapse_255']");
        public static By ManageBankMenu => By.XPath("//*[@href='/Administration/Bank/ManageBank']");

        public static By ManageSearchButton => By.XPath("//input[@id='search']");

        public static By AddBankButton => By.XPath("//input[@value='Add Bank']");
        public static By BankFullName => By.XPath("//input[@id='Name' or @id='name']");
        public static By BankShortName => By.XPath("//input[@id='ShortName' or @id='shortname']");
        public static By BankAddress => By.XPath("//input[@id='Address']");
        public static By BankStatus => By.XPath("//select[@id='Status']");
        public static By BankCreateButton => By.XPath("//input[@value='Create']");
        public static By BankUpdateButton => By.XPath("//input[@value='Update']");

    }
}
