using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using AutomaticTest_14_5.HotMail;
using AutomaticTest_14_5.FaceBook;
using AutomaticTest_14_5.LuotBao;
using AutomaticTest_14_5.nguyenchithanh;
using AutomaticTest_14_5.Pinterest;
using AutomaticTest_14_5.FaceBook.FaceBookAddFriend;

namespace AutomaticTest_14_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //new source update : 20120601

            IWebDriver driver = new FirefoxDriver();      
            //kiem tra facebook                      

            //ket hop dang nhap facebook, vao trang dia chi tin cua trang luot bao
            //FaceBookLuotBaoURL testLogin = new FaceBookLuotBaoURL(driver);
            //testLogin.TestLoginStates("thuc.pham.1@live.com", "25111999", "http://luotbao.com/index.php/pages/article/65912/tru_so_tong_cuc_hai_qnguoi_mac_ket");

            //dang  nhap facebook
            //FacebookLoginFactory facebookLoginFactory = new FacebookLoginFactory(driver);
            //facebookLoginFactory.DoWork();

            ////click vao nut "Like" trong danh sach cac tin kinh te (5 lan) cua trang luot bao.
            //AutomaticTest_14_5.FaceBookComment.LuotBaoThichFactory luotBaoThichFactory = new AutomaticTest_14_5.FaceBookComment.LuotBaoThichFactory(driver);
            //luotBaoThichFactory.DoWork();

            //NCTFactory login = new NCTFactory(driver);
            //login.NCTDoWork();

            //VNExpressTakeScreenShot scrshot = new VNExpressTakeScreenShot(driver);
            //scrshot.TakeScreenShotFactory();
            //PinterestFactory like = new PinterestFactory(driver);
            //like.PinterestFacebookFactory();

            //FacebookAddfriend addFriend = new FacebookAddfriend(driver);
            //addFriend.FacebookAddfriendFactory();

            //chay brokenlinks
            ThptNCTBrokenLinks thptNCTBrokenLinks = new ThptNCTBrokenLinks(driver);
            thptNCTBrokenLinks.ThptNCTBrokenLinksFactory();



        }
    }
}
