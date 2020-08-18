using CaimanProject.DAL;
using CaimanProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaimanProject.Controllers
{
    public class DepartementController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        // GET: Departement
        public ActionResult Departement()
        {
            ViewBag.Spe = db.Specialites.ToList();
            return View();
        }
        public ActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajouter(Specialite specialite)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                    {
                        var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                        specialite.Url_Image = "/Fichier";
                        var path = Path.Combine(Server.MapPath(specialite.Url_Image), fileName);//Enregistrement du fichier dans le dossier Fichier
                        file.SaveAs(path);

                        specialite.ImageSpecialité = fileName;

                    }
                }
                 db.Specialites.Add(specialite);
                 db.SaveChanges();
            }
            return RedirectToAction("Departement");
        }

        public ActionResult VueDepartement(int id)
        {
            var bd = db.Specialites.Find(id);
            ViewBag.Membern = db.Members.Where(s => s.Specialite == bd.SpecialiteName);
            return View(bd);
        }


        [HttpPost]
        public ActionResult VueDepartement(Member member, int id)
        {
            var bd = db.Members.Find(id);
            member.MemberStatus = "Chef de projet";
           /* if (member.MemberStatus == null)
            {
                member.MemberStatus = "Chef de projet";
            }*/
            bd.MemberStatus = member.MemberStatus;
            db.Members.Update(bd);
            return RedirectToAction("VueDepartement");
        }

        public ActionResult ProfilMember(int id)
        {
            var bd = db.Members.Find(id);
            if (bd.Specialite == "Csharp")
                ViewData["message"] = "Purple";
            if (bd.Specialite == "Javascript")
                ViewData["message"] = "Yellow";
            if (bd.Specialite == "Python")
                ViewData["message"] = "Blue";
            if (bd.Specialite == "Data-Analyst")
                ViewData["message"] = "Orange";
            if (bd.Specialite == "Flutter")
                ViewData["message"] = "Turquoise";
            if (bd.Specialite == "Multimedia")
                ViewData["message"] = "Black";
            return View(bd);
        }

        [HttpPost]
        public ActionResult ProfilMember(Member member, int id)
        {
            var bd = db.Members.Find(id);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                {
                    var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                    var path = Path.Combine(Server.MapPath("/Fichier"), fileName);//Enregistrement du fichier dans le dossier Fichier
                    member.MemberImageName = fileName;
                    file.SaveAs(path);
                    bd.MemberImageName = fileName;
                    db.Members.Update(bd);
                    db.SaveChanges();

                }

            }
            else
            {
                bd.MemberName = member.MemberName;
                bd.MemberPnom = member.MemberPnom;
                bd.MemberCommune = member.MemberCommune;
                bd.MemberDescription = member.MemberDescription;
                bd.MemberMail = member.MemberMail;
                bd.MemberQuartier = member.MemberQuartier;
                bd.MemberCommune = member.MemberCommune;
                bd.MemberPhone = member.MemberPhone;
                bd.Transport = member.Transport;
                db.Members.Update(bd);
                db.SaveChanges();
            }
            return RedirectToAction("ProfilMember");
        }

      

    }
    
}