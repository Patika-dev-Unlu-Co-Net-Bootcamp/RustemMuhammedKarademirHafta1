using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev1.Entities.Concrete
{
    public class Brand
    {
        [Required]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "BrandName boş bırakılamaz.")]
        public string BrandName { get; set; }
    }
}
