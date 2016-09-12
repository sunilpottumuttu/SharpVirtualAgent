using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBTApp.PersonalAssistant
{
    public class CalendarResponse
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "intents")]
        public Intent[] Intents { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public Entity[] Entities { get; private set; }
    }

    //public class Rootobject
    //{
    //    public string query { get; set; }
    //    public Intent[] intents { get; set; }
    //    public Entity[] entities { get; set; }
    //}

    public class Intent
    {
        public string intent { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public Resolution resolution { get; set; }
    }

    public class Resolution
    {
        public string resolution_type { get; set; }
        public string time { get; set; }
    }

}



