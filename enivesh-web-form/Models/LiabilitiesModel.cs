using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;

namespace enivesh_web_form.Models
{
    public class LiabilitiesModel
    {
        public int userID { get; set; }
        public double mortgageSelf { get; set; }
        public double mortgageSpouse { get; set; }
        public double mortgageInterestRate { get; set; }
        public double mortgageMonthlyPayment { get; set; }
        public double mortgageTerm { get; set; }
        public double carLoansSelf { get; set; }
        public double carLoansSpouse { get; set; }
        public double carLoansInterestRate { get; set; }
        public double carLoansMonthlyPayment { get; set; }
        public double carLoansTerm { get; set; }
        public double creditorsSelf { get; set; }
        public double creditorsSpouse { get; set; }
        public double creditorsInterestRate { get; set; }
        public double creditorsMonthlyPayment { get; set; }
        public double creditorsTerm { get; set; }
        public double investmentLoansSelf { get; set; }
        public double investmentLoansSpouse { get; set; }
        public double investmentLoansInterestRate { get; set; }
        public double investmentLoansMonthlyPayment { get; set; }
        public double investmentLoansTerm { get; set; }
        public double privateLoansSelf { get; set; }
        public double privateLoansSpouse { get; set; }
        public double privateLoansInterestRate { get; set; }
        public double privateLoansMonthlyPayment { get; set; }
        public double privateLoansLoansTerm { get; set; }
        public double otherSelf { get; set; }
        public double otherSpouse { get; set; }
        public double otherInterestRate { get; set; }
        public double otherMonthlyPayment { get; set; }
        public double otherTerm { get; set; }

        public static string getData(int userID)
        {
            LiabilitiesModel model = new LiabilitiesModel();
            DataSet ds = LiabilitiesService.getLiabilities(userID);
            getModel(ref model, ds, userID);
            return JsonConvert.SerializeObject(model);
        }

        public static void getModel(ref LiabilitiesModel model, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsLiabilities] != null && ds.Tables[AppConstant.dsLiabilities].Rows.Count > 0)
            {
                foreach (DataRow data in ds.Tables[AppConstant.dsLiabilities].Rows)
                {
                    model.userID = userID;
                    model.mortgageSelf = (double)data["MortgageSelf"];
                    model.mortgageSpouse = (double)data["MortgageSpouse"];
                    model.mortgageInterestRate = (double)data["MortgageInterestRate"];
                    model.mortgageMonthlyPayment = (double)data["MortgageMonthlyPayment"];
                    model.mortgageTerm = (double)data["MortgageTerm"];
                    model.carLoansSelf = (double)data["CarLoansSelf"];
                    model.carLoansSpouse = (double)data["CarLoansSpouse"];
                    model.carLoansInterestRate = (double)data["CarLoansInterestRate"];
                    model.carLoansMonthlyPayment = (double)data["CarLoansMonthlyPayment"];
                    model.carLoansTerm = (double)data["CarLoansTerm"];
                    model.creditorsSelf = (double)data["CreditorsSelf"];
                    model.creditorsSpouse = (double)data["CreditorsSpouse"];
                    model.creditorsInterestRate = (double)data["CreditorsInterestRate"];
                    model.creditorsMonthlyPayment = (double)data["CreditorsMonthlyPayment"];
                    model.creditorsTerm = (double)data["CreditorsTerm"];
                    model.investmentLoansSelf = (double)data["InvestmentLoansSelf"];
                    model.investmentLoansSpouse = (double)data["InvestmentLoansSpouse"];
                    model.investmentLoansInterestRate = (double)data["InvestmentLoansInterestRate"];
                    model.investmentLoansMonthlyPayment = (double)data["InvestmentLoansMonthlyPayment"];
                    model.investmentLoansTerm = (double)data["InvestmentLoansTerm"];
                    model.privateLoansSelf = (double)data["PrivateLoansSelf"];
                    model.privateLoansSpouse = (double)data["PrivateLoansSpouse"];
                    model.privateLoansInterestRate = (double)data["PrivateLoansInterestRate"];
                    model.privateLoansMonthlyPayment = (double)data["PrivateLoansMonthlyPayment"];
                    model.privateLoansLoansTerm = (double)data["PrivateLoansTerm"];
                    model.otherSelf = (double)data["OtherSelf"];
                    model.otherSpouse = (double)data["OtherSpouse"];
                    model.otherInterestRate = (double)data["OtherInterestRate"];
                    model.otherMonthlyPayment = (double)data["OtherMonthlyPayment"];
                    model.otherTerm = (double)data["OtherTerm"];
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            LiabilitiesService.insUpdLiabilities(AppConstant.insertOperation, data[0], userID);
        }
    }
}