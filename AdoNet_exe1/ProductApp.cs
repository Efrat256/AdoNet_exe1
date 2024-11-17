using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_exe1
{
    internal class ProductApp
    {
        public int InsertData(string connectionString)
        {
            bool flag = true;
            string isAct, category_Id,product_name, description, price, image;
            int rowsAffected = 0;

            while (flag)
            {
                Console.WriteLine("Insert category_Id");
                category_Id = Console.ReadLine();

                Console.WriteLine("Insert product_name");
                product_name = Console.ReadLine();

                Console.WriteLine("Insert description");
                description = Console.ReadLine();

                Console.WriteLine("Insert price");
                price = Console.ReadLine();

                Console.WriteLine("Insert image");
                image = Console.ReadLine();

                Console.WriteLine("Do you want to continue? (y/n)");
                isAct = Console.ReadLine();

                string query = "INSERT INTO Product(category_Id,product_name,description,price,image)" +
                   "VALUES(@category_Id,@product_name,@description,@price,@image)";
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@category_Id", SqlDbType.Int).Value = category_Id;
                    cmd.Parameters.Add("@product_name", SqlDbType.Char,20).Value = product_name;
                    cmd.Parameters.Add("@description", SqlDbType.Char,50).Value = description;
                    cmd.Parameters.Add("@price", SqlDbType.VarChar,10).Value = price;
                    cmd.Parameters.Add("@image", SqlDbType.VarChar,20).Value = image;
                    cn.Open();
                    rowsAffected += cmd.ExecuteNonQuery();
                    cn.Close();
                    flag = isAct == "y" ? true : false;

                }
            }
            return rowsAffected;
        }
        public void ReadData(string connectionString)
        {
            string queryString = "select * from Product";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
