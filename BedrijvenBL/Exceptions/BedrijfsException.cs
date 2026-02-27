using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenBL.Exceptions
{
    public class BedrijfsException : Exception
    {
        public List<string> Errors { get; set; }
        public BedrijfsException(List<string> errors)
        {
            Errors = errors;
        }

        public BedrijfsException(string? message) : base(message)
        {
        }

        public BedrijfsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
