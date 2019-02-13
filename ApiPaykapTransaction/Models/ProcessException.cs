using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPaykapTransaction.Models
{
    public class ProcessException : Exception
    {
        public ProcessException(string message)
            : base(message)
        {

        }
    }
}