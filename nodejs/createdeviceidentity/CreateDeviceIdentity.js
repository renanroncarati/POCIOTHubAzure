'use strict';

var iothub = require('azure-iothub');

//'{iothub connection string}'
var connectionString = "HostName=IOTBerryTemperatureProject.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=vgvVoTKfZAGqsGadEBokyojgkd/OKXTSqFcs9ClsCBA=";

var registry = iothub.Registry.fromConnectionString(connectionString);

var device = new iothub.Device(null);
device.deviceId = 'myBerryNodeDevice';
registry.create(device, function(err, deviceInfo, res) {
  if (err) {
    registry.get(device.deviceId, printDeviceInfo);
  }
  if (deviceInfo) {
    printDeviceInfo(err, deviceInfo, res)
  }
});

function printDeviceInfo(err, deviceInfo, res) {
  if (deviceInfo) {
    console.log('Device id: ' + deviceInfo.deviceId);
    console.log('Device key: ' + deviceInfo.authentication.SymmetricKey.primaryKey);
  }
}