using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class CGSException : ApplicationException
    {
        //CUSTOM ERROR HANDLING
        public CGSException() : base()
        {

        }
        public CGSException(string message) : base(message)
        {

        }
        public CGSException(string msg, FormatException InneException) : base(msg, InneException)
        {

        }
    }
}
