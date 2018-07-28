namespace CookAssistant.Controllers
{
    public class SkillRequest
    {
        public Request Request { get; set; }
        public Session Session { get; set; }
        public string Version { get; set; }
    }
}