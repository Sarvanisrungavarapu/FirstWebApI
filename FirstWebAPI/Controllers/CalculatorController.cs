using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/add?x=100&y=50
        [HttpGet("Calculator/Add")]
        public int Add(int x, int y)
        {
            return x+y;
        }
        [HttpGet("Calculator/Sum")]
        public int Sum(int x, int y)
        {
            return x + y + 1000;
        }
        //api/calculator/Subtract?x=100&y=50
        [HttpPost]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        //api/calculator/Multiply?x=100&y=50
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/calculator/Divide?x=100&y=50
        [HttpDelete]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
