using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Joy_Slots
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void GameUI_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            // Scramble the slot machine.
            for (int i = 0; i < 3; i++)
            {
                game_ui.Rollbar_1.Controls[i].BackgroundImage = Game_UI.SymbolsPictures[rand.Next(Game_UI.SymbolsPictures.Count)];
                game_ui.Rollbar_2.Controls[i].BackgroundImage = Game_UI.SymbolsPictures[rand.Next(Game_UI.SymbolsPictures.Count)];
                game_ui.Rollbar_3.Controls[i].BackgroundImage = Game_UI.SymbolsPictures[rand.Next(Game_UI.SymbolsPictures.Count)];
                game_ui.Rollbar_4.Controls[i].BackgroundImage = Game_UI.SymbolsPictures[rand.Next(Game_UI.SymbolsPictures.Count)];
                game_ui.Rollbar_5.Controls[i].BackgroundImage = Game_UI.SymbolsPictures[rand.Next(Game_UI.SymbolsPictures.Count)];
            }
            game_ui.Focus();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            game_ui.Dispose();
            this.Dispose();
        }

        private void Main_Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (game_ui.gamble_Winning.Visible) game_ui.gamble_Winning.BTN_Red_Click(sender, e);
#pragma warning disable CS1690
                else if (game_ui.KeypressEvents.gamblingAvailable) game_ui.BTN_Gamble_Click(sender, e);
#pragma warning restore
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (game_ui.gamble_Winning.Visible) game_ui.gamble_Winning.BTN_Black_Click(sender, e);
#pragma warning disable CS1690
                else if (game_ui.KeypressEvents.gamblingAvailable) game_ui.BTN_Gamble_Click(sender, e);
#pragma warning restore
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (game_ui.gamble_Winning.Visible) game_ui.gamble_Winning.BTN_CashIn_Click(sender, e);
                else game_ui.BTN_Spin_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape) game_ui.BTN_Menu_Click(sender, e);
            else if (e.KeyCode == Keys.C) game_ui.Set_Bet_Amount(game_ui.BTN_Bet_1, e);
            else if (e.KeyCode == Keys.V) game_ui.Set_Bet_Amount(game_ui.BTN_Bet_2, e);
            else if (e.KeyCode == Keys.B) game_ui.Set_Bet_Amount(game_ui.BTN_Bet_3, e);
            else if (e.KeyCode == Keys.N) game_ui.Set_Bet_Amount(game_ui.BTN_Bet_4, e);
            else if (e.KeyCode == Keys.M) game_ui.Set_Bet_Amount(game_ui.BTN_Bet_5, e);
        }
    }
}