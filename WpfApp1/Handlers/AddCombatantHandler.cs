using System.Windows.Controls;
using System.Windows.Input;
using GurpsBattleCompanion.WPFwindows;

namespace GurpsBattleCompanion.Handlers
{
    public static class AddCombatantHandler
    {
        public static void ShowAddCombatantWindow()
        {
            Add_Combatant_Dialog add_Combatant_Dialog = new Add_Combatant_Dialog();
            add_Combatant_Dialog.Show();
        }

        public static void PreventMoreThanTwoChars(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Combine the existing text with the input text
            string newText = textBox.Text + e.Text;

            // Check if the resulting text length exceeds 2
            if (newText.Length > 2)
            {
                e.Handled = true; // Cancel the input
            }
        }

        public static void PreventMoreThanTwoCharsOnlyDigitOrNegative(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Combine the existing text with the input text
            string newText = textBox.Text + e.Text;
            string pattern = @"^-?\d{0,2}$"; // optional minus sign followed by up to two digits
            bool IsMatch = System.Text.RegularExpressions.Regex.IsMatch(newText, pattern);
            if (!IsMatch)
            {
                e.Handled = true;
            }
        }

        public static void SpeedParamFormat(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Combine the existing text with the input text
            string newText = textBox.Text + e.Text;
            string pattern = @"^(-?\d+(\.\d{0,2})?)?$";// optional minus sign followed by digits and optional decimal point and digits
            bool IsMatch = System.Text.RegularExpressions.Regex.IsMatch(newText, pattern);
            if (!IsMatch)
            {
                e.Handled = true;
            }
        }

        public static void PreventNonDigit(TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!char.IsDigit(ch))
                {
                    e.Handled = true; // Cancel the input
                    break;
                }
            }
        }
    }
}
