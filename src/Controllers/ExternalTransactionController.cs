using DemoApi.Models;
using DemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("transactions")]
    public class ExternalTransactionController : ControllerBase
    {
        private readonly ExternalTransactionService _service;

        public ExternalTransactionController(ExternalTransactionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Processes an external transaction request
        /// </summary>
        [HttpPost]
        public ActionResult<ExternalTransactionResponse> Post(
            [FromBody] ExternalTransactionRequest request)
        {
            var result = _service.Process(request);
            return Ok(result);
        }
    }
}
