using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Services;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaResposity _hanghoaRepository;

        public ProductsController(IHangHoaResposity hangHoaResposity)
        {
            _hanghoaRepository = hangHoaResposity;
        }
        [HttpGet]
        public IActionResult GetAllProducts(string? sreach, double? from, double? to, string? SortBy , int page = 1)
        {
            try
            {

                var result = _hanghoaRepository.GetAll(sreach, from , to, SortBy, page);
                return Ok(result);
            }catch
            {
                return BadRequest("We can not products");
            }
        }
        [HttpPost]
        public IActionResult Add(HangHoas hanghoa)
        {
            try
            {
                return Ok(_hanghoaRepository.Add(hanghoa));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }



    }
}
