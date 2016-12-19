namespace Phoenix_Temp_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("jual")]
    public partial class jual
    {
        [Key]
        
        public int id_jual { get; set; }

        [Required]
        
        public string username { get; set; }

        [Required]
        [StringLength(5)]
        public string useradmin { get; set; }

        public int id_barang { get; set; }

        

        [Column(TypeName = "date")]
        public DateTime tgl_beli { get; set; }

        [Range(0, 100,
       ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int qty { get; set; }

       

        public virtual Barang Barang { get; set; }

        
    }
}
