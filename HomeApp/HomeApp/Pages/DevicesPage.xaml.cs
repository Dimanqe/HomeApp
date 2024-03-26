using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            var homeDevices = new List<string>()
           {
               "Чайник",
               "Стиральная машина",
               "Посудомоечная машина",
               "Мультиварка",
               "Водонагреватель",
               "Плита",
               "Микроволновая печь",
               "Духовой шкаф",
               "Холодильник",
               "Увлажнитель воздуха",
               "Телевизор",
               "Пылесос",
               "Музыкальный центр",
               "Компьютер",
               "Игровая консоль"
           };

            // Создадим новый стек
            var innerStack = new StackLayout();

            foreach (string deviceName in homeDevices)
            {
                // Создадим текстовый элемент
                var deviceLabel = new Label() { Text = deviceName, FontSize = 17 };

                // Контейнер Frame, внутри которого будет отображаться текстовый элемент
                var frame = new Frame()
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1)
                };

                // Задаем содержимое контейнера Frame
                frame.Content = deviceLabel;

                // Добавляем фреймы в стек для их отображения в едином списке по порядку
                innerStack.Children.Add(frame);
            }
            // Сохраним стек внутрь уже имеющегося в xaml-файле блока прокручиваемой разметки
            scrollView.Content = innerStack;
        }

        public async void AddNew(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewDevicePage());
        }
    }
}