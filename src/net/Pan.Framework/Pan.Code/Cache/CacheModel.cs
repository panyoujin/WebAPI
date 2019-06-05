using System;
using System.Collections.Generic;
using System.Text;

namespace Pan.Code.Cache
{
    internal class CacheModel
    {
        public string Value { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
