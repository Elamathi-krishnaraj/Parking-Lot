using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Core.Model
{
    public class HomePage
    {
        public ICollection<RequestDetails> RequestList { get; set; }

        public  int UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }


    }
}