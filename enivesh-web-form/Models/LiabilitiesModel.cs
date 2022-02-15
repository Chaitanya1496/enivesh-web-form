using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class LiabilitiesModel
    {
        public int userID { get; set; }
        public double mortgageSelf { get; set; }
        public double mortgageSpouse { get; set; }
        public int mortgageInterestRate { get; set; }
        public double mortgageMonthlyPayment { get; set; }
        public double mortgageTerm { get; set; }
        public double carLoansSelf { get; set; }
        public double carLoansSpouse { get; set; }
        public int carLoansInterestRate { get; set; }
        public double carLoansMonthlyPayment { get; set; }
        public double carLoansTerm { get; set; }
        public double creditorsSelf { get; set; }
        public double creditorsSpouse { get; set; }
        public int creditorsInterestRate { get; set; }
        public double creditorsMonthlyPayment { get; set; }
        public double creditorsTerm { get; set; }
        public double investmentLoansSelf { get; set; }
        public double investmentLoansSpouse { get; set; }
        public int investmentLoansInterestRate { get; set; }
        public double investmentLoansMonthlyPayment { get; set; }
        public double investmentLoansTerm { get; set; }
        public double privateLoansSelf { get; set; }
        public double privateLoansSpouse { get; set; }
        public int privateLoansInterestRate { get; set; }
        public double privateLoansMonthlyPayment { get; set; }
        public double privateLoansLoansTerm { get; set; }
        public double otherSelf { get; set; }
        public double otherSpouse { get; set; }
        public int otherInterestRate { get; set; }
        public double otherMonthlyPayment { get; set; }
        public double otherTerm { get; set; }
    }
}