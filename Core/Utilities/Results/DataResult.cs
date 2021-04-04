using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>//sen result yapısını içeriyorsun dedik
    {
        public DataResult(T data, bool success, string message):base(success, message)//bunun basesi Result
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;//datayı set ettik
        }
        public T Data { get; }
    }
}
