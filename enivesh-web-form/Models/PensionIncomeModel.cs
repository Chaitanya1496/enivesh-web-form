using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class PensionIncomeModel
    {
        public int userID { get; set; }
        public int pensionCount { get; set; }
        public string name { get; set; }
        public double companyBenefit { get; set; }
        public double monthlyBenefit { get; set; }
        public double costOfLiving { get; set; }
        public double lumpSum { get; set; }
    }
}