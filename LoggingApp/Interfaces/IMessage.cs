using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public interface IMessage
    {
        Int32 _TypeValue { get; }


        ConsoleColor color { get; }
    }
}
