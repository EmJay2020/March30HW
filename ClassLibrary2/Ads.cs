using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ClassLibrary2
{
    public class Ads
    {
        private string _connection;
        public Ads(string cs)
        {
            _connection = cs;
        }
        public int Add(string name, string number, string text)
        {
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"insert into Ad(DateCreated, Name, Number, Text)
                                values(GetDate(), @name, @number, @text)
                                  select scope_identity() as Id";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@text", text);
            connection.Open();
            int x = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                x = (int)(decimal)reader["id"];
            }
            connection.Close();
            connection.Dispose();
            return x;

        }
        public void delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"delete from Ad where Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public List<Ad> Get3(int skip, int amount)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "GetAd";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@skip", skip);
                command.Parameters.AddWithValue("@amount", amount);
                connection.Open();
                List<Ad> posts = new List<Ad>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    posts.Add(new Ad
                    {
                        CreatedDate = (DateTime)reader["DateCreated"],
                        Text = (string)reader["Text"],
                        Name = (string)reader.GetOrNull<string>("Name"),
                        Id = (int)reader["Id"],
                        Number = (string)reader["Number"]
                    });
                }

                return posts;
            }
        }
        public int GetCount()
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select Count(*) from Ad";
                connection.Open();
                return (int)command.ExecuteScalar();
            }

        }
    }
}
