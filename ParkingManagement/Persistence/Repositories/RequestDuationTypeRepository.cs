using System.Collections.Generic;
using System.Data.Entity;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using System.Threading.Tasks;

namespace ParkingManagement.Persistence.Repositories
{
    public class RequestDuationTypeRepository : Repository<RequestDurationType>, IRequestDuationTypeRepository
    {
        public RequestDuationTypeRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<RequestDurationType>> GetRequestDurationType()
        {
            return await ParkingManagementContext.RequestDurationTypes.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}