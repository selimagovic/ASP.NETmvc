using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class DeviceController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DeviceController(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// GET-index page of Device Model
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int? id)
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
        /// GET-Create
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
                DeviceViewModel obj = new DeviceViewModel()
                {
                    Device = _db.Devices.Find(id),
                    SelectDeviceType = _db.DeviceTypes.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };

                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
            DeviceViewModel deviceViewModel = new DeviceViewModel()
            {
                DeviceType = new DeviceType(),
                SelectDeviceType = _db.DeviceTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(deviceViewModel);
        }
        /// <summary>
        /// POST- create Device Name
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Set(DeviceViewModel obj, int? id)
        {
            //check if fields are empty
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    _db.Devices.Add(obj.Device);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Devices.Update(obj.Device);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
