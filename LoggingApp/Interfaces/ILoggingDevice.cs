using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public interface ILoggingDevice
    {
        bool correctDevice { get;}
        JobLoggerSettings context { get; set; }
        void LogToDevice(string message, IMessage messageType);
        void SaveContext(JobLoggerSettings settings);
    }
}
