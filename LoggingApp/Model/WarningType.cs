using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApp
{
    public class WarningType : IMessage
    {
       

        public Int32 _TypeValue
        {
            get { return 3;}
        }

        public ConsoleColor color {
        get{ return ConsoleColor.Yellow;}
            set { }
        }

        public Int32 typeValue
        {
            get { return _TypeValue; }
        }
    }
}
