using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.Framework;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.ErrorLog;
using enivesh_web_form.Constants;
using enivesh_web_form.Models;

namespace enivesh_web_form.Services
{
    public class RentalRealEstateService
    {
        public static DataSet getData(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getRentalRealEstate, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsRentalRealEstate);
                ds.Tables[AppConstant.dsRentalRealEstate].Load(rdr);
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

        public static void insUpdRentalRealEstate(string operationType, Dictionary<int, RentalRealEstateModel> data)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                conn.Open();
                try
                {
                    for (int i = 1; i < data.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(Procedures.insUpdRentalRealEstate, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = data[i].userID;
                        cmd.Parameters.Add("@propertyNumber", SqlDbType.Int).Value = data[i].propertyNumber;
                        cmd.Parameters.Add("@propertyName", SqlDbType.VarChar).Value = data[i].propertyName;
                        cmd.Parameters.Add("@cityState", SqlDbType.VarChar).Value = data[i].cityState;
                        cmd.Parameters.Add("@purchasePrice", SqlDbType.Money).Value = data[i].purchasePrice;
                        cmd.Parameters.Add("@currentMarketValue", SqlDbType.Money).Value = data[i].currentMarketValue;
                        cmd.Parameters.Add("@annualRent", SqlDbType.Money).Value = data[i].annualRent;
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