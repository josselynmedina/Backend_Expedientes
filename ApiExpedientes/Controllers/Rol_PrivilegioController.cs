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
    public class Rol_PrivilegioController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Rol_Privilegio
        public ActionResult Index()
        {
            var rol_Privilegio = db.Rol_Privilegio.Include(r => r.Privilegio).Include(r => r.Rol).Include(r => r.Usuario).Include(r => r.Usuario1);
            return View(rol_Privilegio.ToList());
        }

        // GET: Rol_Privilegio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Privilegio rol_Privilegio = db.Rol_Privilegio.Find(id);
            if (rol_Privilegio == null)
            {
                return HttpNotFound();
            }
            return View(rol_Privilegio);
        }

        // GET: Rol_Privilegio/Create
        public ActionResult Create()
        {
            ViewBag.PrivilegioId = new SelectList(db.Privilegios, "PrivilegiosId", "Privilegio1");
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Rol_Privilegio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RolId,PrivilegioId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Rol_Privilegio rol_Privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Rol_Privilegio.Add(rol_Privilegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrivilegioId = new SelectList(db.Privilegios, "PrivilegiosId", "Privilegio1", rol_Privilegio.PrivilegioId);
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", rol_Privilegio.RolId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.ModifiedBy);
            return View(rol_Privilegio);
        }

        // GET: Rol_Privilegio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Privilegio rol_Privilegio = db.Rol_Privilegio.Find(id);
            if (rol_Privilegio == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrivilegioId = new SelectList(db.Privilegios, "PrivilegiosId", "Privilegio1", rol_Privilegio.PrivilegioId);
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", rol_Privilegio.RolId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.ModifiedBy);
            return View(rol_Privilegio);
        }

        // POST: Rol_Privilegio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RolId,PrivilegioId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Rol_Privilegio rol_Privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_Privilegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrivilegioId = new SelectList(db.Privilegios, "PrivilegiosId", "Privilegio1", rol_Privilegio.PrivilegioId);
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", rol_Privilegio.RolId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", rol_Privilegio.ModifiedBy);
            return View(rol_Privilegio);
        }

        // GET: Rol_Privilegio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Privilegio rol_Privilegio = db.Rol_Privilegio.Find(id);
            if (rol_Privilegio == null)
            {
                return HttpNotFound();
            }
            return View(rol_Privilegio);
        }

        // POST: Rol_Privilegio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol_Privilegio rol_Privilegio = db.Rol_Privilegio.Find(id);
            db.Rol_Privilegio.Remove(rol_Privilegio);
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
