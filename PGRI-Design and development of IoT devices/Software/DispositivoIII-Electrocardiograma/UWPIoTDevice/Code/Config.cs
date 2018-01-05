using System.IO;

namespace UWPIoTDevice
{
    public static class Config
    {
        public static string UWPDevice
        {
            get
            {
                return File.ReadAllText("DeviceKey.txt");
            }
        }
    }
}
