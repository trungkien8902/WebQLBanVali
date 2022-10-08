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
        public ActionResult Index(int? page)
        {
            List<tDanhMucSP> lstProducts = db.tDanhMucSPs.ToList();
            int pagesize = 8;//số sản phẩm trên một trang
            int pagenumber = (page ?? 1);//số trang
            return View(lstProducts.ToPagedList(pagenumber, pagesize));
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
    }
}