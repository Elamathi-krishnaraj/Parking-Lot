using System;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRegisterRepository Registers { get; }
        IRoleRepository UserRoles { get; }
        void Complete();
    }
}