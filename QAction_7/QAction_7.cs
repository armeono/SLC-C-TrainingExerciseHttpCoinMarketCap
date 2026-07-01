using System;

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
            var rowKey = protocol.RowKey();

            var holderValue = Convert.ToString(
                protocol.GetParameterByName("CategoryIdsHolder"));

            var newValue = String.IsNullOrWhiteSpace(holderValue)
                ? rowKey
                : $"{holderValue},{rowKey}";

            protocol.SetParameterByName("CategoryIdsHolder", newValue);

            protocol.Log(
                $"QA{protocol.QActionID}|Added {rowKey}|Holder={newValue}",
                LogType.Error,
                LogLevel.NoLogging);


        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}
