using CaimanProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{
    public class ArchiveController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        // GET: Archive
        public ActionResult Archive()
        {
            ViewBag.list = db.Members.Where(s => s.MemberIsArchived == true).ToList();
            return View();
        }
    }
}