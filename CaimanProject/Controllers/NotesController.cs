using CaimanProject.DAL;
using CaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{
    public class NotesController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        // GET: Notes
        public ActionResult AddNotes(int id)
        {
            var proj = GetProjet(id);
            var not = GetNote();
            var mode = new ModeNote();
            mode.NotePs = not;
            mode.Projets = proj;
            return View(mode);
        }

        private List<NoteP> GetNote()
        {
            return db.NotePs.ToList();
        }

        private Projet GetProjet(int id)
        {
            var bd = db.Projets.Find(id);
            return bd;
        }

        [HttpPost]
        public ActionResult AddNotes( NoteP noteP, int id)
        {
            noteP.NotePDate = DateTime.Now;
            noteP.ProjetNote = id;
            db.NotePs.Add(noteP);
            db.SaveChanges();
            return RedirectToAction("VueProjet","Home",new { id = id});
        }

        public ActionResult AllNotes(int id, int page = 0 )
        {
            var bd = db.Projets.Find(id);
           
            var bedroom = db.NotePs.Where(s => s.ProjetNote == id);
            const int PageSize = 6; // you can always do something more elegant to set this

            var count = bedroom.Count();

            var data = bedroom.Skip(page * PageSize).Take(PageSize).OrderByDescending(s => s.NotePId).ToList();

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;
            ViewBag.Notes = data;

            return View(bd);
        }

        public ActionResult Readmore(int id)
        {
            var bd = db.NotePs.Find(id);
            return View(bd);
        }

       

       /* private NoteP GetNotes(int id)
        {
            var bd = db.NotePs.Find(id);
            return bd;
        }*/
    }
}