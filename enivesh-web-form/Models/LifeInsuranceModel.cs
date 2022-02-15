using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class LifeInsuranceModel
    {
        public int userID { get; set; }
        public int policyNumber { get; set; }
        public int term { get; set; }
        public string insuranceCompany { get; set; }
        public double insured { get; set; }
        public DateTime startDate { get; set; }
        public double annualPremium { get; set; }
        public double sumAssured { get; set; }
        public double deathBenefit { get; set; }
    }
}