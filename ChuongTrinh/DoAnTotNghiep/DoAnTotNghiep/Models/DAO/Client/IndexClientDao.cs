using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using DoAnTotNghiep.Models.EF;
using DoAnTotNghiep.Models.EFplus;

namespace FreshFoodHTH.Models.DAO.Client
{
    public class IndexClientDao
    {
        BanXeDapDienDBContext db = new BanXeDapDienDBContext();
        public IEnumerable<SanPham> ListSimple(string searching)
        {

            var list = db.Database.SqlQuery<SanPham>($"SELECT sp.IDSanPham, sp.MaSo, sp.Ten AS TenSanPham, tl.Ten AS TenTheLoai, sp.DonViTinh, sp.GiaTien, sp.GiaKhuyenMai, sp.HinhAnh, sp.CoSan, sp.SoLuong, sp.SoLuotXem, sp.SoLuotMua, sp.ModifiedDate " +
               $"FROM dbo.SanPham sp LEFT JOIN dbo.TheLoai tl ON tl.IDTheLoai = sp.IDTheLoai " +
               $"WHERE sp.MaSo LIKE N'%{searching}%' " +
               $"OR sp.Ten LIKE N'%{searching}%' " +
               $"OR tl.Ten LIKE N'%{searching}%' " +
               $"OR sp.DonViTinh LIKE N'%{searching}%' " +
               $"OR sp.GiaTien LIKE N'%{searching}%' " +
               $"OR sp.GiaKhuyenMai LIKE N'%{searching}%' " +
               $"OR sp.SoLuong LIKE N'%{searching}%' " +
               $"OR sp.SoLuotXem LIKE N'%{searching}%' " +
               $"OR sp.SoLuotMua LIKE N'%{searching}%' " +
               $"OR sp.ModifiedDate LIKE N'%{searching}%' " +
               $"ORDER BY sp.ModifiedDate DESC").ToList();
            //var list = db.SanPhams.Where(x => x.MaSo.Contains(searching) || x.Ten.Contains(searching));

            return list;
        }

        public IEnumerable<SanPham> ListSimpleSearch(int PageNum, int PageSize, string searching)
        {
         
               var list = db.Database.SqlQuery<SanPham>($"SELECT sp.IDSanPham, sp.MaSo, sp.Ten AS TenSanPham, tl.Ten AS TenTheLoai, sp.DonViTinh, sp.GiaTien, sp.GiaKhuyenMai, sp.HinhAnh, sp.CoSan, sp.SoLuong, sp.SoLuotXem, sp.SoLuotMua, sp.ModifiedDate " +
              $"FROM dbo.SanPham sp LEFT JOIN dbo.TheLoai tl ON tl.IDTheLoai = sp.IDTheLoai " +
              $"WHERE sp.MaSo LIKE N'%{searching}%' " +
              $"OR sp.Ten LIKE N'%{searching}%' " +
              $"OR tl.Ten LIKE N'%{searching}%' " +
              $"OR sp.DonViTinh LIKE N'%{searching}%' " +
              $"OR sp.GiaTien LIKE N'%{searching}%' " +
              $"OR sp.GiaKhuyenMai LIKE N'%{searching}%' " +
              $"OR sp.SoLuong LIKE N'%{searching}%' " +
              $"OR sp.SoLuotXem LIKE N'%{searching}%' " +
              $"OR sp.SoLuotMua LIKE N'%{searching}%' " +
              $"OR sp.ModifiedDate LIKE N'%{searching}%' " +
              $"ORDER BY sp.ModifiedDate DESC").ToPagedList<SanPham>(PageNum, PageSize);
            return list;

        }


    }
}