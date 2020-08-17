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
    }
}