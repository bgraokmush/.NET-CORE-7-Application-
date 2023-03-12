using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResultSuccess<T> : DataResult<T>
    {
        public DataResultSuccess(T data, string message) : base(data,true, message)
        {
            
        }
        public DataResultSuccess(T data) : base(data, true)
        {
            
        }

        public DataResultSuccess(string message): base(default, true, message)
        {
            
        }

        public DataResultSuccess(): base(default, true)
        {
            
        }
    }
}
