using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;

namespace enivesh_web_form.Models
{
    public class LargeExpenditureModel
    {
        public int userID { get; set; }
        public int largeExpenditureCount { get; set; }
        public string expense { get; set; }
        public double cost { get; set; }
        public int year { get; set; }
        public int frequency { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, LargeExpenditureModel> largeExpendituresModels = new Dictionary<int, LargeExpenditureModel>();
            DataSet ds = LargeExpenditureService.getData(userID);
            getModel(ref largeExpendituresModels, ds, userID);
            return JsonConvert.SerializeObject(largeExpendituresModels);
        }

        public static void getModel(ref Dictionary<int, LargeExpenditureModel> largeExpendituresModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsLargeExpenditures] != null && ds.Tables[AppConstant.dsLargeExpenditures].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsLargeExpenditures].Rows)
                {
                    LargeExpenditureModel model = new LargeExpenditureModel();
                    model.userID = userID;
                    model.largeExpenditureCount = (int)data["LargeExpenditureCount"];
                    model.expense = data["Expense"].ToString();
                    model.cost = (double)data["Cost"];
                    model.year = (int)data["Year"];
                    model.frequency = (int)data["Frequency"];
                    largeExpendituresModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, LargeExpenditureModel> largeExpendituresModels = new Dictionary<int, LargeExpenditureModel>();
            populateModel(ref largeExpendituresModels, data, userID);
            LargeExpenditureService.insLargeExpenditures(AppConstant.insertOperation, largeExpendituresModels);
        }

        public static void populateModel(ref Dictionary<int, LargeExpenditureModel> largeExpendituresModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                LargeExpenditureModel model = new LargeExpenditureModel();
                model.userID = userID;
                model.largeExpenditureCount = count;
                model.expense = item["expenseName"].ToString();
                model.cost = (double)item["expenseCost"];
                model.year = (int)item["expenseYear"];
                model.frequency = (int)item["expenseFrequency"];
                largeExpendituresModels.Add(count, model);
                count += 1;
            }
        }
    }
}