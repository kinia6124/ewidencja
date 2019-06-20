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
    public class AdresyController : Controller
    {
        private EwidencjaContext db = new EwidencjaContext();

        // GET: Adresy
        public ActionResult Index()
        {
            var adresies = db.Adresies.Include(a => a.Obywatel);
            return View(adresies.ToList());
        }

        // GET: Adresy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresy adresy = db.Adresies.Find(id);
            if (adresy == null)
            {
                return HttpNotFound();
            }
            return View(adresy);
        }

        // GET: Adresy/Create
        public ActionResult Create()
        {
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL");
            return View();
        }

        // POST: Adresy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ObywatelID,Ulica,Miasto,Kod_pocztowy,Poczta,Gmina,Powiat,Wojewodztwo,Data_zam,Data_wym,Pobyt,Statusadr")] Adresy adresy)
        {
            if (ModelState.IsValid)
            {
                db.Adresies.Add(adresy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", adresy.ObywatelID);
            return View(adresy);
        }

        // GET: Adresy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresy adresy = db.Adresies.Find(id);
            if (adresy == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", adresy.ObywatelID);
            return View(adresy);
        }

        // POST: Adresy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ObywatelID,Ulica,Miasto,Kod_pocztowy,Poczta,Gmina,Powiat,Wojewodztwo,Data_zam,Data_wym,Pobyt,Statusadr")] Adresy adresy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObywatelID = new SelectList(db.Obywatels, "ID", "PESEL", adresy.ObywatelID);
            return View(adresy);
        }

        // GET: Adresy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresy adresy = db.Adresies.Find(id);
            if (adresy == null)
            {
                return HttpNotFound();
            }
            return View(adresy);
        }

        // POST: Adresy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresy adresy = db.Adresies.Find(id);
            db.Adresies.Remove(adresy);
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
