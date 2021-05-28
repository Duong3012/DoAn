using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using DoAnTotNghiep.Models.EFplus;

namespace DoAnTotNghiep.Models.DAO.Admin
{
    public class ChiTietDonHangDAO
    {
        BanXeDapDienDBContext db;

        public ChiTietDonHangDAO()
        {
            db = new BanXeDapDienDBContext();
        }

        public List<ChiTietDonHang> GetListChiTietDonHang(Guid id)
        {
            return db.ChiTietDonHangs.Where(x => x.IDDonHang == id).ToList();
        }
    }
}