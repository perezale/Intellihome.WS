using System.Runtime.Serialization;

namespace IntelliHome.WS.Models.Db
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [DataContract]
  [Table("Capability")]
  public partial class Capability
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Capability()
    {
      DeviceCapability = new HashSet<DeviceCapability>();
    }

    [DataMember]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [DataMember]
    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    [DataMember]
    [Required]
    [StringLength(250)]
    public string Value_Type { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<DeviceCapability> DeviceCapability { get; set; }
  }
}
