using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class SlotRequestDeatils
    {
        [Key]
        public int RequestId { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSlotAllotted { get; set; }
        public string EmployeeName { get; set; }
        public bool IsSurrender { get; set; }

        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public Registers Registers { get; set; }

        [Display(Name = "Duration")]
        public int DurationId { get; set; }
        [ForeignKey("DurationId")]
        public RequestDurationType RequestDurationType { get; set; }

        [NotMapped]
        public ICollection<RequestDurationType> DurationList { get; set; }

        [Display(Name = "Select Tower")]
        public int TowerId { get; set; }
        [ForeignKey("TowerId")]
        public Tower Tower { get; set; }

        [NotMapped]
        public ICollection<Tower> TowerList { get; set; }

        [Display(Name = "Select Block")]
        public int TowerBlockId { get; set; }
        [ForeignKey("TowerBlockId")]
        public TowerBlock TowerBlock { get; set; }

        [NotMapped]
        public ICollection<TowerBlock> TowerBlockList { get; set; }

        [Display(Name = "Select Slot")]
        public int TowerBlockSlotId { get; set; }
        [ForeignKey("TowerBlockSlotId")]
        public TowerBlockSlot TowerBlockSlot { get; set; }

        [NotMapped]
        public ICollection<TowerBlockSlot> TowerBlockSlotList { get; set; }
    }
}