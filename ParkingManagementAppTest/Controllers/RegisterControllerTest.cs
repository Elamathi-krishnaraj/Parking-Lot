using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using ParkingManagement.Persistence;
using ParkingManagement.Controllers;
using System.Collections.Generic;
using ParkingManagement.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Mvc;
using System;

namespace ParkingManagementAppTest.Controllers
{
    [TestClass]
    public class RegisterControllerTest
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new ParkingManagementContext());
        private readonly Mock<IRoleRepository> _mockRoleRepository = new Mock<IRoleRepository>();
        private RegisterController _registercontroller;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork.UserRoles = _mockRoleRepository.Object;
            _registercontroller = new RegisterController(_unitOfWork);
        }

        [TestMethod]
        public void Index_ValidRequest_Returnsregisters()
        {
            // Arrange
            IList<UserRoles> RoleList = null;
            _mockRoleRepository.Setup(x => x.GetRoleslist())
                .Returns(RoleList = new List<UserRoles> {
                    new UserRoles {
                        RoleId =1, RoleName="test1"},
                    new UserRoles {
                        RoleId =2, RoleName="test2"},
                });


            // Act
            var result = _registercontroller.Index();


            //// Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((Registers)result.Model), typeof(Registers));
            Assert.AreEqual(RoleList.Count, ((Registers)result.Model).RoleList.Count);
        }

    }
}
