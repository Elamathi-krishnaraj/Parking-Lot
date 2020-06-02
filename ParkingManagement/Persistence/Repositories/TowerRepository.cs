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
    public class TowerRepository : Repository<Tower>, ITowerRepository
    {
        public TowerRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<Tower>> GetTowers()
        {
            return await ParkingManagementContext.Towers.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}