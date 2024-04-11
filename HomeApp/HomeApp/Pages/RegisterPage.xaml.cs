using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    public partial class RegisterPage : ContentPage
    {
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Register";
        // Переменная счетчика
        

        public static string email = null;

        public RegisterPage()
        {
            InitializeComponent();
            PlatformAdjust();

            var passFiled = new Entry();
            var passFieldTrigger = new Trigger(typeof(Entry))
            {
                Property = Entry.IsFocusedProperty,
                Value = true
            };
            passFieldTrigger.Setters.Add(new Setter()
            {
                Property = Entry.BackgroundColorProperty,
                Value = Color.Gray
            });
            passFiled.Triggers.Add(passFieldTrigger);
            placeHolder.Triggers.Add(passFieldTrigger);

        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                // Если первая попытка - просто меняем сообщения
                registerButton.Text = $"Введите email";
            }
           
        }
        public void PlatformAdjust()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                placeHolder.PlaceholderColor = Color.SlateGray;
                registerButton.TextColor = Color.AliceBlue;
                registerButton.Margin = new Thickness(0, 5);
            }
            
        }


    }
}