using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllStocks")]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks
             .Select(s => new { s.CompanyName, s.Purchase })
             .ToList();
            return Ok(stocks);
        }

        [HttpGet("GetStockById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }


    }
}
