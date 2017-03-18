using System;
using System.Collections.Generic;
using System.Text;

namespace DroneBackend
{
    public class ClientRegistrationManager
    {
        private SqlDBConnect conn;

        public ClientRegistrationManager(SqlDBConnect conn)
        {
            this.conn = conn;
        }

        public String runProcess(String clientName, String clientAddress)
        {
           
            // Check if this client already exists
            // SELECT count(*) FROM new_schema.client WHERE(clientName='Glendon') AND (clientAddress='Waterloo');
            StringBuilder query = new StringBuilder();
            query.Append("SELECT count(*) FROM " + conn.database + ".client WHERE(clientName='" + clientName);
            query.Append("') AND (clientAddress='" + clientAddress + "');");

            if (conn.Select(query.ToString(), 1)[0][0] == "1")
            {
                return "Error: Client Exists!";
            }

            //Produce new clientId for this client by checking the last added id
            //SELECT MAX(clientId) FROM new_schema.client;
            query = new StringBuilder();
            query.Append("SELECT MAX(clientId) FROM " + conn.database + ".client;");


            List<String>[] output = conn.Select(query.ToString(), 1);
            String id = conn.Select(query.ToString(), 1)[0][0];
            int clientID = 1;
            if (id != null)
            {
                clientID = Int32.Parse(id) + 1;
            }

            //Insert the new client information
            //INSERT INTO sys.client (clientId, clientName, clientAddress) VALUES(2, 'Glen', 'Waterloo');
            StringBuilder insert = new StringBuilder();
            insert.Append("INSERT INTO " + conn.database + ".client (clientId, clientName, clientAddress) VALUES(");
            insert.Append(clientID + ", '" + clientName + "', '" + clientAddress + "');");

            if (conn.Insert(insert.ToString()) == 1)
                return "Client Added!";
            else
                return "Error while inserting new client info!";
        }

    }
}
