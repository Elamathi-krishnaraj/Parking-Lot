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
            RequestDuationTypes = new RequestDuationTypeRepository(_parkingManagementContext);
            Tower = new TowerRepository(_parkingManagementContext);
            TowerBlock = new TowerBlockRepository(_parkingManagementContext);
            TowerBlockSlot = new TowerBlockSlotRepository(_parkingManagementContext);
            slotRequestDetails = new SlotRequestDetailsRepository(_parkingManagementContext);
        }

        public IRegisterRepository Registers { get; private set; }
        public IRoleRepository UserRoles { get; private set; }
        public IRequestDuationTypeRepository RequestDuationTypes { get; private set; }
        public ITowerRepository Tower { get; private set; }
        public ITowerBlockRepository TowerBlock { get; private set; }
        public ITowerBlockSlotRepository TowerBlockSlot { get; private set; }
        public ISlotRequestDetailsRepository slotRequestDetails { get; private set; }

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