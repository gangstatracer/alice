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
                case "приготовим":
                    state.Stage = Stage.ChooseDish;
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    return state.Dish;
                default:
                    return "Вы можете спросить меня что приготовить, я предложу какое-нибудь блюдо";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"приготовить"};
        }
    }
}