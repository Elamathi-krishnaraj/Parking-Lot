using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class RequestDurationType
    {
        [Key]
        public int DurationId { get; set; }

        public string DurationType { get; set; }

        public string DurationDescription { get; set; }
    }
}