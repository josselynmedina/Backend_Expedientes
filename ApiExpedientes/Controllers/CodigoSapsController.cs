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
    public class CodigoSapsController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: CodigoSaps
        public ActionResult Index()
        {
            var codigoSaps = db.CodigoSaps.Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(codigoSaps.ToList());
        }

        // GET: CodigoSaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSap codigoSap = db.CodigoSaps.Find(id);
            if (codigoSap == null)
            {
                return HttpNotFound();
            }
            return View(codigoSap);
        }

        // GET: CodigoSaps/Create
        public ActionResult Create()
        {
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: CodigoSaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoSapId,CodigoSap1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] CodigoSap codigoSap)
        {
            if (ModelState.IsValid)
            {
                db.CodigoSaps.Add(codigoSap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.CreatedBy);
            return View(codigoSap);
        }

        // GET: CodigoSaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSap codigoSap = db.CodigoSaps.Find(id);
            if (codigoSap == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.CreatedBy);
            return View(codigoSap);
        }

        // POST: CodigoSaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoSapId,CodigoSap1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] CodigoSap codigoSap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codigoSap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", codigoSap.CreatedBy);
            return View(codigoSap);
        }

        // GET: CodigoSaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSap codigoSap = db.CodigoSaps.Find(id);
            if (codigoSap == null)
            {
                return HttpNotFound();
            }
            return View(codigoSap);
        }

        // POST: CodigoSaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodigoSap codigoSap = db.CodigoSaps.Find(id);
            db.CodigoSaps.Remove(codigoSap);
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
