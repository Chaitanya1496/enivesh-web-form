using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class AssetsInvestmentModel
    {
        public int userID { get; set; }
        public double mutualFundsSelf { get; set; }
        public double mutualFundsSpouse { get; set; }
        public string mutualFundsRemarks { get; set; }
        public double equitySharesSelf { get; set; }
        public double equitySharesSpouse { get; set; }
        public double equitySharesRemarks { get; set; }
        public double otherInvestmentSelf { get; set; }
        public double otherInvestmentSpouse { get; set; }
        public string otherInvestmentRemarks { get; set; }
        public double otherLiquidAssetsSelf { get; set; }
        public double otherLiquidAssetsSpouse { get; set; }
        public string otherLiquidAssetsRemarks { get; set; }
    }
}