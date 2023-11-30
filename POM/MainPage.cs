using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Level_Up_Project.POM
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private const string createAnAccount = "(//a[contains(@href,'account/create/')])[1]";
        private const string login = "(//a[contains(@href,'account/login/')])[1]";
        private const string search = "search";
        private const string showCart = "//a[@class='action showcart']";
        private const string viewCart = "//a[@class='action viewcart']//span";
        private const string whatsNew = "ui-id-3";
        private const string jacketsCategory = "(//a[contains(@href,'/jackets-women')])[2]";
        private const string jacketsPage = "//h1[@id='page-title-heading']//span";

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickCreateAnAccount()
        {

            driver.FindElement(By.XPath(createAnAccount)).Click();
        }
        public void Login()
        {
            driver.FindElement(By.XPath(login)).Click();

        }
        public void ClickSearch()
        {
            driver.FindElement(By.Id(search)).Click();

        }
        public void SearchForProducts(string product)
        {
            IWebElement searchInput = driver.FindElement(By.Id(search));
            searchInput.SendKeys(product);
            searchInput.SendKeys(Keys.Enter);
        }

        public void ViewCart()
        {
            driver.FindElement(By.XPath(showCart)).Click();
        }

        public void ClickViewAndEditCart()
        {
            driver.FindElement(By.XPath(viewCart)).Click();
        }

        public void ClickWatsNew()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(whatsNew)));
            driver.FindElement(By.Id(whatsNew)).Click();
        }
        public void ChooseJacketsFromCategory()
        {
            driver.FindElement(By.XPath(jacketsCategory)).Click();
        }
        public bool JacketsPageIsOpened()
        {
            return driver.FindElement(By.XPath(jacketsPage)).Displayed;
        }

    }
}
