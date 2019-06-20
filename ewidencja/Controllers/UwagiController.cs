using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ewidencja.DAL;
using ewidencja.Models;

namespace ewidencja.Controllers
{
    public class UwagiController : Controller
    {
        private EwidencjaContext db = new EwidencjaContext();

        // GET: Uwagi
        public ActionResult Index()
        {
            var uwagis = db.Uwagis.Include(u => u.Obywatel);
            return View(uwagis.ToList());
        }

        // GET: Uwagi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uwagi uwagi = db.Uwagis.Find(id);
            if (uwagi == null)
            {
                return HttpNotFound();
            }
            return View(uwagi);
        }

        // GET: Uwagi/Create
        public ActionResult Create()
        {
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL");
            return View();
        }

        // POST: Uwagi/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ObywatelID,Opis")] Uwagi uwagi)
        {
            if (ModelState.IsValid)
            {
                db.Uwagis.Add(uwagi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", uwagi.ObywatelID);
            return View(uwagi);
        }

        // GET: Uwagi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uwagi uwagi = db.Uwagis.Find(id);
            if (uwagi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", uwagi.ObywatelID);
            return View(uwagi);
        }

        // POST: Uwagi/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ObywatelID,Opis")] Uwagi uwagi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uwagi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", uwagi.ObywatelID);
            return View(uwagi);
        }

        // GET: Uwagi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uwagi uwagi = db.Uwagis.Find(id);
            if (uwagi == null)
            {
                return HttpNotFound();
            }
            return View(uwagi);
        }

        // POST: Uwagi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uwagi uwagi = db.Uwagis.Find(id);
            db.Uwagis.Remove(uwagi);
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
