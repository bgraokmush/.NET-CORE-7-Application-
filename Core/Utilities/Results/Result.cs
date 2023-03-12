using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public bool Succes { get; }
        public string Message { get; }

        public Result(bool succes)
        {
            Succes = succes;
        }


        public Result(bool succes, string message):this(succes)
        {
            Message = message;
        }



    }
}
