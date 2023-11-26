using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Level_Up_Project.POM
{
    public class ProductPage
    {
        private readonly IWebDriver driver;
        private const string product = "//img[@alt='Voyage Yoga Bag']";
        private const string pants = "//img[@alt='Cronus Yoga Pant ']";
        private const string addToCart = "product-addtocart-button";
        private const string successMessage = "//div[@data-ui-id='message-success']";
        private const string productDoesNotExist = "//div[@class='message notice']";
        private const string cantAddToCart = "//div[@class='mage-error']";
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickProduct()
        {
            driver.FindElement(By.XPath(product)).Click();
        }

        public void ClickAddToCart()
        {
            driver.FindElement(By.Id(addToCart)).Click();
        }
        public bool ScuccessMessageIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(successMessage)));
            return driver.FindElement(By.XPath(successMessage)).Displayed;

        }
        public bool ProductPageIsOpened()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(product)));
            return driver.FindElement(By.XPath(product)).Displayed;
        }
        public bool ProductIsNotAvailable()
        {
            return driver.FindElement(By.XPath(productDoesNotExist)).Displayed;
        }
        public bool CantAddProductError()
        {
            return driver.FindElement(By.XPath(cantAddToCart)).Displayed;
        }
        public void ClickPants()
        {
            driver.FindElement(By.XPath(pants)).Click();
        }
    }
}
