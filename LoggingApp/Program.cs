using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            JobLoggerSolution p = new JobLoggerSolution(new FileDevice(), new JobLoggerSettings() {logError = true, logMessage = true, logWarning = true });
            
            JobLoggerSolution.LogMessage("Mensaje_de_prueba", new WarningType());
            Console.ReadLine();
            

        }
    }
}
