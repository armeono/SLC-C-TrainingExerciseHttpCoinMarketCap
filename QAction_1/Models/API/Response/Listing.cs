using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace QAction_1.Models.API.Response
{
    public class Listing
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("num_market_pairs")]
        public int NumMarketPairs { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("max_supply")]
        public double MaxSupply { get; set; }

        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }

        [JsonProperty("infinite_supply")]
        public bool InfiniteSupply { get; set; }

        [JsonProperty("platform")]
        public object Platform { get; set; }

        [JsonProperty("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonProperty("self_reported_circulating_supply")]
        public object SelfReportedCirculatingSupply { get; set; }

        [JsonProperty("self_reported_market_cap")]
        public object SelfReportedMarketCap { get; set; }

        [JsonProperty("tvl_ratio")]
        public object TvlRatio { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, Quote> Quote { get; set; }
    }
}
