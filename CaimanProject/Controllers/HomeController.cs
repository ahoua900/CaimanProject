using CaimanProject.DAL;
using CaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{
    public class HomeController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        public ActionResult Index()
        {
            var spe = GetSpecialite();
            var men = GetMembe();
            var pro = Getprojet();
            var mode = new ViewModel();
            mode.Specialites = spe;
            mode.Members = men;
            mode.Projets = pro;
            return View(mode);
           
        }
        public ActionResult VueProjet(int id)
        {
            var pros = GetProd(id);
            var bd = db.Projets.Find(id);
            var ne = new ViewM();
            ne.Projets = pros;
            ViewBag.list = db.Members.ToList();
            return View(ne);
        }

        [HttpPost]
        public ActionResult VueProjet(Projet projet, int id)
        {
            var bf = db.Projets.Find(id);
            bf.ProjetProgressBar = projet.ProjetProgressBar;
            if (bf.ProjetProgressBar == 100)
            {
                bf.IsArchieved = true;
            }
            db.Projets.Update(bf);
            db.SaveChanges();
            return RedirectToAction("VueProjet");

        }

            private Projet GetProd(int id)
        {
            return db.Projets.Find(id);
        }

        private List<Projet> Getprojet()
        {
            var bd = db.Projets.Where(s => s.IsArchieved == false);
            return bd.ToList();
        }

        public ActionResult AddProject()
        {
            var spe = GetSpecialite();
            var men = GetMembe();
            var mode = new ViewModel();
            mode.Specialites = spe;
            mode.Members = men;
            return View(mode);
        }

        private List<Member> GetMembe()
        {
            return db.Members.ToList();
        }

        private List<Specialite> GetSpecialite()
        {
            return db.Specialites.ToList();
        }

        [HttpPost]
        public ActionResult AddProject(Projet projet, Member member,Associ associ)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                {
                    var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                    var path = Path.Combine(Server.MapPath("/Charges"), fileName);//Enregistrement du fichier dans le dossier Fichier
                    file.SaveAs(path);
                    projet.ProjetCahierCharge = fileName;
                    projet.ProjetDateDebut = DateTime.Now;
                    db.Projets.Add(projet);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("AddProject");
        }

        public ActionResult Directive(int id)
        {
            var bd = db.Projets.Find(id);
            return View(bd);
        }

        public ActionResult FinProjet()
        {
            ViewBag.List = db.Projets.Where(s => s.IsArchieved == true).ToList();
            return View();
        }
    }
}