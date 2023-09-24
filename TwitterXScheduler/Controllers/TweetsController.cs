using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterXScheduler.Models;

namespace TwitterXScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {    
        [HttpPost]
        public async Task<IActionResult> PostTweet(PostTweetRequestDto newTweet)
        {
            var client = new TwitterClient("ERS6p9k6nQ42lWq9cyW6TujcN", 
                "ewRcxhod9D6AKVxBBcE9JMDew8mTBedbOffBOAe3asm8LaZLST",
                "2244065371-o7zwKhynavwDGYllcetonlBjONXvwzWXWDcdbzV",
                "pdfQBTA5phbzrluwpSVX10rpsPXwCdwNgu3DNz3HYnXP8");

            var result = await client.Execute.AdvanceRequestAsync(
                BuildTwitterRequest(newTweet, client));

            return Ok(result.Content);
        }
        
        private static Action<ITwitterRequest> BuildTwitterRequest(
            PostTweetRequestDto newTweet,
            TwitterClient client)
        {
            return (ITwitterRequest request) =>
            {
                var jsonBody = client.Json.Serialize(newTweet);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                request.Query.Url = "https://api.twitter.com/2/tweet";
                request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                request.Query.HttpContent = content;
            };
        }
    
    }
}
