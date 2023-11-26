using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Level_Up_Project
{
    public static class BrowserDriver
    {

        public static IWebDriver InitializeChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--headless");

            IWebDriver driver = new ChromeDriver(options);
            if (driver == null)
            {

                Console.WriteLine("Driver initialization failed. Returning null.");
            }

            return driver;
        }

    }
}

