using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Common
{
    public class ErrorException: Exception
    {
        public ErrorException(ErrorType errorType) : base()
        {
            this.ErrorType = errorType;
        }

        public ErrorType ErrorType { get; private set; }
    }
}
