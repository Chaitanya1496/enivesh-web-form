using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enivesh_web_form.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using enivesh_web_form.Constants;

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
        public string equitySharesRemarks { get; set; }
        public double otherInvestmentSelf { get; set; }
        public double otherInvestmentSpouse { get; set; }
        public string otherInvestmentRemarks { get; set; }
        public double otherLiquidAssetsSelf { get; set; }
        public double otherLiquidAssetsSpouse { get; set; }
        public string otherLiquidAssetsRemarks { get; set; }

        public static string getData(int userID)
        {
            AssetsInvestmentModel model = new AssetsInvestmentModel();
            DataSet dsAssetsInvestment = AssetsInvestmentService.getAssetsInvestments(userID);
            getModel(ref model, dsAssetsInvestment, userID);
            return JsonConvert.SerializeObject(model);
        }

        public static void getModel(ref AssetsInvestmentModel model, DataSet dsAssetsInvestment, int userID)
        {
            if (dsAssetsInvestment != null && dsAssetsInvestment.Tables[AppConstant.dsAssetsInvestment] != null && dsAssetsInvestment.Tables[AppConstant.dsAssetsInvestment].Rows.Count > 0)
            {
                foreach (DataRow data in dsAssetsInvestment.Tables[AppConstant.dsAssetsInvestment].Rows)
                {
                    model.userID = userID;
                    model.mutualFundsSelf = (double)data["MutualFundsSelf"];
                    model.mutualFundsSpouse = (double)data["MutualFundsSpouse"];
                    model.mutualFundsRemarks = data["MutualFundsRemarks"].ToString();
                    model.equitySharesSelf = (double)data["EquitySharesSelf"];
                    model.equitySharesSpouse = (double)data["EquitySharesSpouse"];
                    model.equitySharesRemarks = data["EquitySharesRemarks"].ToString();
                    model.otherInvestmentSelf = (double)data["OtherInvestmentSelf"];
                    model.otherInvestmentSpouse = (double)data["OtherInvestmentSpouse"];
                    model.otherInvestmentRemarks = data["OtherInvestmentRemarks"].ToString();
                    model.otherLiquidAssetsSelf = (double)data["OtherLiquidAssetsSelf"];
                    model.otherLiquidAssetsSpouse = (double)data["OtherLiquidAssetsSpouse"];
                    model.otherLiquidAssetsRemarks = data["OtherLiquidAssetsRemarks"].ToString();
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            AssetsInvestmentModel model = populateModel(data[0], userID);
            AssetsInvestmentService.InsUpdAssetsInvestments(AppConstant.insertOperation, model);
        }

        public static AssetsInvestmentModel populateModel(JToken data, int userID)
        {
            AssetsInvestmentModel model = new AssetsInvestmentModel();
            if (data != null)
            {
                model.userID = userID;
                model.mutualFundsSelf = (double)data["mutualFundsSelf"];
                model.mutualFundsSpouse = (double)data["mutualFundsSpouse"];
                model.mutualFundsRemarks = data["mutualFundsRemarks"].ToString();
                model.equitySharesSelf = (double)data["equitySharesSelf"];
                model.equitySharesSpouse = (double)data["equitySharesSpouse"];
                model.equitySharesRemarks = data["equitySharesRemarks"].ToString();
                model.otherInvestmentSelf = (double)data["otherInvestmentsSelf"];
                model.otherInvestmentSpouse = (double)data["otherInvestmentsSpouse"];
                model.otherInvestmentRemarks = data["otherInvestmentsRemarks"].ToString();
                model.otherLiquidAssetsSelf = (double)data["otherLiquidAssetsSelf"];
                model.otherLiquidAssetsSpouse = (double)data["otherLiquidAssets"];
                model.otherLiquidAssetsRemarks = data["otherLiquidAssetsRemarks"].ToString();
            }
            return model;
        }
    }
}