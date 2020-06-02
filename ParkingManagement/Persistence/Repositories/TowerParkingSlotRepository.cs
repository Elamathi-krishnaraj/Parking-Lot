using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using System.Threading.Tasks;

namespace ParkingManagement.Persistence.Repositories
{
    public class TowerParkingSlotRepository : Repository<TowerParkingSlot>, ITowerParkingSlotRepository
    {
        public TowerParkingSlotRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<TowerParkingSlot>> GetTowerParkingSlots()
        {
            return await ParkingManagementContext.TowerParkingSlots
                .Include(c=>c.Tower)
                .Include(c=>c.ParkingSlot)
                .ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}