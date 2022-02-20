using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.Constants;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.Framework;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class AssetsFixedService
    {
        public static DataSet getAssetsFixed(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getAssetsFixed, conn);
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsAssetsFixed);
                ds.Tables[AppConstant.dsAssetsFixed].Load(rdr);
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

        public static void InsUpdAssetsFixed(string operationType, AssetsFixedModel model)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.insUpdAssetsFixed, conn);
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = model.userID;
                cmd.Parameters.Add("@principalResidenceSelf", SqlDbType.Money).Value = model.principalResidenceSelf;
                cmd.Parameters.Add("@principalResidenceSpouse", SqlDbType.Money).Value = model.principalResidenceSpouse;
                cmd.Parameters.Add("@principalResidenceRemarks", SqlDbType.VarChar).Value = model.principalResidenceRemarks;
                cmd.Parameters.Add("@otherPropertySelf", SqlDbType.Money).Value = model.otherPropertySelf;
                cmd.Parameters.Add("@otherPropertySpouse", SqlDbType.Money).Value = model.otherPropertySpouse;
                cmd.Parameters.Add("@otherPropertyRemarks", SqlDbType.VarChar).Value = model.otherPropertyRemarks;
                cmd.Parameters.Add("@carSelf", SqlDbType.Money).Value = model.carSelf;
                cmd.Parameters.Add("@carSpouse", SqlDbType.Money).Value = model.carSpouse;
                cmd.Parameters.Add("@carRemarks", SqlDbType.VarChar).Value = model.carRemarks;
                cmd.Parameters.Add("@furnishingContentsSelf", SqlDbType.Money).Value = model.furnishingContentsSelf;
                cmd.Parameters.Add("@furnishingContentsSpouse", SqlDbType.Money).Value = model.furnishingContentsSpouse;
                cmd.Parameters.Add("@furnishingContentsRemarks", SqlDbType.VarChar).Value = model.furnishingContentsRemarks;
                cmd.Parameters.Add("@jewellarySelf", SqlDbType.Money).Value = model.jewellarySelf;
                cmd.Parameters.Add("@jewellarySpouse", SqlDbType.Money).Value = model.jewellarySpouse;
                cmd.Parameters.Add("@jewellaryRemarks", SqlDbType.VarChar).Value = model.jewellaryRemarks;
                cmd.Parameters.Add("@otherFixedAssetsSelf", SqlDbType.Money).Value = model.otherFixedAssetsSelf;
                cmd.Parameters.Add("@otherFixedAssetsSpouse", SqlDbType.Money).Value = model.otherFixedAssetsSpouse;
                cmd.Parameters.Add("@otherFixedAssetsRemarks", SqlDbType.VarChar).Value = model.otherFixedAssetsRemarks;
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