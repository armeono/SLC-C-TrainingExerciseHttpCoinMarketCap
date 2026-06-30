using System.Collections.Generic;
using Newtonsoft.Json;

namespace QAction_1.Models.API.Response
{
    public class LatestListingsAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("data")]
        public List<Listing> Data { get; set; }
    }

    public class CategoriesAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("data")]
        public List<Category> Data { get; set; }
    }

    public class CategoryAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("data")]
        public Category Data { get; set; }
    }

    public class LatestQuotesAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("data")]
        public MarketMetrics Data { get; set; }
    }

}
