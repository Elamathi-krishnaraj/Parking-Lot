using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using System.Data.Entity;

namespace ParkingManagement.Persistence.Repositories
{
    public class ParkingAllocationRepository : Repository<ParkingAllocation>, IParkingAllocationRepository
    {
        public ParkingAllocationRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<ParkingAllocation> GetParkingAllocations()
        {
            return ParkingManagementContext.ParkingAllocations
                .Include(c => c.RequestDurationType)
                .Include(c=>c.TowerParkingSlot)
                .Include(c=>c.TowerParkingSlot.Tower)
                .Include(c=>c.TowerParkingSlot.ParkingSlot)
                .Include(c=>c.Registers)
                .ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}