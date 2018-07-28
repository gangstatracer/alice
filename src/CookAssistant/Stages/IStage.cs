using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public interface IStage
    {
        bool CanHandle(Stage stage);
        Result Act(string keyword, State state);
        string[] Keywords();
    }
}