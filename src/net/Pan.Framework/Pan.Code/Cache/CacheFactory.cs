using System;
using System.Collections.Generic;
using System.Text;
using static Pan.Code.EnumType;

namespace Pan.Code.Cache
{
    public class CacheFactory
    {
        public static CacheTypeEnum DataCacheType = CacheTypeEnum.Local;

        private static SessionCache _SessionCache = new SessionCache();

        private static LocalCache _LocalCache = new LocalCache();

        public static ICache CacheInstance
        {
            get
            {
                switch (DataCacheType)
                {
                    case CacheTypeEnum.Local:
                        return _LocalCache;
                    case CacheTypeEnum.Session:
                        return _SessionCache;
                }

                return null;
            }
        }
    }
}
