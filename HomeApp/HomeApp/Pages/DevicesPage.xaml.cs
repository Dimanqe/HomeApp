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

            // Сохраним в стек имеющиеся данные, используя свойство Children
            foreach (string deviceName in homeDevices)
            {
                var deviceLabel = new Label() { Text = $"   {deviceName}", FontSize = 17 };
                innerStack.Children.Add(new Label() { Margin=new Thickness(10) });
                innerStack.Children.Add(deviceLabel);
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