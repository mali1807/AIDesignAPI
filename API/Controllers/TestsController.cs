using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testManager;

        public TestsController(ITestService testManager)
        {
            _testManager = testManager;
        }

        [HttpGet]
        public IActionResult GetTests()
        {
           var tests= _testManager.GetTests();
            return Ok(tests);
        }

        [HttpPost]
        public IActionResult AddTest([FromBody] Test test)
        {
            _testManager.Add(test);
            return Ok();
        }
    }
}
