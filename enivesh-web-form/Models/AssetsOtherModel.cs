using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class AssetsOtherModel
    {
        public int userID { get; set; }
        public double loansGivenSelf { get; set; }
        public double loansGivenSpouse { get; set; }
        public string loansGivenRemarks { get; set; }
        public double otherInvestmentsSelf { get; set; }
        public double otherInvestmentsSpouse { get; set; }
        public string otherInvestmentsRemarks { get; set; }
        public double notLiquidSelf { get; set; }
        public double notLiquidSpouse { get; set; }
        public string notLiquidRemarks { get; set; }
        public double anyOtherAssetsSelf { get; set; }
        public double anyOtherAssetsSpouse { get; set; }
        public string anyOtherAssetsRemarks { get; set; }
    }
}