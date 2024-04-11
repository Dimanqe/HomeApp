using System;
using Xamarin.Forms;

namespace HomeApp.Pages
{
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent()
                ;
        }

        /// <summary>
        /// Обработчик навигации
        /// </summary>
        void NavigateToPage(object sender, EventArgs e)
        {
            // переход по ссылке с автодополнением при необходимости
            webView.Source = new UrlWebViewSource { Url = urlEntry.Text.Contains("http") ? urlEntry.Text : $"https://{urlEntry.Text}" };
        }
    }
}