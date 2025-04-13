using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.BoDi;
using System.Drawing;
using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.ERP.Login;
using Xunit.Abstractions;

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

    [BeforeScenario(Order = 0)]
    public void CreateWebDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--incognito");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("safebrowsing.enabled", false);

        Console.WriteLine("Initializing WebDriver...");
        var driver = new ChromeDriver(options);
        driver.Manage().Window.Position = new Point(2000, 0);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _container.RegisterInstanceAs<IWebDriver>(driver);
    }

    [BeforeScenario("@NeedsLogin", Order = 1)]
    public void LoginBeforeScenario()
    {
        _output.WriteLine("Executing login steps...");

        var driver = _container.Resolve<IWebDriver>();
        var jsonHelper = new JsonHelper();
        var loginPage = new LoginPage(driver, jsonHelper);

        // Navigate and login
        loginPage.GoToBaseUrl();
        loginPage.PerformLogin();
    }

    [AfterScenario]
    public void DestroyWebDriver()
    {
        Console.WriteLine("Closing WebDriver...");
        Thread.Sleep(5000);
        var driver = _container.Resolve<IWebDriver>();
        driver.Quit();
        driver.Dispose();
    }
}