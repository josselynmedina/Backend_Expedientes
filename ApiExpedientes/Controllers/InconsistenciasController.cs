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
    public class InconsistenciasController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Inconsistencias
        public ActionResult Index()
        {
            var inconsistencias = db.Inconsistencias.Include(i => i.Categoria1).Include(i => i.Cliente1).Include(i => i.Documento1).Include(i => i.Usuario).Include(i => i.Proveedor1).Include(i => i.Usuario1);
            return View(inconsistencias.ToList());
        }

        // GET: Inconsistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconsistencia inconsistencia = db.Inconsistencias.Find(id);
            if (inconsistencia == null)
            {
                return HttpNotFound();
            }
            return View(inconsistencia);
        }

        // GET: Inconsistencias/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categorias, "CategoriaId", "Categoria1");
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial");
            ViewBag.Documento = new SelectList(db.Documentoes, "DocumentoId", "Documento1");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.Proveedor = new SelectList(db.Proveedors, "ProveedorId", "Proveedor1");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Inconsistencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InconsistenciaId,FechaRegistro,FechaRecepcion,Cliente,HojaRuta,Proveedor,Documento,NumeroDocumento,Categoria,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Inconsistencia inconsistencia)
        {
            if (ModelState.IsValid)
            {
                db.Inconsistencias.Add(inconsistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categorias, "CategoriaId", "Categoria1", inconsistencia.Categoria);
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", inconsistencia.Cliente);
            ViewBag.Documento = new SelectList(db.Documentoes, "DocumentoId", "Documento1", inconsistencia.Documento);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.ModifiedBy);
            ViewBag.Proveedor = new SelectList(db.Proveedors, "ProveedorId", "Proveedor1", inconsistencia.Proveedor);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.CreatedBy);
            return View(inconsistencia);
        }

        // GET: Inconsistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconsistencia inconsistencia = db.Inconsistencias.Find(id);
            if (inconsistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "CategoriaId", "Categoria1", inconsistencia.Categoria);
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", inconsistencia.Cliente);
            ViewBag.Documento = new SelectList(db.Documentoes, "DocumentoId", "Documento1", inconsistencia.Documento);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.ModifiedBy);
            ViewBag.Proveedor = new SelectList(db.Proveedors, "ProveedorId", "Proveedor1", inconsistencia.Proveedor);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.CreatedBy);
            return View(inconsistencia);
        }

        // POST: Inconsistencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InconsistenciaId,FechaRegistro,FechaRecepcion,Cliente,HojaRuta,Proveedor,Documento,NumeroDocumento,Categoria,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Inconsistencia inconsistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inconsistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "CategoriaId", "Categoria1", inconsistencia.Categoria);
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", inconsistencia.Cliente);
            ViewBag.Documento = new SelectList(db.Documentoes, "DocumentoId", "Documento1", inconsistencia.Documento);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.ModifiedBy);
            ViewBag.Proveedor = new SelectList(db.Proveedors, "ProveedorId", "Proveedor1", inconsistencia.Proveedor);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", inconsistencia.CreatedBy);
            return View(inconsistencia);
        }

        // GET: Inconsistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inconsistencia inconsistencia = db.Inconsistencias.Find(id);
            if (inconsistencia == null)
            {
                return HttpNotFound();
            }
            return View(inconsistencia);
        }

        // POST: Inconsistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inconsistencia inconsistencia = db.Inconsistencias.Find(id);
            db.Inconsistencias.Remove(inconsistencia);
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
