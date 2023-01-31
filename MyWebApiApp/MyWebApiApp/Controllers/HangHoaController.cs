using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }catch
            {
                return BadRequest();
                   
            }
          
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            string a;
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                DonGia = hangHoaVM.DonGia,
                TenHangHoa = hangHoaVM.TenHangHoa
            };
            hanghoas.Add(hanghoa);
            return Ok(new {Sucess = true, Data = hanghoa 

            }

                );

        }
        [HttpPut ("{id}")]
        public IActionResult Edit(string id, HangHoa hanghoaEdit)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                // Update
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }    
                hanghoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                hanghoa.DonGia = hanghoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                // Update
                hanghoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
