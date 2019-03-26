using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDAL;
using BLL;

namespace test.net.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
                 
            List<NhanVien> lst = NhanVienMager.getAll();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            NhanVienMager.insert(nv);

            return RedirectToAction("dangky", "TaiKhoan",nv);
        }
      
       
    }
}