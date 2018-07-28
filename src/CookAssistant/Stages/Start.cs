using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Start : StageBase
    {
        public override Stage Type => Stage.Start;

        protected override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "":
                    return "Вы можете спросить меня что приготовить, я предложу какое-нибудь блюдо";
                case "приготовить":
                case "приготовим":
                    state.Stage = Stage.ChooseDish;
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    return state.Dish;
                default:
                    return "не понимаю Вас";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"приготовить", "приготовим", ""};
        }
    }
}