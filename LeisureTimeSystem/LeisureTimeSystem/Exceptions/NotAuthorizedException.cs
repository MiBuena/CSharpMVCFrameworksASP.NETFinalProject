using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeisureTimeSystem.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message):base(message)
        {
            
        }
    }
}