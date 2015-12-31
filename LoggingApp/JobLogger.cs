using System;
using System.Linq;
using System.Text;

namespace LoggingApp
{
    public  class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool _logToDatabase;
        private static bool _initialized;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, 
        bool logMessage, bool logWarning, bool logError) {

            _logToFile = logToFile;
            _logToConsole = logToConsole;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logError = logError;
            _logToDatabase = logToDatabase;

            
        }


        public static void LogMessage(string message, bool message2, bool warning, bool error)
        {
            message.Trim();
            if (message == null || message.Length == 0)
            {
                return;
            }
            if(!_logToConsole && !_logToFile && !_logToDatabase)
            {
                throw new Exception("Invalid Configuration");
            }
            if ((!_logError && !_logMessage && !_logWarning) || (!message2 && !warning && !error))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            int t;
            if (message2 && _logMessage)
            {
                t = 1;
            }
            if (error && _logError)
            {
                t = 2;
            }
            if (warning && _logWarning)
            {
                t = 3;
            }

            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + message + "', " +
                t.ToString() + ")");
            command.ExecuteNonQuery();

            string l;

            if (!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            {
                l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");

            }

            if(error && _logError)
            {
                l = l + DateTime.Now.ToShortDateString() + message;
            }
             if(warning && _logWarning)
            {
                 l = l + DateTime.Now.ToShortDateString() + message;
            }
             if(message2 && _logMessage)
            {
                 l = l + DateTime.Now.ToShortDateString() + message;
            }

           System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt", l);
         
            if(error && _logError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
             if(warning && _logWarning)
            {
               Console.ForegroundColor = ConsoleColor.Yellow;
            }
             if(message2 && _logMessage)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + message);


            /*
             -Usar Using en lugar de referencias las mismas librerias.
             - NO repetir porciones de codigo.
             - reemplazar los IF por comportamiento.
             -Cambiar los nombres de ambas variables message (message y message2).
             -El metodo hace demasiado, aplicar principio de Single Responsability Principle.
             -Se pasan muchos parametros a un metodo.
             -Initialized nunca se usa
             */





        }

    }
}
