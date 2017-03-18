using System;
using System.Windows.Forms;
using DroneBackend;

namespace DroneUI
{
    public partial class BookingQueryForm : Form
    {
        private static BookingQueryForm FormInstance = null;
        private static SqlDBConnect connection;

        private BookingQueryForm(SqlDBConnect conn)
        {
            InitializeComponent();
            connection = conn;
        }

        public static BookingQueryForm GetInstance(SqlDBConnect conn)
        {
            if (FormInstance == null)
                FormInstance = new BookingQueryForm(conn);
            
            return FormInstance;
        }

        private void QueryDronesBtn_Click(object sender, EventArgs e)
        {
            DroneQueryManager manager = new DroneQueryManager(connection);

            var manufacturer = DroneManufacturerTxtField.Text;
            var type = DroneTypeTxtField.Text;
            var range = DroneRangeTxtField.Text;
            var dateTaken = DateTakenPicker.Checked ? DateTakenPicker.Value.ToString("yyyy-MM-dd hh:mm:ss") : null;
            var dateDue = DateDuePicker.Checked ? DateDuePicker.Value.ToString("yyyy-MM-dd hh:mm:ss") : null;

            var results = manager.QueryDrones(type, manufacturer, range, dateTaken, dateDue);

            DroneQueryTxtArea.Text += results;
        }
    }
}
