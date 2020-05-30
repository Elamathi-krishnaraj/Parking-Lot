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
        public UserRoles()
        {
            Registers = new Collection<Registers>(); 
        }
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public ICollection<Registers> Registers { get; set; }
    }
}