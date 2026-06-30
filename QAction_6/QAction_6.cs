using System;
using System.Collections.Generic;
using QAction_1.Models.API.Response;
using Skyline.DataMiner.Scripting;
using Skyline.DataMiner.Utils.SecureCoding.SecureSerialization.Json.Newtonsoft;

/// <summary>
/// DataMiner QAction Class.
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

            protocol.Log($"QA{protocol.QActionID}|{parameterData}|Message", LogType.Error, LogLevel.NoLogging);

            LatestQuotesAPIResponse response = SecureNewtonsoftDeserialization.DeserializeObject<LatestQuotesAPIResponse>(Convert.ToString(parameterData));

            if (response.Data == null)
            {
                return;
            }

            var latestQuote = new List<object[]>
            {
                new LatestquotesQActionRow
                {
                    Latestquotesinstance_701 = '1',
                    Latestquotesbtcdominance_702 = response.Data.BtcDominance,
                    Latestquotesethdominance_703 = response.Data.EthDominance,
                    Latestquotesactivecryptocurrencies_704 = response.Data.ActiveCryptocurrencies,
                    Latestquotesdefimarketcap_705 = response.Data.DefiMarketCap,
                    Latestquotesactivestablecoinmarketcap_706 = response.Data.StablecoinMarketCap,
                }.ToObjectArray(),
            };


            protocol.FillArray(Parameter.Latestquotes.tablePid, latestQuote, NotifyProtocol.SaveOption.Full);
        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}
