using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class AssetsFixedModel
    {
        public string userID { get; set; }
        public double principalResidenceSelf { get; set; }
        public double principalResidenceSpouse { get; set; }
        public string principalResidenceRemarks { get; set; }
        public double otherPropertySelf { get; set; }
        public double otherPropertySpouse { get; set; }
        public string otherPropertyRemarks { get; set; }
        public double carSelf { get; set; }
        public double carSpouse { get; set; }
        public string carRemarks { get; set; }
        public double furnishingContentsSelf { get; set; }
        public double furnishingContentsSpouse { get; set; }
        public string furnishingContentsRemarks { get; set; }
        public double jewellarySelf { get; set; }
        public double jewellarySpouse { get; set; }
        public string jewellaryRemarks { get; set; }
        public double otherFixedAssetsSelf { get; set; }
        public double otherFixedAssetsSpouse { get; set; }
        public string otherFixedAssetsRemarks { get; set; }
    }
}