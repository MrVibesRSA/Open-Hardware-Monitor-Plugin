namespace MrVibesRSA.OpenHardwareMonitor.Models
{
    public class SensorInfo
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string SensorType { get; set; }
        public string Parent { get; set; }
        public string Value { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public int Index { get; set; }
    }
}
