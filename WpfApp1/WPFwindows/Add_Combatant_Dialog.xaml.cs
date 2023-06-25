using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GurpsBattleCompanion.Handlers;
using GurpsBattleCompanion.Entities;

namespace GurpsBattleCompanion.WPFwindows
{
    /// <summary>
    /// Interaction logic for Add_Combatant_Dialog.xaml
    /// </summary>
    public partial class Add_Combatant_Dialog : Window
    {
        public Combatant combatant = new Combatant();
        private int ST, DX, IQ, HT;

        // base combatant`s params are values of params gotten from GURPS formulas
        private int BaseHP, BaseFP, BaseWill, BasePer, BaseSpeed, BaseMove;
        
        // manual combatant`s params are values of params added manually
        // so we any combatant`s param is BaseParam value + ManualParamValue
        private int ManualHP, ManualFP, ManualWill, ManualPer, ManualSpeed, ManualMove;

        public Add_Combatant_Dialog()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ST = 0; DX = 0; IQ = 0; HT = 0; 
        }

        /// <summary>
        /// Character`s params must be only digits and maximum two symbols (00 - 99)
        /// </summary>
        private void PreviewInput_Adjust_Format(object sender, TextCompositionEventArgs e)
        {
            AddCombatantHandler.PreventMoreThanTwoChars(sender, e);
            AddCombatantHandler.PreventNonDigit(e);
        }

        private void HT_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            HT = parsedValue;

            // adjust secondary params according to GURPS rules
            Base_FP_Textbox.Text = HT.ToString();
            Base_SP_Textbox.Text = (((double)HT + (double)(DX)) / 4).ToString("F2");
            Base_MV_Textbox.Text = Math.Truncate((((double)HT + (double)(DX)) / 4)).ToString();
        }

        private void IQ_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            IQ = parsedValue;

            // adjust secondary params according to GURPS rules
            Base_WP_Textbox.Text = IQ.ToString();
            Base_PR_Textbox.Text = IQ.ToString();
        }

        private void DX_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            DX = parsedValue;

            // adjust secondary params according to GURPS rules
            Base_SP_Textbox.Text = (((double)HT + (double)(DX)) / 4).ToString("F2");
            Base_MV_Textbox.Text = Math.Truncate((((double)HT + (double)(DX)) / 4)).ToString();
        }

        private void ST_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;

            int.TryParse(newValue, out int parsedValue);
            ST = parsedValue;

            // adjust secondary params according to GURPS rules
            Base_HP_Textbox.Text = ST.ToString();
        }
  
    }
}
