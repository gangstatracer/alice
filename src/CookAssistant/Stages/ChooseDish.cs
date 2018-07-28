using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class ChooseDish : StageBase
    {
        public override bool CanHandle(Stage stage) => stage == Stage.ChooseDish;

        public override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "еще":
                case "нет":
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    return state.Dish;
                case "давай":
                    state.Stage = Stage.Indegrients;
                    return
                        $"Ингредиенты для {state.Dish}. {RecepiesStorage.GetByName(state.Dish).GetComponentsText()}. Готовим?";
                default:
                    return "не понимаю";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"еще", "нет", "давай",};
        }
    }
}