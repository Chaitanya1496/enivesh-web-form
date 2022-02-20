using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.Framework;
using enivesh_web_form.Models;
using enivesh_web_form.ErrorLog;

namespace enivesh_web_form.Services
{
    public class ChildrenCollegeService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getChildrenCollege, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsChildrenCollege);
                ds.Tables[AppConstant.dsChildrenCollege].Load(rdr);
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

        public static void insUpdChildrenCollege(string operationType, Dictionary<int, ChildrenCollegeModel> data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                conn.Open();
                try
                {
                    for (int i = 1; i < data.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(Procedures.insUpdChildrenCollege, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = data[i].userID;
                        cmd.Parameters.Add("@childrenCount", SqlDbType.Int).Value = data[i].childrenCount;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = data[i].name;
                        cmd.Parameters.Add("@dob", SqlDbType.Date).Value = data[i].dob;
                        cmd.Parameters.Add("@yearOfCollege", SqlDbType.Int).Value = data[i].yearOfCollege;
                        cmd.Parameters.Add("@courseFees", SqlDbType.Money).Value = data[i].courseFees;
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