using System.Windows.Controls;

namespace CommuneCalculator.Models
{
    public class PasswordRequest
    {

        public PasswordBox PasswordBox { private get; set; }

        public PasswordBox PasswordRepeatBox { private get; set; }

        public string Password => PasswordBox.Password;

        public string PasswordRepeat => PasswordRepeatBox.Password;
    }
}