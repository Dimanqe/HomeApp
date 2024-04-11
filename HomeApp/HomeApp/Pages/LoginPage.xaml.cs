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
        public const string REGBUTTON_TEXT = "Регистрация";
        // Переменная счетчика
        public static int loginCouner = 0;
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();
        public LoginPage()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                loginButton.CornerRadius = 0;
                runningDevice.Text = detector.GetDevice();
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                loginButton.CornerRadius = 15;
                //runningDevice.Text = detector.GetDevice();
            }

        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        //private async void Login_Click(object sender, EventArgs e)
        //{
        //    if (loginCouner == 0)
        //    {
        //        loginButton.Text = $"Выполняется вход..";
        //    }
        //    else if (loginCouner > 5)
        //    {

        //        loginButton.IsEnabled = false;
        //        Resources["errorColor"] = Color.FromHex("#e70d4f");

        //        // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку

        //        //var infoMessage = (Label)stackLayout.Children.Last();
        //        // Задаем текст элемента
        //        //infoMessage.TextColor = (Color)Application.Current.Resources["errorColor"];
        //        infoMessage.SetDynamicResource(Label.TextColorProperty, "errorColor");
        //        infoMessage.Text = "Слишком много попыток! Попробуйте позже";


        //        await Navigation.PushAsync(new NavigatorPage());
        //        loginButton.Text = BUTTON_TEXT;
        //        loginButton.IsEnabled=true;

        //    }
        //    else
        //    {
        //        Resources["errorColor"] = Color.FromHex("#ff8e00");
        //        loginButton.Text = $"Выполняется вход...   ";
        //        infoMessage.Text = $"Попыток входа: {loginCouner}";
        //    }

        //    loginCouner += 1;
        //}

        /// <summary>
        /// По клику "логинимся" на главный экран приложения
        /// </summary>
        private async void Login_Click(object sender, EventArgs e)
        {
            loginButton.Text = $"Выполняется вход..";
            // Имитация задержки (приложение загружает данные с сервера)
            await Task.Delay(150);

            // Переход на следующую страницу - страницу списка устройств
            await Navigation.PushAsync(new DeviceListPage());
            // Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
            loginButton.Text = BUTTON_TEXT;
        }
        private async void Register_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}