using MrVibesRSA.OpenHardwareMonitor.GUI;
using MrVibesRSA.OpenHardwareMonitor.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace MrVibesRSA.OpenHardwareMonitor
{
    public static class PluginInstance
    {
        public static Main Main { get; set; }
    }

    public class Main : MacroDeckPlugin
    {
        public Main()
        {
            PluginInstance.Main ??= this;
        }

        private static System.Timers.Timer _timer;
        // Optional; If your plugin can be configured, set to "true". It'll make the "Configure" button appear in the package manager.
        public override bool CanConfigure => true;

        // Gets called when the plugin is loaded
        public override void Enable()
        {
            this.Actions = new List<PluginAction>
            {
                // add the instances of your actions here
                //new StreamerBotAction(),
            };

            MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
        }

        private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
        {
            var seconds = 15;
            string defaultValueString = PluginConfiguration.GetValue(PluginInstance.Main, "ResfreshRate");
            if (defaultValueString != "")
            {
                seconds = int.Parse(defaultValueString);
            }

            // Initialize and start the timer
            _timer = new System.Timers.Timer();
            _timer.Interval = TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();

        }

        public void UpdateIntervals()
        {
            var seconds = 15;
            string defaultValueString = PluginConfiguration.GetValue(PluginInstance.Main, "ResfreshRate");
            if (defaultValueString != "")
            {
                seconds = int.Parse(defaultValueString);
            }

            // Update the timer interval
            _timer.Interval = TimeSpan.FromSeconds(seconds).TotalMilliseconds;

            // If the timer is already running, restart it with the new interval
            if (_timer.Enabled)
            {
                _timer.Stop();
                _timer.Start();
            }
        }

        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // Retrieve and process sensor data
            RetrieveSensorData();
        }

        static void RetrieveSensorData()
        {
            // Define PowerShell script to query hardware and sensor data
            string script = @"
            $hardware = Get-WmiObject -Namespace root/OpenHardwareMonitor -Class Hardware
            $sensors = Get-WmiObject -Namespace root/OpenHardwareMonitor -Class Sensor

            $result = @{
                Hardware = @()
                Sensors = @()
            }

            $hardware | ForEach-Object {
                $result.Hardware += @{
                    Name = $_.Name
                    Identifier = $_.Identifier
                    HardwareType = $_.HardwareType
                    Parent = $_.Parent
                }
            }
            
            $sensors | ForEach-Object {
                $result.Sensors += @{
                    Name = $_.Name
                    Identifier = $_.Identifier
                    SensorType = $_.SensorType
                    Parent = $_.Parent
                    Value = $_.Value
                    Min = $_.Min
                    Max = $_.Max
                    Index = $_.Index
                }
            }

            ConvertTo-Json $result
        ";

            // Invoke PowerShell script
            string jsonOutput = RunPowerShellScript(script);

            // Parse JSON
            JObject data = JObject.Parse(jsonOutput);

            // Filter and output results
            //JArray hardware = (JArray)data["Hardware"];
            JArray sensors = (JArray)data["Sensors"];
            string sensorsJson = sensors.ToString();

            PluginConfiguration.SetValue(PluginInstance.Main, "SensorsInfo", sensorsJson);
            UpdateGlobalVariables(sensorsJson);
        }

        static string RunPowerShellScript(string script)
        {
            // Create PowerShell process
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-NoProfile -ExecutionPolicy unrestricted -Command " + script,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            // Start process and read output
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        private static void UpdateGlobalVariables(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                // Handle the case where 'data' is empty
                return;
            }

            List<SensorInfo> updatedVariables = JsonConvert.DeserializeObject<List<SensorInfo>>(data);

            var whiteList = PluginConfiguration.GetValue(PluginInstance.Main, "CheckboxState");

            if (string.IsNullOrEmpty(whiteList))
            {
                // Handle the case where 'whiteList' is empty
                return;
            }

            List<SensorInfo> whiteListedVariables = JsonConvert.DeserializeObject<List<SensorInfo>>(whiteList);

            foreach (var updatedVariable in updatedVariables)
            {
                foreach (var whiteListedVariable in whiteListedVariables)
                {
                    // Check if the names and sensor types match, and if the white list item is checked
                    if (updatedVariable.Name.ToLower() == whiteListedVariable.Name.ToLower() &&
                        updatedVariable.SensorType.ToLower() == whiteListedVariable.SensorType.ToLower() &&
                        whiteListedVariable.IsChecked)
                    {
                        // Set the corresponding values in VariableManager
                        VariableType valueType = VariableTypeHelper.GetVariableType(updatedVariable.Value);
                        VariableType minType = VariableTypeHelper.GetVariableType(updatedVariable.Min);
                        VariableType maxType = VariableTypeHelper.GetVariableType(updatedVariable.Max);

                        VariableManager.SetValue($"ohm_{updatedVariable.Name}_{updatedVariable.SensorType}_value", updatedVariable.Value, valueType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });
                        VariableManager.SetValue($"ohm_{updatedVariable.Name}_{updatedVariable.SensorType}_min", updatedVariable.Min, minType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });
                        VariableManager.SetValue($"ohm_{updatedVariable.Name}_{updatedVariable.SensorType}_max", updatedVariable.Max, maxType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });

                        MacroDeckLogger.Info(PluginInstance.Main, $"Updating global variables: Successfully updated {updatedVariable.Name} - {updatedVariable.SensorType}");

                    }
                }
            }
        }

        // Optional; Gets called when the user clicks on the "Configure" button in the package manager; If CanConfigure is not set to true, you don't need to add this
        public override void OpenConfigurator()
        {
            using var pluginConfig = new PluginConfig();
            pluginConfig.ShowDialog();
        }
    }
}
