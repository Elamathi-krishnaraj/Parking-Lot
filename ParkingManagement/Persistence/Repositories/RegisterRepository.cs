using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Registers>> GetRegisters(int Id)
        {
            return await ParkingManagementContext.Registers.Where(n=>n.RegisterId == Id).ToListAsync();
        }

        public async Task<Registers> ValidateLogin(Registers LoginDetails)
        {
            return await ParkingManagementContext.Registers.Where(n => n.UserName == LoginDetails.UserName && n.Password == LoginDetails.Password).FirstOrDefaultAsync();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}