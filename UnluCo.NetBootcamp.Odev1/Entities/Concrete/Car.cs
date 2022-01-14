using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev1.Entities.Concrete
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Color { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public bool isActive { get; set; }
    }
}
