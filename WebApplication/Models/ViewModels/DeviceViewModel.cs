using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class DeviceViewModel
    {
        public Device Device { get; set; } 
        public DeviceType DeviceType { get; set; }
        public IEnumerable<SelectListItem> SelectDeviceType { get; set; }

        public DeviceTypePropertie DeviceTypeProperties { get; set; }
    }
}
