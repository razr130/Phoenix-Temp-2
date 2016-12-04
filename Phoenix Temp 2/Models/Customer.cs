namespace Phoenix_Temp_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {

        }

        [Key]
        [StringLength(5)]
        public string id_customer { get; set; }

        [Required]
        [StringLength(16)]
        public string no_ktp { get; set; }

        [Required]
        [StringLength(50)]
        public string nama_customer { get; set; }

        [Required]
        [StringLength(50)]
        public string alamat { get; set; }

        [Required]
        [StringLength(50)]
        public string telp { get; set; }

        [Required]
        [StringLength(50)]
        public string pass { get; set; }

        
    }
    
}
