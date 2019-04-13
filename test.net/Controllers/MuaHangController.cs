using BLL;
using CuaHangDAL;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace test.net.Controllers
{
    public class MuaHangController : Controller
    {
        // GET: MuaHang
        public ActionResult Index(int? page)
        {
            var lstSP = SanPhamMager.getAllSanPham();

            if (lstSP.Count() == 0)
            {
                return HttpNotFound();
            }
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            // số sp trên trang
            int PageSize = 3;
            // Số trang hiện tại
            int PageNumber = (page ?? 1);

            return View(lstSP.OrderBy(n => n.Masp).ToPagedList(PageNumber, PageSize));
        }

        // Lây danh sách giỏ hàng
        public List<itemGioHang> LayGioHang()
        {
            List<itemGioHang> lstGioHang = Session["GioHang"] as List<itemGioHang>;
            if (lstGioHang == null)
            {
                //Nếu session bằng  null thì khởi tạo gio hàng
                lstGioHang = new List<itemGioHang>();
                // Gán lại giỏ hàng cho session
                Session["GioHang"] = lstGioHang;
            }
            // nếu giỏ hàng khác null ( đã có sản phẩm trong giỏ ) thì trả về  list
            return lstGioHang;
        }

        // Tính tổng số lượng
        public double TinhTongSoLuong()
        {
            // Lấy giỏ hàng từ Session
            List<itemGioHang> lstGioHang = Session["GioHang"] as List<itemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }

        // Tính tổng tiền
        public decimal TinhTongTien()
        {
            List<itemGioHang> lstGioHang = Session["GioHang"] as List<itemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }

        public ActionResult GioHangPartial()
        {
            //Kiểm tra nếu tổng số lượng = 0 thì trả về View 0
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            // Gán trả về ViewBag
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();

            return PartialView();
        }

        // GET: GioHang
        public ActionResult XemGioHang()
        {
            List<itemGioHang> lstGioHang = LayGioHang();
            var lstkh = KhachHangMager.GetAllKhachHang();
            ViewBag.khachhang = lstkh;
            return View(lstGioHang);
        }

        //Chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang(int maSP)
        {
            // Kiểm tra giỏ hàng tồn tại hay chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Kiểm tra sp có trong csdl
            SanPham sp = SanPhamMager.GetSanPhamByID(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy list giỏ hàng từ Session
            List<itemGioHang> lstGioHang = LayGioHang();
            // Kiểm tra sp sửa có tồn tại trong list hay không
            itemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == maSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Gán lstGioHang qua ViewBag để tạo giao diện chỉnh sửa
            ViewBag.GioHang = lstGioHang;

            //Nếu tồn tại rồi
            return View(spCheck);
        }

        [HttpPost]
        public ActionResult CapNhatGioHang(itemGioHang itemGH)
        {
            // Kiểm tra tồn kho
            SanPham spCheck = SanPhamMager.GetSanPhamByID(itemGH.MaSP);
            if (spCheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            // Cập nhật số lượng trong session giỏ hàng
            List<itemGioHang> lstGioHang = LayGioHang();
            // tìm itemGH trong lstGioHang
            itemGioHang itemGHUpdate = lstGioHang.Find(n => n.MaSP == itemGH.MaSP);
            itemGHUpdate.SoLuong = itemGH.SoLuong;
            // Cập nhật số lượng --> cập nhật thành tiền
            itemGHUpdate.ThanhTien = itemGHUpdate.DonGia * itemGHUpdate.SoLuong;

            //return RedirectToAction("SuaGioHang",new { @maSP = itemGHUpdate.MaSP});
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XoaGioHang(int maSP)
        {
            // Kiểm tra giỏ hàng tồn tại hay chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "MuaHang");
            }
            //Kiểm tra sp có trong csdl
            SanPham sp = SanPhamMager.GetSanPhamByID(maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Lấy list giỏ hàng từ Session
            List<itemGioHang> lstGioHang = LayGioHang();
            // Kiểm tra sp sửa có tồn tại trong list hay không
            itemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == maSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Xóa item trong giỏ hàng
            lstGioHang.Remove(spCheck);
            var lstkh = KhachHangMager.GetAllKhachHang();

            ViewBag.khachhang = lstkh;

            return PartialView("XemGioHang", lstGioHang);
        }

        //Xây dựng chức năng đặt hàng
        public ActionResult DatHang(int? id)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "MuaHang");
            }
            NhanVien nv = new NhanVien();
            if (Session["USER_SESSION"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Thêm kh bằng session Taikhoan

                TaiKhoan tk = Session["USER_SESSION"] as TaiKhoan;
                nv = NhanVienMager.GetbyTK(tk.MaTK);
            }
            //    //Thêm đơn hàng
            Hd ddh = new Hd();
            ddh.MaKH = id;
            ddh.MaNV = nv.MaNV;
            ddh.NgayDat = DateTime.Now;
            ddh.Status = "trong";
            HoaDonManger.insert(ddh);

            // Thêm chi tiết đơn hàng
            List<itemGioHang> lstGioHang = LayGioHang();
            foreach (var item in lstGioHang)
            {
                Cthd ctdh = new Cthd();
                ctdh.MaHD = ddh.MaHD;
                ctdh.TenSP = item.TenSP;
                ctdh.MaSp = item.MaSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGiaBan = item.DonGia;
                CTHDMager.insert(ctdh);
            }
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");
        }

        // Thêm giỏ hàng Ajax
        public ActionResult ThemGioHangAjax(int MaSP, string strURL)
        {
            // Kiểm tra trong csdl
            SanPham sp = SanPhamMager.GetSanPhamByID(MaSP);
            if (sp == null)
            {
                //Trả về trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            // nếu != null thì Lấy giỏ hàng
            List<itemGioHang> lstGioHang = LayGioHang();
            // Xét trường hợp sản phẩm được chọn đã có trong giỏ hàng -> tăng số lượng và cập nhật thành tiền
            itemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck != null)
            {
                // Kiểm tra số lượng tồn kho
                if (spCheck.SoLuong > sp.SoLuongTon)
                {
                    // trả về thông báo hết hàng
                    return Content("<script>alert(\"không được đặt quá số lượng\"); location.reload();</script>");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;

                ViewBag.TongTien = TinhTongTien();
                ViewBag.TongSoLuong = TinhTongSoLuong();
                ViewBag.giohang = lstGioHang;

                return PartialView("GioHangPartial");
            }
            // nếu sp không có trong giỏ hàng -> tạo sp theo MaSP mới rồi add vào giỏ hàng hiện tại
            itemGioHang itemGH = new itemGioHang(MaSP);
            // Kiểm tra số lượng tồn kho
            if (itemGH.SoLuong > sp.SoLuongTon)
            {
                // trả về thông báo hết hàng
                return Content("   < script >" +
                    " alert(\"không được đặt quá số lượng\");" +
                    "   location.reload(); </ script>");
            }
            lstGioHang.Add(itemGH);
            ViewBag.TongTien = TinhTongTien();
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.giohang = lstGioHang;
            return PartialView("GioHangPartial");
        }
    }
}