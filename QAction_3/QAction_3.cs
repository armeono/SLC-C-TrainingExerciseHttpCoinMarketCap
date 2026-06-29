using System;

using Skyline.DataMiner.Scripting;

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

            var response = protocol.GetParameter(parameterId);


            protocol.Log($"QA{protocol.QActionID}|response|{response}", LogType.Error, LogLevel.NoLogging);
        }
        catch (Exception ex)
        {
            protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
        }
    }
}