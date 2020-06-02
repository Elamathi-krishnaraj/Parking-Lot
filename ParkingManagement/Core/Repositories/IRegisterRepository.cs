using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ParkingManagement.Core.Model;

namespace ParkingManagement.Core.Repositories
{
    public interface IRegisterRepository : IRepository<Registers>
    {
        Task<IEnumerable<Registers>> GetRegisters(int Id);
        Task<Registers> ValidateLogin(Registers LoginDetails);
    }
}