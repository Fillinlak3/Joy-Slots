using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joy_Slots
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();

            MenuBarPanel.Visible = true;
            BetSettingsPanel.Visible = true;
            SymbolsInfoPanel.Visible = false;
        }

        private void SelectCreditValue(object sender, EventArgs e)
        {
            Value_1.Parent!.BackColor = Value_2.Parent!.BackColor = Value_3.Parent!.BackColor
            = Value_4.Parent!.BackColor = Value_5.Parent!.BackColor = Value_6.Parent!.BackColor = Color.FromArgb(56, 56, 56);

            if (sender.GetHashCode() == Value_1.GetHashCode() || sender.GetHashCode() == roundEdgesPanel1.GetHashCode())
            {
                // Mark as selected.
                Value_1.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(0.01f);
            }
            else if (sender.GetHashCode() == Value_2.GetHashCode() || sender.GetHashCode() == roundEdgesPanel2.GetHashCode())
            {
                // Mark as selected.
                Value_2.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(0.02f);
            }
            else if (sender.GetHashCode() == Value_3.GetHashCode() || sender.GetHashCode() == roundEdgesPanel3.GetHashCode())
            {
                // Mark as selected.
                Value_3.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(0.05f);
            }
            else if (sender.GetHashCode() == Value_4.GetHashCode() || sender.GetHashCode() == roundEdgesPanel4.GetHashCode())
            {
                // Mark as selected.
                Value_4.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(0.20f);
            }
            else if (sender.GetHashCode() == Value_5.GetHashCode() || sender.GetHashCode() == roundEdgesPanel5.GetHashCode())
            {
                // Mark as selected.
                Value_5.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(0.50f);
            }
            else if (sender.GetHashCode() == Value_6.GetHashCode() || sender.GetHashCode() == roundEdgesPanel6.GetHashCode())
            {
                // Mark as selected.
                Value_6.Parent.BackColor = Color.FromArgb(31, 81, 255);
                Game_UI.Settings.SetCreditValue(1.00f);
            }
            this.Focus();
        }

        private void HideMenu(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BetSettingsPanel.Visible = true;
            SymbolsInfoPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BetSettingsPanel.Visible = false;
            SymbolsInfoPanel.Visible = true;
        }

        private void Menu_VisibleChanged(object sender, EventArgs e)
        {
            MenuBarPanel.Visible = true;
            BetSettingsPanel.Visible = true;
            SymbolsInfoPanel.Visible = false;
        }
    }
}
