using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiExpedientes.Models;
using ApiExpedientes.Repository;

namespace ApiExpedientes.Controllers
{
    public class DocumentoController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Documento
        public ActionResult Index()
        {
            var documentoes = db.Documentoes.Include(d => d.Usuario).Include(d => d.Usuario1);
            return View(documentoes.ToList());
        }

        // GET: Documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contacto1")] Documento documento)
        {
            try {
                if (ModelState.IsValid)
                {
                    DocumentosRepository DocRepo = new DocumentosRepository();
                    if (DocRepo.AddDocumentos(documento))
                    {
                        ViewBag.Message = "Agregado";
                    }
                }
                return View(documento);
            }
            catch
            {
                return View();
            }
        }

        
        // GET: Documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", documento.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", documento.CreatedBy);
            return View(documento);
        }

        // POST: Documento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentoId,Documento1,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", documento.ModifiedBy);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", documento.CreatedBy);
            return View(documento);
        }

        // GET: Documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = db.Documentoes.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documento documento = db.Documentoes.Find(id);
            db.Documentoes.Remove(documento);
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
