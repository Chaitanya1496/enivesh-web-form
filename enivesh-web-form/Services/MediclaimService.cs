using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.Framework;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class MediclaimService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getMediClaim, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsMediclaim);
                ds.Tables[AppConstant.dsMediclaim].Load(rdr);
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

        public static void insUpdMediclaim(string operationType, Dictionary<int, MediclaimModel> data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                conn.Open();
                try
                {
                    for (int i = 1; i < data.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(Procedures.insUpdMediClaim, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = data[i].userID;
                        cmd.Parameters.Add("@policyCount", SqlDbType.Int).Value = data[i].policyCount;
                        cmd.Parameters.Add("@floater", SqlDbType.VarChar).Value = data[i].floater;
                        cmd.Parameters.Add("@insuranceCompany", SqlDbType.VarChar).Value = data[i].insuranceCompany;
                        cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = data[i].startDate;
                        cmd.Parameters.Add("@annualPremium", SqlDbType.Money).Value = data[i].annualPremium;
                        cmd.Parameters.Add("@sumAssured", SqlDbType.Money).Value = data[i].sumAssured;
                        cmd.Parameters.Add("@membersCovered", SqlDbType.Money).Value = data[i].membersCovered;
                        cmd.Parameters.Add("@operationType", SqlDbType.VarChar).Value = operationType;
                        Application.Save(ref cmd);
                    }
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
}