using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class ParkingAllocation
    {
        [Key]
        public int ParkingAllocationId { get; set; }

        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public Registers Registers { get; set; }

        public int DurationId { get; set; }
        [ForeignKey("DurationId")]
        public RequestDurationType RequestDurationType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        //public int TowerId { get; set; }
        //[ForeignKey("TowerId")]
        //public Tower Tower { get; set; }

        public int TowerParkingSlotId { get; set; }
        [ForeignKey("TowerParkingSlotId")]
        public TowerParkingSlot TowerParkingSlot { get; set; }

        public bool IsSurrender { get; set; }
    }
}