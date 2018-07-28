using Newtonsoft.Json;

namespace CookAssistant.Storage
{
    public class TodoStep
    {
        [JsonProperty("step_description")]
        public string Description { get; set; }
    }
}