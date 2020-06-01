using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;
using System.Data.Entity;

namespace ParkingManagement.Controllers.Api
{
    public class EmployeeSlotController : ApiController
    {
        public EmployeeSlotController() { }
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeSlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET /api/
        public IEnumerable<RequestDetails> GetEmployeeSlot()

        {
            var resultlist = _unitOfWork.RequestDetails.GetRequestDetails().ToList();
            return resultlist;
                //.Include(c => c.RequestDurationType)
        }
    }
}
