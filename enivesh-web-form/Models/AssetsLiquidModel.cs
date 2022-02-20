using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public static string getData(int userID)
        {
            AssetsLiquidModel assetsLiquidModel = new AssetsLiquidModel();
            DataSet assetsLiquidDataSet = AssetsLiquidService.GetAssetsLiquid(userID);
            getModel(ref assetsLiquidModel, assetsLiquidDataSet, userID);
            return JsonConvert.SerializeObject(assetsLiquidModel);
        }

        public static void insertData(JToken data, int userID)
        {
            AssetsLiquidModel model = AssetsLiquidModel.populateModel(data[0], userID);
            AssetsLiquidService.InsUpdAssetsLiquid(AppConstant.insertOperation, model);
        }

        public static void getModel(ref AssetsLiquidModel assetsLiquidModel, DataSet assetsLiquidDataSet, int userID)
        {
            if (assetsLiquidDataSet != null && assetsLiquidDataSet.Tables[AppConstant.dsAssetsLiquid] != null && assetsLiquidDataSet.Tables[AppConstant.dsAssetsLiquid].Rows.Count > 0)
            {
                foreach (DataRow data in assetsLiquidDataSet.Tables[AppConstant.dsAssetsLiquid].Rows)
                {
                    assetsLiquidModel.userID = userID;
                    assetsLiquidModel.bankAccountsSelf = (double)data["BankAccountSelf"];
                    assetsLiquidModel.bankAccoutSpouse = (double)data["BankAccountSpouse"];
                    assetsLiquidModel.bankAccountRemarks = (string)data["BankAccountRemarks"];
                    assetsLiquidModel.bankFdSelf = (double)data["BankFdSelf"];
                    assetsLiquidModel.bankFdSpouse = (double)data["BankFdSpouse"];
                    assetsLiquidModel.bankFdRemarks = (string)data["BankFdRemarks"];
                }
            }
        }

        public static AssetsLiquidModel populateModel(JToken data, int userID)
        {
            AssetsLiquidModel model = new AssetsLiquidModel();
            if (data != null)
            {
                // Check for mis-match with form-fields in react app
                model.userID = userID;
                model.bankAccountsSelf = (double)data["bankBalSelf"];
                model.bankAccoutSpouse = (double)data["bankBalSpouse"];
                model.bankAccountRemarks = data["bankBalRemarks"].ToString();
                model.bankFdSelf = (double)data["bankFdSelf"];
                model.bankFdSpouse = (double)data["bankFdSpouse"];
                model.bankFdRemarks = data["bankFdRemarks"].ToString();
            }
            return model;
        }
    }
}