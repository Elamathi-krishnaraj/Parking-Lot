using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.DTOModel;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;

namespace ParkingManagement.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController() { }
        private readonly IUnitOfWork _unitOfWork;

        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var register = new Registers();
            register.RoleList = _unitOfWork.UserRoles.GetRoles().ToList();

            return View(register);
        }
        [HttpPost]
        public ActionResult RegisterSave(Registers registerObj )
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Registers.Add(new Registers()
                {
                    UserName = registerObj.UserName,
                    Password = registerObj.Password,
                    ConfirmPassword = registerObj.ConfirmPassword,
                    RoleId = registerObj.RoleId
                });
                _unitOfWork.Complete();
            }
            return RedirectToAction("Login");

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return Redirect("/Register/Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidateLogin(Registers LoginUser)
        {
            var loginuser = _unitOfWork.Registers.ValidateLogin(LoginUser);
            if(loginuser != null)
            {
                Session["Username"] = loginuser.UserName;
                Session["UserId"] = loginuser.RegisterId;
                if (loginuser.RoleId == 1)
                    Session["Role"] = "Admin";
                else
                    Session["Role"] = "User";
            }
            return Redirect("/Home/HomePage");
        }

        //public ActionResult GetRoleList()
        //{
        //    var RoleList = _unitOfWork.UserRoles.GetRoles();
        //    if (HttpContext.Request.IsAjaxRequest())
        //        return Json(new SelectList(RoleList.ToArray(), "Id", "RoleName"), JsonRequestBehavior.AllowGet);
        //    return RedirectToAction("Index");
        //}
    }
}