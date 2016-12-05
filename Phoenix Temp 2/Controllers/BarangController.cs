using Phoenix_Temp_2.DAL;
using Phoenix_Temp_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix_Temp_2.Controllers
{
    public class BarangController : Controller
    {
        // GET: Barang
        public ActionResult Index()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetData().ToList();
                return View(result);
            }
        }

        public ActionResult IndexRaket()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetRaket().ToList();
                return View(result);
            }
        }
        public ActionResult IndexKok()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetKok().ToList();
                return View(result);
            }
        }
        public ActionResult IndexBaju()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetBaju().ToList();
                return View(result);
            }
        }
        public ActionResult IndexCelana()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetCelana().ToList();
                return View(result);
            }
        }
        public ActionResult IndexSepatu()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetSepatu().ToList();
                return View(result);
            }
        }
        public ActionResult IndexAksesoris()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetAksesoris().ToList();
                return View(result);
            }
        }

        public ActionResult IndexDiskon()
        {
            using (BarangDAL svbarang = new BarangDAL())
            {
                var result = svbarang.GetDiskon().ToList();
                return View(result);
            }
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(Barang barang, HttpPostedFileBase uploadimage)
        {
            string filePath = "";
            if (uploadimage.ContentLength > 0)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + uploadimage.FileName;
                filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Images"), fileName);
                uploadimage.SaveAs(filePath);
                barang.gbr_barang = fileName;
            }


            using (BarangDAL svBrg = new BarangDAL())
            {
                try
                {
                    svBrg.Add(barang);
                    TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                      "success", "Data Barang " + barang.nama_barang + " berhasil ditambah");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.Message.GetPesan("Error !",
                                          "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (BarangDAL services = new BarangDAL())
            {
                var result = services.GetDataById(id);
                return View(result);
            }
        }

        public ActionResult Search(string txtSearch)
        {
            using (BarangDAL svCat = new BarangDAL())
            {
                var results = svCat.Search(txtSearch).ToList();
                TempData["Pesan"] = Helpers.Message.GetPesan(" ",
                      "warning", "Anda mencari " + txtSearch );
                return View(results);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barang brg)
        {
            
            
            
            
            using (BarangDAL services = new BarangDAL())
            {
                try
                {
                    services.Edit(brg);
                    TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                        "success", "Data barang " + brg.nama_barang + " berhasil diedit");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.Message.GetPesan("Error !",
                                         "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                using (BarangDAL service = new BarangDAL())
                {
                    try
                    {
                        service.Delete(id.Value);
                        TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                            "success", "Data buku berhasil didelete !");
                    }
                    catch (Exception ex)
                    {
                        TempData["Pesan"] = Helpers.Message.GetPesan("Error !",
                                             "danger", ex.Message);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}