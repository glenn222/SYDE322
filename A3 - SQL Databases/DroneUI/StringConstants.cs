using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneUI
{
    public static class StringConstants
    {
        public static string PASSWORD = "password";
        public static string SERVER = "localhost";
        public static string DATABASE = "sys";
        public static string USER_ID = "root";
        public static string CONNECTION_STRING = "SERVER=" + SERVER + ";" + "DATABASE=" +
        DATABASE + ";" + "UID=" + USER_ID + ";" + "PASSWORD=" + PASSWORD + ";";
    }
}
