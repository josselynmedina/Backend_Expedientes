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
    public class PaisController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();
        string connection_string = "Data Source=DESKTOP-F3PHG0S;database = ProcesoLogistico; integrated security=SSPI";

        // GET: Pais
        public ActionResult Index()
        {
            var pais = db.Pais.Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(pais.ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaisId,Pais,CreateDate,ModifiedDate,CreatedBy,ModifiedBy")] Pai pai)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Pais.Add(pai);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.ModifiedBy);
            //ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.CreatedBy);

            return View(pai);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.CreatedBy);
            return View(pai);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaisId,Pais,CreateDate,ModifiedDate,CreatedBy,ModifiedBy")] Pai pai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", pai.CreatedBy);
            return View(pai);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pai pai = db.Pais.Find(id);
            if (pai == null)
            {
                return HttpNotFound();
            }
            return View(pai);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pai pai = db.Pais.Find(id);
            db.Pais.Remove(pai);
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
