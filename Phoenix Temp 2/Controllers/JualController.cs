using Phoenix_Temp_2.DAL;
using Phoenix_Temp_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phoenix_Temp_2.Controllers
{
    public class JualController : Controller
    {
        // GET: Jual
        private PhoenixModel db = new PhoenixModel();
        public ActionResult Index()
        {
            using (JualDAL scService = new JualDAL())
            {
                string username =
                    Session["username"] != null ? Session["username"].ToString() : string.Empty;
                return View(scService.GetAllDatabyUser(username).ToList());
            }
        }

        public ActionResult IndexAdmin()
        {
            using (JualDAL scService = new JualDAL())
            {
                var result = scService.GetAllData().ToList();
                return View(result);
            }
        }

        public ActionResult Edit(int id)
        {
            using (JualDAL services = new JualDAL())
            {
                var result = services.GetDataById(id);
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(jual jual)
        {
            using (JualDAL services = new JualDAL())
            {
                try
                {
                    services.Edit(jual);
                    TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                        "success", "Data Shopping Category " + jual.Barang.nama_barang + " berhasil diedit");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.Message.GetPesan("Error !",
                                         "danger", ex.Message);
                }
            }
            return RedirectToAction("Index");
        }

        public Barang GetBarangById(int id)

        {

            var result = (from b in db.Barangs

                          where b.id_barang == id

                          select b).SingleOrDefault();

            return result;

        }

        [Authorize]
        public ActionResult AddToCart(int id)
        {
            //cek apakah user sudah login
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            var stock = GetBarangById(id);
            if (stock.stok == 0)
            {
                TempData["Pesan"] = Helpers.Message.GetPesan("Sold Out",
                            "danger", "Item is out of stock");

                return RedirectToAction("Index","Barang", new { area = "" });
            }
            else
            {
                using (JualDAL scService = new JualDAL())
                {

                    var newShoppingCart = new jual
                    {
                        username = Session["username"].ToString(),
                        useradmin = "Admin",
                        qty = 1,
                        id_barang = id,
                        tgl_beli = DateTime.Now
                    };
                    scService.AddToCart(newShoppingCart);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                using (JualDAL service = new JualDAL())
                {
                    try
                    {
                        service.Delete(id.Value);
                        TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                            "success", "Data kategori berhasil di hapus !");
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

        public ActionResult DeleteAdmin(int? id)
        {
            if (id != null)
            {
                using (JualDAL service = new JualDAL())
                {
                    try
                    {
                        service.Delete(id.Value);
                        TempData["Pesan"] = Helpers.Message.GetPesan("Sukses !",
                            "success", "Data kategori berhasil di hapus !");
                    }
                    catch (Exception ex)
                    {
                        TempData["Pesan"] = Helpers.Message.GetPesan("Error !",
                        "danger", ex.Message);
                    }
                }
            }
            return RedirectToAction("IndexAdmin");
        }
    }
}