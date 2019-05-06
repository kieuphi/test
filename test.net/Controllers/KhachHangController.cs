using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using CuaHangDAL;

namespace test.net.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index(int? page )
        {
           
            int pagesize = 5;
            int pagenumber = (page ?? 1);
            IEnumerable<KhachHang> lstkh = KhachHangMager.paglistKH(pagenumber, pagesize);
            return View(lstkh);
        }
       [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Ktdangnhap() == true)
            {
                return View(KhachHangMager.GetKhachHangByID(id));

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
                int id = tk.MaTK;
                NhanVien nv = NhanVienMager.GetbyTK(id);
                kh.MaNVchinhsua = nv.MaNV;
                KhachHangMager.uppdateKhachHang(kh);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", kh.MaKh);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            KhachHang kh = KhachHangMager.GetKhachHangByID(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Delete (int id ,FormCollection f)
        {
            
            KhachHangMager.delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost] // luu tt khach hang, tao tai khoan kh
        public ActionResult Create(KhachHang item)
        {
            item.Status = "xoa";
            KhachHangMager.insertKhachhang(item);
            // gui mail
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/gmail/confim.html"));

            content = content.Replace("{{TenKH}}",item.TenKH);
            content = content.Replace("{{NgayMua}}", DateTime.Now.ToString());
            content = content.Replace("{{id}}", item.MaKh.ToString());



            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            new Gmail().SendMail(item.Email, "Đơn hàng mới từ asp", content);
            new Gmail().SendMail(toEmail, "Đơn hàng mới từ asp", content);

            return RedirectToAction("Index");
        }
        public ActionResult confirm(int id)
        {
            KhachHang kh = KhachHangMager.GetKhachHangByID(id);
            kh.Status = "trong";
            KhachHangMager.uppdateKhachHang(kh);
            return RedirectToAction("Index");
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
    }
}