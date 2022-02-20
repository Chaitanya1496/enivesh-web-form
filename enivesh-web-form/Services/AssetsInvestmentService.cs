using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Constants;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Models;
using enivesh_web_form.Framework;

namespace enivesh_web_form.Services
{
    public class AssetsInvestmentService
    {
        public static DataSet getAssetsInvestments(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            DataSet dsAssetsInvestment = new DataSet();
            SqlDataReader rdr;
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getAssetsInvestment, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                dsAssetsInvestment.Tables.Add(AppConstant.dsAssetsInvestment);
                dsAssetsInvestment.Tables[AppConstant.dsAssetsInvestment].Load(rdr);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dsAssetsInvestment;
        }

        public static void InsUpdAssetsInvestments(string operationType, AssetsInvestmentModel model)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUpdAssetsInvestment, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = model.userID;
                cmd.Parameters.Add("@mutualFundSelf", SqlDbType.Money).Value = model.mutualFundsSelf;
                cmd.Parameters.Add("@mutualFundSpouse", SqlDbType.Money).Value = model.mutualFundsSpouse;
                cmd.Parameters.Add("@mutualFundRemarks", SqlDbType.VarChar).Value = model.mutualFundsRemarks;
                cmd.Parameters.Add("@equitySharesSelf", SqlDbType.Money).Value = model.equitySharesSelf;
                cmd.Parameters.Add("@equitySharesSpouse", SqlDbType.Money).Value = model.equitySharesSpouse;
                cmd.Parameters.Add("@equitySharesRemarks", SqlDbType.VarChar).Value = model.equitySharesRemarks;
                cmd.Parameters.Add("@otherInvestmentSelf", SqlDbType.Money).Value = model.otherInvestmentSelf;
                cmd.Parameters.Add("@otherInvestmentSpouse", SqlDbType.Money).Value = model.otherInvestmentSpouse;
                cmd.Parameters.Add("@otherInvestmentRemarks", SqlDbType.VarChar).Value = model.otherInvestmentRemarks;
                cmd.Parameters.Add("@otherLiquidAssetsSelf", SqlDbType.Money).Value = model.otherLiquidAssetsSelf;
                cmd.Parameters.Add("@otherLiquidAssetsSpouse", SqlDbType.Money).Value = model.otherLiquidAssetsSpouse;
                cmd.Parameters.Add("@otherLiquidAssetsRemarks", SqlDbType.VarChar).Value = model.otherLiquidAssetsRemarks;
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