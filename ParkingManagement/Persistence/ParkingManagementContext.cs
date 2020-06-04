using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ParkingManagement.Core.DTOModel;
using ParkingManagement.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParkingManagement.Persistence
{
    //public class ParkingManagementContext : DbContext
    //{
    //    public ParkingManagementContext()
    //        : base("name=ParkingManagementContext")
    //    {
    //        this.Configuration.LazyLoadingEnabled = false;
    //    }

    //    public virtual DbSet<Register> Registers { get; set; }


    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        //modelBuilder.Configurations.Add(new CourseConfiguration());
    //    }
    //}
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ParkingManagementContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<RequestDurationType> RequestDurationTypes { get; set; }
        public virtual DbSet<Tower> Towers { get; set; }
        public virtual DbSet<ParkingSlot> ParkingSlots { get; set; }
        public virtual DbSet<RequestDetails> RequestDetails { get; set; }
        public virtual DbSet<ParkingAllocation> ParkingAllocations { get; set; }
        public virtual DbSet<SurrenderHistory> SurrenderHistories { get; set; }
        public virtual DbSet<TowerParkingSlot> TowerParkingSlots { get; set; }
        public virtual DbSet<Actionlog> Actionlogs { get; set; }


        public virtual DbSet<TowerBlock> TowerBlocks { get; set; }
        public virtual DbSet<TowerBlockSlot> TowerBlockSlots { get; set; }
        public virtual DbSet<SlotRequestDeatils> SlotRequestDeatils { get; set; }


        public ParkingManagementContext()
            : base("ParkingManagementContext", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ParkingManagementContext Create()
        {
            return new ParkingManagementContext();
        }
    }
}