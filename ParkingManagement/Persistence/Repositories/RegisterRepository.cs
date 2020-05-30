using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class RegisterRepository : Repository<Registers>, IRegisterRepository
    {
        public RegisterRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<Registers> GetRegisters(int Id)
        {
            return ParkingManagementContext.Registers.Where(n=>n.Id == Id).ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}