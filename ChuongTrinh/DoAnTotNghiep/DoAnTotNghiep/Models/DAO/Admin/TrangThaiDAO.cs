using DoAnTotNghiep.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace DoAnTotNghiep.Models.DAO.Admin
{
    public class TrangThaiDAO
    {
        BanXeDapDienDBContext db = new BanXeDapDienDBContext();

        public TrangThaiDAO()
        {
            db = new BanXeDapDienDBContext();
        }

        public List<TrangThai> ListLoaiTrangThai()
        {
            return db.TrangThais.ToList();
        }

        public TrangThai GetByID(Guid id)
        {
            return db.TrangThais.Find(id);
        }
        public void Add(TrangThai obj)
        {
            db.TrangThais.Add(obj);
            db.SaveChanges();
        }

        public void Edit(TrangThai obj)
        {
            TrangThai trangthai = GetByID(obj.IDTrangThai);
            if (trangthai != null)
            {
                trangthai.TenTrangThai = obj.TenTrangThai;
                db.SaveChanges();
            }
        }

        public int Delete(Guid id)
        {
            TrangThai trangthai = db.TrangThais.Find(id);
            if (trangthai != null)
            {
                db.TrangThais.Remove(trangthai);
                return db.SaveChanges();
            }
            else
                return -1;
        }


        public IEnumerable<TrangThai> ListSimple(string searching)
        {
            var list = db.Database.SqlQuery<TrangThai>($"SELECT * FROM dbo.TrangThai tt " +
                $"WHERE tt.TenTrangThai LIKE N'%{searching}%' " +
                $"ORDER BY tt.TenTrangThai").ToList();

            return list;
        }

        public IEnumerable<TrangThai> ListSimpleSearch(int PageNum, int PageSize, string searching)
        {
            var list = db.Database.SqlQuery<TrangThai>($"SELECT * FROM dbo.TrangThai tt " +
               $"WHERE tt.TenTrangThai LIKE N'%{searching}%' " +
               $"ORDER BY tt.TenTrangThai").ToPagedList<TrangThai>(PageNum, PageSize);

            return list;
        }
    }
}