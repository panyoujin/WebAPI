using System;
using Pan.Code.Cache;
using Xunit;

namespace Pan.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CacheFactory.CacheInstance.Add("a_1", "123");
            CacheFactory.CacheInstance.Add("a_2", "456");
            CacheFactory.CacheInstance.RemovePrefix("a");
        }
    }
}
