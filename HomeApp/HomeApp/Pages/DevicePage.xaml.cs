using Xamarin.Forms;
using System;
using System.Linq;
using HomeApp.Models;

namespace HomeApp.Pages
{
    public partial class DevicePage : ContentPage
    {
        public static string PageName { get; set; }
        public static bool CreateNew { get; set; }

        // Ссылка на модель
        public HomeDevice HomeDevice { get; set; }

        /// <summary>
        ///  Метод- конструктор принимает данные с предыдущей старницы
        /// </summary>
        public DevicePage(string pageName, HomeDevice homeDevice = null)
        {
            PageName = pageName;

            if (homeDevice == null)
            {
                HomeDevice = new HomeDevice();
                CreateNew = true;
            }
            else
            {
                HomeDevice = homeDevice;
                CreateNew = false;
            }

            InitializeComponent();
            OpenEditor();
        }

        public void OpenEditor()
        {
            // Создание однострочного текстового поля для названия
            var newDeviceName = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название",
                Text = HomeDevice.Name,
                Style = (Style)App.Current.Resources["ValidInputStyle"],
            };
            newDeviceName.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceName);
            stackLayout.Children.Add(newDeviceName);

            // Создание многострочного поля для описания
            var newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание",
                Text = HomeDevice.Description,
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newDeviceDescription.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceDescription);
            stackLayout.Children.Add(newDeviceDescription);

            // Выбор комнаты
            var switchHeader = new Label { Text = "Выберите комнату подключения", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(20, 25, 0, 0) };
            stackLayout.Children.Add(switchHeader);
            var roomPicker = new Picker
            {
                Margin = new Thickness(30, 0)
            };
            roomPicker.Items.Add("Кухня");
            roomPicker.Items.Add("Ванная");
            roomPicker.Items.Add("Гостиная");

            roomPicker.SelectedItem = roomPicker.Items.FirstOrDefault(i => i == HomeDevice.Room);

            roomPicker.SelectedIndexChanged += (sender, eventArgs) => RoomPicker_SelectedIndexChanged(sender, eventArgs, roomPicker);
            stackLayout.Children.Add(roomPicker);

            // Добавляем кнопку перехода на страницу с инструкцией и её обработчик
            var userManualButton = new Button
            {
                Text = "Инструкция по эксплуатации",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver,
            };
            userManualButton.Clicked += (sender, eventArgs) => ManualButtonClicked(sender, eventArgs);
            stackLayout.Children.Add(userManualButton);

            // Кнопка сохранения с обработчиками
            var addButton = new Button
            {
                Text = "Сохранить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver,
            };
            addButton.Clicked += (sender, eventArgs) => SaveButtonClicked(sender, eventArgs, new View[] { newDeviceName, newDeviceDescription, roomPicker });

            stackLayout.Children.Add(addButton);
        }

        /// <summary>
        /// Обновляем комнату в модели
        /// </summary>
        private void RoomPicker_SelectedIndexChanged(object sender, EventArgs e, Picker picker)
        {
            HomeDevice.Room = picker.Items[picker.SelectedIndex];
        }

        /// <summary>
        /// Переход на страницу с инструкцией
        /// </summary>
        private async void ManualButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceManualPage(HomeDevice.Name, HomeDevice.Id));
        }

        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        private async void SaveButtonClicked(object sender, EventArgs e, View[] views)
        {
            if (String.IsNullOrEmpty(HomeDevice.Room))
            {
                await DisplayAlert("Выберите комнату", $"Комната подключения не выбрана!", "ОК");
                return;
            }

            // Деактивируем все контролы
            foreach (var view in views)
                view.IsEnabled = false;

            if (CreateNew)
            {
                // Если нужно создать новое - то сначала выполним проверку, не существует ли ещё такое.
                var existingDevices = await App.HomeDevices.GetHomeDevices();
                if (existingDevices.Any(d => d.Name == HomeDevice.Name))
                {
                    await DisplayAlert("Ошибка", $"Устройство {HomeDevice.Name} уже подключено.{Environment.NewLine}Выберите другое имя.", "ОК");
                }
                else
                {
                    var newDeviceDto = App.Mapper.Map<Data.Tables.HomeDevice>(HomeDevice);
                    await App.HomeDevices.AddHomeDevice(newDeviceDto);

                    // Пример другого способа навигации - с помощью удаления предыдущей страницы из стека и "вставки" (дано для демонстрации возможностей)
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                    Navigation.InsertPageBefore(new DeviceListPage(), this);
                    await Navigation.PopAsync();
                }
                return;
            }

            var updatedDevice = App.Mapper.Map<Data.Tables.HomeDevice>(HomeDevice);
            await App.HomeDevices.UpdateHomeDevice(updatedDevice);
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Отслеживаем изменения пользовательского ввода
        /// </summary>
        private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
        {
            if (view is Entry)
            {
                HomeDevice.Name = view.Text;
            }
            else
            {
                HomeDevice.Description = view.Text;
            }
        }
    }
}