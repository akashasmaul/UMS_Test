using UMS.UI.Test.BusinessModel.Enum.Student;

namespace UMS.UI.Test.BusinessModel.Helper
{
    public static class TestHelper
    {
        private static SelectElement _selectElement = null!;
        private static IList<IWebElement> _webElements = null!;

        private static string[] LatestTextFileReader(string filePath)
        {
            var latestFile = new DirectoryInfo(filePath)
            .GetFiles("*.txt")
            .OrderByDescending(file => file.LastWriteTime)
            .FirstOrDefault();

            return latestFile is not null ?
                File.ReadAllLines(latestFile.FullName) : Array.Empty<string>();
        }

        public static void ShowMessageBox(string message)
        {
            int width = message.Length + 6;

            Console.WriteLine(new string('-', width));
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            Console.WriteLine("|  " + message + "  |");
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            Console.WriteLine(new string('-', width));
        }

        //public static void ShowMessageBox(ITestOutputHelper output, string message)
        //{
        //    int width = message.Length + 6;

        //    output.WriteLine(new string('-', width));
        //    output.WriteLine("|" + new string(' ', width - 2) + "|");
        //    output.WriteLine("|  " + message + "  |");
        //    output.WriteLine("|" + new string(' ', width - 2) + "|");
        //    output.WriteLine(new string('-', width));
        //}

        public static void ShowMessageBox(ITestOutputHelper output, string message, int maxWidth = 50)
        {
            List<string> lines = new List<string>();
            string[] words = message.Split(' ');
            string currentLine = "";

            foreach (var word in words)
            {
                if ((currentLine + word).Length > maxWidth)
                {
                    lines.Add(currentLine.Trim());
                    currentLine = "";
                }
                currentLine += word + " ";
            }

            if (!string.IsNullOrWhiteSpace(currentLine))
                lines.Add(currentLine.Trim());

            int maxLength = lines.Max(line => line.Length);
            int width = maxLength + 6;

            output.WriteLine(new string('-', width));
            output.WriteLine("|" + new string(' ', width - 2) + "|");

            foreach (var line in lines)
            {
                output.WriteLine($"|  {line.PadRight(maxLength)}  |");
            }

            output.WriteLine("|" + new string(' ', width - 2) + "|");
            output.WriteLine(new string('-', width));
        }


        public static string GetRegisterNumber()
        {
            var regOrRoll = string.Empty;
            var filePath = AppHelper.GetFolderPath("TestFiles\\Reports");
            var texts = LatestTextFileReader(filePath);
            foreach (string text in LatestTextFileReader(filePath))
            {
                if (text.Contains("Register"))
                {
                    string[] regText = text.Split(':');
                    regOrRoll = regText[^1].Trim();
                    break;// line.Split(new[] { ':' });
                }
            }
            return regOrRoll;
        }

        public static IList<IWebElement> GetElementOptions(IWebElement element)
        {
            _selectElement = new SelectElement(element);
            return _selectElement.Options.Where(x => x.Enabled).ToList();
        }

        public static IList<string> GetDropdownValues(IWebElement element)
        {
            var options = new SelectElement(element).Options;
            IList<string> dropdownValues = new List<string>();

            foreach (IWebElement option in options)
            {
                dropdownValues.Add(option.Text);  // Add option text to list
            }
            return dropdownValues;
        }

        public static void RandomOptionSelector(IWebElement element)
        {
            _webElements = GetElementOptions(element);
            var index = new Random().Next(1, _webElements.Count);
            _selectElement.SelectByIndex(index);
        }

        public static void FirstOrMaxRandomSelector(IWebElement element, int max)
        {
            _webElements = GetElementOptions(element);
            if (max > 1)
                _selectElement.SelectByIndex(new Random().Next(1, max));
            else
                _selectElement.SelectByIndex(new Random().Next(1, 1));
        }

        public static void BatchItemsSelector(IWebElement element, Batch item)
        {
            _webElements = GetElementOptions(element);
            var firstName = _webElements.ElementAt(0).Text != $"Select Batch {item}";
            if (firstName)
                _selectElement.SelectByIndex(0);
            else if (_webElements.Count >= 2)
                _selectElement.SelectByIndex(1);
            else
                Console.WriteLine($"Error! Batch {item} Not Found.");
        }

