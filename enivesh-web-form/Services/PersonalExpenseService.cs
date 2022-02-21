using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.Models;
using enivesh_web_form.Framework;
using enivesh_web_form.ErrorLog;

namespace enivesh_web_form.Services
{
    public class PersonalExpenseService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getPersonalExpense, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsPersonalExpense);
                ds.Tables[AppConstant.dsPersonalExpense].Load(rdr);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public static void insUpdPersonalExpense(string operationType, PersonalExpenseModel model)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUpdLifeInsurance, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = model.userID;
                cmd.Parameters.Add("@rent", SqlDbType.Money).Value = model.rent;
                cmd.Parameters.Add("@groceries", SqlDbType.Money).Value = model.groceries;
                cmd.Parameters.Add("@eating", SqlDbType.Money).Value = model.eating;
                cmd.Parameters.Add("@utilities", SqlDbType.Money).Value = model.utilities;
                cmd.Parameters.Add("@phone", SqlDbType.Money).Value = model.phone;
                cmd.Parameters.Add("@gas", SqlDbType.Money).Value = model.gas;
                cmd.Parameters.Add("@automobileExpense", SqlDbType.Money).Value = model.automobileExpense;
                cmd.Parameters.Add("@recreation", SqlDbType.Money).Value = model.recreation;
                cmd.Parameters.Add("@dayCare", SqlDbType.Money).Value = model.daycare;
                cmd.Parameters.Add("@gifts", SqlDbType.Money).Value = model.gifts;
                cmd.Parameters.Add("@domesticHelp", SqlDbType.Money).Value = model.domesticHelp;
                cmd.Parameters.Add("@clothing", SqlDbType.Money).Value = model.clothing;
                cmd.Parameters.Add("@homeMaintenance", SqlDbType.Money).Value = model.homeMaintenance;
                cmd.Parameters.Add("@homeFurnishing", SqlDbType.Money).Value = model.homeFurnishing;
                cmd.Parameters.Add("@childSupport", SqlDbType.Money).Value = model.childSupport;
                cmd.Parameters.Add("@alimony", SqlDbType.Money).Value = model.alimony;
                cmd.Parameters.Add("@entertainment", SqlDbType.Money).Value = model.entertainment;
                cmd.Parameters.Add("@vacation", SqlDbType.Money).Value = model.vacations;
                cmd.Parameters.Add("@hobbies", SqlDbType.Money).Value = model.hobbies;
                cmd.Parameters.Add("@gym", SqlDbType.Money).Value = model.gym;
                cmd.Parameters.Add("@subscription", SqlDbType.Money).Value = model.subscription;
                cmd.Parameters.Add("@petExpense", SqlDbType.Money).Value = model.petExpense;
                cmd.Parameters.Add("@booksMovies", SqlDbType.Money).Value = model.booksMovies;
                cmd.Parameters.Add("@cableTV", SqlDbType.Money).Value = model.cableTv;
                cmd.Parameters.Add("@internet", SqlDbType.Money).Value = model.internet;
                cmd.Parameters.Add("@haircut", SqlDbType.Money).Value = model.haircuts;
                cmd.Parameters.Add("@miscelleneous", SqlDbType.Money).Value = model.miscelleneous;
                cmd.Parameters.Add("@operationType", SqlDbType.VarChar).Value = operationType;
                Application.Save(ref cmd);
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