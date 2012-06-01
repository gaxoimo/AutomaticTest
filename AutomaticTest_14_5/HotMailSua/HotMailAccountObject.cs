using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTest_14_5.HotMailSua
{
    public class HotMailAccountObject
    {
        //bien viet chu thuong
        string windowliveid;
        string pass;
        string repass;
        string phonenumber;
        string altemail;
        string lastname;
        string firstname;
        string country;
        string zipcode;
        string gender;
        string birthday;
        string birthmonth;
        string birthyear;
        //tên thuộc tính viết hoa chữ đầu
        public string Windowliveid
        {
            //dùng phương thức get để lấy giá trị thuộc tính
            get { return windowliveid; }
            //dùng phương thức set để gán giá trị cho thuộc tính
            set { windowliveid = value;}
        }
        public string Password 
        {
            get { return pass;}
            set { pass = value;}
        }
        public string Repassword
        {
            get { return repass;}
            set { repass=value; }
        }
        public string Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }        
        }
        public string Altemail
        {
            get { return altemail; }
            set { altemail = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value;}
        }
        public string Fistname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Birthday 
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Birthmonth
        {
            get { return birthmonth; }
            set { birthmonth = value; }
        }
        public string Birthyear
        {
            get { return birthyear; }
            set { birthyear = value; }
        }
             


        
    }
}
