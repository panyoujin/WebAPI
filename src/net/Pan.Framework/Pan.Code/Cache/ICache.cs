using System;
using System.Collections.Generic;
using System.Text;

namespace Pan.Code.Cache
{
    public interface ICache
    {
        T Get<T>(string key);
        string GetString(string key);

        bool Add(string key, object value, int timeout = 60 * 5);

        bool Remove(string key);

        bool RemovePrefix(string prefix);
        bool Clear();
    }
}
