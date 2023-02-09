using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDBContext _context;
        public HangHoaController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.HangHoas.ToList();
                return Ok(dsLoai);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Loai = _context.HangHoas.SingleOrDefault(l => l.MaHH == id);
            if (Loai != null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoaModel model)
        {
            try
            {
                var hh = new HangHoa
                {
                   TenHH = model.TenHH,
                   MoTa = model.MoTa,
                   GiamGia = model.GiamGia,
                   DonGia = model.DonGia,
                   MaLoai = model.MaLoai,
                   


                };
                _context.Add(hh);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, hh);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, HangHoaModel model)
        {
            try
            {
                var HH = _context.HangHoas.SingleOrDefault(lo => lo.MaHH == id);
                if (HH != null)
                {
                    HH.TenHH = model.TenHH;
                    HH.MoTa = model.MoTa;
                    HH.GiamGia = model.GiamGia;
                    HH.DonGia = model.DonGia;
                    HH.MaLoai = model.MaLoai;

                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }catch
            {
                return NotFound();

            }

        }
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var HH = _context.HangHoas.SingleOrDefault(l => l.MaHH == id);
            if (HH != null)
            {
                _context.Remove(HH);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
