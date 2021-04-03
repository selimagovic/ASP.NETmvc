using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class DeviceTypeProperties
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PropertyName { get; set; }

        [DisplayName("Device Type")]
        public int DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public virtual DeviceType DeviceType { get; set; }
    }
}
