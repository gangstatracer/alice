using System.Linq;
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

        public abstract Stage Type { get; }

        public virtual bool CanHandle(Stage stage, string keyword)
        {
            return stage == Type && Keywords().Contains(keyword);
        }

        protected virtual string Act(State state, string keyword)
        {
            return "";
        }

        public virtual Result Act(string keyword, State state)
        {
            return new Result(Act(state, keyword));
        }

        public abstract string[] Keywords();
    }
}