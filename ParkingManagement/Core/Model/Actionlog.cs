using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class Actionlog
    {
        [Key]
        public int ActionLogId { get; set; }
        public string ControllerDescrption { get; set; }
        public string ActionExectionInfo { get; set; }
        public string IPAddressInfo { get; set; }
        //public DateTime DateTimeInfo { get; set; }
        public string ExectionTime { get; set; }
    }
}