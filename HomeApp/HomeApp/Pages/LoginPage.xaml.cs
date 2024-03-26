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
    public partial class LoginPage : ContentPage
    {
        // Константа для текста кнопки                      
        public const string BUTTON_TEXT = "Войти";
        // Переменная счетчика
        public static int loginCouner = 0;

        public LoginPage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private async void Login_Click(object sender, EventArgs e)
        {
            if (loginCouner == 0)
            {
                loginButton.Text = $"Выполняется вход..";
            }
            else if (loginCouner > 5)
            {

                await Navigation.PushAsync(new NavigatorPage());
                loginButton.IsEnabled = true;


                // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку

                var infoMessage = (Label)stackLayout.Children.Last();
                // Задаем текст элемента
                infoMessage.TextColor = Color.FromRgb(255, 127, 80);
                infoMessage.Text = "Слишком много попыток! Попробуйте позже";

                

            }
            else
            {
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCouner}";
            }

            loginCouner += 1;
        }
    }
}