        public static void DispatchEventScript(IWebDriver driver, string elementId)
        {
            var js = driver as IJavaScriptExecutor;

            var script = "var event = new Event('input', { bubbles: true }); " +
                         "arguments[0].dispatchEvent(event);";

            //"var event = new Event('input', { bubbles: true }); " +
            //    $"document.getElementById('{elementId}').dispatchEvent(event);";

            js!.ExecuteScript(script, driver.FindElement(By.Id(elementId)));
        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(@"arguments[0].scrollIntoView(false);", element);
        }

        public static IWebElement? ElementIsNull(IWebDriver driver, By element)
        {
            try { return driver.FindElement(element); } catch { return null; }
        }

        public static string GetOrganizationByBranch(string input, int n = 6)
        {
            var org = string.Empty;
            if (input != null && input.Length > n)
                org = input.Split(' ').Select(x => x.Trim()).Last();

            return org.ToUpper();
        }

        public static string GetRandomMobileNumber()
        {
            var random = new Random();
            var digits = new[] { '3', '4', '5', '6', '7', '8', '9' };
            var number = random.Next(11111111, 99999999);
            return $"01{digits[random.Next(digits.Length)]}{number}";
        }

        public static IList<string> GetStringsBySplitOptions(string text)
        {
            return text.Split(new[] { ',' }, StringSplitOptions.TrimEntries)
                .Where(x => x != string.Empty)
                .ToList();
        }

        public static string GetUniqueUpString(int length = 10)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] nicknameChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                nicknameChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(nicknameChars);
        }

        public static string GetUniqueName(int length = 11)
        {
            var random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                if (i == 0 | i == 6)
                    chars[i] = (char)random.Next(65, 90);
                else if (i == 5)
                    chars[i] = ' ';
                else
                    chars[i] = (char)random.Next(97, 122);

            }
            return new string(chars);
        }

        public static string RemoveSpace(string source)
        {
            return Regex.Replace(source, @"\s", string.Empty);
        }

        public static bool IsValidNickname(string nickName)
        {
            return Regex.IsMatch(nickName, @"^[a-zA-Z-]+$");
        }

        public static bool IsNumber(string input)
        {
            return double.TryParse(input, out _);
        }

        public static bool IsValidRegOrRoll(string number)
        {
            //@"^[0-9]{7}$|^[0-9]{10}$|^[0-9]{11}$"
            return Regex.IsMatch(number, @"^\d{7}|\d{10}|\d{11}$");
        }

        public static bool IsValidMobileNo(string mobile)
        {
            var prefix = new string[]
            {
                "013", "015", "014", "016", "017", "018", "019"
            };

            var isMatch = prefix.Any(p => mobile.StartsWith(p));
            var isValid = Regex.IsMatch(mobile, @"^[0-9]{11}$");
            return isMatch && isValid;
        }

        public static void HandleNewWindow(IWebDriver driver)
        {
            // Get the handles of all open windows/tabs
            string mainWindowHandle = driver.CurrentWindowHandle;
            string newWindowHandle = string.Empty;

            foreach (string handle in driver.WindowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    newWindowHandle = handle;
                    break;
                }
            }

            // Switch to the new window
            driver.SwitchTo().Window(newWindowHandle);
        }

        public static void SelectMultiItems(IWebDriver driver, string searchItems)
        {
            string[] itemList = searchItems.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            IWebElement searchElement = driver.FindElement(By.XPath("//div[@class='btn-group open']//input[@placeholder='Search']"));
            IWebElement dropdownOption(string item) => driver.FindElement(By.XPath($"//label[normalize-space()=\"{item}\"]"));

            foreach (string item in itemList)
            {
                var itemName = item.Trim();
                searchElement.SendKeys(itemName.ToString());
                Thread.Sleep(500);
                dropdownOption(itemName).Click();
                searchElement.Clear();
            }
        }

        public static void SelectMultiTeachers(IWebDriver driver, string teacherPin)
        {
            string[] tPINs = teacherPin.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            IWebElement? teacherElement = driver.FindElement(By.XPath("//input[@id='TeacherId']"));
            IWebElement? TeacherSelect(string tPin) => driver.FindElement(By.XPath($"//ul[@id='multiselectOptionList']//input[@type='checkbox' and @value=\"{tPin}\"]"));
            foreach (string tpin in tPINs)
            {
                foreach (char c in tpin)
                {
                    teacherElement.SendKeys(c.ToString());
                    Thread.Sleep(700); // Delay between typing each character
                }
                string? teaPin = tpin.Trim();
                TeacherSelect(teaPin)!.Click();
                teacherElement.Clear();
            }

        }

    }
}
