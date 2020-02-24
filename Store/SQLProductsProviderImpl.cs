using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AteraAssignment
{
    class SQLProductsProviderImpl : ProductsProvider
    {
        private static SqlConnection connection = null;
        private const string SERVER = "tky4ecqv9m.database.windows.net";
        private const string USER = "TestUser69326@tky4ecqv9m";
        private const string PASSWORD = "Password69326";
        private const string DBNAME = "AteraDevServerForInterviews";

        public List<Product> readProducts()
        {
            List<Product> res = new List<Product>();

            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            SqlConnection connection = getConnection();
            sql = "Select * from Products";
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Product newProduct = new Product(dataReader.GetValue(2).ToString(), Convert.ToSingle(dataReader.GetValue(1)), dataReader.GetValue(0).ToString());
                    res.Add(newProduct);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("SQL ERROR");
            }
            return res;
        }

        private SqlConnection getConnection()
        {
            if (connection == null)
            {
                string connectionString = string.Format("Data Source={0};" +
                    "Initial Catalog={1};" +
                    "User ID={2};" +
                    "Password={3}", SERVER, DBNAME, USER, PASSWORD);
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
    }
}
