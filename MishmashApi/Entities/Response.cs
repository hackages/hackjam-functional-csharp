using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishmashApi.Entities
{
    public class Response<T>
    {
        public T Result { get; set; }
        public long Time { get; set; }
        public long Ticks { get; set; }
    }
}
