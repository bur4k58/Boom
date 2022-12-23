using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Exceptions
{
    public class ValidationException : Exception
    {
        private List<ValidationFailure> failures;

        public ValidationException() : base()
        {

        }

        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(List<ValidationFailure> failures)
        {
            this.failures = failures;
        }
    }
}
