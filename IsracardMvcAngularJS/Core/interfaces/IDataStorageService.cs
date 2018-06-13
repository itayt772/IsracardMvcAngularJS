using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsracardMvcAngularJS.Core.interfaces
{
    public interface IDataStorageService<T>
    {
        T Get(string key);
        void Save(string key, T entity);
        void Remove(string key);
    }
}