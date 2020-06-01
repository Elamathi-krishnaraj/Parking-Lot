using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class ParkingSlotRepository : Repository<ParkingSlot>, IParkingSlotRepository
    {
        public ParkingSlotRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<ParkingSlot> GetParkingSlots()
        {
            return ParkingManagementContext.ParkingSlots.ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}