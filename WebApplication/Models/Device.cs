using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Device Name")]
        [Required]
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public int DeviceTypeId { get; set; }
    }
}
