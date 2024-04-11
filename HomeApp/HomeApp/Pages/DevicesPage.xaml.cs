using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HomeApp.Models;
using System.Threading.Tasks;

namespace HomeApp.Pages
{
    public partial class DevicesPage : ContentPage
    {
        public DevicesPage()
        {
            InitializeComponent();
            GetDevices();
        }

        /// <summary>
        /// Метод для выгрузки устройств
        /// </summary>
        public void GetDevices()
        {
            // Создадим некий список устройств.
            // В реальном приложении они могут доставаться из базы или веб-сервиса.
            var homeDevices = new List<HomeDevice>();

            // Заполняем список устройств
            homeDevices.Add(new HomeDevice("Чайник" /*"kettle.jpg"*/));
            homeDevices.Add(new HomeDevice("Стиральная машина"));
            homeDevices.Add(new HomeDevice("Посудомоечная машина"));
            homeDevices.Add(new HomeDevice("Мультиварка"));
            homeDevices.Add(new HomeDevice("Водонагреватель"));
            homeDevices.Add(new HomeDevice("Плита"));
            homeDevices.Add(new HomeDevice("Микроволновая печь"));
            homeDevices.Add(new HomeDevice("Духовой шкаф"));
            homeDevices.Add(new HomeDevice("Холодильник"));
            homeDevices.Add(new HomeDevice("Увлажнитель воздуха"));
            homeDevices.Add(new HomeDevice("Телевизор"));
            homeDevices.Add(new HomeDevice("Пылесос"));
            homeDevices.Add(new HomeDevice("музыкальный центр"));
            homeDevices.Add(new HomeDevice("Компьютер"));
            homeDevices.Add(new HomeDevice("Игровая консоль"));

            var innerStack = new StackLayout();

            foreach (var homeDevice in homeDevices)
            {
                var deviceLabel = new Label() { Text = homeDevice.Name, FontSize = 17 };

                var frame = new Frame()
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1),
                };

                frame.Content = deviceLabel;

                // Создаем объект, отвечающий за распознавание нажатий
                var gesture = new TapGestureRecognizer();
                // Устанавливаем по событию нажатия вызов метода  ShowImage(...) со ссылкой на изображение в качестве аргумента
                gesture.Tapped += async (sender, e) => await ShowImage(sender, e, homeDevice.Image);
                // Добавляем настроенный распознаватель нажатий в текущий фрейм
                frame.GestureRecognizers.Add(gesture);

                // Добавляем фрейм в стек для его отображения в едином списке по порядку
                innerStack.Children.Add(frame);
            }

            // Сохраним стек внутрь уже имеющегося в xaml-файле блока прокручиваемой разметки
            scrollView.Content = innerStack;
        }

        /// <summary>
        /// Показ изображения по нажатию
        /// </summary>
        public async Task ShowImage(object sender, EventArgs e, string imageName)
        {
            // Если изображение отсутствует
            if (String.IsNullOrEmpty(imageName))
            {
                //await DisplayAlert("", "Изображение устройства отсутствует", "OK");

                // Создаем новый объект изображения
                Image img = new Image(){Aspect = Aspect.AspectFill};
                // Подключаем удаленный ресурс в качестве источника изображения
                img.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri("https://i.stack.imgur.com/y9DpT.jpg")
                };

                // Инициализируем страницу
                Content = img;
                return;
            }
            Image image = new Image(){Aspect = Aspect.AspectFill};
            image.Source = ImageSource.FromResource($"HomeApp.Images.{imageName}");
            Content = image;
        }
        public async void AddNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DevicePage("Новое устрйство"));
        }
        public async void ControlPanel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceControlPage());
        }


    }
}
