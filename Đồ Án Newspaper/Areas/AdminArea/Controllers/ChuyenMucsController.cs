using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Đồ_Án_Newspaper.Models;

namespace Đồ_Án_Newspaper.Areas.AdminArea.Controllers
{
    public class ChuyenMucsController : Controller
    {
        private NewspaperDboV3Entities db = new NewspaperDboV3Entities();

        // GET: AdminArea/ChuyenMucs
        public ActionResult Index()
        {           
            return View(db.ChuyenMucs.ToList());
        }

        // GET: AdminArea/ChuyenMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMucs.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // GET: AdminArea/ChuyenMucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/ChuyenMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_chuyenmuc,LoaiChuyenMuc")] ChuyenMuc chuyenMuc)
        {
            if (ModelState.IsValid)
            {
                db.ChuyenMucs.Add(chuyenMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chuyenMuc);
        }

        // GET: AdminArea/ChuyenMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMucs.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // POST: AdminArea/ChuyenMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_chuyenmuc,LoaiChuyenMuc")] ChuyenMuc chuyenMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenMuc);
        }

        // GET: AdminArea/ChuyenMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenMuc chuyenMuc = db.ChuyenMucs.Find(id);
            if (chuyenMuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenMuc);
        }

        // POST: AdminArea/ChuyenMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenMuc chuyenMuc = db.ChuyenMucs.Find(id);
            db.ChuyenMucs.Remove(chuyenMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            return View();
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
