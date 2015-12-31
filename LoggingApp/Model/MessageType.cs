using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public class MessageType : IMessage
    {
        public Int32 _TypeValue
        {
            get { return 2; }

        }
        public ConsoleColor color
        {
            get { return ConsoleColor.White; }

        }
    

        public Int32 typeValue
        {
            get { return _TypeValue; }
        }

    }
}
