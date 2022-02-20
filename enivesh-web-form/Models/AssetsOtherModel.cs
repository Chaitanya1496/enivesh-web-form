using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enivesh_web_form.Constants;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;

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

        public static string getData(int userID)
        {
            AssetsOtherModel model = new AssetsOtherModel();
            DataSet ds = AssetsOthersService.getAssetsOtherData(userID);
            return JsonConvert.SerializeObject(model);
        }

        public static void getModel(ref AssetsOtherModel model, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsAssetsOthers] != null && ds.Tables[AppConstant.dsAssetsOthers].Rows.Count > 0)
            {
                foreach (DataRow data in ds.Tables[AppConstant.dsAssetsOthers].Rows)
                {
                    model.userID = userID;
                    model.loansGivenSelf = (double)data["LoansGivenSelf"];
                    model.loansGivenSpouse = (double)data["LoansGivenSpouse"];
                    model.loansGivenRemarks = data["LoansGivenRemarks"].ToString();
                    model.otherInvestmentsSelf = (double)data["OtherInvestmentsSelf"];
                    model.otherInvestmentsSpouse = (double)data["OtherInvestmentsSpouse"];
                    model.otherInvestmentsRemarks = data["OtherInvestmentsRemarks"].ToString();
                    model.notLiquidSelf = (double)data["NotLiquidSelf"];
                    model.notLiquidSpouse = (double)data["NotLiquidSpouse"];
                    model.notLiquidRemarks = data["NotLiquidRemarks"].ToString();
                    model.anyOtherAssetsSelf = (double)data["AnyOtherAssetsSelf"];
                    model.anyOtherAssetsSpouse = (double)data["AnyOtherAssetsSpouse"];
                    model.anyOtherAssetsRemarks = data["AnyOtherAssetsRemarks"].ToString();
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            AssetsOthersService.insUpdAssetsOthersService(AppConstant.insertOperation, data[0], userID);
        }
    }
}