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
    public class SolicitudCreditoController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: SolicitudCredito
        public ActionResult Index()
        {
            var solicitudCreditoes = db.SolicitudCreditoes.Include(s => s.Cliente1).Include(s => s.Moneda).Include(s => s.TipoPago1).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(solicitudCreditoes.ToList());
        }

        // GET: SolicitudCredito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCredito solicitudCredito = db.SolicitudCreditoes.Find(id);
            if (solicitudCredito == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCredito);
        }

        // GET: SolicitudCredito/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial");
            ViewBag.Modeda = new SelectList(db.Monedas, "MonedaId", "Moneda1");
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "TipoPagoId", "TipoPago1");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: SolicitudCredito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditoId,Cliente,TramitesMensualesEsperados,ProyeccionCM1Mensual,ProyeccionVolumenMensual,MontoSolicitado,TiempoCredito,Modeda,Division,TipoPago,FinanciamientoImpuestos,TiempoCreditoImpuesto,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] SolicitudCredito solicitudCredito)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudCreditoes.Add(solicitudCredito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", solicitudCredito.Cliente);
            ViewBag.Modeda = new SelectList(db.Monedas, "MonedaId", "Moneda1", solicitudCredito.Modeda);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "TipoPagoId", "TipoPago1", solicitudCredito.TipoPago);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.ModifiedBy);
            return View(solicitudCredito);
        }

        // GET: SolicitudCredito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCredito solicitudCredito = db.SolicitudCreditoes.Find(id);
            if (solicitudCredito == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", solicitudCredito.Cliente);
            ViewBag.Modeda = new SelectList(db.Monedas, "MonedaId", "Moneda1", solicitudCredito.Modeda);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "TipoPagoId", "TipoPago1", solicitudCredito.TipoPago);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.ModifiedBy);
            return View(solicitudCredito);
        }

        // POST: SolicitudCredito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditoId,Cliente,TramitesMensualesEsperados,ProyeccionCM1Mensual,ProyeccionVolumenMensual,MontoSolicitado,TiempoCredito,Modeda,Division,TipoPago,FinanciamientoImpuestos,TiempoCreditoImpuesto,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] SolicitudCredito solicitudCredito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudCredito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Clientes, "ClienteId", "GrupoEmpresarial", solicitudCredito.Cliente);
            ViewBag.Modeda = new SelectList(db.Monedas, "MonedaId", "Moneda1", solicitudCredito.Modeda);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "TipoPagoId", "TipoPago1", solicitudCredito.TipoPago);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", solicitudCredito.ModifiedBy);
            return View(solicitudCredito);
        }

        // GET: SolicitudCredito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCredito solicitudCredito = db.SolicitudCreditoes.Find(id);
            if (solicitudCredito == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCredito);
        }

        // POST: SolicitudCredito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudCredito solicitudCredito = db.SolicitudCreditoes.Find(id);
            db.SolicitudCreditoes.Remove(solicitudCredito);
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
