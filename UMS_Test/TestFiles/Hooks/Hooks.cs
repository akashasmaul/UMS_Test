
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System.Drawing;
using UMS.UI.Test.ERP.Login;
using Xunit.Abstractions;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace UMS.UI.Test.ERP.TestFiles.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private readonly ITestOutputHelper _output;
        
        public Hooks(IObjectContainer container, ITestOutputHelper output)
        {
            _container = container;
            _output = output;
        }
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running Before Test Run");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running Before Feature");
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--incognito");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("safebrowsing.enabled", false);
         //   options.AddExcludedArgument("enable-automation");
         //   options.AddAdditionalOption("useAutomationExtension", false);

            Console.WriteLine("Initializing WebDriver...");
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Position = new Point(2000, 0);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Register WebDriver FIRST
            _container.RegisterInstanceAs<IWebDriver>(driver);

            // THEN register pages that depend on it
            _container.RegisterInstanceAs(new LoginPage(_container));
        }



        [BeforeScenario("@NeedLogin")]
        public void BeforeScenarioWithLogin()
        {
            Console.WriteLine("Executing Login Before Scenario...");

            // Resolve dependencies in correct order
            var loginPage = _container.Resolve<LoginPage>();
            var loginSteps = new UMSLoginStep(_container);

            loginSteps.GivenGoToTheURL();
            loginSteps.GivenGiveCredentialsAndHitLoginBtn();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Thread.Sleep(100);  // Avoid excessive waits in production
        }

        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("Running After Step");
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {

            Console.WriteLine("Closing WebDriver...");
            Thread.Sleep(5500);
            var driver = _container.Resolve<IWebDriver>();
            driver.Quit();
            driver.Dispose();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running After Feature");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running After Test Run");
        }
    }
}