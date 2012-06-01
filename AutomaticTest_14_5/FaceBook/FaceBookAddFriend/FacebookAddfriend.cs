using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace AutomaticTest_14_5.FaceBook.FaceBookAddFriend
{
    public class FacebookAddfriend
    {
        IWebElement element;
        IWebDriver driver;
        IList<IWebElement> elements;

        #region *Hàm tạo
        public FacebookAddfriend(IWebDriver _driver)
        {
            driver = _driver;                     
        }
        #endregion Hàm tạo

        #region * Thêm bạn bè trong facebook
        public void FacebookAddfriendFactory()
        {
            #region * Login facebook
            driver.Navigate().GoToUrl("http://facebook.com");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));

            //tim nut login
            elements = driver.FindElements(By.CssSelector("label#loginbutton > input:first-of-type"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        element = driver.FindElement(By.Id("email"));
                        element.SendKeys("chuotconlilac@hotmail.com");

                        element = driver.FindElement(By.Id("pass"));
                        element.SendKeys("minhbinhxuan");

                        //click vao nut login
                        elements[i].Click();
                        break;
                    }
                    
                }
            } 
            #endregion Login facebook

            #region * Tìm kiếm bạn bè            
            //tim phan tu "tim kiem ban be"
            elements = driver.FindElements(By.CssSelector("a[href='http://www.facebook.com/?sk=ff']"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        //click vao nut login
                        elements[i].Click();
                        //tim duoc phan tu dung moi break
                        break;
                    }
                    
                }
            }

            //tim phan tu "cong cu khac"                        
            //elements = driver.FindElements(By.CssSelector("div > a[class='expand_link rfloat'][href='#']"));
            //elements = driver.FindElements(By.CssSelector("li[id='ut8j2c_6'] > div > div > a[class='expand_link rfloat'][href='#']"));
            //elements = driver.FindElements(By.CssSelector("li[id='ut8j2c_6']"));
            //elements = driver.FindElements(By.CssSelector("div.clearfix uiImageBlockContent"));
            //elements = driver.FindElements(By.CssSelector("div[class='ci_module_header fwb']")); // can tim
            elements = driver.FindElements(By.CssSelector("a + div[class='ci_module_header fwb']"));
            //elements = driver.FindElements(By.CssSelector("div.clearfix uiImageBlockContent > a + div[class='ci_module_header fwb']"));
            
            
            //elements = driver.FindElements(By.CssSelector("ul#ci_modules_visible > li#uwooit_6  a.expand_link rfloat[href='#']"));
            //elements = driver.FindElements(By.CssSelector("ul#ci_modules_visible > li#uwooit_6 div > a.expand_link rfloat"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        //click vao nut login
                        elements[5].Click();
                        break;
                    }
                   
                }
            }            
            //tim phan tu "tim ban tu dai hoc an giang"
            elements = driver.FindElements(By.CssSelector("li.findfriends_block_li > a[href='/find-friends/browser/?type=college&id=111836772176529&ref=ff']"));
            if (elements != null && elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Displayed && elements[i].Enabled)
                    {
                        //click vao nut login
                        elements[i].Click();
                        break;
                    }
                    
                }
            }
            
            //cuon man hinh theo chieu cao 5 lan
            //IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
            //for (int i = 0; i < 40; i++)
            //{
            //    jscript.ExecuteScript("window.scrollTo(0,screen.availHeight);");
            //    Thread.Sleep(1000);
            //}
            
            ////tim nut ket ban
            //elements = driver.FindElements(By.CssSelector("div.FriendButton>label>input[type='button']"));
            //if (elements != null && elements.Count > 0)
            //{
            //    for (int i = 0; i < elements.Count; i++)
            //    {
            //        if (elements[i].Displayed && elements[i].Enabled)
            //        {
            //            //click vao nut login
            //            elements[i].Click();                        
            //        }                   
            //    }
            //}
            IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;
            for (int j = 0; j < 10; j++)
            {
                jscript.ExecuteScript("window.scrollTo(0,screen.availHeight);");
                Thread.Sleep(1000);

                //tim danh sach
                elements = driver.FindElements(By.CssSelector("div.FriendButton>label>input[type='button']"));
                if (elements != null && elements.Count > 0)
                {
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i].Displayed && elements[i].Enabled)
                        {
                            //click vao nut login
                            elements[i].Click();
                        }
                    }
                }
            }
            #endregion Tìm kiếm bạn bè

        }
        #endregion Thêm bạn bè trong facebook
    }
}
