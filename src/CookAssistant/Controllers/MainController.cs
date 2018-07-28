using System;
using System.Collections.Generic;
using System.Linq;
using CookAssistant.Stages;
using Microsoft.AspNetCore.Mvc;

namespace CookAssistant.Controllers
{
    [Route("")]
    [ApiController]
    public class MainController : Controller
    {
        private static readonly string[] Keywords = {"приготовить", "еще", "давай", "нет", "не хочу", "да"};

        private readonly List<IStage> _stagesHandlers = new List<IStage> {new Start(), new ChooseDish(), new Ingredients()};

        [HttpPost]
        public JsonResult Post([FromBody] SkillRequest skillRequest)
        {
            var state = GetState();
            var keyword = GetKeyword(skillRequest.Request.Command);


            string response;
            if (skillRequest.Request.Command == "статус")
            {
                response = state.ToString();
            }
            else
            {
                var handler = _stagesHandlers.FirstOrDefault(h => h.CanHandle(state.Stage));
                response = handler?.Act(state, keyword) ?? "Не понимаю";
            }

            return Json(new SkillResponse
            {
                Session = skillRequest.Session,
                Version = skillRequest.Version,
                Response = new Response
                {
                    Text = response,
                }
            });
        }

        public State GetState()
        {
            return CookingState.CurrentState ?? (CookingState.CurrentState = new State
            {
                Stage = Stage.Start,
            });
        }

        private static string GetKeyword(string command)
        {
            return command.Split(new[] {' ', '-', '-'}, StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => x.ToLower())
                       .FirstOrDefault(x => Keywords.Contains(x))
                   ?? "не понимаю";
        }
    }
}