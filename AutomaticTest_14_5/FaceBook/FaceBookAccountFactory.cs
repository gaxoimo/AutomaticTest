using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Xml;
using OpenQA.Selenium.Support.UI;

namespace AutomaticTest_14_5.FaceBook
{
    public class FaceBookAccountFactory
    {
        IWebDriver driver;
        IWebElement element;
        public FaceBookAccountFactory(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void DoWork(FaceBookAccountObject account)
        {            
            driver.Navigate().GoToUrl(FaceBookAccountElement.URL);
            
            //wait loading webpage; find firstname element; enter to element            
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0,1,0));
            element = driver.FindElement(By.Id(FaceBookAccountElement.INPUT_FIRSNAME_ID));
            element.SendKeys(account.FirstName);

            //find lastname element; enter to element
            element = driver.FindElement(By.Id(FaceBookAccountElement.INPUT_LASTNAME_ID));
            element.SendKeys(account.LastName);

            //find emaillogin element
            element = driver.FindElement(By.Id(FaceBookAccountElement.INPUT_EMAILLOGIN_ID));
            element.SendKeys(account.EmailLogin);

            //find emailconfirm element
            element = driver.FindElement(By.Id(FaceBookAccountElement.INPUT_EMAILCONFIRM_ID));
            element.SendKeys(account.EmailConfirm);

            //find pass element
            element = driver.FindElement(By.Id(FaceBookAccountElement.INPUT_PASS_ID));
            element.SendKeys(account.Pass);

            //select gender combobox
            SelectElement select = new SelectElement(driver.FindElement(By.Id(FaceBookAccountElement.SELECT_GENDER_ID)));
            if (account.Gender == "nữ")
                select.SelectByValue("1");
            else
                select.SelectByValue("2");

            //select birthday element
            select = new SelectElement(driver.FindElement(By.Id(FaceBookAccountElement.SELECT_BIRTHDAY_ID)));
            select.SelectByValue(account.BirthDay);

            //select birthmonth element
            select = new SelectElement(driver.FindElement(By.Id(FaceBookAccountElement.SELECT_BIRTHMONTH_ID)));
            select.SelectByValue(account.BirthMonth);

            //select birthyear element
            select = new SelectElement(driver.FindElement(By.Id(FaceBookAccountElement.SELECT_BIRTHYEAR_ID)));
            select.SelectByValue(account.BirthYear);
        
            //find button element
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 3, 0));
            //IList<IWebElement> elements = driver.FindElements(By.XPath("//label[@class='uiButton uiButtonSpecial']/input[@value]"));
            IList<IWebElement> elements = driver.FindElements(By.XPath("//label[@class='uiButton uiButtonSpecial']/input[@type='submit']"));
            elements[0].Click();

        }
        //ten tham so truyen vao bat dau la chu thuong, sau  la chu in hoa
        public void CreateAccountFromXml(string xmlPath)
        {
            //load xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            //get list node elements
            XmlNodeList e_list = doc.GetElementsByTagName(FaceBookAccountElement.XML_NODE_ACCOUNT);
            
            //gan gia tri cho cac thuoc tinh
            FaceBookAccountObject obj = new FaceBookAccountObject();
            for(int i=0; i < e_list.Count; i++)
            {
                obj.FirstName = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_FIRSTNAME].Value;
                obj.LastName = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_LASTNAME].Value;
                obj.EmailLogin = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_EMAILLOGIN].Value;
                obj.EmailConfirm = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_EMAILCONFIRM].Value;
                obj.Pass = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_PASS].Value;
                obj.Gender = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_GENDER].Value;
                obj.BirthDay = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_BIRTHDAY].Value;
                obj.BirthMonth = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_BIRTHMONTH].Value;
                obj.BirthYear = e_list[i].Attributes[FaceBookAccountElement.XML_ATTRIBUTE_BIRTHYEAR].Value;

                DoWork(obj);
            }        

        
        }
    }
}
