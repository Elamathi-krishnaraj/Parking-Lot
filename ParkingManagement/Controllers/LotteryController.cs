using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Core;
using ParkingManagement.Core.Model;
using ParkingManagement.Persistence;
using System.Collections.Generic;

namespace ParkingManagement.Controllers
{
    public class LotteryController : Controller
    {

        public LotteryController() { }

        //private ParkingManagementContext _context;

        //public LotteryController(ParkingManagementContext context)
        //{
        //    _context = context;
        //}

        private readonly IUnitOfWork _unitOfWork;

        public LotteryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult RunLottery()
        {
            var objlist = _unitOfWork.ParkingAllocation.GetAll().Where(c => c.ToDate <= DateTime.Now || c.IsSurrender == true).ToList();
            if (objlist != null && objlist.Count() > 0)
            {
                foreach (ParkingAllocation item in objlist)
                {
                    //_unitOfWork.ParkingAllocation.Remove(item);
                    //_unitOfWork.SurrenderHistory.Add(new SurrenderHistory()
                    //{
                    //    RegisterId = item.RegisterId,
                    //    DurationId = item.DurationId,
                    //    FromDate = item.FromDate,
                    //    ToDate = item.ToDate,
                    //    TowerId = item.TowerId,
                    //    ParkingSlotId = item.ParkingSlotId,
                    //    IsSurrender = item.IsSurrender,
                    //    IsExpires = (item.ToDate <= DateTime.Now) ? true : false
                    //});
                    //_unitOfWork.Complete();
                }
            }
            List<ParkingSlot> Allparkingslot = _unitOfWork.ParkingSlot.GetAll().ToList();
            List<ParkingAllocation> Notavailableslot = _unitOfWork.ParkingAllocation.GetAll().ToList();
            foreach (ParkingAllocation item in Notavailableslot)
            {
                var parkingid = Convert.ToInt32(item.ParkingSlot);
                var parkingslot = _unitOfWork.ParkingSlot.Get(Convert.ToInt32(parkingid));
                Allparkingslot.Remove(parkingslot);
            }
            var Slotreadyforallocation = Allparkingslot;
            Random rand = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var randomslotid = rand.Next(20);
                var slotavailable = Slotreadyforallocation.Where(f => f.ParkingSlotId == randomslotid)
                    .FirstOrDefault();
                if(slotavailable != null)
                {
                    
                    //_unitOfWork.ParkingAllocation.Add(new ParkingAllocation()
                    //{
                    //    UserName = registerObj.UserName,
                    //    Password = registerObj.Password,
                    //    ConfirmPassword = registerObj.ConfirmPassword,
                    //    RoleId = registerObj.RoleId
                    //});
                    //_unitOfWork.Complete();
                }
                else
                {
                    i--;
                }
            }

                return View();
        }
    }
}
