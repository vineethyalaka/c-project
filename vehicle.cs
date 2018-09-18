using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for vehicle
/// </summary>
public class vehicle
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public vehicle()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
    public string Insert()
    {
       
        using (SqlConnection sqlconn = new SqlConnection(connStr))
        {
            SqlCommand sqlcmd = new SqlCommand("Insertveh", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Year", Year);
                sqlcmd.Parameters.AddWithValue("@Make", Make);
                sqlcmd.Parameters.AddWithValue("@Model", Model);

                sqlconn.Open();
                int count = sqlcmd.ExecuteNonQuery();

                if (count > 0)
                    return "Data added";
                else
                    return "Data not added";
         
        }
    }

    public string Update(int id)
    {
        using (SqlConnection sqlconn = new SqlConnection(connStr))
        {
            SqlCommand sqlcmd = new SqlCommand("Updateveh", sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@Year", Year);
            sqlcmd.Parameters.AddWithValue("@Make", Make);
            sqlcmd.Parameters.AddWithValue("@Model", Model);

            sqlconn.Open();
            int count = sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

            if (count > 0)
                return "Data updated";
            else
                return "Data not updated";
        }
    }

    public List<vehicle> Select(int id)
    {
        using (SqlConnection sqlconn = new SqlConnection(connStr))
        {
            SqlCommand sqlcmd = new SqlCommand("Selectveh", sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);

            sqlconn.Open();
            SqlDataReader dr = sqlcmd.ExecuteReader();

            List<vehicle> listveh = new List<vehicle>();
            while (dr.Read())
            {
                vehicle veh = new vehicle
                {   Id = int.Parse(string.Format("{0}", dr["Id"])),
                    Year = int.Parse(string.Format("{0}", dr["Year"])),
                    Make = dr["Make"].ToString(),
                    Model = dr["Model"].ToString()
                };

                listveh.Add(veh);
            }

            return listveh;
        }
    }

    public string Delete(int id)
    {
        using (SqlConnection sqlconn = new SqlConnection(connStr))
        {
            SqlCommand sqlcmd = new SqlCommand("Deleteveh", sqlconn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", id);

            sqlconn.Open();
            int count = sqlcmd.ExecuteNonQuery();
            sqlconn.Close();

            if (count > 0)
                return "Data deleted";
            else
                return "Data not deleted";
        }
    }
}
