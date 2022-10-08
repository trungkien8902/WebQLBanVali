using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanVaLi_TTK.Models;
using PagedList;
using System.Web.UI;

namespace WebBanVaLi_TTK.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        QLBanVaLi_KienEntities db = new QLBanVaLi_KienEntities();
        public ActionResult Index()
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.ToList();
            return View(lstProducts.ToList());
        }

        public PartialViewResult CountryPartial()
        {
            return PartialView(db.tQuocGias.ToList());
        }
        public ViewResult ProductsByCountry(int? page, string MaNuocSX = "my")
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.Where(n => n.MaNuocSX == MaNuocSX).OrderBy(n => n.MaNuocSX).ToList();
            int pagesize = 8;//số sản phẩm trên một trang
            int pagenumber = (page ?? 1);//số trang

            if (lstProducts.Count == 0)
            {
                ViewBag.Products = "Khong co san pham nay";
                ViewBag.lstProducts = db.tDanhMucSPs.ToList();
            }
            ViewBag.MaNuocSX = MaNuocSX;
            return View(lstProducts.ToPagedList(pagenumber, pagesize));
        }

        public ViewResult ProductsDetail(string MaSP)
        {
            tDanhMucSP sp = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult Delete(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault(n => n.MaSP == MaSP);
            var anhsp = from p in db.tAnhSPs where p.MaSP == sanpham.MaSP select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tAnhSPs.RemoveRange(anhsp);
            db.tDanhMucSPs.Remove(sanpham);
            db.SaveChanges();
            return View("Index");
        }
    }
}