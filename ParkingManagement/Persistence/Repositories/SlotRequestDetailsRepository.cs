using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;

namespace ParkingManagement.Persistence.Repositories
{
    public class SlotRequestDetailsRepository : Repository<SlotRequestDeatils>, ISlotRequestDetailsRepository
    {
        public SlotRequestDetailsRepository(ParkingManagementContext context)
            : base(context)
        {
        }
        public IEnumerable<SlotRequestDeatils> GetSlotRequestDeatils()
        {
            return ParkingManagementContext.SlotRequestDeatils.ToList();
        }

        public ParkingManagementContext ParkingManagementContext
        {
            get { return Context as ParkingManagementContext; }
        }
    }
}