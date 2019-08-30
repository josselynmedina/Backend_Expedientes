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
    public class ClientesController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Pai).Include(c => c.Pai1).Include(c => c.Pai2).Include(c => c.TipoIndustria1).Include(c => c.TipoFiscal).Include(c => c.Usuario).Include(c => c.Usuario1).Include(c => c.LineaProducto1).Include(c => c.Segmento1);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Mercado = new SelectList(db.Pais, "PaisId", "Pais");
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais");
            ViewBag.PaisFacturacion = new SelectList(db.Pais, "PaisId", "Pais");
            ViewBag.TipoIndustria = new SelectList(db.TipoIndustrias, "TipoIndustriaId", "TipoIndustria1");
            ViewBag.TipoRegistro = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.LineaProducto = new SelectList(db.LineaProductoes, "LineaProductoId", "LineaProducto1");
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,GrupoEmpresarial,RegistroTributario,TipoRegistro,Direccion,WebPage,Actividad,LineaProducto,Vision,Mision,Valores,Pais,Telefono,Industria,TipoIndustria,Segmento,RSE,Marcas,Mercado,PaisFacturacion,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mercado = new SelectList(db.Pais, "PaisId", "Pais", cliente.Mercado);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", cliente.Pais);
            ViewBag.PaisFacturacion = new SelectList(db.Pais, "PaisId", "Pais", cliente.PaisFacturacion);
            ViewBag.TipoIndustria = new SelectList(db.TipoIndustrias, "TipoIndustriaId", "TipoIndustria1", cliente.TipoIndustria);
            ViewBag.TipoRegistro = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", cliente.TipoRegistro);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.ModifiedBy);
            ViewBag.LineaProducto = new SelectList(db.LineaProductoes, "LineaProductoId", "LineaProducto1", cliente.LineaProducto);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", cliente.Segmento);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mercado = new SelectList(db.Pais, "PaisId", "Pais", cliente.Mercado);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", cliente.Pais);
            ViewBag.PaisFacturacion = new SelectList(db.Pais, "PaisId", "Pais", cliente.PaisFacturacion);
            ViewBag.TipoIndustria = new SelectList(db.TipoIndustrias, "TipoIndustriaId", "TipoIndustria1", cliente.TipoIndustria);
            ViewBag.TipoRegistro = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", cliente.TipoRegistro);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.ModifiedBy);
            ViewBag.LineaProducto = new SelectList(db.LineaProductoes, "LineaProductoId", "LineaProducto1", cliente.LineaProducto);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", cliente.Segmento);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,GrupoEmpresarial,RegistroTributario,TipoRegistro,Direccion,WebPage,Actividad,LineaProducto,Vision,Mision,Valores,Pais,Telefono,Industria,TipoIndustria,Segmento,RSE,Marcas,Mercado,PaisFacturacion,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mercado = new SelectList(db.Pais, "PaisId", "Pais", cliente.Mercado);
            ViewBag.Pais = new SelectList(db.Pais, "PaisId", "Pais", cliente.Pais);
            ViewBag.PaisFacturacion = new SelectList(db.Pais, "PaisId", "Pais", cliente.PaisFacturacion);
            ViewBag.TipoIndustria = new SelectList(db.TipoIndustrias, "TipoIndustriaId", "TipoIndustria1", cliente.TipoIndustria);
            ViewBag.TipoRegistro = new SelectList(db.TipoFiscals, "TipoFiscalId", "TipoFiscal1", cliente.TipoRegistro);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", cliente.ModifiedBy);
            ViewBag.LineaProducto = new SelectList(db.LineaProductoes, "LineaProductoId", "LineaProducto1", cliente.LineaProducto);
            ViewBag.Segmento = new SelectList(db.Segmentoes, "SegmentoId", "Segmento1", cliente.Segmento);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
