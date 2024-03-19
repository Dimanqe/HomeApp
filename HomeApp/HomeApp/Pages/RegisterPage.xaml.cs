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
        }

        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                // Если первая попытка - просто меняем сообщения
                loginButton.Text = $"Введите email";
            }
           
        }
    }
}