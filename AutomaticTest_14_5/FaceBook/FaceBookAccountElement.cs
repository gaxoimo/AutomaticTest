using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticTest_14_5.FaceBook
{
    public static class FaceBookAccountElement
    {
        //const html elements
        public const string URL = "http://www.facebook.com/";
        public const string INPUT_FIRSNAME_ID = "firstname";
        public const string INPUT_LASTNAME_ID = "lastname";
        public const string INPUT_EMAILLOGIN_ID = "reg_email__";
        public const string INPUT_EMAILCONFIRM_ID = "reg_email_confirmation__";
        public const string INPUT_PASS_ID = "reg_passwd__";
        public const string SELECT_GENDER_ID = "sex";
        public const string SELECT_BIRTHDAY_ID = "birthday_day";
        public const string SELECT_BIRTHMONTH_ID = "birthday_month";
        public const string SELECT_BIRTHYEAR_ID = "birthday_year";
        public const string BUTTON_DANGKY_ID = "u7bezl_1";

        //const XML
        public const string XML_NODE_ACCOUNT = "account";
        public const string XML_ATTRIBUTE_FIRSTNAME = "firstname";
        public const string XML_ATTRIBUTE_LASTNAME = "lastname";
        public const string XML_ATTRIBUTE_EMAILLOGIN = "emaillogin";
        public const string XML_ATTRIBUTE_EMAILCONFIRM = "emailconfirm";
        public const string XML_ATTRIBUTE_PASS = "pass";
        public const string XML_ATTRIBUTE_GENDER = "gender";
        public const string XML_ATTRIBUTE_BIRTHDAY = "birthday";
        public const string XML_ATTRIBUTE_BIRTHMONTH = "birthmonth";
        public const string XML_ATTRIBUTE_BIRTHYEAR = "birthyear";

    }
}
