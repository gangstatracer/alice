using System.Linq;
using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class DefaultHandler : StageBase
    {
        private readonly IStage[] _handlers;

        public DefaultHandler(IStage[] handlers)
        {
            _handlers = handlers;
        }

        public override Stage Type => Stage.Unknown;

        public override bool CanHandle(Stage stage, string keyword) => true;

        public override string[] Keywords()
        {
            return new[] {"статус", "проехали", "выход", "забудь", ""};
        }

        public override Result Act(string keyword, State state)
        {
            Result result;
            switch (keyword)
            {
                case "статус":
                    result = new Result(state.ToString());
                    break;

                case "проехали":
                case "выход":
                case "забудь":
                    state.Stage = Stage.Start;
                    state.ConfirmedDish = null;
                    state.Dish = null;
                    state.TodoStepNumber = 0;
                    result = new Result("Пока!") {IsFinish = true};
                    break;
                default:
                    var handler = _handlers.FirstOrDefault(h => h.Type == state.Stage);
                    result = new Result(
                        $"Доступные команды: {string.Join(", ", handler?.Keywords() ?? new string[0])}");
                    break;
            }

            return result;
        }
    }
}