using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DroneBackend
{
    public struct Booking
    {
        public int droneId, clientId;
        public string dateTaken, dateDue;
    }

    public struct BookingDates
    {
        public string dateTaken, dateDue;
    }

    public class BookingManager
    {
        private SqlDBConnect connection;

        public BookingManager(SqlDBConnect connection)
        {
            this.connection = connection;
        }

        public String CreateBooking(string droneId, string clientId, string dateTaken, string dateDue)
        {
            var booking = new Booking()
            {
                droneId = Int32.Parse(droneId),
                clientId = Int32.Parse(clientId),
                dateTaken = dateTaken,
                dateDue = dateDue
            };

            return CreateBooking(booking);
        }

        public String CreateBooking(Booking booking)
        {
            double outstandingFines = CheckClientForOutStandingFines(booking);

            if (outstandingFines < 0)
                return string.Format("Client with id {0} not found", booking.clientId);
            if (outstandingFines > 0)
                return string.Format("Client {0} has outstanding fines of ${1}", booking.clientId, outstandingFines);
            
            var insertQuery = GenerateInsertBookingQuery(booking);

            // Insert new booking
            int success = connection.Insert(insertQuery);
            
            if (success != 1)
                return "Booking Failed! \n";

            int bookingId = CreateBookingId(booking);

            // Create new bookingId column table
            //CreateBookingIdTable();

            var bookingBuilder = String.Format(
                "UPDATE {0}.booking SET bookingId='{1}' WHERE clientId=('{2}') AND droneId=('{3}') AND dateTaken=('{4}')",
                connection.database, bookingId, booking.clientId, booking.droneId, booking.dateTaken
            );

            success = connection.Insert(bookingBuilder.ToString());

            if (success != 1)
                return "Failed to store bookingId!";

            return String.Format("Booking Successful! Your booking id is {0} \n", bookingId);
        }

        private double CheckClientForOutStandingFines(Booking booking)
        {
            var clientBookings = string.Format("SELECT * FROM {0}.booking WHERE clientId={1} AND droneId={2}", connection.database, booking.clientId, booking.droneId);
           
            var bookings = connection.Select(clientBookings);

            if (bookings == null || bookings[0].Count == 0)
                return 0;

            if (!String.IsNullOrEmpty(bookings[0]["finesDue"]))
                return Double.Parse(bookings[0]["finesDue"]);

            return 0;
        }
        
        private string GenerateInsertBookingQuery(Booking booking)
        {
            // Find all drones
            StringBuilder insertBookingBuilder = new StringBuilder("INSERT INTO " + connection.database + ".booking ");

            // Filter drones by properties given from inputs
            var validInputs = new Dictionary<string, string>();
            var bookingFields = typeof(Booking).GetFields();

            foreach (var field in bookingFields)
            {
                var bookingFieldValue = field.GetValue(booking);

                if (bookingFieldValue != null && bookingFieldValue.ToString() != string.Empty)
                {
                    if (field.Name.Equals("dateTaken") || field.Name.Equals("dateDue"))
                        validInputs.Add(field.Name, string.Format("'{0}'", bookingFieldValue));
                    else
                        validInputs.Add(field.Name, bookingFieldValue.ToString());
                }
            }

            var columns = string.Format("({0})", String.Join(", ", validInputs.Keys));
            var values = string.Format("({0})", String.Join(", ", validInputs.Values));

            insertBookingBuilder.Append(String.Format("{0} VALUES {1}", columns, values));

            return insertBookingBuilder.ToString();
        }

        private string CreateBookingIdTable()
        {
            var alter = new StringBuilder(String.Format("ALTER TABLE {0}.{1} ADD bookingId INT", connection.database, "booking"));

            var success = connection.Insert(alter.ToString());
            if (success != 1)
                return "Failed to create booking id column!";

            return "Created bookingId column in database";
        }

        private int CreateBookingId(Booking booking)
        {
            var dateTime = Convert.ToDateTime(booking.dateTaken);

            //Compute an id based on clientId, droneId, dateTaken.
            int id = (booking.clientId * booking.droneId) + (dateTime.Minute * dateTime.Second * dateTime.Millisecond);

            return id;
        }
    }
}