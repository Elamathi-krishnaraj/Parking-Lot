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
            register.UserRoleList = _unitOfWork.UserRoles.GetRoles().ToList();
            

            return View(register);
        }
        [HttpPost]
        public ActionResult RegisterSave(Registers registerObj )
        {
            _unitOfWork.Registers.Add(registerObj);
            _unitOfWork.Complete();
            //ParkingManagementContext context = new ParkingManagementContext();

            return View();

        }
        public ActionResult GetRoleList()
        {
            var RoleList = _unitOfWork.UserRoles.GetRoles();
            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(RoleList.ToArray(), "Id", "RoleName"), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }
    }
}