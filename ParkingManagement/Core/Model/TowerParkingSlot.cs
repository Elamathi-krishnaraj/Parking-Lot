using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ParkingManagement.Core.Model
{
    public class TowerParkingSlot
    {
        [Key]
        public int TowerParkingSlotId { get; set; }

        public int ParkingSlotId { get; set; }
        [ForeignKey("ParkingSlotId")]
        public ParkingSlot ParkingSlot { get; set; }

        public int TowerId { get; set; }
        [ForeignKey("TowerId")]
        public Tower Tower { get; set; }
    }
}