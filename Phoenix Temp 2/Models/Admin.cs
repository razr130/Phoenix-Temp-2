namespace Phoenix_Temp_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            
        }

        [Key]
        [StringLength(5)]
        public string id_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string nama_admin { get; set; }

        [Required]
        [StringLength(50)]
        public string pass { get; set; }

        
    }
}
