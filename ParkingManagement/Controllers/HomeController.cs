using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;

namespace ParkingManagement.Controllers
{
    public class HomeController : Controller
    {
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
        //[Authorize]
        public ActionResult HomePage()
        {
            if (Session["UserId"] == null)
            {
                return Redirect("/Register/Login");
            }
            else
            {
                var homepage = new HomePage();
                var UserId = Convert.ToInt32(Session["UserId"]);
                homepage.RequestList = _unitOfWork.RequestDetails.GetRequestDetails().Where(c=>c.RegisterId == Convert.ToInt32(UserId)).ToList();
                homepage.UserId = Convert.ToInt32(UserId);
                homepage.UserName = Session["Username"].ToString();
                homepage.RoleName = Session["Role"].ToString();
                return View(homepage);
            }
        }
        public ActionResult LotteryList()
        {
            return View();
        }
    }
}
