using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev1.Entities.Concrete
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public int BrandId { get; set; }
        public string Color { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Aktiflik durumu boş bırakılamaz.")]
        public bool? isActive { get; set; }
    }
}
