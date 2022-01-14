using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.NetBootcamp.Odev1.Entities.Concrete;

namespace UnluCo.NetBootcamp.Odev1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private static List<Brand> Brands = new List<Brand>()
        {
            new Brand{BrandId=1,BrandName="BMW"},
            new Brand{BrandId=2,BrandName="Audi"},
            new Brand{BrandId=3,BrandName="Toyota"},
            new Brand{BrandId=4,BrandName="Mercedes"}
        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Brands);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _brand = Brands.SingleOrDefault(x => x.BrandId == id);
            if (_brand is not null)
                return Ok(_brand);
            return NoContent();
        }
        [HttpGet("listBrandNameAsc")]
        public IActionResult GetListBrandNameAsc()
        {
            List<Brand> BrandNameList = Brands.OrderBy(x => x.BrandName).ToList();
            return Ok(Brands.OrderBy(x => x.BrandName).ToList());
        }
        [HttpGet("listBrandNameDesc")]
        public IActionResult GetListBrandNameDesc()
        {
            List<Brand> BrandNameList = Brands.OrderByDescending(x => x.BrandName).ToList();
            return Ok(BrandNameList);
        }
        [HttpPost]
        public IActionResult Create([FromBody]Brand brand)
        {
            var _brand = Brands.SingleOrDefault(x => x.BrandId == brand.BrandId);
            if(_brand is null)
            {
                Brands.Add(brand);
                return StatusCode(201);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromQuery]string brandName)
        {
            var _brand = Brands.SingleOrDefault(x => x.BrandId == id);
            if (_brand is not null)
            {
                _brand.BrandName = brandName;
                return StatusCode(201);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _brand = Brands.SingleOrDefault(x => x.BrandId == id);
            if (_brand is not null)
            {
                Brands.Remove(_brand);
                return Ok(_brand.BrandId + " Idli marka sistemden silindi");
            }
            return NoContent();
        }
    }
}
