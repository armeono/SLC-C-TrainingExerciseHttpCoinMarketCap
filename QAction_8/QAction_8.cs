using System;
using System.Linq;

using Skyline.DataMiner.Scripting;

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

            var holderValue = Convert.ToString(
                           protocol.GetParameterByName("CategoryIdsHolder"));


            protocol.Log($"QA{protocol.QActionID}|Category ID Queue|{holderValue}", LogType.Information, LogLevel.NoLogging);

            if (String.IsNullOrWhiteSpace(holderValue))
            {
                return;
            }

            var queue = holderValue
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(id => id.Trim())
                .ToList();

            if (queue.Count == 0)
            {
                return;
            }

            // Take first item
            var currentId = queue[0];

            protocol.Log($"QA{protocol.QActionID}|Current ID polling|{currentId}", LogType.Information, LogLevel.NoLogging);

            // Remove it from the queue
            queue.RemoveAt(0);

            // Store current ID
            protocol.SetParameterByName("CurrentCategoryId", currentId);

            // Update queue
            protocol.SetParameterByName(
                "CategoryIdsHolder",
                String.Join(",", queue));


            protocol.CheckTrigger(6);
        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}
