using Xamarin.Forms;

namespace HomeApp
{
    /// <summary>
    /// Действие триггера, меняющее цвет текста, пока поле заполнено неверно
    /// </summary>
    public class EmailTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry emailField)
        {
            if (emailField.IsFocused)
            {
                emailField.TextColor = emailField.Text.Contains("@") && emailField.Text.Contains(".") ? Color.AliceBlue : Color.LightPink;
            }
        }
    }
}