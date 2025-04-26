using UMS.UI.Test.BusinessModel.Helper;
using UMS.UI.Test.OnlinePortal.TestFiles.Support;
using UMS.UI.Test.Repository.Service;

namespace UMS.UI.Test.OnlinePortal.TestFiles.Hooks
{
    [Binding]
    public sealed class SetupHooks : ExtentReport
    {
        private IWebDriver _driver = null!;
        private static bool _login;

        private readonly string? _baseUrl;
        private readonly IObjectContainer _container;
        private readonly IConfiguration _configuration;

        public SetupHooks(IObjectContainer container)
        {
            _container = container;
            _configuration = AppHelper.GetAppSettings();
            _baseUrl = _configuration["Settings:BaseUrl"];
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Before test run..");
            DeployExtentReport();
            SqLiteDbService.SqLiteSchemaDbVerify();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Before feature..");
            if (featureContext.FeatureInfo.Title == "Student Portal Registration" ||
                featureContext.FeatureInfo.Title == "Student Program Enrolment")
            {
                _login = true;
            }

            _feature = _reports
                .CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void CreateWebDriver(ScenarioInfo scenarioInfo)
        {
            Console.WriteLine("Before scenario..");
            var downloadPath = AppHelper.GetFolderPath("TestFiles\\Reports");

            //scenarioInfo.Title.Contains("Teacher")
            var dirUrl = bool.Parse(_configuration["Settings:IsTeacher"]!) ? 
                $"{_baseUrl}/Teacher" : _baseUrl;

            var chromeOptions = new ChromeOptions();
            {
                if (Convert.ToBoolean(_configuration["Settings:IsHeadless"]))
                {
                    chromeOptions.AddArgument("--headless");             // Run in headless mode
                }
                chromeOptions.AddArgument("--window-size=1080,720");     // Set window size to 1920x1080
                //chromeOptions.AddArgument("--no-sandbox");              // Overcome limited resource problems
                //chromeOptions.AddArgument("--disable-dev-shm-usage");   // Overcome limited resource problems
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            }

            _driver = new ChromeDriver(chromeOptions);
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(dirUrl);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

            if (_login == false)
            {
                _ = new LoginHooks(_driver, scenarioInfo);
            }

            // Make this instance available to all other step definitions
            _container.RegisterInstanceAs(_driver, null, true);
            _scenario = _feature.CreateNode<Scenario>(scenarioInfo.Title);
        }

        [BeforeStep]
        public static void BeforeStep()
        {
            Thread.Sleep(200);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            // When step pass
            /*
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepName);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepName);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepName);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(stepName);
            }
            */
            var stepNode = stepType switch
            {
                "Given" => _scenario.CreateNode<Given>(stepName),
                "When" => _scenario.CreateNode<When>(stepName),
                "Then" => _scenario.CreateNode<Then>(stepName),
                "And" => _scenario.CreateNode<And>(stepName),
                _ => null
            };

            // When step fail
            /*
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
                }
            }
            */
            if (scenarioContext.TestError != null && stepNode != null)
            {
                stepNode.Fail(scenarioContext.TestError.Message, MediaEntityBuilder
                    .CreateScreenCaptureFromPath(Photographer(_driver, scenarioContext)).Build());
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After scenario..");
            _container.Resolve<IWebDriver>();
            //_driver.Close();
            _driver.Dispose();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After feature..");
            DisposeExtentReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("After testrun..");
        }

    }
}
