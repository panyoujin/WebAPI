using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.API.Filters;
using Pan.Code.Extentions;

namespace Pan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(ILogger<ValuesController> logger)
        {
            this._logger = logger;
        }


        // GET api/values
        [HttpGet]
        [LoginFilter]
        public ActionResult<object> Get()
        {
            _logger.LogInformation("ValuesController Get LogInformation");
            var str = new string[] { "value1", "value2" };
            return str.ResponseSuccess();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
