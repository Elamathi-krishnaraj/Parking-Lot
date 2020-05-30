using ParkingManagement.Core;
using ParkingManagement.Core.Repositories;
using ParkingManagement.Persistence.Repositories;


namespace ParkingManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingManagementContext _parkingManagementContext;

        public UnitOfWork(ParkingManagementContext parkingManagementContext)
        {
            _parkingManagementContext = parkingManagementContext;
            Registers = new RegisterRepository(_parkingManagementContext);
            UserRoles = new RoleRepository(_parkingManagementContext);
        }

        public IRegisterRepository Registers { get; private set; }
        public IRoleRepository UserRoles { get; private set; }

        public void Complete()
        {
            _parkingManagementContext.SaveChanges();
        }

        public void Dispose()
        {
            _parkingManagementContext.Dispose();
        }
    }
}