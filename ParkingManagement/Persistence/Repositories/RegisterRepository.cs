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
            return ParkingManagementContext.Registers.Where(n=>n.RegisterId == Id).ToList();
        }

        public Registers ValidateLogin(Registers LoginDetails)
        {
            return ParkingManagementContext.Registers.Where(n => n.UserName == LoginDetails.UserName && n.Password == LoginDetails.Password).FirstOrDefault();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}