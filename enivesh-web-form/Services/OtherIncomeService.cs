using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.Framework;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class OtherIncomeService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getOtherIncome, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsOtherIncome);
                ds.Tables[AppConstant.dsOtherIncome].Load(rdr);
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

        public static void insUpdOtherIncome(string operationType, Dictionary<int, OtherIncomeModel> data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                conn.Open();
                try
                {
                    for (int i = 1; i < data.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(Procedures.insUpdOtherIncome, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = data[i].userID;
                        cmd.Parameters.Add("@otherIncomeCount", SqlDbType.Int).Value = data[i].otherIncomeCount;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = data[i].name;
                        cmd.Parameters.Add("@incomeDescription", SqlDbType.VarChar).Value = data[i].incomeDescription;
                        cmd.Parameters.Add("@annualAmount", SqlDbType.Money).Value = data[i].annualAmount;
                        cmd.Parameters.Add("@annualIncDec", SqlDbType.Float).Value = (float)data[i].annualIncDec;
                        cmd.Parameters.Add("@beginningAge", SqlDbType.Int).Value = (int)data[i].beginningAge;
                        cmd.Parameters.Add("@endingAge", SqlDbType.Int).Value = (int)data[i].endingAge;
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