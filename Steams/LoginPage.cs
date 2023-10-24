using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steams
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //returns  IWebElement found by xpath
        public IWebElement Username => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class, 'LoginContainer')]//input[contains(@class, 'newlogindialog_TextInput')]")));
        public IWebElement Password => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='password' and contains(@class, 'newlogindialog_TextInput')]")));
        public IWebElement LoginButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit' and contains(@class, 'SubmitButton')]")));
        public IWebElement LoadingIcon => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'LoadingContainer')]")));
        public IWebElement ErrorMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'newlogindialog_FormError')]")));
       
    }
}
