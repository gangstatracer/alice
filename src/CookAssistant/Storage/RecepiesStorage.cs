using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CookAssistant.Storage
{
    public class RecepiesStorage
    {
        private readonly IList<Recepie> _recepies;

        public RecepiesStorage()
        {
            var content = File.ReadAllText("Storage/recepies.json");
            _recepies = JsonConvert.DeserializeObject<IEnumerable<Recepie>>(content).ToList();
        }

        public IEnumerable<Recepie> GetAll()
        {
            return _recepies;
        }

        public Recepie GetRandom()
        {
            var random = new Random(DateTime.Now.Millisecond);
            return _recepies[random.Next(_recepies.Count)];
        }

        public Recepie GetByName(string name)
        {
            return _recepies.FirstOrDefault(r => r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}