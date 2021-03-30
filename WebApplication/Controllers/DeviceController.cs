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
    public class DeviceController : Controller
    {
        #region Variables

        private readonly ApplicationDbContext _db;
        #endregion
        #region Constructor
        public DeviceController(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion
        #region Custom Methods
        public IActionResult Index()
        {
            IEnumerable<Device> objList = _db.Devices;
            foreach (var obj in objList)
            {
                //This part of code will set FK of other table to this table and use it as its own
                //example: obj.EpexpenseType.Name
                obj.DeviceType = _db.DeviceTypes.FirstOrDefault(u => u.Id == obj.DeviceTypeId);
            }
            return View(objList);
        }

        /// <summary>
        /// GET-returns view of Expenses Index Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            DeviceVM deviceVM = new DeviceVM()
            {
                Device = new Device(),
                TypeDropDown = _db.DeviceTypes.Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };
            return View(deviceVM);
        }
        /// <summary>
        /// GET-Method creates/adds Expence object to DB of Expenses
        /// </summary>
        /// <param name="expenceObj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceVM obj)
        {
            //check if fields are empty
            if (ModelState.IsValid)
            {
                _db.Devices.Add(obj.Device);
                _db.SaveChanges();
                return RedirectToAction("Index");
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
            var obj = _db.Devices.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Devices.Remove(obj);
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
            var obj = _db.Devices.Find(id);
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
        public IActionResult Update(DeviceVM obj)
        {
            //check if fields are empty
            if (ModelState.IsValid)
            {
                _db.Devices.Update(obj.Device);
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
            DeviceVM deviceVM = new DeviceVM()
            {
                Device = new Device(),
                TypeDropDown = _db.DeviceTypes.Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
            };
            if (id == null || id == 0)
            {
                return NotFound();
            }
            deviceVM.Device = _db.Devices.Find(id);
            if (deviceVM == null)
            {
                return NotFound();
            }
            return View(deviceVM);
        }
        #endregion
    }
}
