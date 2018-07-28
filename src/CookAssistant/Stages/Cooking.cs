using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Cooking : StageBase
    {
        public override Stage Type => Stage.Coocking;

        protected override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "повтори":
                case "делаю":
                    return RecepiesStorage.GetByName(state.ConfirmedDish).Todo[state.TodoStepNumber - 1].Description;
                case "дальше":
                case "сделал":
                case "готово":
                {
                    var dish = RecepiesStorage.GetByName(state.ConfirmedDish);
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
            return new[] {"дальше", "сделал", "готово", "повтори", "делаю"};
        }
    }
}