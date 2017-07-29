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
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "Emotion")]
        public string Emotion { get; set; }

        [JsonProperty(PropertyName = "EmotionValue")]   
        public double EmotionValue { get; set; }

        [JsonProperty(PropertyName = "NotEmotion")]
        public string NotEmotion { get; set; }

        [JsonProperty(PropertyName = "NotEmotionValue")]
        public double NotEmotionValue { get; set; }
    }
}
