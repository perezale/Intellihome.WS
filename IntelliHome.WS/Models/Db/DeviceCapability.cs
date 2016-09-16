namespace IntelliHome.WS.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("DeviceCapability")]
    public partial class DeviceCapability
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Device { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Capability { get; set; }

        [DataMember]
        [StringLength(250)]
        public string Status { get; set; }

        public virtual Capability Capability { get; set; }

        public virtual Device Device { get; set; }
    }
}
