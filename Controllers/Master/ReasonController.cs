using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Health_API.Models.Master;

namespace N_Health_API.Controllers.Master
{
    [Authorize]
    [Route("Reason")]
    public class ReasonController : Controller
    {
        public ReasonController()
        {

        }

        [HttpPost, Route("List")]
        public ResonResponse List([FromBody] ReasonRequest request)
        {
            var result = new ResonResponse();
            result.Message = "";
            return result;
        }
    }
}
