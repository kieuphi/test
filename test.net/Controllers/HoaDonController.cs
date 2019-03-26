using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDAL;
using BLL;

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
    }
}