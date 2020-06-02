using System;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManagement.Controllers
{
    public class LotteryController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LotteryController));

        public LotteryController() { }

        private readonly IUnitOfWork _unitOfWork;

        public LotteryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ActionResult> RunLottery()
        {
            try
            {
                // to get expires and surrender parking slots
                var lstObjt = await _unitOfWork.ParkingAllocation.GetAll();
                List<ParkingAllocation> lstObj = lstObjt.ToList();
                var listObj = lstObj.Where(c => c.ToDate <= DateTime.Now || c.IsSurrender == true).ToList();
                if (listObj != null && listObj.Count() > 0)
                {
                    foreach (ParkingAllocation item in listObj)
                    {
                        _unitOfWork.ParkingAllocation.Remove(item);
                        _unitOfWork.SurrenderHistory.Add(new SurrenderHistory()
                        {
                            RegisterId = item.RegisterId,
                            DurationId = item.DurationId,
                            FromDate = item.FromDate,
                            ToDate = item.ToDate,
                            TowerParkingSlotId = item.TowerParkingSlotId,
                            IsSurrender = item.IsSurrender,
                            IsExpires = (item.ToDate <= DateTime.Now) ? true : false
                        });
                        _unitOfWork.Complete();
                    }
                }

                // Totalslot in master
                var lstAllPrakingSlot = await _unitOfWork.TowerParkingSlot.GetAll();
                List<TowerParkingSlot> listAllParkingSlot = lstAllPrakingSlot.ToList();
                // Slot allotted and not available 
                var lstSlot = await _unitOfWork.ParkingAllocation.GetAll();
                List<int> listNotAvailableSlot = lstSlot.Select(c => c.TowerParkingSlotId).ToList();

                // to check the available no of slots
                foreach (int parkingid in listNotAvailableSlot)
                {
                    var Towerparkingslot = _unitOfWork.TowerParkingSlot.Get(Convert.ToInt32(parkingid));
                    listAllParkingSlot.Remove(Towerparkingslot);
                }

                var listOnlyAvailableSlot = listAllParkingSlot; // final available slot

                // to get the list of request which need to allocatated 
                var listReq = await _unitOfWork.RequestDetails.GetAll();
                List<RequestDetails> listPendingReq = listReq.ToList();

                List<RequestDetails> listTodeleteReq = new List<RequestDetails>();
                Random rand = new Random(); // to generate number
                foreach (RequestDetails reqitem in listPendingReq)
                {
                    int index = rand.Next(listPendingReq.Count);
                    var selectrow = listPendingReq.ElementAt(index);
                    TowerParkingSlot newrecord = new TowerParkingSlot();
                    var selectSlotObj1 = listOnlyAvailableSlot.Where(t => t.TowerId == selectrow.PreferenceOneTowerId).OrderBy(c => c.TowerParkingSlotId).FirstOrDefault();
                    if (selectSlotObj1 == null)
                    {
                        var selectSlotObj2 = listOnlyAvailableSlot.Where(t => t.TowerId == selectrow.PreferenceTwoTowerId).OrderBy(c => c.TowerParkingSlotId).FirstOrDefault();
                        if (selectSlotObj2 == null)
                        {
                            var selectSlotObj3 = listOnlyAvailableSlot.Where(t => t.TowerId == selectrow.PreferenceThreeTowerId).OrderBy(c => c.TowerParkingSlotId).FirstOrDefault();
                            if (selectSlotObj3 == null)
                            {
                                // no slot is available
                            }
                            else { newrecord = selectSlotObj3; }
                        }
                        else { newrecord = selectSlotObj2; }
                    }
                    else { newrecord = selectSlotObj1; }

                    if (newrecord != null)
                    {
                        // inserted record into parking allocatin table 
                        _unitOfWork.ParkingAllocation.Add(new ParkingAllocation()
                        {
                            RegisterId = selectrow.RegisterId,
                            DurationId = selectrow.DurationId,
                            FromDate = selectrow.FromDate,
                            ToDate = selectrow.ToDate,
                            TowerParkingSlotId = newrecord.TowerParkingSlotId
                        });
                        _unitOfWork.Complete();
                        listTodeleteReq.Add(selectrow); /// for deleteing request table
                        listOnlyAvailableSlot.Remove(selectSlotObj1); // to track allotted slot
                    }
                }
                // removed record from request table
                foreach (RequestDetails delitem in listTodeleteReq)
                {
                    var ifexistsObj = _unitOfWork.RequestDetails.Get(delitem.RequestDetailsId);
                    if (ifexistsObj != null)
                    {
                        _unitOfWork.RequestDetails.Remove(delitem);
                        _unitOfWork.Complete();
                    }

                }
                return Redirect("/Home/LotteryList");
            }
            catch (Exception ex)
            {
                logger.Info("RunLottery error : " + ex);
                logger.Debug(ex);
                return View("Error");
            }
        }

    }
}
