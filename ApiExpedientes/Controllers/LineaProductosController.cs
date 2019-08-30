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
    public class LineaProductosController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: LineaProductos
        public ActionResult Index()
        {
            var lineaProductoes = db.LineaProductoes.Include(l => l.Usuario).Include(l => l.Usuario1);
            return View(lineaProductoes.ToList());
        }

        // GET: LineaProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaProducto lineaProducto = db.LineaProductoes.Find(id);
            if (lineaProducto == null)
            {
                return HttpNotFound();
            }
            return View(lineaProducto);
        }

        // GET: LineaProductos/Create
        public ActionResult Create()
        {
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: LineaProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaProductoId,LineaProducto1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] LineaProducto lineaProducto)
        {
            if (ModelState.IsValid)
            {
                db.LineaProductoes.Add(lineaProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.CreatedBy);
            return View(lineaProducto);
        }

        // GET: LineaProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaProducto lineaProducto = db.LineaProductoes.Find(id);
            if (lineaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.CreatedBy);
            return View(lineaProducto);
        }

        // POST: LineaProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaProductoId,LineaProducto1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] LineaProducto lineaProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", lineaProducto.CreatedBy);
            return View(lineaProducto);
        }

        // GET: LineaProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaProducto lineaProducto = db.LineaProductoes.Find(id);
            if (lineaProducto == null)
            {
                return HttpNotFound();
            }
            return View(lineaProducto);
        }

        // POST: LineaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaProducto lineaProducto = db.LineaProductoes.Find(id);
            db.LineaProductoes.Remove(lineaProducto);
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
