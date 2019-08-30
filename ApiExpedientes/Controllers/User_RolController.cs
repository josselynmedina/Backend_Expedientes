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
    public class User_RolController : Controller
    {
        private ProcesoLogisticoEntities db = new ProcesoLogisticoEntities();

        // GET: User_Rol
        public ActionResult Index()
        {
            var user_Rol = db.User_Rol.Include(u => u.Rol).Include(u => u.Usuario).Include(u => u.Usuario1).Include(u => u.Usuario2);
            return View(user_Rol.ToList());
        }

        // GET: User_Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Rol user_Rol = db.User_Rol.Find(id);
            if (user_Rol == null)
            {
                return HttpNotFound();
            }
            return View(user_Rol);
        }

        // GET: User_Rol/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription");
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: User_Rol/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,RolId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] User_Rol user_Rol)
        {
            if (ModelState.IsValid)
            {
                db.User_Rol.Add(user_Rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", user_Rol.RolId);
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.UserId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.ModifiedBy);
            return View(user_Rol);
        }

        // GET: User_Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Rol user_Rol = db.User_Rol.Find(id);
            if (user_Rol == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", user_Rol.RolId);
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.UserId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.ModifiedBy);
            return View(user_Rol);
        }

        // POST: User_Rol/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,RolId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] User_Rol user_Rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "RolDescription", user_Rol.RolId);
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.UserId);
            ViewBag.CreatedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(db.Usuarios, "UserId", "UserName", user_Rol.ModifiedBy);
            return View(user_Rol);
        }

        // GET: User_Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Rol user_Rol = db.User_Rol.Find(id);
            if (user_Rol == null)
            {
                return HttpNotFound();
            }
            return View(user_Rol);
        }

        // POST: User_Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Rol user_Rol = db.User_Rol.Find(id);
            db.User_Rol.Remove(user_Rol);
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
