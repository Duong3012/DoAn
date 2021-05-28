using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using DoAnTotNghiep.Models.EFplus;

namespace DoAnTotNghiep.Models.DAO.Admin
{
    public class ChiTietHoaDonNhapDAO
    {
        BanXeDapDienDBContext db;
        HoaDonNhapDAO hdnDao = new HoaDonNhapDAO();

        public ChiTietHoaDonNhapDAO()
        {
            db = new BanXeDapDienDBContext();
        }

        public List<ChiTietHoaDonNhap> GetListChiTietHDNByIDHDN(Guid id)
        {
            return db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDonNhap == id).ToList();
        }

        public List<ChiTietHoaDonNhap> ListChiTietHoaDonNhap()
        {
            return db.ChiTietHoaDonNhaps.ToList();
        }

        public ChiTietHoaDonNhap GetByID(Guid id)
        {
            return db.ChiTietHoaDonNhaps.Find(id);
        }

        public void Add(ChiTietHoaDonNhap obj)
        {
            db.ChiTietHoaDonNhaps.Add(obj);

            HoaDonNhap hdNhap = hdnDao.GetByID(obj.IDHoaDonNhap);
            hdNhap.TienHang = hdNhap.TienHang + obj.ThanhTien;
            hdNhap.TongTien = hdNhap.TienHang + hdNhap.TienShip + hdNhap.TienGiam;
            hdnDao.Edit(hdNhap);

            db.SaveChanges();
        }

        public void Edit(ChiTietHoaDonNhap obj, decimal? thanhTienCu)
        {
            ChiTietHoaDonNhap chitietHDN = GetByID(obj.IDChiTietHoaDonNhap);
            if (chitietHDN != null)
            {
                chitietHDN.SoLuong = obj.SoLuong;
                chitietHDN.ThanhTien = obj.ThanhTien;

                HoaDonNhap hdNhap = hdnDao.GetByID(obj.IDHoaDonNhap);
                hdNhap.TienHang = hdNhap.TienHang - (thanhTienCu - chitietHDN.ThanhTien);
                hdNhap.TongTien = hdNhap.TienHang + hdNhap.TienShip + hdNhap.TienGiam;
                hdnDao.Edit(hdNhap);

                db.SaveChanges();
            }
        }

        public int Delete(Guid id)
        {
            ChiTietHoaDonNhap chitietHDN = db.ChiTietHoaDonNhaps.Find(id);
            if (chitietHDN != null)
            {
                db.ChiTietHoaDonNhaps.Remove(chitietHDN);

                HoaDonNhap hdNhap = hdnDao.GetByID(GetByID(id).IDHoaDonNhap);
                hdNhap.TienHang = hdNhap.TienHang - GetByID(id).ThanhTien;
                hdNhap.TongTien = hdNhap.TienHang + hdNhap.TienShip + hdNhap.TienGiam;
                hdnDao.Edit(hdNhap);


                return db.SaveChanges();
            }
            else
            {
                return -1;
            }
        }
    }
}