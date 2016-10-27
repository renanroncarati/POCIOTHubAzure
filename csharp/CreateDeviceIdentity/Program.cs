using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace CreateDeviceIdentity
{
    public class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=IOTBerryTemperatureProject.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=vgvVoTKfZAGqsGadEBokyojgkd/OKXTSqFcs9ClsCBA=";
        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }

        private static async Task AddDeviceAsync()
        {
            string deviceId = "myBerryDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = registryManager.GetDeviceAsync(deviceId).Result;
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
            //LCyoaCkw5S65PzdfxCYPYs6Q1J58SMJ3lSfEgDvNj24=
        }
    }
}
