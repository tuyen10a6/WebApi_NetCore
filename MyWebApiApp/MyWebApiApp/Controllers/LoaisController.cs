using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaisController(MyDBContext context)
        {
            _context = context; 
        }
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);

            }catch
            {
                return BadRequest();
            }

        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if(Loai !=null)
            {
                return Ok(Loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
             
        }
        [HttpPut("{id}")]
        public IActionResult UpDateLoaiByid(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai ==id);
            if(loai !=null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }    
            else
            {
                return NotFound();
            }    

        }
        [HttpDelete("id")]
        public IActionResult DeleteLoaiById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (Loai != null)
            {
                _context.Remove(Loai);
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
