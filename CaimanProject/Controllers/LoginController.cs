using CaimanProject.DAL;
using CaimanProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CaimanProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        //POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName, UserPnom, UserMail, UserPhone, UserSexe, Password, ConfirmPassword")] RegisterViewMode model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DbCaimanContext())
                {
                    User user = new User();
                    user.UserName = model.UserName;
                    user.UserPnom = model.UserPnom;
                    user.UserMail = model.UserMail;
                    user.UserSexe = model.UserSexe;
                    user.UserPhone = model.UserPhone;
                    user.Password = model.Password;
                    user.ConfirmPassword = model.ConfirmPassword;

                    db.Users.Add(user);
                    db.SaveChanges();
                }

                ViewBag.Message = "Utilisateur Enregistré";

                ModelState.Clear(); //Nettoyage des champs du formulaire

                return View("Register");
            }
            else
            {
                return View("Register", model);
            }
        }

        //GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewMode model)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(model);

                if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserMail, true); //Ticket d'authentification, valeur false pur empêcher l'enregistrement des cookies sur le navigateur
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Echec de connexion", "Tentative de connexion non valide");
                    return View();
                }

            }
            else
            {
                return View(model);
            }
        }

        //Fonction de Vérification de l'existance d'un utilisateur
        public User IsValidUser(LoginViewMode model)
        {
            using (var db = new DbCaimanContext())
            {
                User user = db.Users.Where(q => q.UserMail.Equals(model.UserMail) && q.Password.Equals(model.Password)).SingleOrDefault();

                if (user == null)
                    return null;
                else
                    return user;
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}