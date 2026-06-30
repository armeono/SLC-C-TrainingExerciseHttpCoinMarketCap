using System;
using System.Linq;
using QAction_1.Models.API.Response;
using Skyline.DataMiner.Scripting;
using Skyline.DataMiner.Utils.SecureCoding.SecureSerialization.Json.Newtonsoft;

/// <summary>
/// DataMiner QAction Class: QActkjciwkjionName.
/// </summary>
public static class QAction
{
    /// <summary>
    /// The QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        try
        {

            var parameterId = protocol.GetTriggerParameter();

            var parameterData = protocol.GetParameter(parameterId);

            LatestListingsAPIResponse response = SecureNewtonsoftDeserialization.DeserializeObject<LatestListingsAPIResponse>(Convert.ToString(parameterData));

            if (response.Data.Count == 0)
            {
                return;
            }

            var listings = response.Data.Select((listing) =>
            {

                return new LatestlistingsQActionRow
                {
                    Latestlistingsinstance_501 = listing.Id,
                    Latestlistingsrank_502 = listing.CmcRank,
                    Latestlistingsname_503 = listing.Name,
                    Latestlistingssymbol_504 = listing.Symbol,
                    Latestlistingsprice_505 = listing.Quote["USD"].Price,
                    Latestlistingsmarketcap_506 = listing.Quote["USD"].MarketCap,
                    Latestlistingsvolume24h_507 = listing.Quote["USD"].VolumeChange24h,
                    Latestlistingspercentchange1h_508 = listing.Quote["USD"].PercentChange1h,
                    Latestlistingspercentchange24h_509 = listing.Quote["USD"].PercentChange24h,
                    Latestlistingspercentchange7d_510 = listing.Quote["USD"].PercentChange7d,
                    Latestlistingscirculatingsupply_511 = listing.CirculatingSupply,
                    Latestlistingstotalsupply_512 = listing.TotalSupply,
                    Latestlistingsmaxsupply_513 = listing.MaxSupply,
                    Latestlistingsnumberofmarketpairs_514 = listing.NumMarketPairs,
                    Latestlistingslastupdated_515 = listing.LastUpdated.ToOADate(),
                }.ToObjectArray();

            }).ToList();

            protocol.FillArray(Parameter.Latestlistings.tablePid, listings, NotifyProtocol.SaveOption.Full);
        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}