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
    public class PrivilegiosController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Privilegios
        public ActionResult Index()
        {
            var privilegios = db.Privilegios.Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(privilegios.ToList());
        }

        // GET: Privilegios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegios.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // GET: Privilegios/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Privilegios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrivilegiosId,Privilegio1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Privilegios.Add(privilegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.ModifiedBy);
            return View(privilegio);
        }

        // GET: Privilegios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegios.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.ModifiedBy);
            return View(privilegio);
        }

        // POST: Privilegios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrivilegiosId,Privilegio1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", privilegio.ModifiedBy);
            return View(privilegio);
        }

        // GET: Privilegios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = db.Privilegios.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Privilegio privilegio = db.Privilegios.Find(id);
            db.Privilegios.Remove(privilegio);
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
