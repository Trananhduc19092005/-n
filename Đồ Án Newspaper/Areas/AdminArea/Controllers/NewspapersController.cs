using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Đồ_Án_Newspaper.Models;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Đồ_Án_Newspaper.Areas.AdminArea.Controllers
{
    public class NewspapersController : Controller 
    {
        private NewspaperDboV3Entities db = new NewspaperDboV3Entities();

        // GET: AdminArea/Newspapers
        public ActionResult Index()
        {
            var newspapers = db.Newspapers.Include(n => n.Admin).Include(n => n.ChuyenMuc);
            return View(newspapers.ToList());
        }

        // GET: AdminArea/Newspapers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            return View(newspaper);
        }

        // GET: AdminArea/Newspapers/Create
        public ActionResult Create()
        {
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_id", "Admin_usernane");
            ViewBag.Id_chuyenmuc = new SelectList(db.ChuyenMucs, "Id_chuyenmuc", "LoaiChuyenMuc");
            return View();
        }

        // POST: AdminArea/Newspapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_bao,Anh,NoiDung,TieuDe,Admin_id,TieuDePhu,Id_chuyenmuc")] Newspaper newspaper)
        {
            
            if (ModelState.IsValid)
            {
                
                    db.Newspapers.Add(newspaper);
                    db.SaveChanges();
                    return RedirectToAction("index");
                
            }

            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_id", "Admin_usernane", newspaper.Admin_id);
            ViewBag.Id_chuyenmuc = new SelectList(db.ChuyenMucs, "Id_chuyenmuc", "LoaiChuyenMuc", newspaper.Id_chuyenmuc);
            return View(newspaper);
        }

        // GET: AdminArea/Newspapers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_id", "Admin_usernane", newspaper.Admin_id);
            ViewBag.Id_chuyenmuc = new SelectList(db.ChuyenMucs, "Id_chuyenmuc", "LoaiChuyenMuc", newspaper.Id_chuyenmuc);
            return View(newspaper);
        }

        // POST: AdminArea/Newspapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_bao,Anh,NoiDung,TieuDe,Admin_id,Id_chuyenmuc")] Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newspaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_id", "Admin_usernane", newspaper.Admin_id);
            ViewBag.Id_chuyenmuc = new SelectList(db.ChuyenMucs, "Id_chuyenmuc", "LoaiChuyenMuc", newspaper.Id_chuyenmuc);
            return View(newspaper);
        }

        // GET: AdminArea/Newspapers/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            return View(newspaper);
        }

        // POST: AdminArea/Newspapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            db.Newspapers.Remove(newspaper);
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
