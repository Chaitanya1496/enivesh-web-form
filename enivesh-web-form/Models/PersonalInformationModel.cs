using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.Constants;
using Newtonsoft.Json.Linq;

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

        public static Dictionary<int, PersonalInformationModel> getModel(ref Dictionary<int, PersonalInformationModel> personalInformationModels, SqlDataReader rdr, int userID)
        {
            int count = 1;
            if (rdr != null && rdr.HasRows)
            {
                while (rdr.Read())
                {
                    PersonalInformationModel model = new PersonalInformationModel();
                    model.userID = userID;
                    model.individualCount = (int)rdr["IndividualCount"];
                    model.firstName = (string)rdr["FirstName"];
                    model.lastName = (string)rdr["LastName"];
                    model.dob = rdr["DoB"].ToString();
                    if ((int)rdr["Gender"] == (int)Gender.Female)
                        model.gender = AppConstant.female;
                    else
                        model.gender = AppConstant.male;

                    if ((int)rdr["Smoker"] == (int)Smoker.nonSmoker)
                        model.smoker = AppConstant.nonSmoker;
                    else
                        model.smoker = AppConstant.smoker;

                    if ((int)rdr["MaritalStatus"] == (int)MaritalStatus.Unmarried)
                    {
                        model.maritalStatus = AppConstant.unmarried;
                        model.dateOfMarriage = string.Empty;
                    }
                    else
                    {
                        model.maritalStatus = AppConstant.married;
                        model.dateOfMarriage = rdr["DateOfMarriage"].ToString();
                    }
                    model.retirementAge = (int)rdr["DesiredRetirementAge"];
                    model.lifeExpectancy = (int)rdr["LifeExpectancy"];
                    model.homeAddress = (string)rdr["HomeAddress"];
                    model.city = (string)rdr["City"];
                    model.state = (string)rdr["State"];
                    model.zip = rdr["Zip"].ToString();
                    model.phoneNumber = rdr["PhoneNumber"].ToString();
                    model.emailAddress = (string)rdr["EmailAddress"];
                    model.employer = (string)rdr["Employer"];
                    model.designation = (string)rdr["Designation"];
                    personalInformationModels.Add(count, model);
                    count += 1;
                }
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