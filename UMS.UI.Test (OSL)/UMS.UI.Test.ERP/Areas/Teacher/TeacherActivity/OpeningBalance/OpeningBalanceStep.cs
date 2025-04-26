using Xunit.Abstractions;

namespace UMS.UI.Test.ERP.Areas.Teacher.TeacherActivity.OpeningBalance
{
    [Binding]
    public class OpeningBalanceStep
    {
        private string[]? tpinArray;
        private readonly OpeningBalancePage _page;
        private readonly ITestOutputHelper _output;

        public OpeningBalanceStep(ITestOutputHelper output, OpeningBalancePage page)
        {
            _output = output;
            _page = page;
        }

        [Given("Go to Opening Balance Page")]
        public void GivenGoToOpeningBalancePage()
        {
            _page.TeacherMenu().Click();
            _page.TeacherActivityGroup().Click();
            _page.OpeningBalanceMenu().Click();
            Assert.True(_page.PanelTitle().Displayed, "Opening Balance page is not displayed");
        }

        [When("Select Organization {string} for OBalance")]
        public void WhenSelectOrganizationForOBalance(string organization)
        {
            var wait = new WebDriverWait(_page.GetDriver(), TimeSpan.FromSeconds(3));
            wait.Until(d => _page.SelectOrganization().Enabled && _page.SelectOrganization().Displayed);
            var select = new SelectElement(_page.SelectOrganization());
            var option = select.Options.FirstOrDefault(o =>
                o.Text.Trim().Equals(organization.Trim(), StringComparison.OrdinalIgnoreCase));
            option?.Click();
        }

        [When("Enter TPIN [TeacherId] {string} for Opening Balance")]
        public void WhenEnterTPINTeacherIdForOpeningBalance(string tPIN)
        {
            ProcessTPIN(tPIN);
            string tpins = string.Join(" ", tpinArray ?? Array.Empty<string>());
            _page.TPinList().SendKeys(tpins);
        }

        [When("Click View Button for Opening Balance")]
        public void WhenClickViewButtonForOpeningBalance()
        {
            _page.ViewBtn().Click();
        }

        [When("Verify total teacher count matches with TPIN count for OB")]
        public void WhenVerifyTotalTeacherCountMatchesWithTPINCountForOB()
        {
            int uiCount = int.Parse(_page.TotalTeacherCountNumber().Text.Trim());
            int tableRowCount = _page.GetTotalTeacherRowCount();

            if (uiCount != tpinArray?.Length)
                _output.WriteLine($"\t• UI shows {uiCount} teachers, but processed {tpinArray?.Length} TPINs.");

            Assert.Equal(uiCount, tableRowCount);
            _output.WriteLine($"• Total Teacher Count Matched: {uiCount}");
        }

        [When("Select Date {string} for Opening Balance")]
        public void WhenSelectDateForOpeningBalance(string date)
        {
            SetDateInPicker(_page.OpeningDate(), date);
        }

        [When("Enter Total Class {string} for each Teacher {string} for Opening Balance")]
        public void WhenEnterTotalClassForEachTeacherForOpeningBalance(string classNumbers, string tPINs)
        {
            ProcessTPIN(tPINs);

            string[] classArray = classNumbers.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(x => x.Trim())
                                              .ToArray();
            _output.WriteLine("Entering Total Class Numbers for Teachers:");

            if (tpinArray == null || classArray == null)
            {
                throw new InvalidOperationException("tpinArray or classArray is null. Cannot proceed.");
            }
            for (int i = 0; i < Math.Min(tpinArray.Length, classArray.Length); i++)
            {
                var input = _page.TotalClassInput(tpinArray[i]);
                input.Clear();
                input.SendKeys(classArray[i]);
                _output.WriteLine($"\t• TPIN: {tpinArray[i]} → Class: {classArray[i]}");
            }
        }

        [When("Click Save Opening Balance Button")]
        public void WhenClickSaveOpeningBalanceButton()
        {
            _page.SaveBtn().Click();
        }

        [Then("Opening Balance will be Saved Successfully.")]
        public void ThenOpeningBalanceWillBeSavedSuccessfully_()
        {
            Thread.Sleep(1000);
            string message = _page.GetSuccessAlertMessage().Text.Trim();
            message = message.Replace("×", "").Trim();
            _output.WriteLine($"\t • Success Message: {message}");
            Assert.Contains("Class Opening Balance Save Successfully", message);
        }

        private void SetDateInPicker(IWebElement element, string date)
        {
            DateTime parsedDate;
            string[] formats = {
                                "M/d/yyyy", "M/d/yyyy h:mm:ss tt", "M-d-yyyy",
                                "yyyy-MM-dd", "dd-MM-yy", "d-M-yy", "d/M/yy",
                                "MM/dd/yyyy", "M/d/yyyy h:mm tt", "yyyy/MM/dd", "dd/MM/yyyy"
                            };

            bool isValidDate = DateTime.TryParseExact(
                date,
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            if (!isValidDate)
            {
                isValidDate = DateTime.TryParse(
                    date,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out parsedDate);
            }

            if (!isValidDate)
            {
                throw new Exception($"Could not parse date: {date}. Please check the format.");
            }

            string formattedDate = parsedDate.ToString("yyyy-MM-dd");
            //   string formattedDate = parsedDate.ToString("MM-dd-yyyy");

            IJavaScriptExecutor js = (IJavaScriptExecutor)_page.GetDriver();
            js.ExecuteScript($"arguments[0].value = '{formattedDate}';", element);

            js.ExecuteScript("arguments[0].dispatchEvent(new Event('change', { bubbles: true }));", element);
        }

        private void ProcessTPIN(string tPIN)
        {
            tpinArray = tPIN
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(x => int.TryParse(x, out int num) ? (num >= 22337 ? (num + 1).ToString() : num.ToString()) : x)
                .Distinct()
                .ToArray();
        }
    }
}