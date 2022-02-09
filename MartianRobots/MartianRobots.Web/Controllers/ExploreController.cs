using MartianRobots.Core;
using MartianRobots.Core.Entities;
using MartianRobots.Web.Contract.V1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobots.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExploreController : ControllerBase
    {
        private readonly IExploreService _exploreService;

        public ExploreController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExploreRequestV1 requestV1)
        {
            var (coreRequest, error) = TranslatorV1.TranslateToCoreRequest(requestV1);
            if(coreRequest != null)
            {
                var result = _exploreService.ExploreWorld(coreRequest);
                var responseV1 = TranslatorV1.TranslateToV1Response(result);

                return Ok(responseV1);
            }
            else
            {
                return BadRequest(new ErrorResponseV1(error));
            }
        }

        [HttpGet]
        public string Get()
        {
            return "Martian Robots Version 1.0";
        }
    }
}
