using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class TowerBlockRepository : Repository<TowerBlock>, ITowerBlockRepository
    {
        public TowerBlockRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<TowerBlock> GetTowerBlocks()
        {
            return ParkingManagementContext.TowerBlocks.ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}