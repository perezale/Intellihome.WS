namespace IntelliHome.WS.Models.Db
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IntellihomeContext : DbContext
    {
        public IntellihomeContext()
            : base("name=IntellihomeContext")
        {
        }

        public virtual DbSet<Capability> Capability { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDevice> UserDevice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capability>()
                .HasMany(e => e.Device)
                .WithMany(e => e.Capability)
                .Map(m => m.ToTable("DeviceCapability").MapLeftKey("Id_Capability").MapRightKey("Id_Device"));

            modelBuilder.Entity<Device>()
                .HasMany(e => e.UserDevice)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.Id_Device)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDevice)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Id_User)
                .WillCascadeOnDelete(false);
        }
    }
}
