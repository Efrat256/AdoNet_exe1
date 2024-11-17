using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet_exe1
{
    internal class CategoryApplication
    {
        public int InsertData(string connectionString)
        {
            string categoryName;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Insert Category Name");
                categoryName = Console.ReadLine();
                Console.WriteLine("Do you want to continue?");
            }



        }
    }
}
