using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Cooking : StageBase
    {
        public override bool CanHandle(Stage stage) => stage == Stage.Coocking;

        public override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "что дальше":
                case "сделал":
                case "готово":
                {
                    var dish = RecepiesStorage.GetByName(state.Dish);
                    var todoStepNumber = state.TodoStepNumber++;
                    if (todoStepNumber < dish.Todo.Length)
                        return dish.Todo[todoStepNumber].Description;

                    state.Stage = Stage.Finish;
                    return "Блюдо готово. Вы великолепны! Приятного аппетита!";
                }
                default:
                    return "не понимаю";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"что дальше", "сделал", "готово"};
        }
    }
}