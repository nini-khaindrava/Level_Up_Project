using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Level_Up_Project.POM
{
  
    public class Registration
    {
        private readonly IWebDriver driver;
        private const string firstNameField = "firstname";
        private const string lastNameField = "lastname";
        private const string emailAdress = "email_address";
        private const string passwd = "password";
        private const string paconfirmPassword = "password-confirmation";
        private const string submit = "//button[contains(@class,'action submit primary')]";
        private const string successMessage = "//div[@data-ui-id='message-success']";
        private const string invalidEmail = "email_address-error";
        private const string passRequired = "//div[@id='password-error']";
        
        public Registration(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void EnterFirstName(string firstName)
        {
            driver.FindElement(By.Id(firstNameField)).SendKeys(firstName);
        }
        public void EnterLastName(string lastName)
        {
            driver.FindElement(By.Id(lastNameField)).SendKeys(lastName);
        }
        public void EnterEmail(string email)
        {
            driver.FindElement(By.Id(emailAdress)).SendKeys(email);

        }
        public void EnterPassword(string password)
        {
            driver.FindElement(By.Id(passwd)).SendKeys(password);

        }
        public void ConfirmPassword(string confirmPassword)
        {
            driver.FindElement(By.Id(paconfirmPassword)).SendKeys(confirmPassword);
        }
        public void ClickSubmit()
        {
            driver.FindElement(By.XPath(submit)).Click();
        }
        public bool ScuccessMessageIsDisplayed() {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(successMessage)));
            return driver.FindElement(By.XPath(successMessage)).Displayed;

        }
        public bool RegistrationPageIsOpened()
        {   
            return driver.FindElement(By.XPath(submit)).Displayed;
        }
        public bool EmailIsInvalid()
        {
            return driver.FindElement(By.Id(invalidEmail)).Displayed;
        }

        public bool GetPasswordIsRequieredError()
        {
            return driver.FindElement(By.XPath(passRequired)).Displayed;
        }
    }

}


  
