using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using enivesh_web_form.Constants;
using enivesh_web_form.Services;

namespace enivesh_web_form.Models
{
    public class MediclaimModel
    {
        public int userID { get; set; }
        public int policyCount { get; set; }
        public string floater { get; set; }
        public string insuranceCompany { get; set; }
        public DateTime startDate { get; set; }
        public double annualPremium { get; set; }
        public double sumAssured { get; set; }
        public int membersCovered { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, MediclaimModel> mediclaimModels = new Dictionary<int, MediclaimModel>();
            DataSet ds = MediclaimService.getData(userID);
            getModel(ref mediclaimModels, ds, userID);
            return JsonConvert.SerializeObject(mediclaimModels);
        }

        public static void getModel(ref Dictionary<int, MediclaimModel> mediclaimModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsMediclaim] != null && ds.Tables[AppConstant.dsMediclaim].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsMediclaim].Rows)
                {
                    MediclaimModel model = new MediclaimModel();
                    model.userID = userID;
                    model.policyCount = (int)data["PolicyCount"];
                    model.floater = data["Floater"].ToString();
                    model.insuranceCompany = data["InsuranceCompany"].ToString();
                    model.startDate = DateTime.Parse(data["StartDate"].ToString());
                    model.annualPremium = (double)data["AnnualPremium"];
                    model.sumAssured = (double)data["SumAssured"];
                    model.membersCovered = (int)data["MembersCovered"];
                    mediclaimModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, MediclaimModel> mediClaimModels = new Dictionary<int, MediclaimModel>();
            populateModel(ref mediClaimModels, data, userID);
            MediclaimService.insUpdMediclaim(AppConstant.insertOperation, mediClaimModels);
        }

        public static void populateModel(ref Dictionary<int, MediclaimModel> mediClaimModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                MediclaimModel model = new MediclaimModel();
                model.userID = userID;
                model.policyCount = count;
                model.floater = item["criticalIllness"].ToString();
                model.insuranceCompany = item["mediclaimInsuranceCompany"].ToString();
                model.startDate = DateTime.Parse(item["mediclaimStartDate"].ToString());
                model.annualPremium = (double)item["annualPermium"];
                model.sumAssured = (double)item["mediclaimSumAssured"];
                model.membersCovered = (int)item["mediclaimMembersCovered"];
                mediClaimModels.Add(count, model);
                count += 1;
            }
        }
    }
}