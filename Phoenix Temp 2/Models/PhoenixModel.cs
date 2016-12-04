namespace Phoenix_Temp_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhoenixModel : DbContext
    {
        public PhoenixModel()
            : base("name=PhoenixModel1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<jual> juals { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.id_admin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.nama_admin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.pass)
                .IsUnicode(false);

           

            modelBuilder.Entity<Barang>()
                .Property(e => e.nama_barang)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.jenis_barang)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.warna)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.ukuran)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .HasMany(e => e.juals)
                .WithRequired(e => e.Barang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.id_customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.no_ktp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.nama_customer)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.alamat)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.telp)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.pass)
                .IsUnicode(false);

            

            modelBuilder.Entity<jual>()
                .Property(e => e.id_jual);



            modelBuilder.Entity<jual>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<jual>()
                .Property(e => e.useradmin)
                .IsUnicode(false);
        }
    }
}
