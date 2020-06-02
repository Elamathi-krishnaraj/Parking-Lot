using System;
using System.Linq;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using System.Threading.Tasks;

namespace ParkingManagement.Controllers
{
    public class RegisterController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(RegisterController));

        public RegisterController() { }
        private readonly IUnitOfWork _unitOfWork;

        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var register = new Registers();
                var reg = await _unitOfWork.UserRoles.GetRoles();
                register.RoleList = reg.ToList();

                return View(register);
            }
            catch (Exception ex)
            {
                logger.Info("Index error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult RegisterSave(Registers registerObj)
        {
            try
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
            catch (Exception ex)
            {
                logger.Info("RegisterSave error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }

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
        public async Task<ActionResult> ValidateLogin(Registers LoginUser)
        {
            try
            {
                var loginuser = await _unitOfWork.Registers.ValidateLogin(LoginUser);
                if (loginuser != null)
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
            catch (Exception ex)
            {
                logger.Info("ValidateLogin error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
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