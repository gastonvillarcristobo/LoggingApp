using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public class ConsoleDevice:ILoggingDevice
    {

        public JobLoggerSettings context { get; set; }

         public bool correctDevice
         {
             get { return true; }

         }

       

        public void ColorConsole(IMessage messageType)
        {
            Console.ForegroundColor = messageType.color;
        }
         public void LogToDevice(string message, IMessage messageType)
         {
             this.ColorConsole(messageType);
             Console.WriteLine(DateTime.Now.ToShortDateString() + message);
            
         }
         public void SaveContext(JobLoggerSettings settings)
         {
             this.context = settings;
         }
    }
}
