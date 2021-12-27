using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MRF_Sample_Task.Models;

namespace MRF_Sample_Task.Models
{
    public class MRF_Datalayer
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

        public int Add(MRFModel MRFAdd,string struserid)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("[insertT_MRF_Trs]", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", MRFAdd.id);
                    com.Parameters.AddWithValue("@PositionName", MRFAdd.PositionName);
                    com.Parameters.AddWithValue("@MRFCreatedBy", MRFAdd.Created_By);
                    com.Parameters.AddWithValue("@MRFCreatedDate", MRFAdd.MRF_Created_Date);
                    com.Parameters.AddWithValue("@Positiontobefilledbefore", MRFAdd.Position_to_be_filled_before);
                    com.Parameters.AddWithValue("@VacancyFor", MRFAdd.Vacancy_For);
                    com.Parameters.AddWithValue("@VacancyType", MRFAdd.Vacancy_Type);
                    com.Parameters.AddWithValue("@TerritoryHQ", MRFAdd.TerritoryHQ);
                    com.Parameters.AddWithValue("@DivisionName", MRFAdd.DivisionName);
                    com.Parameters.AddWithValue("@MinExperience", MRFAdd.Min_Yrs);
                    com.Parameters.AddWithValue("@MaxExperience", MRFAdd.Max_yrs);
                    com.Parameters.AddWithValue("@MaxCTC", MRFAdd.MaxCTC);
                    com.Parameters.AddWithValue("@MinCTC", MRFAdd.MinCTC);
                    com.Parameters.AddWithValue("@AdditionalReq", MRFAdd.Additional_Requirement);
                    com.Parameters.AddWithValue("@ReqStatus", MRFAdd.Status);
    
                    i = com.ExecuteNonQuery();
                }
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}