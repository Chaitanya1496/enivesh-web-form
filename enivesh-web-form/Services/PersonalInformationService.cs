using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enivesh_web_form.Models;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Framework;
using enivesh_web_form.Constants;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Constants;
using System.Collections.Generic;

namespace enivesh_web_form.Services
{
    public class PersonalInformationService
    {
        public static Dictionary<int, PersonalInformationModel> GetPersonalInformation(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr = null;
            Dictionary<int, PersonalInformationModel> personalInformationModels = new Dictionary<int, PersonalInformationModel>();
            string result = String.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getPersonalInformation, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                PersonalInformationModel.getModel(ref personalInformationModels, rdr, userID);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return personalInformationModels;
        }
        public static void InsUpdPersonalInformation(string operationType, PersonalInformationModel model)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            string result = String.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUpdPersonalInformation, conn);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = model.userID;
                cmd.Parameters.Add("@individualCount", SqlDbType.Int).Value = model.individualCount;
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = model.firstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = model.lastName;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = DateTime.Parse(model.dob).ToShortDateString();
                cmd.Parameters.Add("@gender", SqlDbType.Int).Value = AppConstant.female == model.gender ? Gender.Female : Gender.Male;
                cmd.Parameters.Add("@smoker", SqlDbType.Int).Value = AppConstant.nonSmoker == model.smoker ? Smoker.nonSmoker : Smoker.smoker;
                cmd.Parameters.Add("@maritalStatus", SqlDbType.Int).Value = AppConstant.unmarried == model.maritalStatus ? MaritalStatus.Unmarried : MaritalStatus.Married;
                cmd.Parameters.Add("@dateOfMarriage", SqlDbType.Date).Value = model.dateOfMarriage != null || model.dateOfMarriage != string.Empty ? DateTime.Parse(model.dateOfMarriage).ToShortDateString() : null;
                cmd.Parameters.Add("@retirementAge", SqlDbType.Int).Value = model.retirementAge;
                cmd.Parameters.Add("@lifeExpectancy", SqlDbType.Int).Value = model.lifeExpectancy;
                cmd.Parameters.Add("@homeAddress", SqlDbType.VarChar).Value = model.homeAddress;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = model.city;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = model.state;
                cmd.Parameters.Add("@zip", SqlDbType.VarChar).Value = model.zip;
                cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = model.phoneNumber;
                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = model.emailAddress;
                cmd.Parameters.Add("@employer", SqlDbType.VarChar).Value = model.employer;
                cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = model.designation;
                cmd.Parameters.Add("@operationType", SqlDbType.VarChar).Value = operationType;
                conn.Open();
                result = Application.Save(ref cmd);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}