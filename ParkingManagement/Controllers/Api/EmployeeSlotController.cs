using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;
using System.Data.Entity;

namespace ParkingManagement.Controllers.Api
{
    public class EmployeeSlotController : ApiController
    {
        private ParkingManagementContext _context;

        public EmployeeSlotController() {
            _context = new ParkingManagementContext();
        }
        // GET /api/
        public IHttpActionResult GetEmployeeSlot()
        {

            var resultlistQuery = _context.RequestDetails
                .Include(c => c.Registers)
                .Include(c => c.RequestDurationType)
                .ToList();
            return Ok(resultlistQuery);
        }
    }
}
