namespace HomeApp
{
    /// <summary>
    /// Общий интерфейс для классов отдельных платформ
    /// </summary>
    public interface IDeviceDetector
    {
        /// <summary>
        /// Получение информации об устройстве
        /// </summary>
        string GetDevice();
    }
}