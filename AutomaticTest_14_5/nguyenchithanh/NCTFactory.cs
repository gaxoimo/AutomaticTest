using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AutomaticTest_14_5.nguyenchithanh
{
    public class NCTFactory
    {
        IWebDriver driver;
        IWebElement element;
        public NCTFactory(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void NCTDoWork()
        {
            driver.Navigate().GoToUrl("http://thptnguyenchithanh.angiang.edu.vn/");
            //wait loading
            element = driver.FindElement(By.CssSelector("div[class='Head title_vis'] a>img[src$='DNN-plus.png']"));            
            element.Click();
            

        }
    }
}
