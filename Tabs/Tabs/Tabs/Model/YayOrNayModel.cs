using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class YayOrNayModel
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "Deleted")]
        public bool Deleted { get; set; }

    }
}
