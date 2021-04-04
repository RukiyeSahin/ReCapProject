using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //Mesajı ve success sonucu zaten IResultta var diye implemmete ettik
    {
        T Data { get; }
    }
}
