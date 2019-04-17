using BLL;
using CuaHangDAL;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;

namespace test.net.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
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

        public ActionResult Index()
        {
            List<DanHMuc> lst = DanhMucMager.getAllDanhMuc();
            return View(lst);
        }

        public ActionResult Create()
        {
            if (Ktdangnhap() == true)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost] // luu thong tin nhan vien tao tai khoan nhan vien
        public ActionResult Create(DanHMuc dm)
        {
            try
            {
                DanhMucMager.insert(dm);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Ktdangnhap() == true)
            {
                return View(DanhMucMager.GetItemById(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(DanHMuc item)
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
                int id = tk.MaTK;
                NhanVien nv = NhanVienMager.GetbyTK(id);
                item.MaNVchinhsua = nv.MaNV;
                DanhMucMager.uppdate(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", item.MaDM);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (Ktdangnhap() == true)
            {
                return View(DanhMucMager.GetItemById(id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            DanhMucMager.delete(id);
            return RedirectToAction("Index");
        }
    }
}