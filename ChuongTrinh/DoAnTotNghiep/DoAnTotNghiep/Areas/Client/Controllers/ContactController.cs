using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnTotNghiep.Areas.Client.Controllers
{
    public class ContactController : Controller
    {
        BanXeDapDienDBContext db = new BanXeDapDienDBContext();
        // GET: Client/Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}