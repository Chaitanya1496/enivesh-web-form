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
    public class ChildrenCollegeModel
    {
        public int userID { get; set; }
        public int childrenCount { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public int yearOfCollege { get; set; }
        public double courseFees { get; set; }
        public static string getData(int userID)
        {
            Dictionary<int, ChildrenCollegeModel> childrenCollegeModels = new Dictionary<int, ChildrenCollegeModel>();
            DataSet ds = ChildrenCollegeService.getData(userID);
            getModel(ref childrenCollegeModels, ds, userID);
            return JsonConvert.SerializeObject(childrenCollegeModels);
        }

        public static void getModel(ref Dictionary<int, ChildrenCollegeModel> childrenCollegeModels, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsChildrenCollege] != null && ds.Tables[AppConstant.dsChildrenCollege].Rows.Count > 0)
            {
                int count = 1;
                foreach (DataRow data in ds.Tables[AppConstant.dsChildrenCollege].Rows)
                {
                    ChildrenCollegeModel model = new ChildrenCollegeModel();
                    model.userID = userID;
                    model.childrenCount = (int)data["ChildrenCount"];
                    model.name = data["Name"].ToString();
                    model.dob = DateTime.Parse(data["DoB"].ToString());
                    model.yearOfCollege = (int)data["YearOfCollege"];
                    model.courseFees = (double)data["CourseFees"];
                    childrenCollegeModels.Add(count, model);
                    count += 1;
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            Dictionary<int, ChildrenCollegeModel> childrenCollegeModels = new Dictionary<int, ChildrenCollegeModel>();
            populateModel(ref childrenCollegeModels, data, userID);
            ChildrenCollegeService.insUpdChildrenCollege(AppConstant.insertOperation, childrenCollegeModels);
        }

        public static void populateModel(ref Dictionary<int, ChildrenCollegeModel> childrenCollegeModels, JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                ChildrenCollegeModel model = new ChildrenCollegeModel();
                model.userID = userID;
                model.childrenCount = count;
                model.name = item["childName"].ToString();
                model.dob = DateTime.Parse(item["childBirthDate"].ToString());
                model.yearOfCollege = (int)item["yearCollege"];
                model.courseFees = (double)item["childCourseFee"];
                childrenCollegeModels.Add(count, model);
                count += 1;
            }
        }
    }
}