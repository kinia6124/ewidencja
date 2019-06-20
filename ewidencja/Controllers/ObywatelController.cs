﻿using System;
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
    public class ObywatelController : Controller
    {
        private EwidencjaContext db = new EwidencjaContext();

        // GET: Obywatel
        public ActionResult Index()
        {
            return View(db.Obywatels.ToList());
        }

        // GET: Obywatel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatels.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            return View(obywatel);
        }

        // GET: Obywatel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obywatel/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PESEL,Imie,Drugie_imie,Nazwisko,Data_urodzenia,Data_zgonu,Status")] Obywatel obywatel)
        {
            if (ModelState.IsValid)
            {
                db.Obywatels.Add(obywatel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obywatel);
        }

        // GET: Obywatel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatels.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            return View(obywatel);
        }

        // POST: Obywatel/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PESEL,Imie,Drugie_imie,Nazwisko,Data_urodzenia,Data_zgonu,Status")] Obywatel obywatel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obywatel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obywatel);
        }

        // GET: Obywatel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obywatel obywatel = db.Obywatels.Find(id);
            if (obywatel == null)
            {
                return HttpNotFound();
            }
            return View(obywatel);
        }

        // POST: Obywatel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obywatel obywatel = db.Obywatels.Find(id);
            db.Obywatels.Remove(obywatel);
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
