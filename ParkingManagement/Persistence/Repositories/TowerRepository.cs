using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class TowerRepository : Repository<Tower>, ITowerRepository
    {
        public TowerRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<Tower> GetTowers()
        {
            return ParkingManagementContext.Towers.ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}