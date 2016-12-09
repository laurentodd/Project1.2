using Project1.DAL;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private Project1Context db = new Project1Context();


        public ActionResult Index()
        {   
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Degrees()
        {
             ViewBag.Message = "Learn about the degrees offered in Information Systems";
            return View();
        }

         [Authorize]
        public ActionResult SelectedDegree(string degree)
        {
            if (degree == "BSIS")
            {
                ViewBag.Title = "Bachelor of Science Information Systems";
                ViewBag.DegreeName = "Bachelor's of Science Information Systems";
                ViewBag.Coordinator = "Dr. Conan Albrecht";
                ViewBag.ProfTitle = "Professor of Information Systems";
                ViewBag.Address = "780 TNRB";
                ViewBag.PhD = "Doctor of Philosophy, Management, Management Information Systems Department, University of Arizona, 2000";
                ViewBag.Masters = "Masters of Accountancy, School of Accountancy and Information Systems, Brigham Young University, 1997";
                ViewBag.Bachelors = "Bachelors of Science, School of Accountancy and Information Systems, Brigham Young University, 1997";
                ViewBag.Picture = Url.Content("http://www.devincollier.com/wp-content/uploads/albrecht.jpg");
            }

            else if (degree == "MISM") {
                ViewBag.Title = "Masters of Information Systems Management";
                ViewBag.DegreeName = "Masters of Information Systems Management";
                ViewBag.Coordinator = "Dr. Bonnie Anderson";
                ViewBag.ProfTitle = "Associate Professor of Information Systems";
                ViewBag.Address = "776 TNRB";
                ViewBag.PhD = "Doctor of Philosophy, Information Systems, Carnegie Mellon University, 2001";
                ViewBag.Masters = "Masters of Philosophy, Piblic Policy,  Carnegie Mellon University, 2000";
                ViewBag.Masters = "Masters of Accounting, Information Systems, Brigham Young University, 1995";
                ViewBag.Bachelors = "Bachelors of Science, School of Accountancy, Brigham Young University, 1995";
                ViewBag.Picture = Url.Content("http://neurosecurity.byu.edu/wp-content/uploads/2015/01/bonnie_brinton_anderson.jpg");

            }
            return View();
        }
        //Login

        public ActionResult Login()
        {
            return View();
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(Users account, bool bRememberMe = false)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(account);
                db.SaveChanges();

                ModelState.Clear();
                Session["UserID"] = account.UserID;
                Session["Username"] = account.Email;
                FormsAuthentication.SetAuthCookie(account.Email.ToString(), bRememberMe);

                return RedirectToAction("Degrees");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(Users account, FormCollection form, int? id, bool rememberMe = false)
        {
            Session["degrees"] = id;
            //Session["userID"] = userid;

            using (Project1Context db = new Project1Context())
            {
                //var usr = db.user.Single(u => u.userEmail = account.userEmail && u.uPassword == account.uPassword).FirstOrDefault;
                var usr = db.User.Where(Users => Users.Email == account.Email && Users.Password == account.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["username"] = usr.Email.ToString();
                    FormsAuthentication.SetAuthCookie(usr.Email, rememberMe);
                    return RedirectToAction("Degrees", "Home", new { id = Session["degrees"], userid = Session["UserID"] });
                    // return RedirectToAction("Index", "MissionQuestions", new { id = Session["mission"] });

                }
                else
                {
                    ModelState.AddModelError(" ", "Username or password is wrong. ");
                    // return RedirectToAction("Index");
                }


            }
            return View();


        }

    }


}