using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AutomaticTest_14_5.nguyenchithanh
{
    public class ThptNCTBrokenLinks
    {
        IWebDriver driver;
        IWebElement element;
        IList<IWebElement> elements;
        #region * Hàm tạo
        public ThptNCTBrokenLinks(IWebDriver _driver)
        {
            driver = _driver;
        }
        #endregion Hàm tạo

        #region * Xử lý die links
        public void ThptNCTBrokenLinksFactory()
        { 
            //mo website
            driver.Navigate().GoToUrl("http://thptnguyenchithanh.angiang.edu.vn/");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));

            elements = driver.FindElements(By.CssSelector("a[href^='http://']"));
            
            /*
             * if (String.IsNullOrEmpty(element.GetAttribute("href")) 
   // thuộc tính href ko có giá trị
else 
  // thuộc tính href có giá trị
             */
            if (elements != null && elements.Count > 0)
            {
                for (int i=0; i < elements.Count; i++)
                {

                    //Console.WriteLine(elements[i]);
                    //if (String.IsNullOrEmpty(elements[i].GetAttribute("href")))
                    //{
                    //    Console.WriteLine("khong co thuoc tinh href");
                    //}
                    //else
                    //{
                        //string url = elements[1].GetAttribute("href");
                        //string url = elements[i].GetAttribute("href");
                        Console.WriteLine("href= " + elements[i].GetAttribute("href"));
                        driver.Navigate().GoToUrl(elements[i].GetAttribute("href"));
                       
                       // driver.Navigate().GoToUrl(url);

                        //chup hinh lai sau khi load xong
                        //ITakesScreenshot scrshotDriver = driver as ITakesScreenshot;
                        //Screenshot scrshot;
                        //scrshot = scrshotDriver.GetScreenshot();
                        //scrshot.SaveAsFile("D:\\congviec_binhminh\\brokenlink\\anh" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);                  
                    //}
                                        
                }
                Console.Read();
            
            }
        
        }
        #endregion Xử lý die links
    }
}
