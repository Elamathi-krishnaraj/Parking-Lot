using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;

namespace ParkingManagement.Controllers
{
    public class SlotrequestController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SlotrequestController));
        public SlotrequestController() { }

        private readonly IUnitOfWork _unitOfWork;

        public SlotrequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RequestView()
        {
            try
            {
                var requestnew = new RequestDetails();
                var lstduration = await _unitOfWork.RequestDuationTypes.GetRequestDurationType();
                requestnew.DurationList = lstduration.ToList();
                var listrequestnew = await _unitOfWork.Tower.GetTowers();
                requestnew.TowerList = listrequestnew.ToList();
                var userid = Convert.ToInt32(Session["UserId"]);
                requestnew.RegisterId = Convert.ToInt32(userid);
                requestnew.FromDate = DateTime.Now;
                requestnew.ToDate = DateTime.Now;
                return View(requestnew);
            }
            catch (Exception ex)
            {
                logger.Info("RequestView error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveRequestView(RequestDetails reqObj)
        {
            try
            {
                var IsSaved = false;
                if (ModelState.IsValid)
                {
                     var UserId = Convert.ToInt32(Session["UserId"]);
                    _unitOfWork.RequestDetails.Add(new RequestDetails()
                    {
                        RegisterId = Convert.ToInt32(UserId),
                        DurationId = reqObj.DurationId,
                        FromDate = reqObj.FromDate,
                        ToDate = reqObj.ToDate,
                        PreferenceOneTowerId = reqObj.PreferenceOneTowerId,
                        PreferenceTwoTowerId = reqObj.PreferenceTwoTowerId,
                        PreferenceThreeTowerId = reqObj.PreferenceThreeTowerId

                    });
                    _unitOfWork.Complete();
                    IsSaved = true;
                }

                if (HttpContext.Request.IsAjaxRequest())
                    return Json(IsSaved, JsonRequestBehavior.AllowGet);
                return Redirect("/Home/HomePage");
            }
            catch (Exception ex)
            {
                logger.Info("SaveRequestView error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }

        public ActionResult DeleteView(int id)
        {
            try
            {
                var req = _unitOfWork.RequestDetails.Get(id);
                _unitOfWork.RequestDetails.Remove(req);
                _unitOfWork.Complete();
                return Redirect("/Home/HomePage");
            }
            catch (Exception ex)
            {
                logger.Info("DeleteView error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }
        public async Task<ActionResult> Surrenderview()
        {
            try
            {
                HomePage obj = new HomePage();
                var UserId = Convert.ToInt32(Session["UserId"]);
                var parkingObj = await _unitOfWork.ParkingAllocation.GetParkingAllocations();
                List<ParkingAllocation> lstObj = parkingObj.ToList();
                obj.ParkingAllocatin = lstObj.Where(c => c.RegisterId == Convert.ToInt32(UserId) && c.IsSurrender == false).ToList();
                return View(obj);
            }
            catch (Exception ex)
            {
                logger.Info("Surrender error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }

        public ActionResult UpdateSurrender(int id)
        {
            try
            {
                var IsSaved = false;
                var RoleList = _unitOfWork.ParkingAllocation.Get(id);
                using (var db = new ParkingManagementContext())
                {
                    var obj = db.ParkingAllocations.Where(c => c.ParkingAllocationId == id).FirstOrDefault();
                    obj.IsSurrender = true;
                    db.SaveChanges();
                    IsSaved = true;
                }
                if (HttpContext.Request.IsAjaxRequest())
                    return Json(IsSaved, JsonRequestBehavior.AllowGet);
                return RedirectToAction("Surrenderview");
            }
            catch (Exception ex)
            {
                logger.Info("UpdateSurrender error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }


    }
}
