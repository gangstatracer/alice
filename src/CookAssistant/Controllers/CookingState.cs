using System.Collections.Concurrent;

namespace CookAssistant.Controllers
{
    public static class CookingState
    {
        static CookingState()
        {
            States =  new ConcurrentDictionary<string, State>();
        }

        public static ConcurrentDictionary<string, State> States { get; }
    }
}