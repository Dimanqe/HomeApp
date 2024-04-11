using System.Threading.Tasks;
using SQLite;
using HomeApp.Data.Tables;

namespace HomeApp.Data
{
    public class HomeDeviceRepository
    {
        // Асинхронное подключение к Базе данных
        SQLiteAsyncConnection dbConnection;

        public HomeDeviceRepository(string databasePath)
        {
            // Создаем подключение в методе-конструкторе
            dbConnection = new SQLiteAsyncConnection(databasePath);
        }

        /// <summary>
        /// Проверяем на наличие таблицы и создаем в случае необходимости.
        /// </summary>
        public async Task InitDatabase()
        {
            await dbConnection.CreateTableAsync<HomeDevice>();
        }

        /// <summary>
        /// Получение всех устройств
        /// </summary>
        public async Task<HomeDevice[]> GetHomeDevices()
        {
            return await dbConnection.Table<HomeDevice>().ToArrayAsync();
        }

        /// <summary>
        /// Поиск устройства по идентификатору
        /// </summary>
        public async Task<HomeDevice> GetHomeDevice(int id)
        {
            return await dbConnection.GetAsync<HomeDevice>(id);
        }

        /// <summary>
        /// Удаление устройства
        /// </summary>
        public async Task<int> DeleteHomeDevice(HomeDevice homeDevice)
        {
            return await dbConnection.DeleteAsync(homeDevice);
        }

        /// <summary>
        /// Добавление устройства
        /// </summary>
        public async Task<int> AddHomeDevice(HomeDevice homeDevice)
        {
            return await dbConnection.InsertAsync(homeDevice);
        }

        /// <summary>
        /// Обновление существующего устройства
        /// </summary>
        public async Task<int> UpdateHomeDevice(HomeDevice homeDevice)
        {
            return await dbConnection.UpdateAsync(homeDevice);
        }
    }
}