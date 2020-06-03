using NUnit.Framework;
using ParkingManagement.Controllers.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web;
using System;

namespace ParkingManagementTest
{
    [TestFixture]
    public class EmployeeSlotControllerTest
    {
        [Test]
        public void GetEmployeeSlot_IdIsZero_ReturnNotFound()
        {
            var controller = new EmployeeSlotController();

            //var result = controller.GetEmployeeSlot(0);

            //// NotFound 
            //Assert.That(result, Is.TypeOf<NotFound>());

        }
    }
}
