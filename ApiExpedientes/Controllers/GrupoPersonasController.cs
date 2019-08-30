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
    public class GrupoPersonasController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: GrupoPersonas
        public ActionResult Index()
        {
            var grupoPersonas = db.GrupoPersonas.Include(g => g.Usuario).Include(g => g.Usuario1);
            return View(grupoPersonas.ToList());
        }

        // GET: GrupoPersonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPersona grupoPersona = db.GrupoPersonas.Find(id);
            if (grupoPersona == null)
            {
                return HttpNotFound();
            }
            return View(grupoPersona);
        }

        // GET: GrupoPersonas/Create
        public ActionResult Create()
        {
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: GrupoPersonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoPersonaId,GrupoPersona1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] GrupoPersona grupoPersona)
        {
            if (ModelState.IsValid)
            {
                db.GrupoPersonas.Add(grupoPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.CreatedBy);
            return View(grupoPersona);
        }

        // GET: GrupoPersonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPersona grupoPersona = db.GrupoPersonas.Find(id);
            if (grupoPersona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.CreatedBy);
            return View(grupoPersona);
        }

        // POST: GrupoPersonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupoPersonaId,GrupoPersona1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] GrupoPersona grupoPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", grupoPersona.CreatedBy);
            return View(grupoPersona);
        }

        // GET: GrupoPersonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPersona grupoPersona = db.GrupoPersonas.Find(id);
            if (grupoPersona == null)
            {
                return HttpNotFound();
            }
            return View(grupoPersona);
        }

        // POST: GrupoPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoPersona grupoPersona = db.GrupoPersonas.Find(id);
            db.GrupoPersonas.Remove(grupoPersona);
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
