using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.Framework;
using Newtonsoft.Json.Linq;

namespace enivesh_web_form.Services
{
    public class AssetsOthersService
    {
        public static DataSet getAssetsOtherData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getOtherAssets, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsAssetsOthers);
                ds.Tables[AppConstant.dsAssetsOthers].Load(rdr);
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

        public static void insUpdAssetsOthersService(string operationType, JToken data, int userID)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                try
                {
                    SqlCommand cmd = new SqlCommand(Procedures.insUpdOtherAssets, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userID;
                    cmd.Parameters.Add("@loansGivenSelf", SqlDbType.Money).Value = (double)data["loansGivenSelf"];
                    cmd.Parameters.Add("@loansGivenSpouse", SqlDbType.Money).Value = (double)data["loansGivenSpouse"];
                    cmd.Parameters.Add("@loansGivenRemarks", SqlDbType.VarChar).Value = data["loansGivenRemarks"].ToString();
                    cmd.Parameters.Add("@otherInvestmentsSelf", SqlDbType.Money).Value = (double)data["otherInvestmentsSelf"];
                    cmd.Parameters.Add("@otherInvestmentsSpouse", SqlDbType.Money).Value = (double)data["otherInvestmentsSpouse"];
                    cmd.Parameters.Add("@otherInvestmentsRemarks", SqlDbType.VarChar).Value = data["otherInvestmentsRemarks"].ToString();
                    cmd.Parameters.Add("@notLiquidSelf", SqlDbType.Money).Value = (double)data["nonLiquidSelf"];
                    cmd.Parameters.Add("@notLiquidSpouse", SqlDbType.Money).Value = (double)data["nonLiquidSpouse"];
                    cmd.Parameters.Add("@notLiquidRemarks", SqlDbType.VarChar).Value = data["nonLiquidRemarks"].ToString();
                    cmd.Parameters.Add("@anyOtherAssetsSelf", SqlDbType.Money).Value = (double)data["anyOtherAssetsSelf"];
                    cmd.Parameters.Add("@anyOtherAssetsSpouse", SqlDbType.Money).Value = (double)data["anyOtherAssetsSpouse"];
                    cmd.Parameters.Add("@anyOtherAssetsRemarks", SqlDbType.VarChar).Value = data["anyOtherAssetsRemarks"].ToString();
                    cmd.Parameters.Add("@operationType", SqlDbType.VarChar).Value = operationType;
                    conn.Open();
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
}