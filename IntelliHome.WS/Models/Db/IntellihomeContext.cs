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
    public virtual DbSet<DeviceCapability> DeviceCapability { get; set; }
    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Capability>()
          .HasMany(e => e.DeviceCapability)
          .WithRequired(e => e.Capability)
          .HasForeignKey(e => e.Id_Capability)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<Device>()
          .HasMany(e => e.DeviceCapability)
          .WithRequired(e => e.Device)
          .HasForeignKey(e => e.Id_Device)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<Device>()
          .HasMany(e => e.User)
          .WithMany(e => e.Device)
          .Map(m => m.ToTable("UserDevice").MapLeftKey("Id_Device").MapRightKey("Id_User"));
    }
  }
}
