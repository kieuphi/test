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
            TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
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
                List<NhaCungCap> lstcc = NhaCungCapMager.getAll();
                ViewBag.nhaccc = lstcc;
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
                int id = tk.MaTK;
                NhanVien nv = NhanVienMager.GetbyTK(id);

                ViewBag.MaNv = nv.MaNV;
                return View();
            }
            else { return RedirectToAction("Index","Home"); }
   
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
            try
            {
                SanPham sp;
                foreach (var x in lst)
                { // cap nhap so luong
                    sp = SanPhamMager.GetSanPhamByID(x.MaSp);
                    if (PhieuNhapMager.ktthamso(x.MaSp, x.SoLuong) == true)
                    {
                        sp.SoLuongTon = sp.SoLuongTon + x.SoLuong;
                        SanPhamMager.uppdateSanPham(sp);
                        x.MaPN = item.MaPN;
                        x.TenSP = sp.TenSp;
                    }

                    else
                    {
                        return PartialView("error");
                        //return Content("<script>  alert(\"" + x.SanPham.TenSp + " da bi loi \")+  location.reload(); </script>");
                    }

                }
                CtPnMager.insertall(lst);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("error");
            }
        }
        public ActionResult Details (int? id)
        {
            List<Ctpn> lst = CtPnMager.GetItembyMapn(id);
            return View(lst);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Ktdangnhap() == true)
            {
                return View(PhieuNhapMager.GetItemById(id));

            }
            else return RedirectToAction("Index");
        }

        [HttpPost]  // xoa san pham , luu tt nhan vien xoa
        public ActionResult Delete(int id, FormCollection f)
        {
            try
            {
                PhieuNhapMager.delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}