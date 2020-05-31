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

        public ActionResult RaiseRequest()
        {
            var slotrequest = new SlotRequestDeatils();
            slotrequest.DurationList = _unitOfWork.RequestDuationTypes.GetRequestDurationType().ToList();
            slotrequest.TowerList = _unitOfWork.Tower.GetTowers().ToList();
            slotrequest.TowerBlockList = _unitOfWork.TowerBlock.GetTowerBlocks().ToList();
            slotrequest.TowerBlockSlotList = _unitOfWork.TowerBlockSlot.GetTowerBlockSlots().ToList();
            slotrequest.SlotRegisterId = Convert.ToInt32(Session["UserId"]);

            return View(slotrequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRequest(SlotRequestDeatils slotObj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.slotRequestDetails.Add(new SlotRequestDeatils()
                {
                    SlotRegisterId = slotObj.SlotRegisterId,
                    DurationId = slotObj.DurationId,
                    TowerId = slotObj.TowerId,
                    TowerBlockId = slotObj.TowerBlockId,
                    TowerBlockSlotId = slotObj.TowerBlockSlotId,
                    Remarks = slotObj.Remarks,
                });
                _unitOfWork.Complete();
            }
                return Redirect("/Home/HomePage");
        }
    }
}
