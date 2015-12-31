using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public class ErrorType : IMessage
    {
        public Int32 _TypeValue
        {
            get { return 1; }

        }
        public ConsoleColor color
        {
            get { return ConsoleColor.Red; }

        }

        public Int32 typeValue {
            get { return _TypeValue; }
         }


     }
}
