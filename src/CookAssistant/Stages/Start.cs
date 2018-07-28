using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Start : StageBase
    {
        public override bool CanHandle(Stage stage) => stage == Stage.Start;

        public override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "приготовить":
                    state.Stage = Stage.ChooseDish;
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    return state.Dish;
                default:
                    return "не понимаю";
            }
        }
    }
}