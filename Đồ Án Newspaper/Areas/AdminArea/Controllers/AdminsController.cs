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
    public class AdminsController : Controller
    {
        private NewspaperDboV3Entities db = new NewspaperDboV3Entities();

        // GET: AdminArea/Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: AdminArea/Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: AdminArea/Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Admin_usernane,Admin_password,Admin_repassword,Admin_id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (db.Admins.Any(x => x.Admin_usernane == admin.Admin_usernane))
                {
                    ViewBag.Notification = "This Account Is Already Exit";
                    return View();
                }
                else
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }    
            }


            return View(admin);
        }

        // GET: AdminArea/Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: AdminArea/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Admin_usernane,Admin_repassword,Admin_password,Admin_id")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: AdminArea/Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: AdminArea/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var check = db.Admins.Where(x => x.Admin_usernane.Equals(admin.Admin_usernane) && x.Admin_password.Equals(admin.Admin_password)).FirstOrDefault();
            if (check != null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai username hoặc password vui lòng nhập lại";
            return RedirectToAction("Login");

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
