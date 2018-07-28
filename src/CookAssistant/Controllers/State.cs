namespace CookAssistant.Controllers
{
    public class State
    {
        public Stage Stage { get; set; }

        public string Dish { get; set; }
        public string ConfirmedDish { get; set; }

        public override string ToString()
        {
            return $"Stage: {Stage:G}, блюдо: {Dish ?? "не выбранно"}";
        }

        public int TodoStepNumber { get; set; }
    }
}