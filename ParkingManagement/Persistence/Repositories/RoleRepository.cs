using System.Collections.Generic;
using System.Data.Entity;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using System.Threading.Tasks;

namespace ParkingManagement.Persistence.Repositories
{
    public class RoleRepository : Repository<UserRoles>, IRoleRepository
    {
        public RoleRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<UserRoles>> GetRoles()
        {
            return await ParkingManagementContext.UserRoles.ToListAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}