using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace March30HW.Models
{
    //public class Ads
    //{
    //    private string _connection;
    //    public Ads(string cs)
    //    {
    //        _connection = cs;
    //    }
    //    public List<Ad> GetAds()
    //    {
    //        SqlConnection connection = new SqlConnection(_connection);
    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = @"select * from Ad";
    //        connection.Open();
    //        List<Ad> result = new List<Ad>();
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        while (reader.Read())
    //        {
    //            result.Add(new Ad
    //            {
    //                CreatedDate = (DateTime)reader["DateCreated"],
    //                Text = (string)reader["Text"],
    //                Name = (string)reader.GetOrNull<string>("Name"),
    //                Id =(int)reader["Id"],
    //                Number = (string)reader["Number"]
    //            });

    //        }
    //        connection.Close();
    //        connection.Dispose();
    //        return result;

    //    }
    //   public int Add(string name, string number, string text)
    //    {
    //        SqlConnection connection = new SqlConnection(_connection);
    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = @"insert into Ad(DateCreated, Name, Number, Text)
    //                            values(GetDate(), @name, @number, @text)
    //                              select scope_identity() as Id";
    //        cmd.Parameters.AddWithValue("@name", name);
    //        cmd.Parameters.AddWithValue("@number", number);
    //        cmd.Parameters.AddWithValue("@text", text);
    //        connection.Open();
    //        int x = 0;
    //        SqlDataReader reader = cmd.ExecuteReader();
    //        while (reader.Read())
    //        {
    //            x = (int)(decimal)reader["id"];
    //        }
    //        connection.Close();
    //        connection.Dispose();
    //        return x;

    //    }
    //}
    //public class Ad 
    //{ 
    //    public DateTime CreatedDate { get; set; }
    //    public string Text { get; set; }
    //    public string Name { get; set; }
    //    public string Number { get; set; }
    //    public int Id { get; set; }
    //}
    //public static class Extensions
    //{
    //    public static T GetOrNull<T>(this SqlDataReader reader, string column)
    //    {
    //        object obj = reader[column];
    //        if (obj == DBNull.Value)
    //        {
    //            return default(T);
    //        }
    //        return (T)obj;
    //    }
    //}
}
