using CookAssistant.Controllers;
using CookAssistant.Storage;

namespace CookAssistant.Stages
{
    public abstract class StageBase : IStage
    {
        protected readonly RecepiesStorage RecepiesStorage;

        protected StageBase()
        {
            RecepiesStorage = new RecepiesStorage();
        }

        public abstract bool CanHandle(Stage stage);

        public abstract string Act(State state, string keyword);
    }
}