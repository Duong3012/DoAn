using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using DoAnTotNghiep.Models.EFplus;

namespace DoAnTotNghiep.Models.DAO.Admin
{
    public class ChiTietGioHangDAO
    {
        BanXeDapDienDBContext db;

        public ChiTietGioHangDAO()
        {
            db = new BanXeDapDienDBContext();
        }

        public List<ChiTietGioHang> GetListChiTietGioHang(Guid id)
        {
            return db.ChiTietGioHangs.Where(x => x.IDKhachHang == id).ToList();
        }
    }
}