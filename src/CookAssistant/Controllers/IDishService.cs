namespace CookAssistant.Controllers
{
    public interface IDishService
    {
        string GetRandomDish();
        string GetGetIndegrients(string dish);
    }
}