using BLL;
using CuaHangDAL;
using System.Web.Mvc;
using test.net.Models;

namespace test.net.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TaiKhoan taikhoan)
        {
     
            var newlogin = TaiKhoanMager.login(taikhoan.TenTK, Encryptormd5.MD5Hash(taikhoan.MatKhau));
            if (newlogin ==true) 
            {
                TaiKhoan tk = TaiKhoanMager.GetItemByTen(taikhoan.TenTK);
                
                Session.Add(constains.USER_SESSION, tk);
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            Session["taikhoan"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DangKy(NhanVien nv)
        {
            ViewBag.TenNV = nv.TenNv;
            ViewBag.MaNV = nv.MaNV;
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(TaiKhoan tk, FormCollection x)
        {
            string id = x["id"].ToString();
     
            TaiKhoanMager.insert(tk);
            // gan tai khoan cho nhan vien
            int idtk = tk.MaTK;
            int idnv = int.Parse(id);
            NhanVienMager.saveTK(idnv, idtk);
            // ma hoa mat khau
            TaiKhoanMager.MaHoaMK(idtk);
           
            return RedirectToAction("Index", "NhanVien");
        }

        [HttpGet]
        public ActionResult DangkyKH(KhachHang item)
        {
            ViewBag.TenKH = item.TenKH;
            ViewBag.MaNV = item.MaKh;
            return View();
        }

        [HttpPost]
        public ActionResult DangKyKH(TaiKhoan tk, FormCollection x)
        {
            string id = x["id"].ToString();
           
            TaiKhoanMager.insert(tk);
            // gan tai khoan cho khach hang
            int idtk = tk.MaTK;
            int idnv = int.Parse(id);
            KhachHangMager.saveTK(idnv, idtk);
            // ma hoa mat khau
            TaiKhoanMager.MaHoaMK(idtk);

            return RedirectToAction("Index", "KhachHang");
        }
    }
}