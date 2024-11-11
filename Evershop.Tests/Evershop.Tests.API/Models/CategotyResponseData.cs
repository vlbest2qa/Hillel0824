using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class CategoryResponseData
    {
        [JsonProperty("data")]
        public CategoryData Data { get; set; }
        internal class CategoryData
        {
            [JsonProperty("uuid")]
            public string Uuid { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
