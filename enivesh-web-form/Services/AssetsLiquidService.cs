using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Framework;
using System.Data;
using enivesh_web_form.Constants;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class AssetsLiquidService
    {
        public static DataSet GetAssetsLiquid(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            DataSet assetLiquidDataset = new DataSet();
            try
            {
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand(Procedures.getLiquidAssets, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;

                conn.Open();

                rdr = Application.GetData(cmd);
                assetLiquidDataset.Tables.Add(AppConstant.dsAssetsLiquid);
                assetLiquidDataset.Tables[AppConstant.dsAssetsLiquid].Load(rdr);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return assetLiquidDataset;
        }

        public static void InsUpdAssetsLiquid(string operationType, AssetsLiquidModel model)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUpdLiquidAssets, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = model.userID;
                cmd.Parameters.Add("@bankAccountSelf", SqlDbType.Money).Value = model.bankAccountsSelf;
                cmd.Parameters.Add("@bankAccountSpouse", SqlDbType.Money).Value = model.bankAccoutSpouse;
                cmd.Parameters.Add("@bankAccountRemarks", SqlDbType.VarChar).Value = model.bankAccountRemarks;
                cmd.Parameters.Add("@cashBankFdSelf", SqlDbType.Money).Value = model.bankFdSelf;
                cmd.Parameters.Add("@cashBankFdSpouse", SqlDbType.Money).Value = model.bankFdSpouse;
                cmd.Parameters.Add("@cashBankFdRemarks", SqlDbType.Money).Value = model.bankFdRemarks;
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