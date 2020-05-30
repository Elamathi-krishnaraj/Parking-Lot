using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace ParkingManagement.Core.Model
{
    public class UserRoles
    {
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}