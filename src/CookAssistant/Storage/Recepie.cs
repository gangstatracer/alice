using Newtonsoft.Json;

namespace CookAssistant.Storage
{
    public class Recepie
    {
        [JsonProperty("dish")]
        public string Name { get; set; }

        public string[] Components { get; set; }

        public TodoStep[] Todo { get; set; }

        public string GetComponentsText()
        {
            return string.Join(", ", Components);
        }
    }
}