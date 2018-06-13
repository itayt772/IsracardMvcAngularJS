using System;
using IsracardMvcAngularJS.Core.interfaces;
using System.Web;

namespace IsracardMvcAngularJS.Core
{
    public class SessionDataStorageService<T> : IDataStorageService<T>
    {
        public T Get(string key)
        {
            var sessionObject = HttpContext.Current.Session[key];

            if (sessionObject == null) return default(T);

            return (T)HttpContext.Current.Session[key];
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public void Save(string key, T entity)
        {
            HttpContext.Current.Session[key] = entity;
        }
    }
}