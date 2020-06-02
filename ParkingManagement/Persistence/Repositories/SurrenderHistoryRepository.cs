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
    public class SurrenderHistoryRepository : Repository<SurrenderHistory>, ISurrenderHistoryRepository
    {
        public SurrenderHistoryRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<SurrenderHistory>> GetSurrenderHistories()
        {
            return await ParkingManagementContext.SurrenderHistories.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}