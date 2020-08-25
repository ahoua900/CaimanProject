using CaimanProject.DAL;
using CaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{
    public class MemberCtController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        // GET: MemberCt
        public ActionResult AddMember()
        {
            var Spe = GetSpecialité();
            var Mem = GetMemeber();
            var mode = new ViewModel();
            mode.Specialites = Spe;
            mode.Members = Mem;

            ViewBag.spe = db.Specialites.ToList();

            return View(mode);
        }
        private List<Member> GetMemeber()
        {
            return db.Members.ToList();
        }

        private List<Specialite> GetSpecialité()
        {
            return db.Specialites.ToList();
        }

        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            member.MemberStatus = "Membre simple";
                db.Members.Add(member);
                db.SaveChanges();
     
            return RedirectToAction("AddMember");
        }
    }
}