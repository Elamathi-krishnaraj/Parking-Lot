using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ParkingManagementAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void ShowBalance_WithNonExistantAccount_GoesToShowError()

        {
            //Arrange
            //Mock<HttpSessionStateBase> session = new Mock<HttpSessionStateBase>();
            //session.SetupGet(s => s["AccountId"]).Returns(99999999);
            //session.SetupGet(s => s["Last4DigitsOfSsn"]).Returns("9999");

            //Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            //httpContext.SetupGet(c => c.Session).Returns(session.Object);

            //ControllerContext ctx = new ControllerContext();
            //ctx.HttpContext = httpContext.Object;
            //var quickPayServiceMock = new Mock<IQuickPayService>();
            //quickPayServiceMock.Setup(quickpayservice => quickpayservice.ValidateAccount(99999999, "9999")).Returns(new AccountStatus { IsValid = false });

            //KioskController controller = new KioskController(quickPayServiceMock.Object);
            //controller.ControllerContext = ctx;
            ////Act
            //RedirectToRouteResult redirectToRouteResult = controller.ShowBalance() as RedirectToRouteResult;
            ////Assert
            //Assert.AreEqual("ShowError", redirectToRouteResult.RouteValues["action"].ToString());

        }
    }
}

        //        [TestMethod]
        //        public void TestMethod1()
        //        {
        //        }
        //        [TestMethod]
        //        public async Task HomePage_ValidRequest_Returnshomepage()
        //        {
        //            // Arrange
        //            //IList<RequestDetails> latestrequests = null;
        //            var latestrequests = _mockRequestDetailsRepository
        //        .Setup(x => x.GetRequestDetails())
        //        .ReturnsAsync(new List<RequestDetails>
        //        {
        //                        new RequestDetails {
        //                        RegisterId = 1,
        //                        DurationId =1,
        //                        PreferenceOneTowerId =1,
        //                        PreferenceTwoTowerId =2,
        //                        PreferenceThreeTowerId =3
        //                    },
        //                    new RequestDetails {
        //                        RegisterId = 1,
        //                        DurationId =1,
        //                        PreferenceOneTowerId =3,
        //                        PreferenceTwoTowerId =2,
        //                        PreferenceThreeTowerId =1
        //                    }
        //        });
        //            //List<RequestDetails> xx = latestrequests;
        //            //latestrequests = _mockRequestDetailsRepository.Setup(x => x.GetRequestDetails(It.IsAny<int?>()))
        //            //   .ReturnsAsync<int?>(x => latestrequests = new List<RequestDetails> {
        //            //        new RequestDetails {
        //            //            RegisterId = 1,
        //            //            DurationId =1,
        //            //            PreferenceOneTowerId =1,
        //            //            PreferenceTwoTowerId =2,
        //            //            PreferenceThreeTowerId =3
        //            //        },
        //            //        new RequestDetails {
        //            //            RegisterId = 1,
        //            //            DurationId =1,
        //            //            PreferenceOneTowerId =3,
        //            //            PreferenceTwoTowerId =2,
        //            //            PreferenceThreeTowerId =1
        //            //        }
        //            //   });

        //            // Act
        //            //var result = await _sut.HomePage() as ActionResult;
        //            //var model = (List<RequestDetails>)((ActionResult)result).Model;


        //            //// Assert
        //            //Assert.IsInstanceOfType(result, typeof(ActionResult));
        //            //Assert.IsInstanceOfType(result.model, typeof(HomePage));
        //            //Assert.AreEqual(latestrequests.Count, ((RequestDetails)result.model).latestrequests.Count);
        //        }
        //    }
        //}


