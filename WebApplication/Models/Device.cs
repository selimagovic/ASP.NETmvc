using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public virtual DeviceType DeviceType { get; set; }
    }
}
