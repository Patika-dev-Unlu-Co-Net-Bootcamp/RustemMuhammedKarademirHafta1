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
    public class CarsController : ControllerBase
    {
        List<Car> Cars = new List<Car>()
        {
            new Car{CarId=1,BrandId=1,Color="Mavi",ModelName="5.2",ModelYear=2015,isActive=true},
            new Car{CarId=2,BrandId=2,Color="Kırmızı",ModelName="A3",ModelYear=2020,isActive=true},
            new Car{CarId=3,BrandId=3,Color="Siyah",ModelName="Auris",ModelYear=2014,isActive=true},
            new Car{CarId=4,BrandId=4,Color="Beyaz",ModelName="c180",ModelYear=2018,isActive=false}
        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Cars);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _car = Cars.SingleOrDefault(x => x.CarId == id);
            if (_car is not null)
                return Ok(_car);
            return BadRequest("Girilen Id sistemde kayıtlı değil");
        }
        [HttpGet("listCarYearAsc")]
        public IActionResult GetListCarYearAsc()
        {
            List<Car> CarYearList = Cars.OrderBy(x => x.ModelYear).ToList();
            return Ok(CarYearList);
        }
        [HttpGet("listCarYearDesc")]
        public IActionResult GetListCarYearDesc()
        {
            List<Car> CarYearList = Cars.OrderByDescending(x => x.ModelYear).ToList();
            return Ok(CarYearList);
        }
        [HttpPost]
        public IActionResult Create([FromBody]Car car)
        {
            var _brand = Cars.SingleOrDefault(x => x.CarId == car.CarId);
            if (_brand is null)
            {
                Cars.Add(car);
                return Ok(car.CarId + " Idli araç sisteme eklendi");
            }
            return BadRequest("Girilen Id sistemde kayıtlı");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm]Car car)
        {
            var _car = Cars.SingleOrDefault(x => x.CarId == id);
            if (_car is not null)
            {
                _car.BrandId = car.BrandId;
                _car.Color = car.Color;
                _car.ModelName = car.ModelName;
                _car.ModelYear = car.ModelYear;
                return Ok(id + " Idli araç bilgileri güncellendi");
            }
            return BadRequest("Girilen Id sistemde kayıtlı değil");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _car = Cars.SingleOrDefault(x => x.CarId == id);
            if (_car is not null)
            {
                Cars.Remove(_car);
                return Ok(_car.CarId + " Idli araç sistemden silindi");
            }
            return BadRequest("Girilen Id sistemde kayıtlı değil");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, bool isActive)
        {
            var _car = Cars.SingleOrDefault(x => x.CarId == id);
            if (_car is not null)
            {
                _car.isActive = isActive;
                return Ok(id + " Idli araç bilgileri güncellendi");
            }
            return BadRequest("Girilen Id sistemde kayıtlı değil");
        }
    }
}
