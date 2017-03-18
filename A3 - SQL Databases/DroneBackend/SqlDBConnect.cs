using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DroneBackend
{
    public class SqlDBConnect
    {
        private MySqlConnection connection;
        private string server;
        public string database;
        private string uid;
        private string password;

        //Constructor
        public SqlDBConnect(string server, string database, string userId, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = userId;
            this.password = password;

            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            var connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public int Insert(string insertQuery)
        {
            int result = 0;

            try {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    result = cmd.ExecuteNonQuery();
                    //Console.WriteLine(result.ToString());
                }

                CloseConnection();
            }
            catch (MySqlException e)
            {
                CloseConnection();
                return -1;
            }

            return result;
        }
        //Select statement
        public List<string>[] Select(string selectQuery, int listSize)
        {
            //Create a list to store the result
            List<string>[] queryList = new List<string>[listSize];
            for (int i = 0; i < queryList.Length; i++)
                queryList[i] = new List<string>();

            try
            {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        foreach (var list in queryList)
                        {
                            //Console.WriteLine(dataReader[dataReader.GetName(i)]);
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                list.Add(dataReader[dataReader.GetName(i)].ToString());
                            }
                        }
                    }

                    //close Data Reader
                    dataReader.Close();
                }

                CloseConnection();

                return queryList;
            }
            catch (MySqlException e)
            {
                CloseConnection();
                return null;
            }

            return queryList;
        }

        //Select statement
        public List<Dictionary<string, string>> Select(string selectQuery)
        {
            //Create a list to store the result
            List<Dictionary<string, string>> queryList = new List<Dictionary<string, string>>(5);
            for (int i = 0; i < queryList.Capacity; i++)
                queryList.Add(new Dictionary<string, string>());

            try
            {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        foreach (var dict in queryList)
                        {
                            //Console.WriteLine(dataReader[dataReader.GetName(i)]);
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                dict.Add(dataReader.GetName(i), dataReader[dataReader.GetName(i)].ToString());
                            }
                        }
                        break;
                    }

                    //close Data Reader
                    dataReader.Close();
                }

                CloseConnection();

                return queryList;
            }
            catch (MySqlException e)
            {
                CloseConnection();
                return null;
            }

            return queryList;
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Count statement
        public int Count()
        {
            return 1;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
