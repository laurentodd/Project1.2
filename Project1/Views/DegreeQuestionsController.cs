using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.DAL;
using Project1.Models;

namespace Project1.Views
{
    public class DegreeQuestionsController : Controller
    {
        private Project1Context db = new Project1Context();

        // GET: DegreeQuestions
        public ActionResult Index()
        {
            return View(db.DegreeQuestion.ToList());
        }

        // GET: DegreeQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestions degreeQuestions = db.DegreeQuestion.Find(id);
            if (degreeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestions);
        }

        // GET: DegreeQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DegreeQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeQuestionID,DegreeID,UserID,Question,Answer")] DegreeQuestions degreeQuestions)
        {
            if (ModelState.IsValid)
            {
                db.DegreeQuestion.Add(degreeQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degreeQuestions);
        }

        // GET: DegreeQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestions degreeQuestions = db.DegreeQuestion.Find(id);
            if (degreeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestions);
        }

        // POST: DegreeQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeQuestionID,DegreeID,UserID,Question,Answer")] DegreeQuestions degreeQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degreeQuestions);
        }

        // GET: DegreeQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestions degreeQuestions = db.DegreeQuestion.Find(id);
            if (degreeQuestions == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestions);
        }

        // POST: DegreeQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeQuestions degreeQuestions = db.DegreeQuestion.Find(id);
            db.DegreeQuestion.Remove(degreeQuestions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
