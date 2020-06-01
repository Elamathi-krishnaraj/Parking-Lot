using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class SurrenderHistory
    {
        [Key]
        public int SurrenderHistoryId { get; set; }

        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public Registers Registers { get; set; }

        public int DurationId { get; set; }
        [ForeignKey("DurationId")]
        public RequestDurationType RequestDurationType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int TowerId { get; set; }
        [ForeignKey("TowerId")]
        public Tower Tower { get; set; }

        public int ParkingSlotId { get; set; }
        [ForeignKey("ParkingSlotId")]
        public ParkingSlot ParkingSlot { get; set; }

        public bool IsSurrender { get; set; }
        public bool IsExpires { get; set; }
        public bool IsAllotted { get; set; }

    }
}