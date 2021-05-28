using DoAnTotNghiep.Models.DAO.Admin;
using DoAnTotNghiep.Models.EF;
using FreshFoodHTH.Models.DAO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnTotNghiep.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        BanXeDapDienDBContext db = new BanXeDapDienDBContext();
        TheLoaiDAO tlDao = new TheLoaiDAO();
        IndexClientDao iDao = new IndexClientDao();

        // GET: Client/Home
        public ActionResult Index( int? page, int? PageSize, string searching)
        {
            IEnumerable<SanPham> list;
            ViewBag.Searching = searching;
            if (!string.IsNullOrEmpty(searching))
                list = db.SanPhams.Where(x => x.Ten.Contains(searching)).ToList();
            else
                list = db.SanPhams.ToList();
            ViewBag.SearchList = list;
            return View(list);

            //ViewBag.SearchString = searching;
            //ViewBag.PageSize = new List<SelectListItem>()
            //{
            //    new SelectListItem() { Value="10", Text= "10" },
            //    new SelectListItem() { Value="15", Text= "15" },
            //    new SelectListItem() { Value="20", Text= "20" },
            //    new SelectListItem() { Value="25", Text= "25" },
            //    new SelectListItem() { Value="50", Text= "50" }
            //};
            //int pageNumber = (page ?? 1);
            //int pagesize = (PageSize ?? 20);
            //ViewBag.pnumber = pageNumber;
            //ViewBag.psize = pagesize;
            ////ViewBag.Count = iDao.ListSimple(searching).Count();
            //return View(iDao.ListSimpleSearch(pageNumber, pagesize, searching));
        }

        public ActionResult IndexByCategory(Guid idcategory)
        {
            IEnumerable<SanPham> list;
            list = db.SanPhams.Where(x => x.IDTheLoai == idcategory).ToList();
            ViewBag.CategoryName = (tlDao.GetByID(idcategory)).Ten;
            return View(list);
        }

        public ActionResult CategoryShow()
        {
            return PartialView(db.TheLoais.ToList());
        }

        public ActionResult CategoryShowImage()
        {
            return PartialView(db.TheLoais.ToList());
        }

        public ActionResult ListCategoryShow()
        {
            return PartialView(db.TheLoais.ToList());
        }

        public ActionResult HeaderCart()
        {
            return PartialView();
        }

        public ActionResult ProductTopNew()
        {
            return PartialView(db.SanPhams.OrderByDescending(p => p.ModifiedDate).Take(9));
        }

        public ActionResult ProductTopSale()
        {
            return PartialView(db.SanPhams.OrderByDescending(p => p.SoLuotMua).Take(9));
        }

        public ActionResult ProductTopReview()
        {
            return PartialView(db.SanPhams.OrderByDescending(p => p.SoLuotXem).Take(9));
        }

        public ActionResult SaleOff()
        {
            return PartialView(db.SanPhamKhuyenMais.Where(x => x.ThoiGianKetThuc < DateTime.Now).ToList());
        }
    }
}