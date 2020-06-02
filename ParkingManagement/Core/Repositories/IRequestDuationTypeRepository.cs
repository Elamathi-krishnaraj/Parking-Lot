using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Core.Model;

namespace ParkingManagement.Core.Repositories
{
    public interface IRequestDuationTypeRepository : IRepository<RequestDurationType>
    {
        Task<IEnumerable<RequestDurationType>> GetRequestDurationType();
    }
}