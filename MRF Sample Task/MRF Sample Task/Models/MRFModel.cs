using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRF_Sample_Task.Models
{
    public class MRFModel
    {
        public int id { get; set; }
        public string PositionName { get; set; }
        public int MRF_Created_By { get; set; }
        public string Created_By { get; set; }
        public DateTime MRF_Created_Date { get; set; }
        public DateTime Position_to_be_filled_before { get; set; }
        public int Vacancy_For { get; set; }
        public string VacancyField { get; set; }
        public int Vacancy_Type { get; set; }
        public string VacancyVacant{get;set;}
        public string TerritoryHQ {get;set;}
        public string DivisionName { get; set; }
        public int Min_Yrs { get; set; }
        public int Max_yrs { get; set; }
        public int MinCTC { get; set; }
        public int MaxCTC { get; set; }
        public string Additional_Requirement { get; set; }
        public int Status { get; set; }
        public string Sta_tus { get; set; }
    }
}