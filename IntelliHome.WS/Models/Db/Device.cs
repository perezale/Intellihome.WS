using System.Linq;
using System.Runtime.Serialization;

namespace IntelliHome.WS.Models.Db
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [DataContract]
  [Table("Device")]
  public partial class Device
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Device()
    {
      DeviceCapability = new HashSet<DeviceCapability>();
      User = new HashSet<User>();
    }

    [DataMember(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [DataMember(Order = 1)]
    [StringLength(250)]
    public string Name { get; set; }

    [DataMember(Order = 2)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<DeviceCapability> DeviceCapability { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<User> User { get; set; }
   
  }
}
