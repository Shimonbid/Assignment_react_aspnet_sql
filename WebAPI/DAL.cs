using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DAL
    {
        //Stored Procedure Direct C#
        public List<Dictionary<string, object>> StoredProcedureFromDate(DateTime datetime)
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
