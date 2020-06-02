using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class TowerBlockSlotRepository : Repository<TowerBlockSlot>, ITowerBlockSlotRepository
    {
        public TowerBlockSlotRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<TowerBlockSlot>> GetTowerBlockSlots()
        {
            return await ParkingManagementContext.TowerBlockSlots.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}