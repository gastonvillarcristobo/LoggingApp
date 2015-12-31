using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoggingApp
{
    public class DatabaseDevice:ILoggingDevice
    {
        public JobLoggerSettings context { get; set; }
        public bool correctDevice
        {
            get { return true; }

        }

       

        public void LogToDevice(string message, IMessage messageType)
        {
             //Open connection
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();

            String value = messageType._TypeValue.ToString();
           
            SqlCommand command = new SqlCommand();
            command.CommandText = "Insert into Log Values('" + message + "', " + value + ")";
            command.ExecuteNonQuery();
        }
        public void SaveContext(JobLoggerSettings settings)
        {
            this.context = settings;
        }
    }
}
