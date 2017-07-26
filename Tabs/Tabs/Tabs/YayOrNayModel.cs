﻿using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "Longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "Latitude")]
        public float Latitude { get; set; }
    }
}
