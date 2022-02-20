using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using enivesh_web_form.Constants;
using enivesh_web_form.Framework;
using enivesh_web_form.StoredProcedures;
using enivesh_web_form.ErrorLog;
using Newtonsoft.Json.Linq;

namespace enivesh_web_form.Services
{
    public class LiabilitiesService
    {
        public static DataSet getLiabilities(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            DataSet ds = new DataSet();
            SqlDataReader rdr;
            try
            {
                SqlCommand cmd = new SqlCommand(Procedures.getLiabilities, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                conn.Open();
                rdr = Application.GetData(cmd);
                ds.Tables.Add(AppConstant.dsLiabilities);
                ds.Tables[AppConstant.dsLiabilities].Load(rdr);
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

        public static void insUpdLiabilities(string operationType, JToken data, int userID)
        {
            if (data != null)
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                try
                {
                    SqlCommand cmd = new SqlCommand(Procedures.insUpdLiabilities, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    cmd.Parameters.Add("@mortgageHomeSelf", SqlDbType.Money).Value = data["mortgageSelf"];
                    cmd.Parameters.Add("@mortgageHomeSpouse", SqlDbType.Money).Value = data["mortgageSpouse"];
                    cmd.Parameters.Add("@mortgageHomeInterestRate", SqlDbType.Float).Value = data["mortgageInterestRate"];
                    cmd.Parameters.Add("@mortgageHomeMonthlyPayment", SqlDbType.Money).Value = data["mortgageMonthlyPayment"];
                    cmd.Parameters.Add("@mortgageHomeTerm", SqlDbType.Float).Value = data["mortgageTerm"];
                    cmd.Parameters.Add("@carSelf", SqlDbType.Money).Value = data["carSelf"];
                    cmd.Parameters.Add("@carSpouse", SqlDbType.Money).Value = data["carSpouse"];
                    cmd.Parameters.Add("@carInterestRate", SqlDbType.Float).Value = data["carInterestRate"];
                    cmd.Parameters.Add("@carMonthlyPayment", SqlDbType.Money).Value = data["carMonthlyPayment"];
                    cmd.Parameters.Add("@carTerm", SqlDbType.Float).Value = data["carTerm"];
                    cmd.Parameters.Add("@creditorsSelf", SqlDbType.Money).Value = data["creditorsSelf"];
                    cmd.Parameters.Add("@creditorsSpouse", SqlDbType.Money).Value = data["creditorsSpouse"];
                    cmd.Parameters.Add("@creditorsInterestRate", SqlDbType.Float).Value = data["creditorsInterestRate"];
                    cmd.Parameters.Add("@creditorsMonthlyPayment", SqlDbType.Money).Value = data["creditorsMonthlyPayment"];
                    cmd.Parameters.Add("@creditorsTerm", SqlDbType.Float).Value = data["creditorsTerm"];
                    cmd.Parameters.Add("@investmentSelf", SqlDbType.Money).Value = data["investmentSelf"];
                    cmd.Parameters.Add("@investmentSpouse", SqlDbType.Money).Value = data["investmentSpouse"];
                    cmd.Parameters.Add("@investmentInterestRate", SqlDbType.Float).Value = data["investmentInterestRate"];
                    cmd.Parameters.Add("@investmentMonthlyPayment", SqlDbType.Money).Value = data["investmentMonthlyPayment"];
                    cmd.Parameters.Add("@investmentTerm", SqlDbType.Float).Value = data["investmentTerm"];
                    cmd.Parameters.Add("@privateSelf", SqlDbType.Money).Value = data["privateSelf"];
                    cmd.Parameters.Add("@privateSpouse", SqlDbType.Money).Value = data["privateSpouse"];
                    cmd.Parameters.Add("@privateInterestRate", SqlDbType.Float).Value = data["privateInterestRate"];
                    cmd.Parameters.Add("@privateMonthlyPayment", SqlDbType.Money).Value = data["privateMonthlyPayment"];
                    cmd.Parameters.Add("@privateTerm", SqlDbType.Float).Value = data["privateTerm"];
                    cmd.Parameters.Add("@otherSelf", SqlDbType.Money).Value = data["otherSelf"];
                    cmd.Parameters.Add("@otherSpouse", SqlDbType.Money).Value = data["otherSpouse"];
                    cmd.Parameters.Add("@otherInterestRate", SqlDbType.Float).Value = data["otherInterestRate"];
                    cmd.Parameters.Add("@otherMonthlyPayment", SqlDbType.Money).Value = data["otherMonthlyPayment"];
                    cmd.Parameters.Add("@otherTerm", SqlDbType.Float).Value = data["otherTerm"];
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
}