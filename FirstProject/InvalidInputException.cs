using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class InvalidInputException : Exception
    {
       private static string message = "You are out of range. We will set the default values.";
       public InvalidInputException() : base(message) {
       }

       public string getMessage() {
           return message;
       }
    }
}
