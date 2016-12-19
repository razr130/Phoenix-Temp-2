namespace Phoenix_Temp_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barang")]
    public partial class Barang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barang()
        {
            juals = new HashSet<jual>();
        }

        [Key]
        public int id_barang { get; set; }

        [Required]
        [StringLength(50)]
        public string nama_barang { get; set; }

        [StringLength(50)]
        public string gbr_barang { get; set; }

        [Required]
        [StringLength(10)]
        public string jenis_barang { get; set; }

        public int harga { get; set; }

        [Range(0,100,
       ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        
        public int? stok { get; set; }

        [StringLength(50)]
        public string model { get; set; }

        [StringLength(50)]
        public string warna { get; set; }

        [StringLength(5)]
        public string ukuran { get; set; }

        public int? diskon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<jual> juals { get; set; }
    }
}
