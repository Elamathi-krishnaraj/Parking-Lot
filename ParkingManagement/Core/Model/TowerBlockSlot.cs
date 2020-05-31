using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.Model
{
    public class TowerBlockSlot
    {
        [Key]
        public int TowerBlockSlotId { get; set; }
        public string SlotDescription { get; set; }
    }

}