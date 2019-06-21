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
using System.Threading.Tasks;

namespace ewidencja.Controllers
{
    public class AdresyController : Controller
    {
        private EwidencjaContext db = new EwidencjaContext();

        // GET: Adresy
        public async Task<ActionResult> Index(string sortOrder, string searchString)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.PeselSortParm = String.IsNullOrEmpty(sortOrder) ? "pesel_desc" : "";
                ViewBag.UlicaSortParm = sortOrder == "ulica" ? "ulica_desc" : "ulica";
                ViewBag.MiastoSortParm = sortOrder == "miasto" ? "miasto_desc" : "miasto";
                ViewBag.GminaSortParm = sortOrder == "gmina" ? "gmina_desc" : "gmina";
                ViewBag.KodSortParm = sortOrder == "kod" ? "kod_desc" : "kod";
                ViewBag.WojSortParm = sortOrder == "woj" ? "woj_desc" : "woj";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                var adresies = from a in db.Adresies.Include(a => a.Obywatel)
                               select a;
                if (!String.IsNullOrEmpty(searchString))
                {
                    adresies = adresies.Where(a => a.Obywatel.PESEL.Contains(searchString)
                                                    || a.Ulica.Contains(searchString)
                                                    || a.Miasto.Contains(searchString)
                                                    || a.Kod_pocztowy.Contains(searchString)
                                                    || a.Gmina.Contains(searchString)
                                                    || a.Wojewodztwo.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "pesel_desc":
                        adresies = adresies.OrderByDescending(a => a.Obywatel.PESEL);
                        break;
                    case "ulica":
                        adresies = adresies.OrderBy(a => a.Ulica);
                        break;
                    case "ulica_desc":
                        adresies = adresies.OrderByDescending(a => a.Ulica);
                        break;
                    case "miasto":
                        adresies = adresies.OrderBy(a => a.Miasto);
                        break;
                    case "miasto_desc":
                        adresies = adresies.OrderByDescending(a => a.Miasto);
                        break;
                    case "gmina":
                        adresies = adresies.OrderBy(a => a.Gmina);
                        break;
                    case "gmina_desc":
                        adresies = adresies.OrderByDescending(a => a.Gmina);
                        break;
                    case "kod":
                        adresies = adresies.OrderBy(a => a.Kod_pocztowy);
                        break;
                    case "kod_desc":
                        adresies = adresies.OrderByDescending(a => a.Kod_pocztowy);
                        break;
                    case "woj":
                        adresies = adresies.OrderBy(a => a.Wojewodztwo);
                        break;
                    case "woj_desc":
                        adresies = adresies.OrderByDescending(a => a.Wojewodztwo);
                        break;
                    case "Date":
                        adresies = adresies.OrderBy(a => a.Data_zam);
                        break;
                    case "date_desc":
                        adresies = adresies.OrderByDescending(a => a.Data_zam);
                        break;
                    default:
                        adresies = adresies.OrderBy(a => a.Obywatel.PESEL);
                        break;
                }

                return View(adresies.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Adresy") });
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                   db.Adresies.Add(adresy);
                   db.SaveChanges();
                   return RedirectToAction("Index");
                }
            }
            catch(DataException/*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the " +
                    "problem persist see your system administrator");
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
