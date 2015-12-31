using System;
using System.Linq;
using System.Text;



namespace LoggingApp
{
    public class JobLoggerSolution
    {

        private static ILoggingDevice stateDevice;
        private static bool logMessage;
        private static bool logWarning;
        private static bool logError;

        public JobLoggerSolution(ILoggingDevice pDevice, JobLoggerSettings pSettings) {

            stateDevice = pDevice;
            logMessage = pSettings.logMessage;
            logWarning = pSettings.logWarning;
            logError = pSettings.logError;
            
        }
        public static void LogMessage(string message, IMessage type)
        {
            //Validation
            message.Trim();

            if (String.IsNullOrEmpty(message))
            {
                throw new Exception("There is no message to log in a device.");
            }

            if(!stateDevice.correctDevice)
            {
                throw new Exception("Invalid Configuration.");
            }

            if ( !(logError && logMessage && logWarning))
            {
                throw new Exception("Any logging way must be specified.");
            }

            //Logueo
            stateDevice.LogToDevice(message, type);
          
    }


}
}
