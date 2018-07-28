using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CookAssistant.Controllers
{
    [Route("")]
    [ApiController]
    public class MainController : Controller
    {
        [HttpPost]
        public JsonResult Post([FromBody] SkillRequest skillRequest)
        {
            return Json(new SkillResponse
            {
                Session = skillRequest.Session,
                Version = skillRequest.Version,
                Response = new Response
                {
                    Text = skillRequest.Request.Command
                }
            });
        }
    }
}
