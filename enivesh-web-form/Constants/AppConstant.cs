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

        #region DatasetNames
        public static string dsPersonalInformation = "PersonalInformation";
        public static string dsAssetsLiquid = "AssetsLiquid";
        public static string dsAssetsInvestment = "AssetsInvestment";
        #endregion

        #region ReactForms
        public static string formPersonalInformation = "personalInfo";
        public static string formLiquidAssets = "liquidAssets";
        public static string formInvestmentAssets = "investments";
        public static string formFixedAssets = "fixedAssets";
        public static string formOtherAssets = "otherAssets";
        public static string formLiabilities = "liabilities";
        public static string formLifeInsurance = "lifeInsurance";
        public static string formMediclaim = "mediclaim";
        public static string formChildrenEducation = "childrenEducation";
        public static string formPensionIncome = "pensionIncome";
        public static string formOtherIncome = "otherIncome";
        public static string formRentalRealEstate = "rentalRealEstate";
        public static string formPersonalExpense = "personalExpenses";
        public static string formLargeExpenditure = "largeExpenditure";
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