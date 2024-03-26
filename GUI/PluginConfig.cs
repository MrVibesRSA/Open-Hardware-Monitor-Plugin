using MrVibesRSA.OpenHardwareMonitor.Models;
using Newtonsoft.Json;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MrVibesRSA.OpenHardwareMonitor.GUI
{
    public partial class PluginConfig : DialogForm
    {
        //private List<Tuple<string, string, string, string, string>> selectedVariables = new List<Tuple<string, string, string, string, string>>();
        private List<SensorInfo> selectedVariables = new List<SensorInfo>();
        private List<SensorInfo> checkboxStates = new List<SensorInfo>();

        public PluginConfig()
        {
            InitializeComponent();

            string defaultValueString = PluginConfiguration.GetValue(PluginInstance.Main, "ResfreshRate");
            if (defaultValueString != "")
            {
                decimal defaultValue = int.Parse(defaultValueString);
                numericUpDown1.Value = defaultValue;
            }

            ProcessSensorData();
        }

        private void ProcessSensorData()
        {
            dataGridView1.Rows.Clear();

            var sensorInfosJson = PluginConfiguration.GetValue(PluginInstance.Main, "SensorsInfo");
            if (!string.IsNullOrEmpty(sensorInfosJson))
            {
                List<SensorInfo> sensorInfos = JsonConvert.DeserializeObject<List<SensorInfo>>(sensorInfosJson);

                foreach (SensorInfo sensorInfo in sensorInfos)
                {
                    dataGridView1.Rows.Add(
                        false,
                        sensorInfo.Name,
                        sensorInfo.SensorType,
                        sensorInfo.Value,
                        sensorInfo.Min,
                        sensorInfo.Max
                    );
                }

                SortDataGridViewByNameColumn();
                // Refresh the DataGridView
                LoadCheckboxState();
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["checkBoxColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;

                // Toggle the checkbox state
                checkBoxCell.Value = !(bool)checkBoxCell.Value;

                // Get the current state after the click
                bool currentState = (bool)checkBoxCell.Value;

                // Get the variable name and type
                string sensorName = dataGridView1.Rows[e.RowIndex].Cells["SensorName"].Value.ToString().ToLower();
                string sensorType = dataGridView1.Rows[e.RowIndex].Cells["SensorType"].Value.ToString().ToLower();

                string sensorNameWithUnderscores = sensorName.Replace(" ", "_");

                if (currentState)
                {
                    // Checkbox is checked
                    VariableType valueType = VariableTypeHelper.GetVariableType(dataGridView1.Rows[e.RowIndex].Cells["Value"].Value.ToString());
                    VariableType minType = VariableTypeHelper.GetVariableType(dataGridView1.Rows[e.RowIndex].Cells["Min"].Value.ToString());
                    VariableType maxType = VariableTypeHelper.GetVariableType(dataGridView1.Rows[e.RowIndex].Cells["Max"].Value.ToString());

                    // Add to selectedVariables
                    selectedVariables.Add(new SensorInfo
                    {
                        IsChecked = currentState,
                        Name = sensorName,
                        SensorType = sensorType,
                        Value = "",
                        Min = "",
                        Max = ""
                    });

                    // Set the corresponding values in VariableManager
                    VariableManager.SetValue($"ohm_{sensorNameWithUnderscores}_{sensorType}_value", dataGridView1.Rows[e.RowIndex].Cells["Value"].Value.ToString(), valueType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });
                    VariableManager.SetValue($"ohm_{sensorNameWithUnderscores}_{sensorType}_min", dataGridView1.Rows[e.RowIndex].Cells["Min"].Value.ToString(), minType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });
                    VariableManager.SetValue($"ohm_{sensorNameWithUnderscores}_{sensorType}_max", dataGridView1.Rows[e.RowIndex].Cells["Max"].Value.ToString(), maxType, PluginInstance.Main, new string[] { "OHM Gobal Variables" });
                }
                else
                {
                    // Checkbox is unchecked
                    // Remove from selectedVariables
                    selectedVariables.RemoveAll(v => v.Name == sensorName && v.SensorType == sensorType);

                    // Remove the corresponding values from VariableManager
                    VariableManager.DeleteVariable($"ohm_{sensorNameWithUnderscores}_{sensorType}_value");
                    VariableManager.DeleteVariable($"ohm_{sensorNameWithUnderscores}_{sensorType}_min");
                    VariableManager.DeleteVariable($"ohm_{sensorNameWithUnderscores}_{sensorType}_max");
                }

                // Save checkbox state
                SaveCheckboxState();
            }
        }


        private void SaveCheckboxState()
        {
            // If checkboxStates is null, initialize it
            if (checkboxStates == null)
            {
                checkboxStates = new List<SensorInfo>();
            }

            // Clear existing checkbox states
            checkboxStates.Clear();

            // Add current checkbox states
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);

                string sensorName = row.Cells["SensorName"].Value.ToString();
                string sensorType = row.Cells["SensorType"].Value.ToString();
                string sensorValue = row.Cells["Value"].Value.ToString();
                string sensorMin = row.Cells["Min"].Value.ToString();
                string sensorMax = row.Cells["Max"].Value.ToString();

                checkboxStates.Add(new SensorInfo
                {
                    IsChecked = isChecked,
                    Name = sensorName,
                    SensorType = sensorType,
                    Value = sensorValue,
                    Min = sensorMin,
                    Max = sensorMax,
                });
            }

            // Serialize and save checkbox states
            string json = JsonConvert.SerializeObject(checkboxStates, Formatting.Indented);
            PluginConfiguration.SetValue(PluginInstance.Main, "CheckboxState", json);
        }

        private void LoadCheckboxState()
        {
            string json = PluginConfiguration.GetValue(PluginInstance.Main, "CheckboxState");

            if (!string.IsNullOrEmpty(json))
            {
                checkboxStates = JsonConvert.DeserializeObject<List<SensorInfo>>(json);

                if (checkboxStates.Count > 0)
                {
                    // Set checkbox states based on loaded data
                    foreach (var state in checkboxStates)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["SensorName"].Value.ToString() == state.Name && row.Cells["SensorType"].Value.ToString() == state.SensorType)
                            {
                                row.Cells["checkBoxColumn"].Value = state.IsChecked;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Method to sort DataGridView by the "Name" column
        private void SortDataGridViewByNameColumn()
        {
            // Check if the DataGridView contains the "Name" column
            if (dataGridView1.Columns.Contains("SensorName"))
            {
                // Sort the DataGridView by the "Name" column in ascending order
                dataGridView1.Sort(dataGridView1.Columns["SensorName"], ListSortDirection.Ascending);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrimary1_Click(object sender, EventArgs e)
        {
            ProcessSensorData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PluginConfiguration.SetValue(PluginInstance.Main, "ResfreshRate", numericUpDown1.Value.ToString());
            PluginInstance.Main.UpdateIntervals();
        }
    }
}
