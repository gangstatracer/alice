namespace CookAssistant.Controllers
{
    public class Response
    {
        public string Text { get; set; }
        public string Tts { get; set; }
        public Button[] Buttons { get; set; }
        public bool End_session { get; set; }
    }
}