using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DevicePropertyValues
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }

        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual DeviceTypeProperties TypeProperties { get; set; }

        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
    }
}
