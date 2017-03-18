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
    public partial class BookingRegistrationForm : Form
    {
        private static BookingRegistrationForm FormInstance = null;
        private BookingManager _bookingManager = null;
        private static SqlDBConnect _connection;

        private BookingRegistrationForm(SqlDBConnect conn)
        {
            InitializeComponent();
            _connection = conn;

            if (_bookingManager == null)
                _bookingManager = new BookingManager(conn);
        }

        public static BookingRegistrationForm GetInstance(SqlDBConnect conn)
        {
            if (FormInstance == null)
                FormInstance = new BookingRegistrationForm(conn);
            
            return FormInstance;
        }

        private void RegisterBookingBtn_Click(object sender, EventArgs e)
        {
            var clientId = ClientIdTxtField.Text;
            var droneId = DroneIdTxtField.Text;
            var dateTaken = DateTakenPicker.Checked ? DateTakenPicker.Value.ToString("yyyy-MM-dd hh:mm:ss") : null;
            var dateDue = DateDuePicker.Checked ? DateDuePicker.Value.ToString("yyyy-MM-dd hh:mm:ss") : null;
            
            var results = _bookingManager.CreateBooking(droneId, clientId, dateTaken, dateDue);

            ResultBookingTxtArea.Text += results;
        }
    }
}