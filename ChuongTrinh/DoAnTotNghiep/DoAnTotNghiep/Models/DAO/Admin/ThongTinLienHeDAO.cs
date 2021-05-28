using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using DoAnTotNghiep.Models.EFplus;

namespace DoAnTotNghiep.Models.DAO.Admin
{
    public class ThongTinLienHeDAO
    {
        BanXeDapDienDBContext db;

        public ThongTinLienHeDAO()
        {
            db = new BanXeDapDienDBContext();
        }

        public ThongTinLienHe GetInfoObj()
        {
            return db.ThongTinLienHes.ToList().ElementAt(0);
        }

        public Guid GetInfoID()
        {
            return GetInfoObj().ID;
        }

        public void Edit(ThongTinLienHe obj)
        {
            ThongTinLienHe info = GetInfoObj();
            info.ID = obj.ID;
            info.TenCuaHang = obj.TenCuaHang;
            info.DiaChi = obj.DiaChi;
            info.DienThoai1 = obj.DienThoai1;
            info.DienThoai2 = obj.DienThoai2;
            info.GioMoCua = obj.GioMoCua;
            info.Email = obj.Email;
            info.LinkFacebook = obj.LinkFacebook;
            info.LinkYoutube = obj.LinkYoutube;
            info.LinkInstagram = obj.LinkInstagram;

            db.SaveChanges();
        }
    }
}