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
        private int BaseHP, BaseFP, BaseWill, BasePer, BaseMove;
        private double BaseSpeed;

        // manual combatant`s params are values of params added manually
        // so any combatant`s param is BaseParam value + ManualParamValue
        private int ManualHP, ManualFP, ManualWill, ManualPer, ManualMove;
        private double ManualSpeed;

        // final params
        private int FinalHP, FinalFP, FinalWill, FinalPer, FinalMove;
        private double FinalSpeed;

        public Add_Combatant_Dialog()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ST = 0; DX = 0; IQ = 0; HT = 0; 
        }
        #region Format methods
        /// <summary>
        /// Character`s main params must be only digits and maximum two symbols (00 - 99)
        /// </summary>
        private void Adjust_FormatInput(object sender, TextCompositionEventArgs e)
        {
            AddCombatantHandler.PreventMoreThanTwoChars(sender, e);
            AddCombatantHandler.PreventNonDigit(e);
        }

        /// <summary>
        /// Manual params must be only digits and maximum two symbols. Negative values allowed
        /// </summary>
        private void Adjust_FormatManualInput(object sender, TextCompositionEventArgs e)
        {
            AddCombatantHandler.PreventMoreThanTwoCharsOnlyDigitOrNegative(sender, e);
        }

        /// <summary>
        /// Secondary param Speed must be digit with step "0.25"
        /// </summary>
        private void Adjust_FormatDoubleInput(object sender, TextCompositionEventArgs e)
        {
            AddCombatantHandler.SpeedParamFormat(sender, e);
        }
        #endregion

        #region Main Combatant`s params change methods
        private void HT_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            HT = parsedValue;

            // adjust secondary params according to GURPS rules
            BaseFP = HT;
            Base_FP_Textbox.Text = BaseFP.ToString();

            BaseSpeed = (((double)HT + (double)(DX)) / 4);
            Base_SP_Textbox.Text = BaseSpeed.ToString("F2");

            BaseMove = (int)Math.Truncate((((double)HT + (double)(DX)) / 4));
            Base_MV_Textbox.Text = BaseMove.ToString();

            // adjust final values
            FinalFP = BaseFP + ManualFP;
            Final_FP_Textbox.Text = FinalFP.ToString();

            FinalSpeed = BaseSpeed + ManualSpeed;
            Final_SP_Textbox.Text = FinalSpeed.ToString("F2");

            FinalMove = BaseMove + ManualMove;
            Final_MV_Textbox.Text = FinalMove.ToString();
        }

        private void IQ_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            IQ = parsedValue;

            // adjust secondary params according to GURPS rules
            BaseWill = IQ;
            Base_WP_Textbox.Text = BaseWill.ToString();

            BasePer = IQ;
            Base_PR_Textbox.Text = BasePer.ToString();

            // adjust final values
            FinalWill = BaseWill + ManualWill;
            Final_WP_Textbox.Text = FinalWill.ToString();

            FinalPer = BasePer + ManualPer;
            Final_PR_Textbox.Text = FinalPer.ToString();
        }

        private void DX_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);
            DX = parsedValue;

            // adjust secondary params according to GURPS rules
            BaseSpeed = (((double)HT + (double)(DX)) / 4);
            Base_SP_Textbox.Text = BaseSpeed.ToString("F2");

            BaseMove = (int)Math.Truncate((((double)HT + (double)(DX)) / 4));
            Base_MV_Textbox.Text = BaseMove.ToString();

            // adjust final values
            FinalSpeed = BaseSpeed + ManualSpeed;
            Final_SP_Textbox.Text = FinalSpeed.ToString("F2");

            FinalMove = BaseMove + ManualMove;
            Final_MV_Textbox.Text = FinalMove.ToString();
        }

        private void ST_Input_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;

            int.TryParse(newValue, out int parsedValue);
            ST = parsedValue;

            // adjust secondary params according to GURPS rules
            BaseHP = ST;
            Base_HP_Textbox.Text = BaseHP.ToString();

            //Adjust final values
            FinalHP = BaseHP + ManualHP;
            Final_HP_Textbox.Text = FinalHP.ToString();
        }
        #endregion

        #region Secondary Combatant`s params change methods
        private void Manual_HP_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);

            ManualHP = parsedValue;

            FinalHP = BaseHP + ManualHP;
            // final param can`t be less than 0
            if (FinalHP < 0) FinalHP = 0;
            Final_HP_Textbox.Text = FinalHP.ToString();
        }

        private void Manual_FP_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);

            ManualFP = parsedValue;

            FinalFP = BaseFP + ManualFP;
            // final param can`t be less than 0
            if (FinalFP < 0) FinalFP = 0;
            Final_FP_Textbox.Text = FinalFP.ToString();
        }

        private void Manual_SP_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Manual_MV_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);

            ManualMove = parsedValue;

            FinalMove = BaseMove + ManualMove;
            // final param can`t be less than 0
            if (FinalMove < 0) FinalMove = 0;
            Final_MV_Textbox.Text = FinalMove.ToString();
        }

        private void Manual_WP_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);

            ManualWill = parsedValue;

            FinalWill = BaseWill + ManualWill;
            // final param can`t be less than 0
            if (FinalWill < 0) FinalWill = 0;
            Final_WP_Textbox.Text = FinalWill.ToString();
        }

        private void Manual_PR_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string newValue = textBox.Text;
            int.TryParse(newValue, out int parsedValue);

            ManualPer = parsedValue;

            FinalPer = BasePer + ManualPer;
            // final param can`t be less than 0
            if (FinalPer < 0) FinalPer = 0;
            Final_PR_Textbox.Text = FinalPer.ToString();
        }
        #endregion
    }
}
