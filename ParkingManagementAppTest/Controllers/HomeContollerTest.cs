﻿using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Core.Repositories;
using ParkingManagement.Persistence;
using ParkingManagement.Controllers;
using System.Collections.Generic;
using ParkingManagement.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System;

namespace ParkingManagementAppTest.Controllers
{
    [TestClass]
    public class HomeContollerTest
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new ParkingManagementContext());
        private readonly Mock<IRequestDetailsRepository> _mockRequestDetailsRepository = new Mock<IRequestDetailsRepository>();
        private HomeController _homecontroller;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork.RequestDetails = _mockRequestDetailsRepository.Object;
            _homecontroller = new HomeController(_unitOfWork);
        }

        [TestMethod]
        public void Index_ValidRequest_ReturnsView()
        {
            // Arrange

            // Act
            var result = _homecontroller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void HomePage_ValidRequest_Returnshomepage()
        {
            // Arrange
            IList<RequestDetails> RequestList = null;
            _mockRequestDetailsRepository.Setup(x => x.GetRequestDetails())
                .Returns(RequestList = new List<RequestDetails> {
                    new RequestDetails {
                        RegisterId=1, DurationId=1, FromDate= DateTime.Now,ToDate=DateTime.Now,PreferenceOneTowerId=1, PreferenceTwoTowerId=2,PreferenceThreeTowerId=3, RequestDetailsId=1 },
                    new RequestDetails {
                        RegisterId=2, DurationId=1, FromDate= DateTime.Now,ToDate=DateTime.Now,PreferenceOneTowerId=1, PreferenceTwoTowerId=2,PreferenceThreeTowerId=3, RequestDetailsId=1 },
                });


            // Act
            var result = _homecontroller.ResultPage(25);


            //// Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(((HomePage)result.Model), typeof(HomePage));
            Assert.AreEqual(RequestList.Count, ((HomePage)result.Model).RequestList.Count);
        }

        [TestMethod]
        public void LotteryList_ValidRequest_ReturnsView()
        {
            // Arrange

            // Act
            var result = _homecontroller.LotteryList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}
