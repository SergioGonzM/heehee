using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Steams
{
    [TestFixture]
    public class Tests
    {
        //Page Objects
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private const string URL = "https://store.steampowered.com";
        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void Teardown() 
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            //home page is displayed
            Assert.IsNotNull(homePage.HomeElement);

            //go to login page
            homePage.ClickLogin();
            Assert.AreEqual(driver.Url, "https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_4__global-header");

            //generate random user and password
            string randomUser = GenerateRandomCredentials();
            loginPage.Username.SendKeys(randomUser);
            string randomPwd = GenerateRandomCredentials();
            loginPage.Password.SendKeys(randomPwd);

            //click login button
            loginPage.LoginButton.Click();

            //loading element is displayed
            Assert.IsNotNull(loginPage.LoadingIcon);

            //error message is displayed
            Assert.IsTrue(loginPage.ErrorMessage.Displayed);

        }

        private string GenerateRandomCredentials()
        {
            string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 8; 

            Random rand = new Random();
            char[] randomText = new char[length];

            for (int i = 0; i < length; i++)
            {
                int randomIndex = rand.Next(AllowedChars.Length);
                randomText[i] = AllowedChars[randomIndex];
            }
            string randomCredentials = new string(randomText);

            return randomCredentials;
        }


    }
}