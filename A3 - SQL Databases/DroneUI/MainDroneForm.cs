using System;
using System.Windows.Forms;
using DroneBackend;

namespace DroneUI
{
    public partial class MainDroneForm : Form
    {
        private SqlDBConnect connection;

        public MainDroneForm()
        {
            InitializeComponent();
            string password = StringConstants.PASSWORD;
            string server = StringConstants.SERVER;
            string database = StringConstants.DATABASE;
            string uid = StringConstants.USER_ID;
            string connectionString = StringConstants.CONNECTION_STRING;

            connection = new SqlDBConnect(server, database, uid, password);
        }

        private void ClientRegistrationExercise1_Click(object sender, EventArgs e)
        {
            ClientRegistrationForm.GetInstance(connection).Show();
        }

        private void BookingQueryExercise2_Click(object sender, EventArgs e)
        {
            BookingQueryForm.GetInstance(connection).Show();
        }

        private void BookingRegistrationExercise4_Click(object sender, EventArgs e)
        {
            BookingRegistrationForm.GetInstance(connection).Show();
        }
    }
}
