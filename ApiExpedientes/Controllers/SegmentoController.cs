using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiExpedientes.Models;

namespace ApiExpedientes.Controllers
{
    public class SegmentoController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Segmento
        public ActionResult Index()
        {
            var segmentoes = db.Segmentoes.Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(segmentoes.ToList());
        }

        // GET: Segmento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // GET: Segmento/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Segmento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SegmentoId,Segmento1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Segmentoes.Add(segmento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.ModifiedBy);
            return View(segmento);
        }

        // GET: Segmento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.ModifiedBy);
            return View(segmento);
        }

        // POST: Segmento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SegmentoId,Segmento1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", segmento.ModifiedBy);
            return View(segmento);
        }

        // GET: Segmento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentoes.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segmento segmento = db.Segmentoes.Find(id);
            db.Segmentoes.Remove(segmento);
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
