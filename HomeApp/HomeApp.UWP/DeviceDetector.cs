using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(HomeApp.UWP.DeviceDetector))]

namespace HomeApp.UWP
{
    public class DeviceDetector : IDeviceDetector
    {
        public string GetDevice()
        {
            // Создаем объект класса с информацией об устройстве
            var devInfo = new EasClientDeviceInformation();
            // Сообщаем строку с информацией о платформе
            return $"Запущено на устройстве {devInfo.SystemManufacturer},{Environment.NewLine} платформа {Device.RuntimePlatform}";
        }
    }
}