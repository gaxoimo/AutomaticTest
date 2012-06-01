using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Xml;
using OpenQA.Selenium.Support.UI;

namespace AutomaticTest_14_5.HotMail
{
    public class HotMailAccountFactory
    {
        IWebDriver driver;
        IWebElement element;

        //tao ham dung
        public HotMailAccountFactory(IWebDriver _driver)
        {
            driver = _driver;
        }

        //tao phuong thuc DoWork có 1 tham số tuyền vào
        public void DoWork(HotMailAccountObject acc)
        { 
            //go to the website
            driver.Navigate().GoToUrl(HotMailAccountElement.URL);

            //wait loading webpage
            //finding iframe element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));            
            element = driver.FindElement(By.Id(HotMailAccountElement.IFRAME_ID));
            driver.SwitchTo().Frame(element);

            //finding signup element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_DANGKY_ID));
            element.Click();

            //wait loading webpage to find "windows live id" element
            //finding windowliveid element
            //enter in textbox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));           
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_WINDOWSLIVEID_ID));            
            element.SendKeys(acc.Windowliveid);

            //find pass element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_PASS_ID));
            element.SendKeys(acc.Password);

            //find confirm pass element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_REPASS_ID));
            element.SendKeys(acc.Repassword);

            //select phone number combobox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            SelectElement select = new SelectElement(driver.FindElement(By.Id(HotMailAccountElement.SELECT_PHONENUMBER_ID)));
            select.SelectByValue(acc.Phonenumber);

            //find altemail element
            //enter in textbox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_ALTEMAIL_ID));
            element.SendKeys(acc.Altemail);

            //find lastname element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_LASTNAME_ID));
            element.SendKeys(acc.Lastname);

            //find firstname element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_FIRSTNAME_ID));
            element.SendKeys(acc.Fistname);

            //select country combobox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            select = new SelectElement(driver.FindElement(By.Id(HotMailAccountElement.SELECT_COUNTRY_ID)));
            select.SelectByValue(acc.Country);

            //finding zipcode element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_ZIPCODE_ID));
            element.SendKeys(acc.Zipcode);

            //find gendermale element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            IWebElement element_male = driver.FindElement(By.Id(HotMailAccountElement.INPUT_GENDERMALE_ID));
            //find genderfemale element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            IWebElement element_female = driver.FindElement(By.Id(HotMailAccountElement.INPUT_GENDERFEMALE_ID));
            if (acc.Gender == "female")
                element_female.Click();
            else
                element_male.Click();

            //select birthday combobox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            select = new SelectElement(driver.FindElement(By.Id(HotMailAccountElement.SELECT_BIRTHDAY_ID)));
            select.SelectByValue(acc.Birthday);

            //select birthmonth combobox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            select = new SelectElement(driver.FindElement(By.Id(HotMailAccountElement.SELECT_BIRTHMONTH_ID)));
            select.SelectByValue(acc.Birthmonth);

            //select birthyear combobox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            select = new SelectElement(driver.FindElement(By.Id(HotMailAccountElement.SELECT_BIRTHYEAR_ID)));
            select.SelectByValue(acc.Birthyear);

            //enter in captcha
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.INPUT_CAPTCHA_ID));
            Console.WriteLine("Hay nhap vao cac ki tu ban nhin thay trong hinh");
            string captcha = Console.ReadLine();
            element.SendKeys(captcha);

            //checkbox option email
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.Id(HotMailAccountElement.CHECKBOX_OPTIONEMAIL_ID));
            if (!element.Selected && element != null && element.Displayed)
                element.Click();
            
            //click on accept button
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));  
            element = driver.FindElement(By.XPath(HotMailAccountElement.BUTTON_ACCEPT_XPATH));
            element.Click();            
         }
        //create accounts from xml
        public void CreateAccoutnsFromXML(string xmlPath)
        {
            //load file xml            
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            
            //lấy danh sách các phần tử node account
            XmlNodeList e_list = doc.GetElementsByTagName(HotMailAccountElement.XML_NODE_ACCOUNT);
            for (int i = 0; i < e_list.Count; i++)
            {
                //gán giá trị cho các thuộc tính
                HotMailAccountObject obj = new HotMailAccountObject();
                obj.Windowliveid = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_WINDOWSLIVE].Value;
                
                //xu ly sai password
                obj.Password = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_PASS].Value;          
                //xac nhan lai mat khau
                obj.Password = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_PASS].Value;
                obj.Phonenumber = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_PHONENUMBER].Value;
                obj.Altemail = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_ALTEMAIL].Value;
                obj.Lastname = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_LASTNAME].Value;
                obj.Fistname = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_FIRSNAME].Value;
                obj.Country = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_COUNTRY].Value;
                obj.Zipcode = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_ZIPCODE].Value;
                obj.Gender = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_GENDER].Value;
                obj.Birthday = e_list[i].Attributes[HotMailAccountElement.XML_ATRRIBUTE_BIRTHDAY].Value;
                obj.Birthmonth = e_list[i].Attributes[HotMailAccountElement.XMIL_ATTRIBUTE_BIRTHMONTH].Value;
                obj.Birthyear = e_list[i].Attributes[HotMailAccountElement.XML_ATTRIBUTE_BIRTHYEAR].Value;                                        
                //truyen gia tri tham so cho ham DoWork()
                DoWork(obj);
            }
        }

    }
}
