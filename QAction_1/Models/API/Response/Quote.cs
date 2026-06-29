using System;
using Newtonsoft.Json;

namespace QAction_1.Models.API.Response
{
    public class Quote
    {
        [JsonProperty("total_market_cap")]
        public double TotalMarketCap { get; set; }

        [JsonProperty("total_volume_24h")]
        public double TotalVolume24h { get; set; }

        [JsonProperty("total_volume_24h_reported")]
        public double TotalVolume24hReported { get; set; }

        [JsonProperty("altcoin_volume_24h")]
        public double AltcoinVolume24h { get; set; }

        [JsonProperty("altcoin_volume_24h_reported")]
        public double AltcoinVolume24hReported { get; set; }

        [JsonProperty("altcoin_market_cap")]
        public double AltcoinMarketCap { get; set; }

        [JsonProperty("defi_volume_24h")]
        public double DefiVolume24h { get; set; }

        [JsonProperty("defi_volume_24h_reported")]
        public double DefiVolume24hReported { get; set; }

        [JsonProperty("defi_24h_percentage_change")]
        public double Defi24hPercentageChange { get; set; }

        [JsonProperty("defi_market_cap")]
        public double DefiMarketCap { get; set; }

        [JsonProperty("stablecoin_volume_24h")]
        public double StablecoinVolume24h { get; set; }

        [JsonProperty("stablecoin_volume_24h_reported")]
        public double StablecoinVolume24hReported { get; set; }

        [JsonProperty("stablecoin_24h_percentage_change")]
        public double Stablecoin24hPercentageChange { get; set; }

        [JsonProperty("stablecoin_market_cap")]
        public double StablecoinMarketCap { get; set; }

        [JsonProperty("derivatives_volume_24h")]
        public double DerivativesVolume24h { get; set; }

        [JsonProperty("derivatives_volume_24h_reported")]
        public double DerivativesVolume24hReported { get; set; }

        [JsonProperty("derivatives_24h_percentage_change")]
        public double Derivatives24hPercentageChange { get; set; }

        [JsonProperty("total_market_cap_yesterday")]
        public double TotalMarketCapYesterday { get; set; }

        [JsonProperty("total_volume_24h_yesterday")]
        public long TotalVolume24hYesterday { get; set; }

        [JsonProperty("total_market_cap_yesterday_percentage_change")]
        public double TotalMarketCapYesterdayPercentageChange { get; set; }

        [JsonProperty("total_volume_24h_yesterday_percentage_change")]
        public double TotalVolume24hYesterdayPercentageChange { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

}
