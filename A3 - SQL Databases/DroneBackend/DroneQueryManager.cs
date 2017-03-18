using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DroneBackend
{
    public struct Drone
    {
        public string type, manufacturer, range;
    }

    public class DroneQueryManager
    {
        private SqlDBConnect connection;

        public DroneQueryManager(SqlDBConnect connection)
        {
            this.connection = connection;
        }

        public String QueryDrones(string type, string manufacturer, string range, string dateTaken, string dateDue)
        {
            Drone droneQuery = new Drone()
            {
                manufacturer = manufacturer,
                type = type,
                range = range
            };
            
            BookingDates booking = new BookingDates()
            {
                dateTaken = dateTaken,
                dateDue = dateDue
            };
            
            return QueryDrones(droneQuery, booking);
        }

        private string CheckMaintananceRecords(Drone drone, BookingDates dates)
        {
            var maintananceRecordQuery =
                String.Format("SELECT * FROM {0}.drone WHERE {1}=(false) AND {2}=('{3}') AND {4}=('{5}') AND {6}=('{7}')"
                , connection.database, "available", "droneType", drone.type, "drone.range", drone.range, "manufacturer", drone.manufacturer);

            var availableDroneQuery =
                String.Format("SELECT * FROM {0}.drone WHERE {1}=(true) AND {2}=('{3}') AND {4}=('{5}') AND {6}=('{7}')"
                , connection.database, "available", "droneType", drone.type, "drone.range", drone.range, "manufacturer", drone.manufacturer);

            var dronesInMaintanance = connection.Select(maintananceRecordQuery);

            var availableDrones = connection.Select(availableDroneQuery);

            var builder = new StringBuilder();
            builder.Append("Here are the drones in maintanence: \n");

            foreach (var d in dronesInMaintanance) { 
                foreach (var droneColumn in d) {
                    builder.Append(string.Format("{0} = {1}\n", droneColumn.Key, droneColumn.Value));
                }
                builder.Append("\n");
            }

            builder.Append("Here are the drones available: \n");
            foreach (var d in availableDrones)
            {
                foreach (var droneColumn in d)
                {
                    builder.Append(string.Format("{0} = {1}\n", droneColumn.Key, droneColumn.Value));
                }
                builder.Append("\n");
            }

            return builder.ToString();
        }

        private String QueryDrones(Drone droneRequest, BookingDates booking)
        {
            // Find all drones
            StringBuilder selectDroneQueryBuilder = new StringBuilder("SELECT * FROM " + connection.database + ".drone ");

            StringBuilder joinBookingQueryBuilder = new StringBuilder("JOIN booking ");
            selectDroneQueryBuilder.Append(joinBookingQueryBuilder);
            
            // Filter drones by properties given from inputs
            StringBuilder filter = new StringBuilder("WHERE ");

            var allDroneTableColumns = new String[] { "droneID" };
            var droneTableColumns = new String[] { "droneType", "manufacturer", "drone.range" };
            var bookingTableColumns = new String[] { "dateTaken", "dateDue" };

            allDroneTableColumns = allDroneTableColumns.Union(droneTableColumns).ToArray();
            var allTableColumns = allDroneTableColumns.Union(bookingTableColumns).ToArray();

            var droneFields = typeof(Drone).GetFields();
            var bookingFields = typeof(BookingDates).GetFields();
            //var allTableColumns = droneFields.ToArray().Union(bookingFields).ToArray();
            
            var validInputs = new List<string>();

            // Filter through drone properties to narrow search.
            for (int i = 0; i < droneFields.Length; i++)
            {
                var droneField = droneFields[i];
                var droneFieldValue = droneField.GetValue(droneRequest);

                if (droneFieldValue != null && droneFieldValue.ToString() != string.Empty)
                {
                    validInputs.Add(String.Format("({0}='{1}')", droneTableColumns[i], droneFieldValue.ToString()));
                }
            }

            for (int i = 0; i < bookingTableColumns.Length; i++)
            {
                var bookingField = bookingFields[i];
                var bookingFieldValue = bookingField.GetValue(booking);

                if (bookingFieldValue != null && bookingFieldValue.ToString() != string.Empty)
                {
                    validInputs.Add(String.Format("({0}='{1}')", bookingTableColumns[i], bookingFieldValue.ToString()));
                }
            }

            var filterString = string.Join(" AND ", validInputs);
            filter.Append(filterString);

            selectDroneQueryBuilder.Append(filter);

            var drones = connection.Select(selectDroneQueryBuilder.ToString(), 1);

            var resultBuilder = new StringBuilder();
            
            if (drones.Length > 0 && drones[0].Count > 0)
            {
                int droneCount = 0;
                foreach (var drone in drones)
                {
                    for (int i = 0; i < drone.Count; i++)
                    {
                        if (drone[i] != null && drone[i].ToString() != string.Empty)
                        {
                            resultBuilder.Append(String.Format("{0},", drone[i]));
                            droneCount++;
                        }
                    }
                    resultBuilder.Append("\n");
                }
            }

            resultBuilder.Append(CheckMaintananceRecords(droneRequest, booking));

            return resultBuilder.ToString();
        }
    }
}