using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace N_Health_API.Controllers.Master
{
    [Authorize]
    [Route("JobType")]
    public class JobTypeController : Controller
    {
        public JobTypeController()
        {

        }
    }
}
