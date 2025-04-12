using Microsoft.Extensions.Configuration;

namespace UMS.UI.Test.BusinessModel.Helper
{
    public class JsonHelper
    {
        private readonly IConfiguration _configuration;
        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "appsettings.json");

        public JsonHelper()
        {
            try
            {
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(ConfigFilePath, optional: false, reloadOnChange: true);

                _configuration = configBuilder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }
        public string? GetConfigValue(string key)
        {
            var value = _configuration[key];
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Warning: Config Key '{key}' not found.");
                return null;
            }
            return value;
        }

        public string? BaseURL => GetConfigValue("Settings:BaseUrl");
        public string? UserName => GetConfigValue("Settings:Username");
        public string? Password => GetConfigValue("Settings:Password");
    }
}
