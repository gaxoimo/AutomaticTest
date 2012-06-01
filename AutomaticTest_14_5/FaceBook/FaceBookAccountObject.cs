using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTest_14_5.FaceBook
{
    //ten bien viet tat ca thuong
    //ten thuoc tinh viet hoa dau moi tu
    public class FaceBookAccountObject
    {
        string firstname;
        string lastname;
        string emaillogin;
        string emailconfirm;
        string pass;
        string gender;
        string birthday;
        string birthmonth;
        string birthyear;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string EmailLogin
        {
            get { return emaillogin; }
            set { emaillogin = value; }        
        }
        public string EmailConfirm
        {
            get { return emailconfirm; }
            set { emailconfirm = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string BirthDay
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string BirthMonth
        {
            get { return birthmonth; }
            set { birthmonth = value; }
        }
        public string BirthYear
        {
            get { return birthyear; }
            set { birthyear = value; }
        }
    }
}
