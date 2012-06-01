using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

//thay doi ten namespace
namespace AutomaticTest_14_5.FaceBookComment
{
    public class LuotBaoThichFactory
    {
        IWebDriver driver;
        IWebElement element;
        public LuotBaoThichFactory(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void DoWork()
        {
            driver.Url = "http://luotbao.com";
            //wait load
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            

            //find "dunghiennua" element
            element = driver.FindElement(By.Id("fancybox-close"));
            element.Click();

            //find "kinhte" element   
            //tao vong lap for cho viec lap lai type:
            //di tu 1 den 12
            //element = driver.FindElement(By.CssSelector("ul>li:nth-of-type(7)>a"));
            for (int i = 1; i < 11; i++ )
            {
                string css = "ul>li:nth-of-type("+ i+ ")>a";
                Console.WriteLine(css);
                element = driver.FindElement(By.CssSelector(css));
                            
            //Lấy danh sách tin (5 tin) trong muc "kinh te"
            //chua su dung scroll            
            IList<IWebElement> article_elements = driver.FindElements(By.CssSelector("a[href^='http://luotbao.com/index.php/pages/article']"));
            
            //kiem tra su ton tai cua phan tu vua tim
            if (article_elements != null && article_elements.Count > 0)
            {
                //Chạy từng bài báo
                foreach (IWebElement article_ele in article_elements)
                {
                    string url = article_ele.GetAttribute("href");

                    //dung javascript mo 1 cua so moi
                    IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
                    jscript.ExecuteScript("window.open()");

                    //nhay vao cua so cuoi cung.                        
                    List<string> handles = driver.WindowHandles.ToList<string>();
                    driver.SwitchTo().Window(handles.Last());

                    //dan dia chi url vao.
                    driver.Navigate().GoToUrl(url);

                    //Lấy link nút Like của facebook trên bài báo
                    //tim frame cong nge
                    IList<IWebElement> frames;
                    IWebElement tieudeh4 = driver.FindElement(By.CssSelector("h4.title"));
                    string chuoi = tieudeh4.Text;
                    string comment = "Chia sẻ: " + chuoi;
                    Console.WriteLine(comment);
                    try
                    {
                        //tim frame facebook
                        frames = driver.FindElements(By.CssSelector("div.fblikebutton>iframe[src^='http://www.facebook.com/plugins/like.php?href=http://luotbao.com/index.php/pages/article']"));
                    }
                    catch
                    {
                        //tim khong thay frame facebook, thi dong cua so window.
                        //nhay vao cua so cuoi cung.
                        driver.SwitchTo().Window(handles.Last());
                        jscript.ExecuteScript("window.close()");

                        //nhay vao trang danh sach.
                        handles = driver.WindowHandles.ToList<string>();
                        driver.SwitchTo().Window(handles.Last());

                        continue;
                    }

                    //neu frame ton tai thi nhay vao
                    if (frames.Count > 0)
                    {
                        //nhay vao frame
                        //string link_likeFacebook = frames[0].GetAttribute("src"); ;
                        driver.SwitchTo().Frame(frames[0]);
                        driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));

                        //neu nut like book o trang thai like button thi thoat
                        //try
                        //{
                        //tim phan tu nut like o 2 trang thai
                        IWebElement like_button_no_like = driver.FindElement(By.CssSelector("a[class^='connect_widget_like_button clearfix']"));
                        if (like_button_no_like.GetAttribute("class").Contains("like_button_no_like"))
                        {
                            //kiem tra neu chua thich thi click thich
                            like_button_no_like.Click();                           

                            
                            //chú ý: con chuot trên màn hình, khi mouseover phai đem ra ngoài khu vực cửa sổ mới mở.
                            
                            Thread.Sleep(1000);
                            IWebElement likebuttonlike = driver.FindElement(By.CssSelector("a[class='connect_widget_like_button clearfix like_button_like']"));
                            Actions builer = new Actions(driver);
                            builer.MoveToElement(likebuttonlike).Build().Perform();

                            //click chuot vao nut like_button_like de xuat hien commment

                            likebuttonlike.Click();
                            IWebElement element_comment = driver.FindElement(By.CssSelector("table.uiGrid td:first-of-type > input"));
                            
                            element_comment.Click();


                            //tim phan tu comment                                                                                                            

                            element_comment.Clear();
                            element_comment.SendKeys(comment);
                            Thread.Sleep(1000);
                            element_comment.Click();
                            //element_comment.SendKeys(Keys.Tab);
                            element_comment.SendKeys(Keys.Enter);

                            IWebElement element_dang = driver.FindElement(By.CssSelector("table.uiGrid td:last-of-type > label > input"));
                            element_dang.Click();

                            driver.SwitchTo().Window(handles.Last());
                            jscript.ExecuteScript("window.close()");
                        }
                        else
                        {
                            //throw new Exception();
                            driver.SwitchTo().Window(handles.Last());
                            jscript.ExecuteScript("window.close()");
                        }
                        
                    }
                    //tim danh sach cua so. nhay vao cua so cuoi.
                    handles = driver.WindowHandles.ToList<string>();
                    driver.SwitchTo().Window(handles.Last());

                }
            }
                    

                    }
                

                }

            }
           
            
                        
    
        }




