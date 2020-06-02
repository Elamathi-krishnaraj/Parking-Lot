using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ParkingManagement.Persistence.Repositories
{
    public class ParkingAllocationRepository : Repository<ParkingAllocation>, IParkingAllocationRepository
    {
        public ParkingAllocationRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<ParkingAllocation>> GetParkingAllocations()
        {
            return await ParkingManagementContext.ParkingAllocations
                .Include(c => c.RequestDurationType)
                .Include(c=>c.TowerParkingSlot)
                .Include(c=>c.TowerParkingSlot.Tower)
                .Include(c=>c.TowerParkingSlot.ParkingSlot)
                .Include(c=>c.Registers)
                .ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}