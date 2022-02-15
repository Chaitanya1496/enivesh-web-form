using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class AssetsLiquidModel
    {
        public int userID { get; set; }
        public double bankAccountsSelf { get; set; }
        public double bankAccoutSpouse { get; set; }
        public string bankAccountRemarks { get; set; }
        public double bankFdSelf { get; set; }
        public double bankFdSpouse { get; set; }
        public string bankFdRemarks { get; set; }
    }
}