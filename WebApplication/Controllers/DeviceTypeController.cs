using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeviceTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DeviceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<DeviceType> deviceTypes = _db.DeviceTypes;
            return View(deviceTypes);
        }
        /// <summary>
        /// GET-Set Device Type
        /// </summary>
        /// <returns></returns>
        public IActionResult Set(int? id)
        {
            if (id != null)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var obj = _db.DeviceTypes.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
            return View();
        }

        /// <summary>
        /// SET-POST
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Set(DeviceType deviceType,int? id)
        {            
            if (ModelState.IsValid)
            {
                if(id==null)
                {
                    _db.DeviceTypes.Add(deviceType);
                    _db.SaveChanges();
                }
                else
                {
                    _db.DeviceTypes.Update(deviceType);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(deviceType);
        }

    }
}
