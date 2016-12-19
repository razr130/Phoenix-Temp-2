using Phoenix_Temp_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phoenix_Temp_2.DAL
{
    public class JualDAL : IDisposable
    {
        private PhoenixModel db = new PhoenixModel();

        public jual GetDatabyUser(string username, int idbarang)
        {
            var results = (from s in db.juals.Include("Barang")
                          where s.username == username && s.id_barang == idbarang
                          orderby s.tgl_beli ascending
                          select s).SingleOrDefault();
            return results;
        }

        public IQueryable<jual> GetAllData()
        {
            var results = from s in db.juals.Include("Barang")
                          orderby s.tgl_beli descending
                          select s;
            return results;
        }

        public IQueryable<jual> GetAllDatabyUser(string username)
        {
            var results = from s in db.juals.Include("Barang")
                          where s.username == username
                          orderby s.tgl_beli descending
                          select s;
            return results;
        }

        public Barang GetBarangById(int id)

        {

            var result = (from b in db.Barangs

                          where b.id_barang == id

                          select b).SingleOrDefault();

            return result;

        }

        public jual GetDataById(int id)
        {
            var result = (from a in db.juals
                          where a.id_jual == id
                          select a).SingleOrDefault();

            return result;
        }

        public void AddToCart(jual jual)
        {
            //cek apakah cart dengan pengguna dan buku sama sudah ada
            var result = GetDatabyUser(jual.username, jual.id_barang);
            var stock = GetBarangById(jual.id_barang);
           
            stock.stok -= 1;
            if (result != null)
            {
                //update
                result.qty += 1;
                result.tgl_beli = DateTime.Now;
            }
            else
            {
                //tambah baru
                db.juals.Add(jual);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Edit(jual obj)
        {
            var model = GetDataById(obj.id_jual);

            if (model != null)
            {
                model.username = obj.username;
                model.useradmin = obj.useradmin;
                model.id_barang = obj.id_barang;
                model.tgl_beli = obj.tgl_beli;
                model.qty = obj.qty;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan !");
            }
        }

        public void Delete(int id, int qty)
        {
            var result = GetDataById(id);
            if (result != null)
            {
                db.juals.Remove(result);
                try
                {
                    var stock = GetBarangById(result.id_barang);

                    stock.stok += qty;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}