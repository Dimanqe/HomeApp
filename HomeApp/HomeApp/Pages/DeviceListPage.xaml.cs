using System;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using HomeApp.Models;

namespace HomeApp.Pages
{
    public partial class DeviceListPage : ContentPage
    {
        /// <summary>
        /// Группируемая коллекция
        /// </summary>
        public ObservableCollection<Group<string, HomeDevice>> DeviceGroups { get; set; }

        /// <summary>
        /// Ссылка на выбранный объект
        /// </summary>
        HomeDevice SelectedDevice;

        public DeviceListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            // Загрузка данных из базы
            var devicesFromDb = await App.HomeDevices.GetHomeDevices();
            // Мапим сущности БД в сущности бизнес-логики
            var deviceList = App.Mapper.Map<Models.HomeDevice[]>(devicesFromDb);

            // Сгруппируем по комнатам
            var devicesByRooms = deviceList.GroupBy(d => d.Room).Select(g => new Group<string, HomeDevice>(g.Key, g));

            // Сохраним
            DeviceGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);
            BindingContext = this;

            base.OnAppearing();
        }

        /// <summary>
        /// Обработчик нажатия
        /// </summary>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            SelectedDevice = (HomeDevice)e.SelectedItem;
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
            await Navigation.PopAsync();
        }

        private async void NewDeviceButton_Clicked(object sender, EventArgs e)
        {
            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new DevicePage("Новое устройство"));
        }

        private async void EditDeviceButton_Clicked(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь устройство из списка
            if (SelectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new DevicePage("Изменить устройство", SelectedDevice));
        }

        private async void UserProfileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Получаем сущность базы данных, которую следует удалить (мапим из внутренней сущности, представляющей выбранное устройство)
            var deviceToDelete = App.Mapper.Map<Data.Tables.HomeDevice>(SelectedDevice);
            // Удаляем сущность из бд
            await App.HomeDevices.DeleteHomeDevice(deviceToDelete);

            // Обновляем интерфейс
            var grp = DeviceGroups.FirstOrDefault(g => g.Name == SelectedDevice.Room);
            var deviceToRemove = grp.FirstOrDefault(d => d.Id == deviceToDelete.Id);
            grp.Remove(deviceToRemove);
        }
    }
}