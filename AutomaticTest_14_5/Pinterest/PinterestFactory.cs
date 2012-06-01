using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace AutomaticTest_14_5.Pinterest
{
    public class PinterestFactory
    {
        IWebDriver driver;
        IWebElement element;
        IList<IWebElement> elements;

        #region * Hàm tạo
        public PinterestFactory(IWebDriver _driver)
        {
            driver = _driver;
        }
        #endregion Hàm tạo
        
        #region * Xử lý Khi click vào thích trong Pinterest, sẽ đưa bảng tin đó vào tài khoản Facebook thông qua tài khoản Twitter
        public void PinterestFacebookFactory()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            #region * Xử lý ĐĂNG NHẬP FACEBOOK                  
            //mo trang facebook
            driver.Navigate().GoToUrl("http://facebook.com");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));
            
            //--
            IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
            jscript.ExecuteScript("window.open();");

            List<string> handles = driver.WindowHandles.ToList<string>();
            driver.SwitchTo().Window(handles.Last());
            driver.Navigate().GoToUrl("http://facebook.com");

            
            //--


            //tim nut login
            elements = driver.FindElements(By.CssSelector("label#loginbutton > input:first-of-type"));
            if (elements!= null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++ )
                {
                    if ( elements[i].Displayed && elements[i].Enabled)
                    {
                        element = driver.FindElement(By.Id("email"));
                        element.SendKeys("chuotconlilac@hotmail.com");

                        element = driver.FindElement(By.Id("pass"));
                        element.SendKeys("minhbinhxuan");

                        //click vao nut login
                        elements[i].Click();
                        
                    }
                    break;
                }
            }            
            #endregion * Xử lý ĐĂNG NHẬP FACEBOOK

            #region * Xử lý ĐĂNG NHẬP PINTEREST
            
            //mo trang pinterest
            driver.Navigate().GoToUrl("http://pinterest.com/");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));

                     


            //cho load trang
            //click on "login" button
            elements = driver.FindElements(By.CssSelector("div > a[class='Button WhiteButton Button18'][href='/login/?next=%2F']"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        elements[i].Click();                        
                    }
                    break;
                }

            }
            #region * Xử lý ĐĂNG NHẬP TÀI KHOẢN TWITTER

            //cho load trang moi
            //nhap email
            element = driver.FindElement(By.Id("id_email"));
            element.Clear();
            element.SendKeys("xcoivie@gmail.com");

            //nhap pass
            element = driver.FindElement(By.Id("id_password"));
            element.Clear();
            element.SendKeys("clrscr");
            
            //click vao nut "login with twitter" buttons
            elements = driver.FindElements(By.CssSelector("a[class='tw login_button']"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        elements[i].Click();                       
                    }
                    break;
                }            
            }         

            //cho load trang moi. 
            //tim user tren trang moi
            element = driver.FindElement(By.Id("username_or_email"));
            if (element.Displayed && element.Enabled)
            {                
                element.Clear();
                element.SendKeys("xcoivie@gmail.com");

                // sendkey pass
                element = driver.FindElement(By.Id("password"));
                element.Clear();
                element.SendKeys("clrscr");

                //click on sign in
                element = driver.FindElement(By.Id("allow"));
                element.Click();
            }
            #endregion  *Xử lý ĐĂNG NHẬP TÀI KHOẢN TWITTER

            
            #region Maximize window and ZOOM IN PAGE
            //Cuon trang tin
            //cuon man hinh theo chieu cao 5 lan
            jscript = driver as IJavaScriptExecutor;
            for (int i = 0; i < 5; i++)
            {
                jscript.ExecuteScript("window.scrollTo(0,screen.availHeight);");
                Thread.Sleep(2000);
            }

            String script = "if (window.screen){window.moveTo(0,0);window.resizeTo(window.screen.availWidth,window.screen.availHeight);};";
            jscript.ExecuteScript(script);

            //--
            IWebElement el = driver.FindElement(By.Id("Pinterest"));

            int times = 0;
            while (times++ < 5)
            {
                Thread.Sleep(3000);

                (new Actions(driver))
                .SendKeys(Keys.Control)
                .SendKeys(Keys.Subtract)
                .Build()
                .Perform();
            }

            #endregion  

            #region * Xử lý click vào danh sách các tin

             


            //tim danh sach cac tin trong printerest.
            elements = driver.FindElements(By.CssSelector("a[class='PinImage ImgLink'][href^='/pin/']"));
            if (elements != null && elements.Count> 0)
            {
                foreach (IWebElement tinmoi in elements)
                {
                    //lay dia chi cua moi tin
                    string url = tinmoi.GetAttribute("href");                    
                    
                    //mo cua so moi bang javascript
                    js = driver as IJavaScriptExecutor;
                    js.ExecuteScript("window.open();");
                    
                    
                    //dem so luong cua so
                    List<string> cuaso = driver.WindowHandles.ToList<string>();
                    driver.SwitchTo().Window(cuaso.Last());

                    //dan dia chi cho cua so vua mo.
                    driver.Url = url;
                    driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));

                    #region * Xu ly tim frame
                    //tim fram tren cua so moi mo.
                    IList<IWebElement> framefacebook1 = driver.FindElements(By.CssSelector("iframe[src^='http://www.facebook.com/plugins/']"));
                    if (framefacebook1 != null && framefacebook1.Count > 0)
                    {
                        for (int i = 0; i < framefacebook1.Count; i++)
                        {
                            if (framefacebook1[i].Displayed && framefacebook1[i].Enabled)
                            {
                                driver.SwitchTo().Frame(framefacebook1[i]);
                                break;
                            }
                            
                        }
                        #region * Xu ly sau khi vao trong frame
                        
                        //tim nut thich
                        elements = driver.FindElements(By.CssSelector("div.pluginToggle>div>div>button[type='submit']"));

                        // tim thay nut thich thi thôi không load những thứ khác nữa
                        //framefacebook1[0].SendKeys(Keys.Escape); 

                        if (elements != null && elements.Count > 0)
                        {
                            for (int i = 0; i < elements.Count; i++)
                            {
                                if (elements[i].Displayed && elements[i].Enabled)
                                {
                                    elements[i].Click();
                                    break;
                                }
                                
                            }
                        }                       

                        #endregion * Xu ly sau khi vao trong frame

                    }
                    //nhay vao cua so cuoi
                    driver.SwitchTo().Window(cuaso.Last());
                    js.ExecuteScript("window.close();");

                    //nhay vao cua so main
                    cuaso = driver.WindowHandles.ToList<string>();
                    driver.SwitchTo().Window(cuaso.Last());
                    #endregion * Xu ly tim frame
                }
            }
            #endregion * Xử lý click vào danh sách các tin            

            #endregion Xử lý ĐĂNG NHẬP PINTEREST

        }
        #endregion Xử lý Khi click vào thích trong Pinterest, sẽ đưa bảng tin đó vào tài khoản Facebook thông qua tài khoản Twitter


    }
}
