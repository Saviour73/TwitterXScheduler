using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterXScheduler.Models
{
    public class PostTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

    }
}
