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
    public class RentalRealEstateModel
    {
        public int userID { get; set; }
        public int propertyNumber { get; set; }
        public string propertyName { get; set; }
        public string cityState { get; set; }
        public double purchasePrice { get; set; }
        public double currentMarketValue { get; set; }
        public double annualRent { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, RentalRealEstateModel> rentalRealEstateModels = new Dictionary<int, RentalRealEstateModel>();
            DataSet ds = RentalRealEstateService.getData(userID);
            getModel(ref rentalRealEstateModels, ds, userID);
            return JsonConvert.SerializeObject(rentalRealEstateModels);
        }

        public static void getModel(ref Dictionary<int, RentalRealEstateModel> rentalRealEstateModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsRentalRealEstate] != null && ds.Tables[AppConstant.dsRentalRealEstate].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsRentalRealEstate].Rows)
                {
                    RentalRealEstateModel model = new RentalRealEstateModel();
                    model.userID = userID;
                    model.propertyNumber = (int)data["PropertyNumber"];
                    model.propertyName = data["PropertyName"].ToString();
                    model.cityState = data["CityState"].ToString();
                    model.purchasePrice = (double)data["PurchasePrice"];
                    model.currentMarketValue = (double)data["CurrentMarketValue"];
                    model.annualRent = (double)data["AnnualRent"];
                    rentalRealEstateModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, RentalRealEstateModel> rentalRealEstateModels = new Dictionary<int, RentalRealEstateModel>();
            populateModel(ref rentalRealEstateModels, data, userID);
            RentalRealEstateService.insUpdRentalRealEstate(AppConstant.insertOperation, rentalRealEstateModels);
        }

        public static void populateModel(ref Dictionary<int, RentalRealEstateModel> rentalRealEstateModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                RentalRealEstateModel model = new RentalRealEstateModel();
                model.userID = userID;
                model.propertyNumber = count;
                model.propertyName = item["propertyName"].ToString();
                model.cityState = item["propertyCity"].ToString();
                model.purchasePrice = (double)item["propertyPurchasePrice"];
                model.currentMarketValue = (double)item["propertyMarketValue"];
                model.annualRent = (double)item["propertyAnnualRent"];
                rentalRealEstateModels.Add(count, model);
                count += 1;
            }
        }
    }
}