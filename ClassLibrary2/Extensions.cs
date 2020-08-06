using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ClassLibrary2
{
    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string column)
        {
            object obj = reader[column];
            if (obj == DBNull.Value)
            {
                return default(T);
            }
            return (T)obj;
        }
    }
}
