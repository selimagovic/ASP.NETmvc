using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
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
        public IActionResult Index()
        {
            IEnumerable<Device> objList = _db.Devices;
            //foreach (var obj in objList)
            //{
            //    //This part of code will set FK of other table to this table and use it as its own
            //    //example: obj.EpexpenseType.Name
            //    obj.DeviceType = _db.DeviceTypes.FirstOrDefault(u => u.Id == obj.DeviceTypeId);
            //}
            return View(objList);
        }
    }
}
