using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomaticTest_14_5.LuotBao
{
    public class LuotBaoThichFactory
    {
        IWebDriver driver;
        IWebElement element;
        IList<IWebElement> elements;
        public LuotBaoThichFactory(IWebDriver _driver)
        {
            driver = _driver;
        }
        public void DoWork()
        {
            driver.Url =LuotBaoThichElement.URL;
            //wait load
            //driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            

            //find "dunghiennua" element
            element = driver.FindElement(By.Id("fancybox-close"));
            element.Click();

            //find "congnghe" element
            
            element = driver.FindElement(By.CssSelector("ul>li:nth-of-type(5)>a"));
            element.Click();

            //find "Lenovo giới thiệu hàng loạt mẫu laptop ThinkPad mới" element


            //Lấy danh sách các bài báo trong muc cong nghe 
            //chua su dung scroll
            //---------------------------
            IList<IWebElement> article_elements = driver.FindElements(By.CssSelector("a[href^='http://luotbao.com/index.php/pages/article']"));
            if (article_elements != null && article_elements.Count > 0)
            {                
                //Chạy từng bài báo
                foreach (IWebElement article_e in article_elements)                
                {
                    string url = article_e.GetAttribute("href");

                    //dung javascript mo 1 cua so moi
                    IJavaScriptExecutor jscript = driver as IJavaScriptExecutor; 
                    jscript.ExecuteScript("window.open()");

                    //nhay vao cua so cuoi cung.
                    //=================================================================
                    List<string> handles = driver.WindowHandles.ToList<string>(); 
                    driver.SwitchTo().Window(handles.Last());
                    
                    //dan dia chi url vao.
                    driver.Navigate().GoToUrl(url); 
                                      
                    //Lấy link nút Like của facebook trên bài báo
                    //tim frame cong nge
                    IList<IWebElement> frame_congnge = driver.FindElements(By.CssSelector("div.fblikebutton>iframe[src^='http://www.facebook.com/plugins/like.php?href=http://luotbao.com/index.php/pages/article']"));

                    if (frame_congnge.Count > 0)
                    {
                        string link_likeFacebook = frame_congnge[0].GetAttribute("src"); ;
                        driver.SwitchTo().Frame(frame_congnge[0]);

                        IWebElement facebookLikeButton;
                        try
                        {

                            facebookLikeButton = wait.Until<IWebElement>((d) =>
                            {
                                return driver.FindElement(By.CssSelector("a[class^='connect_widget_like_button clearfix']"));
                            });
                            
                        }
                        catch 
                        {
                            driver.SwitchTo().Window(handles.Last());
                            jscript.ExecuteScript("window.close()");

                            handles = driver.WindowHandles.ToList<string>();
                            driver.SwitchTo().Window(handles.Last());

                            continue;
                        }
                        if(facebookLikeButton!=null && facebookLikeButton.Displayed)
                            facebookLikeButton.Click();
                    }
                    
                    //nhay vao cua so cuoi, dong cua so
                    driver.SwitchTo().Window(handles.Last());
                    jscript.ExecuteScript("window.close()");
                    
                    handles = driver.WindowHandles.ToList<string>();                    
                    driver.SwitchTo().Window(handles.Last());

                }

            }

            
           
            
                        
    
        }

    }
}
