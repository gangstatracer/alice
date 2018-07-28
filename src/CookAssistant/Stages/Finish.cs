using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Finish : StageBase
    {
        public override bool CanHandle(Stage stage) => stage == Stage.Finish;

        public override string Act(State state, string keyword)
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
                    return "Это было классно!";
                }
                default:
                    return "не понимаю";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"спасибо", "все", "закончили"};
        }
    }
}