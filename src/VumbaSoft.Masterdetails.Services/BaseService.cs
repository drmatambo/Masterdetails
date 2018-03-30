using VumbaSoft.Masterdetails.Data.Core;
using System;

namespace VumbaSoft.Masterdetails.Services
{
    public abstract class BaseService : IService
    {
        public Int32 CurrentAccountId { get; set; }
        protected IUnitOfWork UnitOfWork { get; }

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
