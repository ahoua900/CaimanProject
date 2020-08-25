using CaimanProject.DAL;
using CaimanProject.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{ 
    [Authorize]
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
            var not = GetNote(id);
            var pros = GetProd(id);

            var bd = db.Associs.Where(x => x.ProjetId == id);
            
            var ne = new ViewM();
            ne.Projets = pros;
            ne.notePs = not;
            ViewBag.list = db.Members.ToList();
            return View(ne);
        }

        private List<NoteP> GetNote(int id)
        {
            return db.NotePs.Where(s=> s.ProjetNote == id).ToList();
        }

        [HttpPost]
        public ActionResult VueProjet(Projet projet, int id)
        {
            var bf = db.Projets.Find(id);
            bf.ProjetProgressBar = projet.ProjetProgressBar;
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
        var bd = db.Projets.Where(s => s.IsArchieved == false || s.ProjetProgressBar < 100);
        return bd.OrderByDescending(s => s.ProjetId).ToList();
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
                    //Boucle et recupere les Id des membres
                    var bd = from s in db.Members select s;
                        foreach (var item in bd)
                        {
                        //fait le verification s'ils sont identiques
                            if (member.MemberId == item.MemberId)
                            {
                                associ.MemberId = item.MemberId;
                                associ.ProjetId = projet.ProjetId;
                                break;
                            }
                            db.Associs.Add(associ);
                        } 
                }
                db.SaveChanges();
            }
            return RedirectToAction("AddProject");
        }

        public ActionResult Directive(int id)
        {
            var bd = db.Projets.Find(id);
            return View(bd);
        }

        public ActionResult FinProjet(int page = 0)
        {
            var bedroom = from s in db.Projets.Where(s => s.IsArchieved == true || s.ProjetProgressBar == 100) select s;
            const int PageSize = 3; // you can always do something more elegant to set this

            var count = bedroom.Count();

            var data = bedroom.Skip(page * PageSize).Take(PageSize).OrderByDescending(s => s.ProjetId).ToList();

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;
            ViewBag.List = data;
            return View();
           
           
        }

        public ActionResult FinishProjet(int id)
        {
            var pros = GetProd(id);
            var bd = db.Projets.Find(id);
            var ne = new ViewM();
            ne.Projets = pros;
            return View(ne);
           
        }

        [HttpPost]
        public ActionResult FinishProjet(Projet projet, int id)
        {
            var bd = db.Projets.Find(id);
            bd.BilanProjet = projet.BilanProjet;
            bd.ProjetMoney = projet.ProjetMoney;
            bd.ProjetDateFin = DateTime.Now;
            bd.ProjetProgressBar = 100;
            bd.IsArchieved = true;
            db.Projets.Update(bd);
            db.SaveChanges();

            return RedirectToAction("FinProjet");
        }

    }
}