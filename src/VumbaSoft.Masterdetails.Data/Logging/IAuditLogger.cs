using VumbaSoft.Masterdetails.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace VumbaSoft.Masterdetails.Data.Logging
{
    public interface IAuditLogger : IDisposable
    {
        void Log(IEnumerable<DbEntityEntry<BaseModel>> entries);
        void Save();
    }
}
