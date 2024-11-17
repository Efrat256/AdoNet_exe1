using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace AdoNet_exe1
{
    internal class CategoryApp
    {
        public int InsertData(string connectionString)
        {
            bool flag = true;
            string isAct,categoryName;
            int rowsAffected = 0;
            
            while (flag) { 
            Console.WriteLine("Insert Category Name");
            categoryName = Console.ReadLine();
            Console.WriteLine("Do you want to continue? (y/n)");
            isAct = Console.ReadLine();

            string query = "INSERT INTO Category(categoryName)" +
               "VALUES(@categoryName)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@categoryName", SqlDbType.VarChar, 20).Value = categoryName;
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
            string queryString = "select * from Category";
            using(SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
                }
            }
           
        }
    }
