using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pan.Code.Extentions;

namespace Pan.Code.Cache
{
    public class LocalCache : ICache
    {
        private static readonly Dictionary<string, CacheModel> Data = new Dictionary<string, CacheModel>();


        public T Get<T>(string key)
        {
            if (Data.ContainsKey(key))
            {
                var model = Data[key];
                if (model == null || model.ExpireTime < DateTime.Now)
                {
                    Data.Remove(key);
                }
                else
                {
                    return model.Value.ToModel<T>();
                }
            }
            return default(T);
        }
        public string GetString(string key)
        {
            if (Data.ContainsKey(key))
            {
                var model = Data[key];
                if (model == null || model.ExpireTime < DateTime.Now)
                {
                    Data.Remove(key);
                }
                else
                {
                    return model.Value;
                }
            }
            return string.Empty;
        }

        public bool Add(string key, object value, int timeout = 60 * 5)
        {
            try
            {
                Data[key] = new CacheModel() { Value = value.ToJson(), ExpireTime = DateTime.Now.AddSeconds(timeout) };
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Remove(string key)
        {
            try
            {
                if (Data.ContainsKey(key))
                {
                    Data.Remove(key);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemovePrefix(string prefix)
        {
            try
            {
                var keys = Data.Keys.ToList();
                foreach (var key in keys)
                {
                    if (key.IndexOf(prefix) == 0)
                    {
                        Data.Remove(key);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Clear()
        {
            try
            {
                Data.Clear();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
