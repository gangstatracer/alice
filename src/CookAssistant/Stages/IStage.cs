using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public interface IStage
    {
        bool CanHandle(Stage stage);
        string Act(State state, string keyword);
    }
}