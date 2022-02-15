using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using enivesh_web_form.Constants;
using enivesh_web_form.ErrorLog;

namespace enivesh_web_form.Framework
{
    public class Application
    {
        public SqlDataReader GetData(SqlCommand cmd)
        {
            SqlDataReader rdr = null;
            try
            {
                rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rdr;
        }
        public static string Save(ref SqlCommand cmd)
        {
            int suceessState = 0;
            try
            {
                suceessState = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (suceessState != 0)
            {
                return AppConstant.success;
            }
            else
            {
                return AppConstant.failure;
            }
        }
    }
}