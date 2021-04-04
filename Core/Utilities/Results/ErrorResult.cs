using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//base Resultı kasdeder burada 2 parametreli consructora değer yolladık
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
