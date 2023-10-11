using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joy_Slots
{
    public partial class Gamble_Winning : UserControl
    {
        private List<Bitmap> card_symbols;
        private List<Bitmap> big_card_symbols;
        private List<PictureBox> history_cards;
        private int gamble_tries = 3;
        private SoundPlayer cards_flickering_sound;
        private bool gamblingButtonsAvailable;

        public Gamble_Winning()
        {
            InitializeComponent();

            card_symbols = new List<Bitmap>()
            {
                Properties.Resources.hearts_symbol,
                Properties.Resources.spades_symbol
            };
            big_card_symbols = new List<Bitmap>()
            {
                Properties.Resources.hearts_symbol_big,
                Properties.Resources.spades_symbol_big
            };
            history_cards = new List<PictureBox>()
            {
                card_5,
                card_4,
                card_3,
                card_2,
                card_1
            };
            cards_flickering_sound = new SoundPlayer(Properties.Resources.SE_cards_flickering);

            // Set control's opacity to 50%
            this.Paint += (sender, e) =>
            {
                // Calculate the new background color with 50% transparency
                int alpha = (int)(0.5f * 255); // 50% transparency (0.5 * 255)
                Color transparentBackColor = Color.FromArgb(alpha, BackColor);

                // Fill the background with the transparent color
                using (SolidBrush brush = new SolidBrush(transparentBackColor))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            };

            Random rand = new Random();
            foreach (var card in history_cards)
            {
                card.BackgroundImage = card_symbols[rand.Next(card_symbols.Count)];
            }
            card_1.BackgroundImage = Properties.Resources.small_card;
        }

        private void Setup(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                MainCard.Image = null;
                MainCard.BackgroundImage = null;
                cards_flickering_sound.Stop();
                return;
            }

            try
            {
                Task.Run(async () =>
                {
                    cards_flickering_sound.PlayLooping();
                    using (WaveOutEvent gamble_enter = new WaveOutEvent())
                    {
                        gamble_enter.Init(new WaveFileReader(Properties.Resources.SE_gamble_enter));
                        gamble_enter.Play();

                        while (gamble_enter.PlaybackState == PlaybackState.Playing)
                            await Task.Delay(100);
                    }
                });

                MainCard.Image = Properties.Resources.cards_flickering;
                LB_Istoric.Focus();
                gamble_tries = 5;
                LB_IncercariRamase.Text = gamble_tries.ToString();
                LB_SumaGamble.Text = Game_UI.LB_AmountWon.Text;
                LB_GambleCastig.Text = Math.Round(Double.Parse(LB_SumaGamble.Text) * 2, 2).ToString("F2");
                gamblingButtonsAvailable = true;
            }
            catch (Exception) { }
        }

        public async void BTN_Red_Click(object sender, EventArgs e)
        {
            if (!gamblingButtonsAvailable) return;
            gamblingButtonsAvailable = false;

            cards_flickering_sound.Stop();
            BTN_Red.Enabled = BTN_Black.Enabled = BTN_CashIn.Enabled = false;
            LB_Istoric.Focus();
            Random rand = new Random();
            int card_1_symbol_code = rand.Next(card_symbols.Count);
            card_1.BackgroundImage = card_symbols[card_1_symbol_code];
            MainCard.Image = null;
            int MainCard_symbol_code = 0;
            MainCard.BackgroundImage = big_card_symbols[card_1_symbol_code];

            if (card_1_symbol_code == MainCard_symbol_code)
            {
                SoundPlayer gamble_win = new SoundPlayer(Properties.Resources.SE_gamble_win);
                gamble_win.Play();
                MainCard.BackgroundImage = Properties.Resources.hearts_symbol_win;

                // Need to add here money growing animation.
                Game_UI.LB_AmountWon.Text = LB_SumaGamble.Text = LB_GambleCastig.Text;
                Game_UI.last_amount_won = Math.Round(Double.Parse(Game_UI.LB_AmountWon.Text), 2);
                if (gamble_tries - 1 != 0)
                    LB_GambleCastig.Text = Math.Round(Double.Parse(LB_SumaGamble.Text) * 2, 2).ToString("F2");
                await Task.Delay(1000);
                LB_IncercariRamase.Text = $"{--gamble_tries}";
                gamblingButtonsAvailable = true;
            }
            else
            {
                SoundPlayer gamble_lose = new SoundPlayer(Properties.Resources.SE_gamble_lose);
                gamble_lose.Play();

                // Maybe implement here money lose to 0 animation.
                Game_UI.LB_AmountWon.Text = "0.00";
                Game_UI.last_amount_won = 0;
                await Task.Delay(1000);
                this.Visible = false;
            }

            if (gamble_tries == 0)
            {
                BTN_CashIn_Click(sender, e);
            }
            else if (gamble_tries != 0 && Game_UI.LB_AmountWon.Text != "0.00")
            {
                MainCard.BackgroundImage = null;
                MainCard.Image = Properties.Resources.cards_flickering;
                cards_flickering_sound.PlayLooping();
            }

            for (int i = 0; i < history_cards.Count - 1; i++)
                history_cards[i].BackgroundImage = history_cards[i + 1].BackgroundImage;
            card_1.BackgroundImage = Properties.Resources.small_card;
            BTN_Red.Enabled = BTN_Black.Enabled = BTN_CashIn.Enabled = true;
        }

        public async void BTN_Black_Click(object sender, EventArgs e)
        {
            if (!gamblingButtonsAvailable) return;
            gamblingButtonsAvailable = false;

            cards_flickering_sound.Stop();
            BTN_Red.Enabled = BTN_Black.Enabled = BTN_CashIn.Enabled = false;
            LB_Istoric.Focus();
            Random rand = new Random();
            int card_1_symbol_code = rand.Next(card_symbols.Count);
            card_1.BackgroundImage = card_symbols[card_1_symbol_code];
            MainCard.Image = null;
            int MainCard_symbol_code = 1;
            MainCard.BackgroundImage = big_card_symbols[card_1_symbol_code];

            if (card_1_symbol_code == MainCard_symbol_code)
            {
                SoundPlayer gamble_win = new SoundPlayer(Properties.Resources.SE_gamble_win);
                gamble_win.Play();
                MainCard.BackgroundImage = Properties.Resources.spades_symbol_win;

                // Need to add here money growing animation.
                Game_UI.LB_AmountWon.Text = LB_SumaGamble.Text = LB_GambleCastig.Text;
                Game_UI.last_amount_won = Math.Round(Double.Parse(Game_UI.LB_AmountWon.Text), 2);
                if (gamble_tries - 1 != 0)
                    LB_GambleCastig.Text = Math.Round(Double.Parse(LB_SumaGamble.Text) * 2, 2).ToString("F2");
                await Task.Delay(1000);
                LB_IncercariRamase.Text = $"{--gamble_tries}";
                gamblingButtonsAvailable = true;
            }
            else
            {
                SoundPlayer gamble_lose = new SoundPlayer(Properties.Resources.SE_gamble_lose);
                gamble_lose.Play();

                // Maybe implement here money lose to 0 animation.
                Game_UI.LB_AmountWon.Text = "0.00";
                Game_UI.last_amount_won = 0;
                await Task.Delay(1000);
                this.Visible = false;
            }

            if (gamble_tries == 0)
            {
                BTN_CashIn_Click(sender, e);
            }
            else if (gamble_tries != 0 && Game_UI.LB_AmountWon.Text != "0.00")
            {
                MainCard.BackgroundImage = null;
                MainCard.Image = Properties.Resources.cards_flickering;
                cards_flickering_sound.PlayLooping();
            }

            for (int i = 0; i < history_cards.Count - 1; i++)
                history_cards[i].BackgroundImage = history_cards[i + 1].BackgroundImage;
            card_1.BackgroundImage = Properties.Resources.small_card;
            BTN_Red.Enabled = BTN_Black.Enabled = BTN_CashIn.Enabled = true;
        }

        public async void BTN_CashIn_Click(object sender, EventArgs e)
        {
            if (!gamblingButtonsAvailable) return;

            try
            {
                cards_flickering_sound.Stop();
                LB_Istoric.Focus();
                Game_UI.last_amount_won = Math.Round(Double.Parse(Game_UI.LB_AmountWon.Text), 2);
                await Task.Delay(200);
                // Maybe implement balance money grow animation here.
                this.Visible = false;
            }
            catch (Exception) { }
        }
    }
}
