using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Level_Up_Project.POM
{
    public class Login
    {
        private readonly IWebDriver driver;
        private const string email = "email";
        private const string passwd = "pass";
        private const string singInBt = "send2";
        private const string userLoggedIn = "(//span[@class='logged-in'])[1]";
        private const string signInError = "//div[@data-ui-id='message-error']";
       

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void EnterEmail(string emaiAddress)
        {
            driver.FindElement(By.Id(email)).SendKeys(emaiAddress);
        }
        public void EnterPassword(string password)
        {
            driver.FindElement(By.Id(passwd)).SendKeys(password);
        }
        public void ClickSignIn() {

            driver.FindElement(By.Id(singInBt)).Click();
        }
        public bool UserIsLoggedIn()
        {
            return driver.FindElement(By.XPath(userLoggedIn)).Displayed;
        }

        public bool SingInErrOrrorIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(signInError)));
            return driver.FindElement(By.XPath(signInError)).Displayed!;
        }
    }
}
