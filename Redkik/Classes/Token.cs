using System;
using System.Collections.Generic;

namespace Redkik.Classes
{
    public class Token
    {
        public string? id { get; set; }
        public int? ttl { get; set; }
        public List<string>? scopes { get; set; }
        public DateTimeOffset? created { get; set; }
        public string? userId { get; set; }
    }
}
