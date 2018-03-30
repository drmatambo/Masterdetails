using System;

namespace VumbaSoft.Masterdetails.Services
{
    public interface IService : IDisposable
    {
        Int32 CurrentAccountId { get; set; }
    }
}
