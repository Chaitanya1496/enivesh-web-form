using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.Constants;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using enivesh_web_form.Services;
using System.Data;
using enivesh_web_form.Models;

namespace enivesh_web_form.Models
{
    public class PersonalInformationModel
    {
        public int userID { get; set; }
        public int individualCount { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string smoker { get; set; }
        public string maritalStatus {get; set;}
        public string dateOfMarriage { get; set; }
        public int retirementAge { get; set; }
        public int lifeExpectancy { get; set; }
        public string homeAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string employer { get; set; }
        public string designation { get; set; }

        public static string getData(int userID)
        {
            Dictionary<int, PersonalInformationModel> personalInformationModels = new Dictionary<int, PersonalInformationModel>();
            DataSet personalInformationDataSet = PersonalInformationService.GetPersonalInformation(userID);
            getModel(ref personalInformationModels, personalInformationDataSet, userID);
            string jsonData = JsonConvert.SerializeObject(personalInformationModels);
            return jsonData;
        }

        public static void insertData(JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                PersonalInformationModel personalInfoModel = populateModel(item, count, userID);
                PersonalInformationService.InsUpdPersonalInformation(AppConstant.insertOperation, personalInfoModel);
                count += 1;
            }
        }

        public static Dictionary<int, PersonalInformationModel> getModel(ref Dictionary<int, PersonalInformationModel> personalInformationModels, DataSet personalInformationDataSet, int userID)
        {
            int count = 1;
            foreach (DataRow data in personalInformationDataSet.Tables[AppConstant.dsPersonalInformation].Rows)
            {
                PersonalInformationModel model = new PersonalInformationModel();
                model.userID = userID;
                model.individualCount = (int)data["IndividualCount"];
                model.firstName = (string)data["FirstName"];
                model.lastName = (string)data["LastName"];
                model.dob = data["DoB"].ToString();
                if ((int)data["Gender"] == (int)Gender.Female)
                    model.gender = AppConstant.female;
                else
                    model.gender = AppConstant.male;

                if ((int)data["Smoker"] == (int)Smoker.nonSmoker)
                    model.smoker = AppConstant.nonSmoker;
                else
                    model.smoker = AppConstant.smoker;

                if ((int)data["MaritalStatus"] == (int)MaritalStatus.Unmarried)
                {
                    model.maritalStatus = AppConstant.unmarried;
                    model.dateOfMarriage = string.Empty;
                }
                else
                {
                    model.maritalStatus = AppConstant.married;
                    model.dateOfMarriage = data["DateOfMarriage"].ToString();
                }
                model.retirementAge = (int)data["DesiredRetirementAge"];
                model.lifeExpectancy = (int)data["LifeExpectancy"];
                model.homeAddress = (string)data["HomeAddress"];
                model.city = (string)data["City"];
                model.state = (string)data["State"];
                model.zip = data["Zip"].ToString();
                model.phoneNumber = data["PhoneNumber"].ToString();
                model.emailAddress = (string)data["EmailAddress"];
                model.employer = (string)data["Employer"];
                model.designation = (string)data["Designation"];
                personalInformationModels.Add(count, model);
                count += 1;
            }
            return personalInformationModels;
        }
        public static PersonalInformationModel populateModel(JToken data, int count, int userID)
        {
            PersonalInformationModel model = new PersonalInformationModel();
            // Work on the data part
            model.userID = userID;
            model.individualCount = count;
            model.firstName = data["firstName"].ToString();
            model.lastName = data["lastName"].ToString();
            model.dob = data["dob"].ToString();
            model.gender = data["gender"].ToString();
            model.smoker = data["smoker"].ToString();
            model.maritalStatus = data["maritalStatus"].ToString();
            model.dateOfMarriage = data["dateOfMarriage"].ToString();
            model.retirementAge = (int)data["desiredRetirementAge"];
            model.lifeExpectancy = (int)data["lifeExpectancyAge"];
            model.homeAddress = data["homeAddress"].ToString();
            model.city = data["city"].ToString();
            model.state = data["state"].ToString();
            model.zip = data["zip"].ToString();
            model.phoneNumber = data["phoneNumber"].ToString();
            model.emailAddress = data["email"].ToString();
            model.employer = data["employer"].ToString();
            model.designation = data["designation"].ToString();
            return model;
        }
    }
}