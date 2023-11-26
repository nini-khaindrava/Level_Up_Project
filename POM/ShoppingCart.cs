using OpenQA.Selenium;


namespace Level_Up_Project.POM
{
    public class ShoppingCart
    {
        private readonly IWebDriver driver;
        private const string deleteItem = "//a[@class='action action-delete']";
        private const string emptyCart = "//div[@class='cart-empty']";

        public ShoppingCart(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void DeleteItemFromShoppingCart()
        {
            driver.FindElement(By.XPath(deleteItem)).Click();

        }
        public bool CartIsEmpty()
        {
           return driver.FindElement(By.XPath(emptyCart)).Displayed;

        }
    }
}
