using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Magazyn3.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Magazyn3.Data;
using Magazyn3.Models.AccountViewModels;
using Magazyn3.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Magazyn3.App_Data.Controllers
{
    [Authorize(Roles = "Magazynier")]
    public class TowaryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Towary
        public ActionResult Index()
        {
            return View(db.Towary.ToList());
        }

        // GET: Towary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Towary towary = db.Towary.FirstOrDefault(c => c.IdTowaru==id);
            if (towary == null)
            {
                return NotFound();
            }
            return View(towary);
        }

        // GET: Towary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Towary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdTowaru,NazwaTowaru,Cena,Magazyn")] Towary towary)
        {
            if (ModelState.IsValid)
            {
                db.Towary.Add(towary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(towary);
        }

        // GET: Towary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Towary towary = db.Towary.FirstOrDefault(c => c.IdTowaru==id);
            if (towary == null)
            {
                return NotFound();
            }
            return View(towary);
        }

        // POST: Towary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("IdTowaru,NazwaTowaru,cena,magazyn")] Towary towary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(towary);
        }

        // GET: Towary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Towary towary = db.Towary.FirstOrDefault(c => c.IdTowaru==id);
            if (towary == null)
            {
                return NotFound();
            }
            return View(towary);
        }

        // POST: Towary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             Towary towary = db.Towary.FirstOrDefault(c => c.IdTowaru==id);
            db.Towary.Remove(towary);
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
