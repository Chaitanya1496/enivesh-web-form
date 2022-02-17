using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Framework;
using System.Data;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class AssetsLiquidService
    {
        public static void GetAssetsLiquid(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlDataReader rdr = null;
                AssetsLiquidModel model = new AssetsLiquidModel();
                SqlCommand cmd = new SqlCommand(Procedures.getLiquidAssets, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;

                conn.Open();

                rdr = Application.GetData(cmd);
                AssetsLiquidModel.getModel(ref model, rdr);
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