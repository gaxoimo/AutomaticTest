using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomaticTest_14_5.FaceBook;

namespace AutomaticTest_14_5.FaceBook
{        
    public class FacebookLoginFactory
    {
        IWebDriver driver;
        IWebElement element;
        public FacebookLoginFactory(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void DoWork()
        {
            //go to webpage
            driver.Navigate().GoToUrl("http://facebook.com");
            //wait loading; find element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));
            element = driver.FindElement(By.Id("email"));
            element.SendKeys("thuc.pham.1@live.com");

            element = driver.FindElement(By.Id("pass"));
            element.SendKeys("25111999");
            //
            element = driver.FindElement(By.CssSelector("label#loginbutton > input:first-of-type"));
            element.Click();
        }
    }
}
