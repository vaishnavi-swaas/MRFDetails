using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_Sample_Task.Models
{
    public class LoginDb
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;

        public int Login(string Email, string Password)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("LoginPage", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@Email", Email);
                    com.Parameters.AddWithValue("@Password", Password);

                    i = (Int32)com.ExecuteScalar();
                }
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}