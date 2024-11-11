using Newtonsoft.Json;

namespace Evershop.Tests.API.Models
{
    internal class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url_key")]
        public string UrlKey { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("include_in_nav")]
        public string IncludeInNav { get; set; }

        [JsonProperty("show_products")]
        public string ShowProducts { get; set; }
    }
}