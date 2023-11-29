using Level_Up_Project.POM;
using NUnit.Allure.Core;

namespace Level_Up_Project.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class MagentoTests:BaseTest
    {
        string randomEmail;
        string randomPassword;
       
        [Test, Order(1)]
        public void Registration()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickCreateAnAccount();
            string randomFirstName = RandomDateGenerator.GenerateRandomFirstName();
            Registration registration=new Registration(driver);
            Assert.IsTrue(registration.RegistrationPageIsOpened(), "Registration page is not opened");
            registration.EnterFirstName(randomFirstName);
            string randomLastName = RandomDateGenerator.GenerateRandomLastName();
            registration.EnterLastName(randomLastName);
            randomEmail = RandomDateGenerator.GenerateRandomEmail();
            randomPassword= RandomDateGenerator.GenerateRandomPassword();
            registration.EnterEmail(randomEmail);
            registration.EnterPassword(randomPassword);
            registration.ConfirmPassword(randomPassword);
            registration.ClickSubmit();
            Assert.IsTrue(registration.ScuccessMessageIsDisplayed(),"Account was not created");       
        }
        [Test, Order(2)]
        public void SignIn()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Login();
            Login loginPage = new Login(driver);
            loginPage.EnterEmail(randomEmail);
            loginPage.EnterPassword(randomPassword);
            loginPage.ClickSignIn();
           Assert.IsTrue(loginPage.UserIsLoggedIn(), "User is not logged in");

        }
        [Test, Order(3)]
        public void SearchForProcut()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickSearch();
            mainPage.SearchForProducts("Bag");
            ProductPage productPage = new ProductPage(driver);
            Assert.IsTrue(productPage.ProductPageIsOpened(), "product page is not opened");
        }
        [Test, Order(4)]
        public void AddProcutToTheCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickSearch();
            mainPage.SearchForProducts("Bag");
            ProductPage productPage = new ProductPage(driver);
            productPage.ClickProduct();
            productPage.ClickAddToCart();
            Assert.IsTrue(productPage.ScuccessMessageIsDisplayed(), "product is not added to the cart");
        }

        [Test, Order(5)]
        public void ChooseFromCategory()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickWatsNew();
            mainPage.ChooseJacketsFromCategory();
            Assert.IsTrue(mainPage.JacketsPageIsOpened(), " Chosen Category page is not opened");
        }
        [Test, Order(6)]
        public void DeleteProductFromCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Login();
            Login loginPage = new Login(driver);
            loginPage.EnterEmail(randomEmail);
            loginPage.EnterPassword(randomPassword);
            loginPage.ClickSignIn();
            Assert.IsTrue(loginPage.SingInErrOrror(), "Sing in error ins not displayed");
        }
        [Test, Order(7)]
        public void InvalidEmailAdress()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickCreateAnAccount();
            string randomFirstName = RandomDateGenerator.GenerateRandomFirstName();
            Registration registration = new Registration(driver);
            Assert.IsTrue(registration.RegistrationPageIsOpened(), "Registration page is not opened");
            registration.EnterFirstName(randomFirstName);
            string randomLastName = RandomDateGenerator.GenerateRandomLastName();
            registration.EnterLastName(randomLastName);
            registration.EnterEmail("example.com");
            registration.ClickSubmit();
            Assert.IsTrue(registration.EmailIsInvalid(), "email  is  in a valid  format");
        }
        [Test, Order(8)]
        public void PasswordIsRequiered()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickCreateAnAccount();
            string randomFirstName = RandomDateGenerator.GenerateRandomFirstName();
            Registration registration = new Registration(driver);
            Assert.IsTrue(registration.RegistrationPageIsOpened(), "Registration page is not opened");
            registration.EnterFirstName(randomFirstName);
            string randomLastName = RandomDateGenerator.GenerateRandomLastName();
            registration.EnterLastName(randomLastName);
            registration.ClickSubmit();
            Assert.IsTrue(registration.GetPasswordIsRequieredError(), "password is provided");
        }
        [Test, Order(9)]
        public void ProductDoesNotExist()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickSearch();
            mainPage.SearchForProducts("fdf");
            ProductPage productPage = new ProductPage(driver);
            Assert.IsTrue(productPage.ProductIsNotAvailable(), " searched product is available" );
        }
        [Test, Order(10)]                                 
        public void CanNotItemToTheCart()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.ClickSearch();
            mainPage.SearchForProducts("Pant");
            ProductPage productPage = new ProductPage(driver);
            productPage.ClickPants();
            productPage.ClickAddToCart();
            Assert.IsTrue(productPage.CantAddProductError(), "product is added to the cart");

        }

    }
}
