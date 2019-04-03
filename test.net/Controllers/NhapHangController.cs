using BLL;
using CuaHangDAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace test.net.Controllers
{
    public class NhapHangController : Controller
    {
        // GET: NhapHang
        public ActionResult Index()
        {
            List<Pn> lst = PhieuNhapMager.getAll();
            return View(lst);
        }

        public bool Ktdangnhap()
        {
            TaiKhoan tk = (TaiKhoan)Session["taikhoan"];
            if (tk != null)
            {
                if (tk.Loaitk == "nhan vien")
                    return true;
                else return false;
            }
            else
                return false;
        } // h kiem tra session tai khoan  nhan vien

        public ActionResult Create()
        {

            if (Ktdangnhap() == true)
            {
                List<NhaCungCap> lstdm = NhaCungCapMager.getAll();
                ViewBag.nhaccc = new SelectList(lstdm, "MaNCC", "TenNCC");
                TaiKhoan tk = (TaiKhoan)Session["taikhoan"];
                int id = tk.MaTK;
                NhanVien nv = NhanVienMager.GetbyTK(id);

                ViewBag.MaNv = nv.MaNV;
                return View();
            }
            else { return RedirectToAction("Index"); }
   
        }
        [HttpPost]
        public ActionResult Create(Pn item)
        {
            PhieuNhapMager.insert(item);
            return RedirectToAction("CreateCtPn",item);
        }
        public ActionResult CreateCtPn(Pn item)
        {
            ViewBag.tennv = item.NhanVien.TenNv;
            ViewBag.mapn = item.MaPN;
            List<SanPham> lstsp = SanPhamMager.getAllSanPham();
            ViewBag.sanpham = new SelectList(lstsp,"Masp","TenSp");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCtPn(Pn item, IEnumerable<Ctpn> lst)
        {
            SanPham sp;
            foreach( var x in lst)
            { // cap nhap so luong
                sp = SanPhamMager.GetSanPhamByID(x.MaSp);
                sp.SoLuongTon = sp.SoLuongTon + x.SoLuong;
                SanPhamMager.uppdateSanPham(sp);
                x.MaPN = item.MaPN;
                
            }
            CtPnMager.insertall(lst);
            return RedirectToAction("Index");
        }
        public ActionResult Details (int? id)
        {
            List<Ctpn> lst = CtPnMager.GetItembyMapn(id);
            return View(lst);
        }
    }
}