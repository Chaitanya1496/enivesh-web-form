using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class RentalRealEstateModel
    {
        public int userID { get; set; }
        public int policyNumber { get; set; }
        public string propertyName { get; set; }
        public string cityState { get; set; }
        public double purchasePrice { get; set; }
        public double currentMarketValue { get; set; }
        public double annualRent { get; set; }
    }
}