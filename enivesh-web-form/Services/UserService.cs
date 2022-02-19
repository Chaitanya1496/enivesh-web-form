using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Framework;
using System.Data;

namespace enivesh_web_form.Services
{
    public class UserService
    {
        public static int InsUser()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            string result = string.Empty;
            int userID = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUser, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int);
                cmd.Parameters["@userId"].Direction = System.Data.ParameterDirection.Output;
                conn.Open();
                Application.Save(ref cmd);
                userID = (int)cmd.Parameters["@userId"].Value;
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return userID;
        }
    }
}