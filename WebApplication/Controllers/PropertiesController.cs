using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PropertiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<DeviceType> obj = _db.DeviceTypes;
            return View(obj);
        }
        /// <summary>
        /// GET/Create method returns view of CreateAction
        /// </summary>
        /// <returns></returns>
        public IActionResult Create(DeviceTypeProperties obj)
        {
            if (ModelState.IsValid)
            {
                _db.DeviceTypeProperties.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
