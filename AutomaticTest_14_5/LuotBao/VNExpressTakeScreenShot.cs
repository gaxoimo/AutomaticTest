using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Drawing;
using System.Collections;

namespace AutomaticTest_14_5.LuotBao
{
    public class VNExpressTakeScreenShot
    {
        IWebDriver driver;
        IWebElement element;
        public VNExpressTakeScreenShot(IWebDriver _driver)
        {
            driver = _driver;        
        }
        public void TakeScreenShotFactory()
        {
            driver.Navigate().GoToUrl("http://vnexpress.net/");
            
            //wait loading

            //su dung css tim phan tu
            //element = driver.FindElement(By.CssSelector("a[href$='/gl/kinh-doanh/']")); 
           
            //su dung javascript
            
            
            //IWebElement element_js = (IWebElement)js;
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("return $('a[href$=\"/gl/kinh-doanh/\"]')"); 
            //js.ExecuteScript(" return $('a[href$=\"/gl/kinh-doanh/\"]')");
            


            
            ////mouse over
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();


            //su dung xpath
            IList<IWebElement> elements = driver.FindElements(By.XPath("//a[contains(text(),'Doanh nhân')]"));
            elements[1].Click();

            
            //elements[0].Click();

            //take screenshot
            ITakesScreenshot scrshotdriver = driver as ITakesScreenshot;
            Screenshot scrshot = scrshotdriver.GetScreenshot();
            //scrshot.SaveAsFile("d")
            //File scrFile = (ITakesScreenshot)driver.geet
            scrshot.SaveAsFile("D:\\congviec_binhminh\\nhadep.Png" , System.Drawing.Imaging.ImageFormat.Png);




//            ile scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
//FileUtils.copyFile(scrFile, new File("c:\\tmp\\screenshot.jpg"));

//c:\\tmp\\screenshot.jpg -> Location of screenshot 

           //scrshot.SaveAsFile("D:\\congviec_binhminh\nha.png");
            
            //scrshot.SaveAsFile("D:\\congviec_binhminh", nhadep.Png);
           //scrshot.SaveAsFile("C:\\\min.png");
//            WebDriver driver = new FirefoxDriver();
//driver.get("http://www.google.com/");
//File scrFile = ((TakesScreenshot)driver).getScreenshotAs(OutputType.FILE);
//// Now you can do whatever you need to do with it, for example copy somewhere
//FileUtils.copyFile(scrFile, new File("c:\\tmp\\screenshot.png"));


        }
             
    }
}
