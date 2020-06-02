using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using System.Data.Entity;
using ParkingManagement.Core.Repositories;
using System.Threading.Tasks;

namespace ParkingManagement.Persistence.Repositories
{
    public class TowerBlockRepository : Repository<TowerBlock>, ITowerBlockRepository
    {
        public TowerBlockRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<TowerBlock>> GetTowerBlocks()
        {
            return await ParkingManagementContext.TowerBlocks.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}