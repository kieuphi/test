using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangDAL;
using BLL;

namespace CuaHangDAL
{
    public class itemGioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public itemGioHang()
        {

        }

        public itemGioHang(int iMaSP)
        {

            this.MaSP = iMaSP;
            SanPham sp = SanPhamMager.GetSanPhamByID(iMaSP);
            this.TenSP = sp.TenSp;
            this.DonGia = sp.DonGiaBan.Value;
            //khởi tạo thì sl = 1
            this.SoLuong = 1;
            this.ThanhTien = DonGia * SoLuong;


        }
        public itemGioHang(int iMaSP, int sl)
        {
            this.MaSP = iMaSP;
            SanPham sp = SanPhamMager.GetSanPhamByID(iMaSP);
            this.TenSP = sp.TenSp;
            this.DonGia = sp.DonGiaBan.Value;
            this.SoLuong = sl;
            this.ThanhTien = DonGia * SoLuong;


        }

    }
}