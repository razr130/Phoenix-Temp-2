using Phoenix_Temp_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phoenix_Temp_2.DAL
{
    public class BarangDAL : IDisposable
    {
        private PhoenixModel db = new PhoenixModel();
        public IQueryable<Barang> GetData()
        {
            var results = from b in db.Barangs
                          orderby b.nama_barang
                          select b;

            return results;
        }

        public void Add(Barang barang)

        {
            try
            {
                db.Barangs.Add(barang);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Barang GetDataById(int id)

        {

            var result = (from b in db.Barangs

                          where b.id_barang == id

                          select b).SingleOrDefault();

            return result;

        }
        public IQueryable<Barang> GetRaket()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Raket"
                         select b;
            return result;
        }
        public IQueryable<Barang> GetKok()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Kok"
                         select b;
            return result;
        }
        public IQueryable<Barang> GetBaju()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Baju"
                         select b;
            return result;
        }
        public IQueryable<Barang> GetCelana()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Celana"
                         select b;
            return result;
        }
        public IQueryable<Barang> GetSepatu()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Sepatu"
                         select b;
            return result;
        }
        public IQueryable<Barang> GetAksesoris()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.jenis_barang == "Aksesoris"
                         select b;
            return result;
        }

        public IQueryable<Barang> GetDiskon()
        {
            var result = from b in db.Barangs
                         orderby b.nama_barang
                         where b.diskon >= 50
                         select b;
            return result;
        }
        public IQueryable<Barang> Search(string txtsearch)
        {
            var results = from m in db.Barangs
                          where m.nama_barang.ToLower().Contains(txtsearch.ToLower())
                          select m;
           
                return results;
            
            



        }
        //public Barang GetFileName(int id)
        //{
        //    var result = (from b in db.Barangs
        //                  where b.id_barang == id
        //                  select new Barang
        //                  {
        //                      gbr_barang = b.gbr_barang
        //                  }
        //                  ).SingleOrDefault();
        //    return result;
        //}
        public void Edit(Barang brg)

        {

            var result = GetDataById(brg.id_barang);

            if (result != null)

            {

                result.nama_barang = brg.nama_barang;

                result.gbr_barang = brg.gbr_barang;

                result.jenis_barang = brg.jenis_barang;

                result.harga = brg.harga;

                result.stok = brg.stok;

                result.model = brg.model;

                result.warna = brg.warna;

                result.ukuran = brg.ukuran;

                result.diskon = brg.diskon;

                db.SaveChanges();

            }

            else

            {

                throw new Exception("Data tidak ditemukan !");

            }

        }

        public void Delete(int id)
        {
            var model = GetDataById(id);
            if (model != null)
            {
                try
                {
                    db.Barangs.Remove(model);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan !");
            }

        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}