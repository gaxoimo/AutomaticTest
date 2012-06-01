using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using AutomaticTest_14_5.LuotBao;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace AutomaticTest_14_5.FaceBook
{
    public class FaceBookLuotBaoURL
    {
        IWebDriver driver;
        IWebElement element;
        public FaceBookLuotBaoURL(IWebDriver _driver)
        {
            driver = _driver;
        }
        #region *login face book, mo truc tiep dia chi tren firefox
        public void TestLogin(string user, string pass, string url)
        {
            driver.Navigate().GoToUrl("http://facebook.com");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));
            element = driver.FindElement(By.CssSelector("label#loginbutton > input:first-of-type"));
            if (element.Displayed && element != null)
            {
                //wait loading; find element             
                element = driver.FindElement(By.Id("email"));
                element.SendKeys(user);

                element = driver.FindElement(By.Id("pass"));
                element.SendKeys(pass);

                element = driver.FindElement(By.CssSelector("label#loginbutton > input:first-of-type"));
                element.Click();
            }            
                //xu li trang luot bao
                //gán dia chi trang luot bao.
                driver.Navigate().GoToUrl(url);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                //tim frames
                IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;                 
                IWebElement tieudeh4 = driver.FindElement(By.CssSelector("h4.title"));
                string chuoi = tieudeh4.Text;
                string comment = "Chia sẻ: " + chuoi;
                Console.WriteLine(comment);
                try
                {
                    //tim frame facebook
                    IList<IWebElement>  frames = driver.FindElements(By.CssSelector("div.fblikebutton>iframe[src^='http://www.facebook.com/plugins/like.php?href=http://luotbao.com/index.php/pages/article']"));
                    
                    //nhay vao frame
                    driver.SwitchTo().Frame(frames[0]);                    

                    //tim nut like
                    IWebElement like_button_no_like = driver.FindElement(By.CssSelector("a[class^='connect_widget_like_button clearfix']"));
                    if (like_button_no_like.GetAttribute("class").Contains("like_button_no_like"))
                    {
                        //kiem tra neu chua thich thi click thich
                        like_button_no_like.Click();

                        //chú ý: con chuot trên màn hình, khi mouseover phai đem ra ngoài khu vực cửa sổ mới mở.                        
                        IWebElement likebuttonlike = driver.FindElement(By.CssSelector("a[class='connect_widget_like_button clearfix like_button_like']"));
                        Actions builer = new Actions(driver);
                        builer.MoveToElement(likebuttonlike).Build().Perform();

                        //click chuot vao nut like_button_like de xuat hien commment
                        likebuttonlike.Click();

                        //tim comment
                        IWebElement element_comment = driver.FindElement(By.CssSelector("table.uiGrid td:first-of-type > input"));
                        element_comment.Click();                                                                                                                                 

                        //nhap vao commment
                        element_comment.Clear();
                        element_comment.SendKeys(comment);
                        Thread.Sleep(1000);
                        element_comment.Click();
                        //element_comment.SendKeys(Keys.Tab);
                        element_comment.SendKeys(Keys.Enter);

                        //click on nut dang
                        IWebElement element_dang = driver.FindElement(By.CssSelector("table.uiGrid td:last-of-type > label > input"));
                        element_dang.Click();

                        //driver.SwitchTo().Window(handles.Last());
                        jscript.ExecuteScript("window.close()");
                    }   
                }
                catch
                {
                    //tim khong thay frame facebook, thi dong cua so window.
                    //nhay vao cua so cuoi cung.
                    //driver.SwitchTo().Window(handles.Last());
                    jscript.ExecuteScript("window.close()");

                    //nhay vao trang danh sach.
                    //handles = driver.WindowHandles.ToList<string>();
                    //driver.SwitchTo().Window(handles.Last());

                    //continue;
                }
        #endregion

        }

        #region *login facebook, dua dia chi moi vao muc trang thai
        public void TestLoginStates(string user, string pass, string url)
        {
            try
            {
                driver.Navigate().GoToUrl("http://facebook.com");
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));
                element = driver.FindElement(By.CssSelector("label#loginbutton > input:first-of-type"));
                if (element.Displayed && element != null)
                {
                    //wait loading; find element             
                    element = driver.FindElement(By.Id("email"));
                    element.SendKeys(user);

                    element = driver.FindElement(By.Id("pass"));
                    element.SendKeys(pass);

                    element = driver.FindElement(By.CssSelector("label#loginbutton > input:first-of-type"));
                    element.Click();
                }

                //tim textarea
                IWebElement textarea = driver.FindElement(By.CssSelector("div.innerWrap > textarea:first-of-type"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(textarea).Click();
                
                //nhap url
                textarea.SendKeys(url);
                
                //nhan tab, cho bai bao goc, doi xuat hien nut dong.
                textarea.SendKeys(Keys.Enter);               
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
                wait.Until(d => d.FindElement(By.CssSelector("label[class$='uiCloseButton'] input:first-of-type")));                
                
                //tim nut dang, click vào
                IList<IWebElement> dangs = driver.FindElements(By.CssSelector("div#uiComposerMessageBoxControls li:nth-of-type(2) input:first-of-type"));
                dangs[0].Click();                

                //chup hinh cuoi cung sau khi dang url thanh cong
                ITakesScreenshot scrshotdriver = driver as ITakesScreenshot;
                Screenshot scrshot = scrshotdriver.GetScreenshot();
                scrshot.SaveAsFile("D:\\congviec_binhminh\\facebooknew.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi la: ", e);
                Console.Read();
            
            }      
        }

        #endregion
    }
 }   



