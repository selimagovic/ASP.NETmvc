using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeviceTypeController : Controller
    {
        #region Variables
        private readonly ApplicationDbContext _db;

        #endregion

        #region Constructor
        public DeviceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Custom Methods
        public IActionResult Index()
        {
            IEnumerable<DeviceType> obj = _db.DeviceTypes;
            return View(obj);
        }

        /// <summary>
        /// GET-returns view of Expenses Index Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// GET-Method creates/adds Expence object to DB of Expenses
        /// </summary>
        /// <param name="expenceObj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceType obj)
        {
            //check if fields are empty
            if (ModelState.IsValid)
            {
                _db.DeviceTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Properties");
            }
            return View(obj);
        }
        /// <summary>
        /// Delete-Method deletes/removes Expence object to DB of Expenses
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.DeviceTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.DeviceTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Get-Delete action view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
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


        /// <summary>
        /// POST -Update-Method updates/changes Expense object to DB of Expenses
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DeviceType obj)
        {
            //check if fields are empty
            if (ModelState.IsValid)
            {
                _db.DeviceTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        /// <summary>
        /// Get-Update returns View for updating object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Update(int? id)
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
        #endregion
    }
}
