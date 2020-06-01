using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;

namespace ParkingManagement.Controllers
{
    public class SlotrequestController : Controller
    {
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

       public ActionResult RequestView()
        {
            var requestnew = new RequestDetails();
            requestnew.DurationList = _unitOfWork.RequestDuationTypes.GetRequestDurationType().ToList();
            requestnew.TowerList = _unitOfWork.Tower.GetTowers().ToList();
            var userid = Convert.ToInt32(Session["UserId"]);
            requestnew.RegisterId = Convert.ToInt32(userid);
            requestnew.FromDate = DateTime.Now;
            requestnew.ToDate = DateTime.Now;
            return View(requestnew);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRequestView(RequestDetails reqObj)
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
            return Redirect("/Home/HomePage");
        }

        public ActionResult DeleteView(int id)
        {
            var req = _unitOfWork.RequestDetails.Get(id);
            _unitOfWork.RequestDetails.Remove(req);
            _unitOfWork.Complete();
            return Redirect("/Home/HomePage");
        }

        /// <summary>
        /// old request methods
        /// </summary>
        /// <returns></returns>
        public ActionResult RaiseRequest()
        {
            var slotrequest = new SlotRequestDeatils();
            slotrequest.DurationList = _unitOfWork.RequestDuationTypes.GetRequestDurationType().ToList();
            slotrequest.TowerList = _unitOfWork.Tower.GetTowers().ToList();
            slotrequest.TowerBlockList = _unitOfWork.TowerBlock.GetTowerBlocks().ToList();
            slotrequest.TowerBlockSlotList = _unitOfWork.TowerBlockSlot.GetTowerBlockSlots().ToList();
            slotrequest.RegisterId = Convert.ToInt32(Session["UserId"]);

            return View(slotrequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRequest(SlotRequestDeatils slotObj)
        {
            if (ModelState.IsValid)
            {
                var UserId = Convert.ToInt32(Session["UserId"]);
                _unitOfWork.slotRequestDetails.Add(new SlotRequestDeatils()
                {
                    RegisterId = Convert.ToInt32(UserId),
                    DurationId = slotObj.DurationId,
                    TowerId = slotObj.TowerId,
                    TowerBlockId = slotObj.TowerBlockId,
                    TowerBlockSlotId = slotObj.TowerBlockSlotId,
                    Remarks = slotObj.Remarks,
                    EmployeeName = Session["Username"].ToString()
                });
                _unitOfWork.Complete();
            }
                return Redirect("/Home/HomePage");
        }


    }
}
