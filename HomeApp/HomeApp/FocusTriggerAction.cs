using Xamarin.Forms;

namespace HomeApp
{
    /// <summary>
    /// Действие триггера, добавляющее анимацию для полей в фокусе
    /// </summary>
    public class FocusTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            if (sender.IsFocused)
                sender.FadeTo(1);
        }
    }
}