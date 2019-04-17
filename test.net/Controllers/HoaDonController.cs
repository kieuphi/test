using BLL;
using CuaHangDAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace test.net.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            List<Hd> lst = HoaDonManger.getAll();
            return View(lst);
        }

        public ActionResult Details(int? id)
        {
            List<Cthd> lst = CTHDMager.GetItembyMaHD(id);
            return View(lst);
        }

        // them
        [HttpGet]
        public ActionResult create()
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];

                List<SanPham> lst = SanPhamMager.getAllSanPham();
                List<KhachHang> lstkh = KhachHangMager.GetAllKhachHang();
                ViewBag.khachhang =/* new SelectList(lstkh,"MaKh","TenKH");*/ lstkh;
                ViewBag.sanpham = new SelectList(lst, "Masp", "TenSp");
                ViewBag.nhanvien = TaiKhoanMager.getNVbytk(tk.MaTK);
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult create(Hd hd, IEnumerable<Cthd> lstcthd)
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];

                HoaDonManger.insert(hd);
                SanPham sp;
                Hd item = HoaDonManger.GetItemById(hd.MaHD);
                KhachHang kh = KhachHangMager.GetKhachHangByID(hd.MaKH);
                if (kh != null)
                {
                    decimal? thanhtien;
                    foreach (var x in lstcthd)
                    {
                        sp = SanPhamMager.GetSanPhamByID(x.MaSp);
                        if (x.SoLuong < sp.SoLuongTon)
                        {
                            sp.SoLuongTon = sp.SoLuongTon - x.SoLuong;
                            SanPhamMager.tinhgiaban(x.MaSp);
                            SanPhamMager.uppdateSanPham(sp);
                            x.MaHD = item.MaHD;
                            x.TenSP = sp.TenSp;
                            x.DonGiaBan = sp.DonGiaBan;
                            thanhtien = x.SoLuong * x.DonGiaBan * (decimal)0.1;
                            kh.Diemso = kh.Diemso + (int)thanhtien;
                            KhachHangMager.uppdateKhachHang(kh);
                        }
                    }
                }

                CTHDMager.insertall(lstcthd);
                KhachHangMager.checkpointKH(kh.MaKh);
                return RedirectToAction("Index");
            }
            catch
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];

                List<SanPham> lst = SanPhamMager.getAllSanPham();
                List<KhachHang> lstkh = KhachHangMager.GetAllKhachHang();
                ViewBag.khachhang = lstkh;
                ViewBag.sanpham = new SelectList(lst, "Masp", "TenSp");
                ViewBag.nhanvien = TaiKhoanMager.getNVbytk(tk.MaTK);
                return View();
            }
        }

        public bool Ktdangnhap()
        {
            TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
            if (tk != null)
            {
                if (tk.Loaitk == "nhan vien")
                    return true;
                else return false;
            }
            else
                return false;
        }

        // xoa
        public ActionResult Delete(int? id)
        {
            if (Ktdangnhap() == true)
            {
                return View(HoaDonManger.GetItemById(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection f)
        {
            try
            {
                HoaDonManger.delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}