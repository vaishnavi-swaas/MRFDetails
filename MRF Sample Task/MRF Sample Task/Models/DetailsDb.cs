using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_Sample_Task.Models
{
    public class DetailsDb
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVCConnectionString"].ConnectionString;
        public List<MRFModel> ListAll()
        {
            List<MRFModel> objMRFmodels = new List<MRFModel>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Getdetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    objMRFmodels.Add(new MRFModel
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        PositionName = rdr["PositionName"].ToString(),
                        Created_By = rdr["CreatedBy"].ToString(),
                        MRF_Created_Date = Convert.ToDateTime(rdr["MRFCreatedDate"]),
                        Position_to_be_filled_before = Convert.ToDateTime(rdr["Positionfilledbefore"]),
                        VacancyField = rdr["PositionName"].ToString(),
                        VacancyVacant = rdr["User_Name"].ToString(),
                        TerritoryHQ = rdr["TerritoryHQ"].ToString(),
                        DivisionName = rdr["DivisionName"].ToString(),
                        Min_Yrs = Convert.ToInt32(rdr["MinExperiece"]),
                        Max_yrs = Convert.ToInt32(rdr["MaxExperiece"]),
                        MinCTC = Convert.ToInt32(rdr["MinCTC"]),
                        MaxCTC = Convert.ToInt32(rdr["MaxCTC"]),
                        Additional_Requirement = rdr["AdditionalReq"].ToString(),
                        Status = Convert.ToInt32(rdr["ReqStatus"]),
                        Sta_tus = Convert.ToString(rdr["Sta_tus"]) 
                    });

                }
                return objMRFmodels;

            }
        }
        //public int UpdateRequestStatus(int ID, int iRequestStatus)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("usp_UpdateRequestStatus", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@P_Id", ID);
        //        com.Parameters.AddWithValue("@P_RequestStatus", iRequestStatus);
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;

        //}
        public int Update(MRFModel emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Update", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.id);
                com.Parameters.AddWithValue("@PositionName", emp.PositionName);
                com.Parameters.AddWithValue("@MRFCreatedBy", emp.MRF_Created_By);
                com.Parameters.AddWithValue("@MRFCreatedDate", emp.MRF_Created_By);
                com.Parameters.AddWithValue("@Positiontobefilledbefore", emp.Position_to_be_filled_before);
                com.Parameters.AddWithValue("@VacancyFor", emp.Vacancy_For);
                com.Parameters.AddWithValue("@VacancyType", emp.Vacancy_Type);
                com.Parameters.AddWithValue("@TerritoryHQ ", emp.TerritoryHQ);
                com.Parameters.AddWithValue("@DivisionName", emp.DivisionName);
                com.Parameters.AddWithValue("@MinExperience", emp.Min_Yrs);
                com.Parameters.AddWithValue("@MaxExperience", emp.Max_yrs);
                com.Parameters.AddWithValue("@MaxCTC", emp.MaxCTC);
                com.Parameters.AddWithValue("@MinCTC", emp.MinCTC);
                com.Parameters.AddWithValue("@AdditionalReq", emp.Additional_Requirement);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
            public int Delete(int id)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Delete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                i = com.ExecuteNonQuery();
            }
            return i;
        }


    }
}
