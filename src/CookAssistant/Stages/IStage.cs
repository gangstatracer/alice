using CookAssistant.Controllers;

namespace CookAssistant.Stages
{
    public interface IStage
    {
        Stage Type { get; }
        bool CanHandle(Stage stage, string keyword);
        Result Act(string keyword, State state);
        string[] Keywords();
    }
}