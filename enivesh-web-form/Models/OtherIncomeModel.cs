using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class OtherIncomeModel
    {
        public int userID { get; set; }
        public int otherIncomeCount { get; set; }
        public string name { get; set; }
        public string incomeDescription { get; set; }
        public double annualAmount { get; set; }
        public double annualIncDec { get; set; }
        public int beginningAge { get; set; }
        public int endingAge { get; set; }
    }
}