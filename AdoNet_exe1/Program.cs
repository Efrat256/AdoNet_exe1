using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_exe1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source=srv2\\pupils;initial catalog=AdoNet_exe1;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            CategoryApp ca = new CategoryApp();
            Console.WriteLine(ca.InsertData(connectionString));
            ca.ReadData(connectionString);
            ProductApp pa = new ProductApp();
            Console.WriteLine(pa.InsertData(connectionString));
            pa.ReadData(connectionString);


        }
    }
}
