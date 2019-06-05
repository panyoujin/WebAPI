using System;

namespace Pan.Code.Cache
{
    public class SessionCache : ICache
    {
        public string GetString(string key)
        {
            throw new NotImplementedException();
        }

        public bool Add(string key, object value, int timeout = 60 * 5)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool RemovePrefix(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
