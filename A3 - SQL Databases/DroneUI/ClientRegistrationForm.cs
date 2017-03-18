using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DroneBackend;

namespace DroneUI
{
    public partial class ClientRegistrationForm : Form
    {
        private static ClientRegistrationForm FormInstance = null;
        private static SqlDBConnect connection;

        private enum ClientStatus { Success, Failed, Error };

        private ClientRegistrationForm()
        {
            InitializeComponent();
        }

        public static ClientRegistrationForm GetInstance(SqlDBConnect conn)
        {
            if (FormInstance == null)
            {
                FormInstance = new ClientRegistrationForm();
                connection = conn;
            }

            return FormInstance;
        }

        private void RegisterClientBtn_Click(object sender, EventArgs e)
        {
            string name = ClientNameTxtField.Text;
            string address = ClientAddressTxtField.Text;
            
            // TODO: Pass into another class that manages input and db.
            ClientRegistrationManager clientManager = new ClientRegistrationManager(connection);
            String result = clientManager.runProcess(name, address);
            
            UpdateClientStatus(result);
        }

        private void UpdateClientStatus(ClientStatus status)
        {
            ClientStatusLbl.Text = "Status: " + status.ToString();
        }

        private void UpdateClientStatus(string status)
        {
            ClientStatusLbl.Text = "Status: " + status.ToString();
        }
    }
}
