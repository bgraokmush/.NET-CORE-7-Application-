using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResultError<T> : DataResult<T>
    {
        public DataResultError(T data, string message) : base(data, false, message)
        {
        }

        public DataResultError(T data) : base(data, false)
        {
            
        }


        public DataResultError(string message) : base(default, false, message)
        {

        }

        public DataResultError() : base(default, false)
        {

        }
    }
}
