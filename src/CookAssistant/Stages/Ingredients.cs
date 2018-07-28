using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Ingredients : StageBase
    {
        public override bool CanHandle(Stage stage) => stage == Stage.Indegrients;

        public override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "да":
                    state.Stage = Stage.Coocking;
                    state.ConfirmedDish = state.Dish;
                    return $"Шаг для {state.Dish}";
                case "нет":
                case "не хочу":
                    state.Stage = Stage.ChooseDish;
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    state.ConfirmedDish = null;
                    return state.Dish;
                default:
                    return "не понимаю";
            }
        }
    }
}