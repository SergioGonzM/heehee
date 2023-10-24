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
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void ClickLogin()
        {
            //LoginText.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", LoginText);
        }

        //returns home element found by xpath
        public IWebElement HomeElement => driver.FindElement(By.XPath("//div[contains(@class, 'home_cluster_ctn')]"));

        //returns Login Text found by xpath
        public IWebElement LoginText => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(@href, 'https://store.steampowered.com/login/')]")));
    }
}
