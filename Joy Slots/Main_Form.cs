using System.Diagnostics;
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
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            game_ui.Dispose();
            this.Dispose();
        }
    }
}