﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnTotNghiep.Models.EFplus
{
    public class flatTaiKhoan
    {
        public Guid IDUser { get; set; }
        public string Username { get; set; }
        public Guid IDLoaiNguoiDung{ get; set; }
        public string TenLoaiNguoiDung { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}