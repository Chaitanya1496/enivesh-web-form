using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace enivesh_web_form.Models
{
    public class AssetsFixedModel
    {
        public int userID { get; set; }
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

        public static string getData(int userID)
        {
            AssetsFixedModel model = new AssetsFixedModel();
            DataSet dsAssetsFixed = AssetsFixedService.getAssetsFixed(userID);
            getModel(ref model, dsAssetsFixed, userID);
            return JsonConvert.SerializeObject(model);
        }

        public static void getModel(ref AssetsFixedModel model, DataSet dsAssetsFixed, int userID)
        {
            if (dsAssetsFixed != null && dsAssetsFixed.Tables[AppConstant.dsAssetsFixed] != null)
            {
                foreach (DataRow data in dsAssetsFixed.Tables[AppConstant.dsAssetsFixed].Rows)
                {
                    model.userID = userID;
                    model.principalResidenceSelf = (double)data["PrincipalResidenceSelf"];
                    model.principalResidenceSpouse = (double)data["PrincipalResidenceSpouse"];
                    model.principalResidenceRemarks = data["PrincipalResidenceRemarks"].ToString();
                    model.otherPropertySelf = (double)data["OtherPropertySelf"];
                    model.otherPropertySpouse = (double)data["OtherPropertySpouse"];
                    model.otherPropertyRemarks = data["OtherPropertyRemarks"].ToString();
                    model.carSelf = (double)data["CarSelf"];
                    model.carSpouse = (double)data["CarSpouse"];
                    model.carRemarks = data["CarRemarks"].ToString();
                    model.furnishingContentsSelf = (double)data["FurnishingContentsSelf"];
                    model.furnishingContentsSpouse = (double)data["FurnishingContentsSpouse"];
                    model.furnishingContentsRemarks = data["FurnishingContentsRemarks"].ToString();
                    model.jewellarySelf = (double)data["JewellarySelf"];
                    model.jewellarySpouse = (double)data["JewellarySpouse"];
                    model.jewellaryRemarks = data["JewellaryRemarks"].ToString();
                    model.otherFixedAssetsSelf = (double)data["OtherFixedAssetsSelf"];
                    model.otherFixedAssetsSpouse = (double)data["OtherFixedAssetsSpouse"];
                    model.otherFixedAssetsRemarks = data["OtherFixedAssetsRemarks"].ToString();
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            AssetsFixedModel model = populateModel(data[0], userID);
            AssetsFixedService.InsUpdAssetsFixed(AppConstant.insertOperation, model);
        }

        public static AssetsFixedModel populateModel(JToken data, int userID)
        {
            AssetsFixedModel model = new AssetsFixedModel();
            if (data != null)
            {
                // Check the names with the react form fields
                model.userID = userID;
                model.principalResidenceSelf = (double)data["principalResidenceSelf"];
                model.principalResidenceSpouse = (double)data["principalResidenceSpouse"];
                model.principalResidenceRemarks = data["principalResidenceRemarks"].ToString();
                model.otherPropertySelf = (double)data["otherPropertiesSelf"];
                model.otherPropertySpouse = (double)data["otherPropertiesSpouse"];
                model.otherPropertyRemarks = data["otherPropertiesRemarks"].ToString();
                model.carSelf = (double)data["carSelf"];
                model.carSpouse = (double)data["carSpouse"];
                model.carRemarks = data["carRemarks"].ToString();
                model.furnishingContentsSelf = (double)data["furnishingsContentsSelf"];
                model.furnishingContentsSpouse = (double)data["furnishingsContentsSpouse"];
                model.furnishingContentsRemarks = data["furnishingsContentsRemarks"].ToString();
                model.jewellarySelf = (double)data["jewellerySelf"];
                model.jewellarySpouse = (double)data["jewellerySpouse"];
                model.jewellaryRemarks = data["jewelleryRemarks"].ToString();
                model.otherFixedAssetsSelf = (double)data["otherFixedAssetsSelf"];
                model.otherFixedAssetsSpouse = (double)data["otherFixedAssetsSpouse"];
                model.otherFixedAssetsRemarks = data["otherFixedAssetsRemarks"].ToString();
            }
            return model;
        }
    }
}