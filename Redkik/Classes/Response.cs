using System;
using System.Collections.Generic;

namespace Redkik.Classes
{
    public class Response<T>
    {
        public T? result { get; set; }
        public List<string>? errors { get; set; }
    }
}
