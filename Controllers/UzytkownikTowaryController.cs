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
    [Authorize(Roles = "Uzytkownik")]
    public class UzytkownikTowaryController : Controller
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
