using System.Linq;
using System.Web.Http;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;
using System.Data.Entity;
using System.Web.Mvc;

namespace ParkingManagement.Controllers.Api
{
    public class EmployeeSlotController : ApiController
    {
        private ParkingManagementContext _context;

        public EmployeeSlotController() {
            _context = new ParkingManagementContext();
        }
        [CacheFiltercs(TimeDuration = 300 )]
        // GET /api/EmployeeSlot
        public IHttpActionResult GetEmployeeSlot()
        {

            var resultlistQuery = _context.RequestDetails
                .Include(c => c.Registers)
                .Include(c => c.RequestDurationType)
                .ToList();
            return Ok(resultlistQuery);
        }


        //// GET /api/EmployeeSlot/id
        //public IHttpActionResult GetEmployeeSlot(int id)
        //{
        //    if (id == 0)
        //        return NotFound();

        //    return Ok();
        //}
    }
}
