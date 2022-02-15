using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class MediclaimModel
    {
        public int userID { get; set; }
        public int policyCount { get; set; }
        public int floater { get; set; }
        public string insuranceCompany { get; set; }
        public DateTime startDate { get; set; }
        public double annualPremium { get; set; }
        public double sumAssured { get; set; }
        public int membersCovered { get; set; }
    }
}