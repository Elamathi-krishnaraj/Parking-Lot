using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;

namespace ParkingManagement.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public HomeController() { }

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public  ViewResult HomePage()
        {
            try
            {
                    var homepage = new HomePage();
                    var UserId = Convert.ToInt32(Session["UserId"]);
                    var reqList = _unitOfWork.RequestDetails.GetRequestDetails().ToList();
                    List<RequestDetails> requestList = reqList.ToList();
                    homepage.RequestList = reqList.Where(c => c.RegisterId == Convert.ToInt32(UserId)).ToList();
                    homepage.UserId = Convert.ToInt32(UserId);
                    homepage.UserName = Session["Username"].ToString();
                    homepage.RoleName = Session["Role"].ToString();
                    return View(homepage);
            }
            catch (Exception ex)
            {
                logger.Info("HomePage error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }
        public ActionResult LotteryList()
        {
            return View();
        }

    }
}
