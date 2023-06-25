using System.Windows.Controls;
using System.Windows.Input;
using GurpsBattleCompanion.WPFwindows;

namespace GurpsBattleCompanion.Handlers
{
    public class AddCombatantHandler
    {
        public static void ShowAddCombatantWindow()
        {
            Add_Combatant_Dialog add_Combatant_Dialog = new Add_Combatant_Dialog();
            add_Combatant_Dialog.Show();
        }

        public static void AddCombatantInputChanged()
        {

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
