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
    public class LifeInsuranceModel
    {
        public int userID { get; set; }
        public int policyNumber { get; set; }
        public float term { get; set; }
        public string insuranceCompany { get; set; }
        public string insured { get; set; }
        public DateTime startDate { get; set; }
        public double annualPremium { get; set; }
        public double sumAssured { get; set; }
        public double deathBenefit { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, LifeInsuranceModel> lifeInsuranceModels = new Dictionary<int, LifeInsuranceModel>();
            DataSet ds = LifeInsuranceService.getData(userID);
            getModel(ref lifeInsuranceModels, ds, userID);
            return JsonConvert.SerializeObject(lifeInsuranceModels);
        }

        public static void getModel(ref Dictionary<int, LifeInsuranceModel> lifeInsuranceModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsLifeInsurance] != null && ds.Tables[AppConstant.dsLifeInsurance].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsLifeInsurance].Rows)
                {
                    LifeInsuranceModel model = new LifeInsuranceModel();
                    model.userID = userID;
                    model.policyNumber = (int)data["PolicyNumber"];
                    model.term = (float)data["Term"];
                    model.insuranceCompany = data["InsuranceCompany"].ToString();
                    model.insured = (int)data["Insured"] == (int)YesNo.yes ? AppConstant.yes : AppConstant.no;
                    model.startDate = DateTime.Parse(data["StartDate"].ToString());
                    model.annualPremium = (double)data["AnnualPremium"];
                    model.sumAssured = (double)data["SumAssured"];
                    model.deathBenefit = (double)data["DeathBenefit"];
                    lifeInsuranceModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, LifeInsuranceModel> lifeInsuranceModels = new Dictionary<int, LifeInsuranceModel>();
            populateModel(ref lifeInsuranceModels, data, userID);
            LifeInsuranceService.insUpdLifeInsurance(AppConstant.insertOperation, lifeInsuranceModels);
        }

        public static void populateModel(ref Dictionary<int, LifeInsuranceModel> lifeInsuranceModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                LifeInsuranceModel model = new LifeInsuranceModel();
                model.userID = userID;
                model.policyNumber = count;
                model.term = (float)item["termPlan"];
                model.insuranceCompany = item["insuranceCompany"].ToString();
                model.insured = item["insured"].ToString();
                model.startDate = DateTime.Parse(item["insuraceStartDate"].ToString());
                model.annualPremium = (double)item["insuranceAnnualPremium"];
                model.sumAssured = (double)item["insuranceSumAssured"];
                model.deathBenefit = (double)item["deathBenefit"];
                lifeInsuranceModels.Add(count, model);
                count += 1;
            }
        }
    }
}