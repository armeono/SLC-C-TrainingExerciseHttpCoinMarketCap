using System;
using System.Linq;
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

            CategoriesAPIResponse response = SecureNewtonsoftDeserialization.DeserializeObject<CategoriesAPIResponse>(Convert.ToString(parameterData));

            if (response.Data.Count == 0)
            {
                return;
            }

            var categories = response.Data.Select((category) =>
            {

                return new CategoriesQActionRow
                {
                    Categoriesinstance_601 = category.Id,
                    Categoriesname_602 = category.Name,
                    Categoriesnumberoftokens_603 = category.NumTokens,
                    Categoriesmarketcap_604 = category.MarketCap,
                    Categoriesmarketcapchange_605 = category.MarketCapChange,
                    Categoriesvolume_606 = category.Volume,
                    Categoriesvolumechange_607 = category.VolumeChange,
                    Categoriesaveragepricechange_608 = category.AvgPriceChange,
                    Categorieslastupdated_609 = category.LastUpdated,
                }.ToObjectArray();

            }).ToList();

            protocol.FillArray(Parameter.Categories.tablePid, categories, NotifyProtocol.SaveOption.Full);

        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}
