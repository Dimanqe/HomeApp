using System;
using SQLite;

namespace HomeApp.Data.Tables
{
    /// <summary>
    /// Класс - модель таблицы устройств
    /// </summary>
    [Table("HomeDevices")]
    public class HomeDevice
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Room { get; set; }
    }
}