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
    public class PensionIncomeModel
    {
        public int userID { get; set; }
        public int pensionCount { get; set; }
        public string name { get; set; }
        public double companyBenefit { get; set; }
        public double monthlyBenefit { get; set; }
        public double costOfLiving { get; set; }
        public double lumpSum { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, PensionIncomeModel> pensionIncomeModels = new Dictionary<int, PensionIncomeModel>();
            DataSet ds = PensionIncomeService.getData(userID);
            getModel(ref pensionIncomeModels, ds, userID);
            return JsonConvert.SerializeObject(pensionIncomeModels);
        }

        public static void getModel(ref Dictionary<int, PensionIncomeModel> pensionIncomeModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsPensionIncome] != null && ds.Tables[AppConstant.dsPensionIncome].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsPensionIncome].Rows)
                {
                    PensionIncomeModel model = new PensionIncomeModel();
                    model.userID = userID;
                    model.pensionCount = (int)data["PensionCount"];
                    model.name = data["Name"].ToString();
                    model.companyBenefit = (double)data["CompanyBenefit"];
                    model.monthlyBenefit = (double)data["MonthlyBenefit"];
                    model.costOfLiving = (double)data["CostOfLiving"];
                    model.lumpSum = (double)data["LumpSum"];
                    pensionIncomeModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, PensionIncomeModel> pensionIncomeModels = new Dictionary<int, PensionIncomeModel>();
            populateModel(ref pensionIncomeModels, data, userID);
            PensionIncomeService.insUpdPensionIncome(AppConstant.insertOperation, pensionIncomeModels);
        }

        public static void populateModel(ref Dictionary<int, PensionIncomeModel> pensionIncomeModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                PensionIncomeModel model = new PensionIncomeModel();
                model.userID = userID;
                model.pensionCount = count;
                model.name = item["pensionName"].ToString();
                model.companyBenefit = (double)item["pensionCompany"];
                model.monthlyBenefit = (double)item["pensionMonthlyBenefit"];
                model.costOfLiving = (double)item["pensionCostOfLivingAdj"];
                model.lumpSum = (double)item["pensionLumpSum"];
                pensionIncomeModels.Add(count, model);
                count += 1;
            }
        }
    }
}