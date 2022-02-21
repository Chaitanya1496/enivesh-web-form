using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Framework;
using enivesh_web_form.Models;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Constants;

namespace enivesh_web_form.Services
{
    public class LargeExpenditureService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getLargeExpenditures, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsLargeExpenditures);
                ds.Tables[AppConstant.dsLargeExpenditures].Load(rdr);
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

        public static void insLargeExpenditures(string operationType, Dictionary<int, LargeExpenditureModel> data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                conn.Open();
                try
                {
                    for (int i = 1; i < data.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(Procedures.insUpdLargeExpenditures, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = data[i].userID;
                        cmd.Parameters.Add("@largeExpenditureCount", SqlDbType.Int).Value = data[i].largeExpenditureCount;
                        cmd.Parameters.Add("@expense", SqlDbType.VarChar).Value = data[i].expense;
                        cmd.Parameters.Add("@cost", SqlDbType.Money).Value = data[i].cost;
                        cmd.Parameters.Add("@year", SqlDbType.Int).Value = data[i].year;
                        cmd.Parameters.Add("@frequency", SqlDbType.Int).Value = data[i].frequency;
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