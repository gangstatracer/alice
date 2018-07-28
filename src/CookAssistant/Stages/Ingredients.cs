using System.Linq;
using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public class Ingredients : StageBase
    {
        public override Stage Type => Stage.Indegrients;
        
        protected override string Act(State state, string keyword)
        {
            switch (keyword)
            {
                case "да":
                case "поехали":
                case "готовим":
                    state.Stage = Stage.Coocking;
                    state.ConfirmedDish = state.Dish;
                    var todoStep = RecepiesStorage.GetByName(state.Dish).Todo.First().Description;
                    state.TodoStepNumber = 1;
                    return todoStep;
                case "нет":
                    state.Stage = Stage.ChooseDish;
                    state.Dish = RecepiesStorage.GetRandom().Name;
                    state.ConfirmedDish = null;
                    return state.Dish;
                default:
                    return "не понимаю";
            }
        }

        public override string[] Keywords()
        {
            return new[] {"да", "нет", "поехали", "готовим"};
        }
    }
}