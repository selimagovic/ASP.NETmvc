using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class DeviceVM
    {
        public Device Device { get; set; }
        public DeviceTypeProperties typeProperties { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
