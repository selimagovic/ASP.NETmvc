using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Set(int? id)
        {
            if (id != null)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                DeviceViewModel obj = new DeviceViewModel()
                {
                    DeviceType = _db.DeviceTypes.Find(id)
                };
                if (obj.DeviceType is null)
                {
                    return NotFound();
                }
                return View(obj);
            }
            return NotFound();
        }
        /// <summary>
        /// POST-Set 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Set(DeviceViewModel obj)
        {
           // Console.WriteLine(obj);
            if (ModelState.IsValid)
            {
               _db.DeviceTypeProperties.Add(obj.DeviceTypeProperties);
               _db.SaveChanges();

                return RedirectToAction("Index", "DeviceType");
            }
            return RedirectToAction("Index","DeviceType");
        }
    }
}
