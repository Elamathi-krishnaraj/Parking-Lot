using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;

namespace ParkingManagement.Core.Repositories
{
    public interface IRegisterRepository : IRepository<Registers>
    {
        IEnumerable<Registers> GetRegisters(int Id);
    }
}