using Accounts.DAL.Repositories.Interfaces;
using System;

namespace Accounts.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IPositionRepository PositionRepository { get; }

        Task BeginTransactionAsync();
        Task EndTransactionAsync();
        void SetError();
        Task SaveAsync();
    }
}
