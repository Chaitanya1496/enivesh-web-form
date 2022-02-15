using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Constants
{
    public class AppConstant
    {
        #region DataBase Operations
        public static string success = "Success";
        public static string failure = "Failure";
        public static string insertOperation = "Insert";
        public static string updateOperation = "Update";
        #endregion

        #region Gender
        public static string female = "Female";
        public static string male = "Male";
        #endregion

        #region MaritalStatus
        public static string married = "Married";
        public static string unmarried = "Unmarried";
        #endregion

        #region Smoker
        public static string smoker = "Yes";
        public static string nonSmoker = "No";
        #endregion
    }
    enum Gender
    {
        Female = 0,
        Male = 1
    }

    enum MaritalStatus
    {
        Unmarried = 0,
        Married = 1
    }

    enum Smoker
    {
        nonSmoker = 0,
        smoker = 1
    }
}