using OpenQA.Selenium;

namespace Level_Up_Project.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver= (WebDriver)BrowserDriver.InitializeChromeDriver();
           
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");
            
        }
           
        [TearDown]
        public void CleanUp()
        {
              
         driver.Quit();
        }

        }
    }
