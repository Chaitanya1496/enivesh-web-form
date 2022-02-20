using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using enivesh_web_form.Constants;
using enivesh_web_form.Services;

namespace enivesh_web_form.Models
{
    public class OtherIncomeModel
    {
        public int userID { get; set; }
        public int otherIncomeCount { get; set; }
        public string name { get; set; }
        public string incomeDescription { get; set; }
        public double annualAmount { get; set; }
        public double annualIncDec { get; set; }
        public int beginningAge { get; set; }
        public int endingAge { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, OtherIncomeModel> otherIncomeModels = new Dictionary<int, OtherIncomeModel>();
            DataSet ds = OtherIncomeService.getData(userID);
            getModel(ref otherIncomeModels, ds, userID);
            return JsonConvert.SerializeObject(otherIncomeModels);
        }

        public static void getModel(ref Dictionary<int, OtherIncomeModel> otherIncomeModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsOtherIncome] != null && ds.Tables[AppConstant.dsOtherIncome].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsOtherIncome].Rows)
                {
                    OtherIncomeModel model = new OtherIncomeModel();
                    model.userID = userID;
                    model.otherIncomeCount = (int)data["OtherIncomeCount"];
                    model.name = data["Name"].ToString();
                    model.incomeDescription = data["IncomeDescription"].ToString();
                    model.annualAmount = (double)data["AnnualAmount"];
                    model.annualIncDec = (double)data["AnnualIncDec"];
                    model.beginningAge = (int)data["BeginningAge"];
                    model.endingAge = (int)data["EndingAge"];
                    otherIncomeModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, OtherIncomeModel> otherIncomeModels = new Dictionary<int, OtherIncomeModel>();
            populateModel(ref otherIncomeModels, data, userID);
            OtherIncomeService.insUpdOtherIncome(AppConstant.insertOperation, otherIncomeModels);
        }

        public static void populateModel(ref Dictionary<int, OtherIncomeModel> otherIncomeModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                OtherIncomeModel model = new OtherIncomeModel();
                model.userID = userID;
                model.otherIncomeCount = count;
                model.name = item["otherIncomeName"].ToString();
                model.incomeDescription = item["icomeDescription"].ToString();
                model.annualAmount = (double)item["annualAmount"];
                model.annualIncDec = (double)item["annualChange"];
                model.beginningAge = (int)item["beginningAge"];
                model.endingAge = (int)item["endingAge"];
                otherIncomeModels.Add(count, model);
                count += 1;
            }
        }
    }
}