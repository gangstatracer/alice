using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Finish : StageBase
    {
        public override Stage Type => Stage.Finish;

        public override Result Act(string keyword, State state)
        {
            switch (keyword)
            {
                case "спасибо":
                case "все":
                case "закончили":
                {
                    state.Stage = Stage.Start;
                    state.Dish = null;
                    state.ConfirmedDish = null;
                    state.TodoStepNumber = 0;
                    return new Result("Это было классно!") {IsFinish = true};
                }
                default:
                    return new Result("не понимаю");
            }
        }

        public override string[] Keywords()
        {
            return new[] {"спасибо", "все", "закончили"};
        }
    }
}