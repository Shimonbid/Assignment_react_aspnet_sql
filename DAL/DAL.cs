using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class DAL
    {
        //Singleton
        private static DAL instance = null;
        private static readonly object padlock = new object();

        //Entities
        private DBInfoEntities db;

        public DAL()
        {
            db = new DBInfoEntities();
        }

        public static DAL Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DAL();
                    }
                    return instance;
                }
            }
        }

        //LINQ = StoredProcedure
        public object GetResultsFromDateByLINQ(DateTime datetime)
        {
            return db.Results.Where(x => x.UserQuery.DateQuery > datetime)
              .Select(s => new { s.UserQuery.Query, s.Title, s.Link });
        }

        //Stored Procedure Simple
        public List<GetResultsByDate_Result> GetResultsFromDateByStoredProcedure(DateTime datetime)
        {
            return db.GetResultsByDate(datetime).ToList();
        }

        //Stored Procedure Direct C#
        public List<Dictionary<string, object>> GetResultsFromDateByStoredProcedureDirect(DateTime datetime)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\ProjectsV13;Database=DBInfo;Trusted_Connection=True;MultipleActiveResultSets=True;");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("GetResultsByDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FromDate", datetime);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}