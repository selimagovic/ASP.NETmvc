using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class DeviceTypePropertiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DeviceTypePropertiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Set()
        {
            return View();
        }
        /// <summary>
        /// POST-Set 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Set(DeviceViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.DeviceTypeProperties.Add(obj.DeviceTypeProperties);
                _db.SaveChanges();

                return RedirectToAction("Index", "DeviceType");
            }
            return View(obj);
        }
    }
}
