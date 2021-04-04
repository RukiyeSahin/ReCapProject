using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result //inheritance Resultaki constructorları kullandığımız için onlara değer yolladığımız için IResult değilde Result kullandık
    {
        public SuccessResult(string message) : base(true, message)//base Resultı kasdeder burada Resultun 2 parametreli consructorına değer yolladık
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
