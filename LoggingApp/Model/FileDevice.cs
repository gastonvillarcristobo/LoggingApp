using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoggingApp
{
    public class FileDevice: ILoggingDevice
    {
        private String _route = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile";
        private String _currentDate = DateTime.Now.ToString("yyyyMMdd");
        private String _extension = ".txt";


        public JobLoggerSettings context { get; set; }

         public bool correctDevice
         {
             get { return true; }

         }

         public String route
         {
             get{return _route;}
         }
         public String currentDate
         {
             get{return _currentDate;}
         }
         public String extension
         {
             get{return _extension;}
         }

         public void LogToDevice(string message, IMessage messageType)
         {
            
             String path = route + currentDate + extension;
             String newText = currentDate + message;

             if (!File.Exists(path))
             {
                 File.WriteAllText(path, newText);
             }

             File.AppendAllText(path, newText);

           //  File.WriteAllText(path, newText); < -- Se pisa si usamos este!!

         }
         public void SaveContext(JobLoggerSettings settings)
         {
             this.context = settings;
         }
    }
}
