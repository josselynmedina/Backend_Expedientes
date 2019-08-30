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
    public class ProveedorController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Proveedor
        public ActionResult Index()
        {
            var proveedors = db.Proveedors.Include(p => p.Cliente1).Include(p => p.GrupoPersona1).Include(p => p.Pai).Include(p => p.Pai1).Include(p => p.Segmento1).Include(p => p.TipoFiscal).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(proveedors.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial");
            ViewBag.GrupoPersona = new SelectList(db.GrupoPersonas, "GrupoPersonaId", "GrupoPersona1");
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais");
            ViewBag.PaisOperacion = new SelectList(db.Pais, "PaisId", "Pais");
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1");
            ViewBag.TipoIdentificador = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: Proveedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProveedorId,Proveedor1,IdentificadorFiscal,TipoIdentificador,GrupoPersona,Cliente,Pais,PaisOperacion,Segmento,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedors.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", proveedor.Cliente);
            ViewBag.GrupoPersona = new SelectList(db.GrupoPersonas, "GrupoPersonaId", "GrupoPersona1", proveedor.GrupoPersona);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", proveedor.Pais);
            ViewBag.PaisOperacion = new SelectList(db.Pais, "PaisId", "Pais", proveedor.PaisOperacion);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", proveedor.Segmento);
            ViewBag.TipoIdentificador = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", proveedor.TipoIdentificador);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.ModifiedBy);
            return View(proveedor);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", proveedor.Cliente);
            ViewBag.GrupoPersona = new SelectList(db.GrupoPersonas, "GrupoPersonaId", "GrupoPersona1", proveedor.GrupoPersona);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", proveedor.Pais);
            ViewBag.PaisOperacion = new SelectList(db.Pais, "PaisId", "Pais", proveedor.PaisOperacion);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", proveedor.Segmento);
            ViewBag.TipoIdentificador = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", proveedor.TipoIdentificador);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.ModifiedBy);
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProveedorId,Proveedor1,IdentificadorFiscal,TipoIdentificador,GrupoPersona,Cliente,Pais,PaisOperacion,Segmento,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", proveedor.Cliente);
            ViewBag.GrupoPersona = new SelectList(db.GrupoPersonas, "GrupoPersonaId", "GrupoPersona1", proveedor.GrupoPersona);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", proveedor.Pais);
            ViewBag.PaisOperacion = new SelectList(db.Pais, "PaisId", "Pais", proveedor.PaisOperacion);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", proveedor.Segmento);
            ViewBag.TipoIdentificador = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", proveedor.TipoIdentificador);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", proveedor.ModifiedBy);
            return View(proveedor);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            db.Proveedors.Remove(proveedor);
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
