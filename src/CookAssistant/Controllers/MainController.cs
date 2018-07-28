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
        private static readonly List<IStage> StagesHandlers;

        static MainController()
        {
            StagesHandlers = new List<IStage>
            {
                new Start(),
                new ChooseDish(),
                new Ingredients(),
                new Cooking(),
                new Finish(),
            };
            StagesHandlers.Add(new DefaultHandler(StagesHandlers.ToArray()));
        }

        [HttpPost]
        public JsonResult Post([FromBody] SkillRequest skillRequest)
        {
            var state = GetState(skillRequest.Session.User_id);
            var keyword = GetKeyword(state.Stage, skillRequest.Request.Command);


            Result result;
            if (skillRequest.Request.Command == "статус")
            {
                result = new Result(state.ToString());
            }
            else
            {
                var handler = StagesHandlers.FirstOrDefault(h => h.CanHandle(state.Stage, keyword));
                result = handler?.Act(keyword, state);
            }

            return Json(ToResponse(skillRequest, result));
        }

        private SkillResponse ToResponse(SkillRequest request, Result result)
        {
            return new SkillResponse
            {
                Session = request.Session,
                Version = request.Version,
                Response = new Response
                {
                    Text = result.Text ?? "Не понимаю",
                    End_session = result.IsFinish,
                }
            };
        }

        public State GetState(string userId)
        {
            return CookingState.States.GetOrAdd(userId, new State
            {
                Stage = Stage.Start,
            });
        }

        private static string GetKeyword(Stage stage, string command)
        {
            var keywords = StagesHandlers.Where(x => x.Type == stage || x.Type == Stage.Unknown)
                .SelectMany(x => x.Keywords());
            return command.Split(new[] {' ', '-', '-', '?'}, StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => x.ToLower())
                       .FirstOrDefault(x => keywords.Contains(x))
                   ?? "";
        }
    }
}