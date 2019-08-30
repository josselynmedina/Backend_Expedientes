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
    public class TipoIndustriasController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: TipoIndustrias
        public ActionResult Index()
        {
            var tipoIndustrias = db.TipoIndustrias.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoIndustrias.ToList());
        }

        // GET: TipoIndustrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIndustria tipoIndustria = db.TipoIndustrias.Find(id);
            if (tipoIndustria == null)
            {
                return HttpNotFound();
            }
            return View(tipoIndustria);
        }

        // GET: TipoIndustrias/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: TipoIndustrias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoIndustriaId,TipoIndustria1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] TipoIndustria tipoIndustria)
        {
            if (ModelState.IsValid)
            {
                db.TipoIndustrias.Add(tipoIndustria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.ModifiedBy);
            return View(tipoIndustria);
        }

        // GET: TipoIndustrias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIndustria tipoIndustria = db.TipoIndustrias.Find(id);
            if (tipoIndustria == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.ModifiedBy);
            return View(tipoIndustria);
        }

        // POST: TipoIndustrias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoIndustriaId,TipoIndustria1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] TipoIndustria tipoIndustria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoIndustria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", tipoIndustria.ModifiedBy);
            return View(tipoIndustria);
        }

        // GET: TipoIndustrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIndustria tipoIndustria = db.TipoIndustrias.Find(id);
            if (tipoIndustria == null)
            {
                return HttpNotFound();
            }
            return View(tipoIndustria);
        }

        // POST: TipoIndustrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoIndustria tipoIndustria = db.TipoIndustrias.Find(id);
            db.TipoIndustrias.Remove(tipoIndustria);
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
