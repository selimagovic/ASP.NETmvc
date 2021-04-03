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
    public class SetDeviceController : Controller
    {
        #region Variables

        private readonly ApplicationDbContext _db;
        #endregion

        public SetDeviceController(ApplicationDbContext db)
        {
            _db = db;
            //}
            ///// <summary>
            ///// POST request create or edit
            ///// </summary>
            ///// <param name="devType"></param>
            ///// <returns></returns>

            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult SetDevice(ViewModel obj )
            //{
            //    if(ModelState.IsValid)
            //    {
            //        _db.Devices.Add(obj.Device);
            //        _db.DeviceTypes.Add(obj.DeviceType);
            //        _db.SaveChanges();
            //        return RedirectToAction("Index", "Device");
            //    }

            //    return View(obj);

            //}
        }
    }
}
