using System;
using DroneBackend;

namespace SYDE322A3
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "password";
            string server = "localhost";
            string database = "sys";
            string uid = "root";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            SqlDBConnect connection = new SqlDBConnect(server, database, uid, password);
            
            var selectQuery = "SELECT * FROM sys.client WHERE(clientName='Glen')";
            connection.Select(selectQuery, 1);
            
            Console.ReadKey();
        }
    }
}
