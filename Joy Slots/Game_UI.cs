using NAudio.Wave;
using System.Diagnostics;
using System.Media;

namespace Joy_Slots
{
    public partial class Game_UI : UserControl
    {
        //public List<PictureBox> Symbols;
#pragma warning disable CS8618
        public static List<Bitmap> SymbolsPictures;
        private static List<Bitmap> SpecialSymbolsPictures;
#pragma warning restore
        public Gamble_Winning gamble_Winning;
        private Menu game_menu;

        #region Game Structs
        public struct GameSettings
        {
            private bool m_volume_mute = true;
            /// <summary>
            /// In-game sounds active.
            /// </summary>
            public bool Volume_Mute { get => this.m_volume_mute; set => this.m_volume_mute = value; }

            private float m_volume_level = 1.0f;
            public float Volume_Level { get => this.m_volume_level; set => this.m_volume_level = value; }

            private bool m_canspin = false;
            public bool CanSpin { get => this.m_canspin; set => this.m_canspin = value; }

            private double m_bet_amount = 0;
            public double Bet_Amount { get => this.m_bet_amount; }

            private double m_credit_value = 1;
            public double Credit_Value { get => this.m_credit_value; }

            public GameSettings()
            {

            }

            public void SetBetAmount(double bet_amount)
            {
                this.m_bet_amount = bet_amount;
            }
            public void SetCreditValue(double credit_value)
            {
                this.m_credit_value = credit_value;
            }
        }
        public static GameSettings Settings;

        public struct KeyboardKeypressEvents
        {
            private bool m_crownAnimation = false;
            /// <summary>
            /// Disable the button press for rolling lines to prevent bug.
            /// </summary>
            public bool crownAnimation { get => this.m_crownAnimation; set => this.m_crownAnimation = value; }

            private bool m_gamblingAvailable = false;
            /// <summary>
            /// If user has a current win that can be gambled.
            /// </summary>
            public bool gamblingAvailable { get => this.m_gamblingAvailable; set => this.m_gamblingAvailable = value; }

            public KeyboardKeypressEvents()
            {

            }
        }
        public KeyboardKeypressEvents KeypressEvents;

        struct WinningLine
        {
            public List<PictureBox> Symbols;
            public int symbols_count;
            public int line;
            public double amount_won;

            public WinningLine(int line, List<PictureBox> Symbols, int symbols_count = 0, double amount_won = 0)
            {
                this.line = line;
                this.Symbols = Symbols;
                this.symbols_count = symbols_count;
                this.amount_won = amount_won;
            }

            public WinningLine SetSymbolsCount(int symbols_count)
            {
                this.symbols_count = symbols_count;
                return this;
            }

            public WinningLine SetAmountWon(double amount_won)
            {
                this.amount_won = amount_won;
                return this;
            }
        }
        List<WinningLine> WinningLines;

        struct Symbol
        {
            Image? Image = null;
            string? Name = String.Empty;
            double Value_on_2 = 0, Value_on_3, Value_on_4, Value_on_5;

            public Symbol(Image picture)
            {
                if (SymbolsPictures.Contains(picture) == false && SpecialSymbolsPictures.Contains(picture) == false)
                    throw new Exception(@"Symbol's picture not found in list.");

                this.Image = picture;
                if (picture == SymbolsPictures[0])
                {
                    this.Name = "Robert";
                    Value_on_2 = Math.Round(Settings.Bet_Amount, 2);
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 5, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 25, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 500, 2);
                }
                else if (picture == SymbolsPictures[1])
                {
                    this.Name = "Bucurie";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 4, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 12, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 70, 2);
                }
                else if (picture == SymbolsPictures[2])
                {
                    this.Name = "Teo";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 4, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 12, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 70, 2);
                }
                else if (picture == SymbolsPictures[3])
                {
                    this.Name = "Rizea";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 2, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 4, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 20, 2);
                }
                else if (picture == SymbolsPictures[4])
                {
                    this.Name = "Rusu";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 1, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 3, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 15, 2);
                }
                else if (picture == SymbolsPictures[5])
                {
                    this.Name = "Catanoiu";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 1, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 3, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 15, 2);
                }
                else if (picture == SymbolsPictures[6])
                {
                    this.Name = "Gabi";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 1, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 3, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 15, 2);
                }
                else if (picture == SymbolsPictures[7])
                {
                    this.Name = "Petru";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 1, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 3, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 15, 2);
                }
                else if (picture == SpecialSymbolsPictures[1])
                {
                    this.Name = "Scatter-Dollar";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 5, 2);
                    Value_on_4 = Math.Round(Settings.Bet_Amount * 20, 2);
                    Value_on_5 = Math.Round(Settings.Bet_Amount * 100, 2);
                }
                else if (picture == SpecialSymbolsPictures[2])
                {
                    this.Name = "Scatter-Star";
                    Value_on_3 = Math.Round(Settings.Bet_Amount * 20, 2);
                }
            }
            public double GetValue(int number_of_symbols)
            {
                switch (number_of_symbols)
                {
                    case 2:
                        return Value_on_2;
                    case 3:
                        return Value_on_3;
                    case 4:
                        return Value_on_4;
                    case 5:
                        return Value_on_5;
                    default:
                        return 0;
                }
            }
        }
        #endregion

        public Game_UI()
        {
            InitializeComponent();
            Settings = new GameSettings();
            Settings.SetCreditValue(0.01f);

            // gamble_Winning
            gamble_Winning = new Gamble_Winning();
            gamble_Winning.Visible = false;
            gamble_Winning.Location = new Point(228, 113);
            gamble_Winning.TabIndex = 0;
            gamble_Winning.TabStop = false;
            gamble_Winning.BackColor = Color.Transparent;
            gamble_Winning.Margin = new Padding(0);
            gamble_Winning.Name = "gamble_Winning";
            gamble_Winning.Size = new Size(1210, 690);
            gamble_Winning.VisibleChanged += ReturnFromGamble!;
            this.Controls.Add(gamble_Winning);
            gamble_Winning.BringToFront();

            // game_menu
            game_menu = new Menu();
            game_menu.Visible = false;
            game_menu.Location = new Point(228, 113);
            game_menu.Name = "gamble_menu";
            game_menu.TabIndex = 0;
            game_menu.TabStop = false;
            game_menu.Size = new Size(1210, 690);
            for (int i = 0; i < 6; i++)
            {
                game_menu.BetSettingsPanel.Controls[i].Click += (sender, e) => Set_Bet_Amount(BTN_Bet_1, e);
                game_menu.BetSettingsPanel.Controls[i].Controls[0].Click += (sender, e) => Set_Bet_Amount(BTN_Bet_1, e);
                game_menu.BetSettingsPanel.Controls[i].Cursor =
                game_menu.BetSettingsPanel.Controls[i].Controls[0].Cursor = Cursors.Hand;
            }
            game_menu.VisibleChanged += (sender, e) => { Settings.CanSpin = BTN_Spin.Visible = !game_menu.Visible; };
            this.Controls.Add(game_menu);
            game_menu.BringToFront();

            SymbolsPictures = new List<Bitmap>() {
                Properties.Resources.Robert,
                Properties.Resources.Bucurie_2,
                Properties.Resources.Teo,
                Properties.Resources.Rizea,
                Properties.Resources.Rusu,
                Properties.Resources.Catanoiu,
                Properties.Resources.Gabi,
                Properties.Resources.Petru
            };
            SpecialSymbolsPictures = new List<Bitmap>()
            {
                Properties.Resources.Iris,
                Properties.Resources.Ali,
                Properties.Resources.Jumi
            };
            WinningLines = new List<WinningLine>();
            WinningLinesAnimation.Enabled = false;

            Set_Bet_Amount(BTN_Bet_1, null!);
            LB_LeiWinning.Visible = false;
            LB_AmountWon.Visible = false;
            BTN_Gamble.Visible = false;
            BTN_CashIn.Visible = false;
            LB_Balance.Text = "100.00";
            Settings.CanSpin = true;
            Logo_Picture.Focus();
            UpdateTextsLocation();
        }

        /// <summary>
        /// Stop the spin.
        /// </summary>
        public CancellationTokenSource? cancellationTokenSource;
        /// <summary>
        /// The button that activates the scrambling and rolling animation that
        /// can be stopped and then checks for win.
        /// </summary>
        public async void BTN_Spin_Click(object sender, EventArgs e)
        {
            // Preventing the rolling bug here.
            if (KeypressEvents.crownAnimation) return;

            // If the user stops the spin (presses a second time on the button).
            if (String.IsNullOrWhiteSpace(LB_Status.Text) || cancellationTokenSource != null)
            {
                // Animation is currently running, cancel it.
                if (cancellationTokenSource != null)
                {
                    // Don't stop the reels immediately.
                    if (String.IsNullOrWhiteSpace(LB_Status.Text)) await Task.Delay(200); // Initial value: 400

                    // Send stop request.
                    if (cancellationTokenSource != null)
                        cancellationTokenSource.Cancel();
                    return;
                }
            }
            if (Settings.CanSpin == false) return;

            // Add the last winning to balance.
            if (last_amount_won != 0) { LB_Balance.Text = Math.Round(Double.Parse(LB_Balance.Text) + last_amount_won, 2).ToString("F2"); last_amount_won = 0; }

            // Clear all animations.
            Logo_Picture.Focus();
            BTN_CashIn.Visible = false;
            BTN_Gamble.Visible = false;
            KeypressEvents.gamblingAvailable = false;
            KeypressEvents.crownAnimation = false;
            WinningLinesAnimation.Enabled = false;
            LB_Winning.Text = "ULTIMUL CÂȘTIG:";
            LB_Status.Text = "";
            UpdateTextsLocation();
            ClearLines(clear_fires: true);

            // Check the balance status.
            if (Math.Round(Double.Parse(LB_Balance.Text), 2) == 0)
            { LB_Status.Text = "SESIUNE DE JOC TERMINATĂ. VĂ MULȚUMIM!"; MessageBox.Show("Balanță incompatibilă."); BTN_Spin.Visible = false; return; }
            else if (Math.Round(Double.Parse(LB_Balance.Text) - Settings.Bet_Amount, 2) < 0)
            { LB_Status.Text = $"VĂ RUGĂM, SELECTAȚI ALT BET."; MessageBox.Show("Bet necorespunzător."); return; }

            // Accept the bet and take the money from balance.
            LB_Balance.Text = Math.Round(Double.Parse(LB_Balance.Text) - Settings.Bet_Amount, 2).ToString("F2");

            // Button press sound and reels_rolling.
            SoundPlayer reels_rolling_sound = new SoundPlayer(Properties.Resources.roller_rolling);
            WaveOutEvent button_sound = new WaveOutEvent();
            button_sound.Init(new WaveFileReader(Properties.Resources.spin_button));
            button_sound.Volume = Settings.Volume_Level;
            button_sound.Play();

            // Block the button to prevent bugs.
            BTN_Spin.Visible = Settings.CanSpin = false;

            // Create the token for stopping the reels if the user asks.
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Special Symbols Rarity Percentage.
            float special_symbol_percentage = 0.10f;
            Random rand = new Random();
            List<Task> tasks = new List<Task>()
            {
                new Task(async () => {
                    reels_rolling_sound.PlayLooping();
                    for (int i = 0; i < 20 && cancellationToken.IsCancellationRequested == false; i++)
                    {
                        for (int j = 2; j >= 1; j--)
                        {
                            Rollbar_1.Controls[j].BackgroundImage = Rollbar_1.Controls[j - 1].BackgroundImage;
                        }
                        Rollbar_1.Controls[0].BackgroundImage = SymbolsPictures[rand.Next(SymbolsPictures.Count)];
                        await Task.Delay(17);
                    }
                    if(rand.NextDouble() < special_symbol_percentage)
                        Rollbar_1.Controls[rand.Next(2)].BackgroundImage = SpecialSymbolsPictures[rand.Next(1, SpecialSymbolsPictures.Count)];

                    bool special_sound = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if(Rollbar_1.Controls[i].BackgroundImage == SpecialSymbolsPictures[1])
                        {
                            using (WaveOutEvent scatter_dollar_sound = new WaveOutEvent())
                            {
                                scatter_dollar_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_ding));
                                scatter_dollar_sound.Play();
                                while (scatter_dollar_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_1.Controls[i].BackgroundImage == SpecialSymbolsPictures[2])
                        {
                            using (WaveOutEvent scatter_star_sound = new WaveOutEvent())
                            {
                                scatter_star_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_TONE_1));
                                scatter_star_sound.Play();
                                while (scatter_star_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                    }

                    if(special_sound == false)
                    {
                        using (WaveOutEvent roller_stop_sound = new WaveOutEvent())
                        {
                            roller_stop_sound.Init(new WaveFileReader(Properties.Resources.roller_stop));
                            roller_stop_sound.Play();
                            while (roller_stop_sound.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }),
                new Task(async () => {
                    for (int i = 0; i < 30 && cancellationToken.IsCancellationRequested == false; i++)
                    {
                        for (int j = 2; j >= 1; j--)
                        {
                            Rollbar_2.Controls[j].BackgroundImage = Rollbar_2.Controls[j - 1].BackgroundImage;
                        }
                        Rollbar_2.Controls[0].BackgroundImage = SymbolsPictures[rand.Next(SymbolsPictures.Count)];
                        await Task.Delay(30);
                    }
                    if(rand.NextDouble() < special_symbol_percentage)
                        Rollbar_2.Controls[rand.Next(2)].BackgroundImage = SpecialSymbolsPictures[rand.Next(2)];

                    bool special_sound = false;
                    for (int i = 0; i < 3; i++) {
                        if(Rollbar_2.Controls[i].BackgroundImage == SpecialSymbolsPictures[0])
                        {
                            using (WaveOutEvent crown_sound = new WaveOutEvent())
                            {
                                crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance));
                                crown_sound.Play();
                                while (crown_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_2.Controls[i].BackgroundImage == SpecialSymbolsPictures[1])
                        {
                            using (WaveOutEvent scatter_dollar_sound = new WaveOutEvent())
                            {
                                scatter_dollar_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_ding));
                                scatter_dollar_sound.Play();
                                while (scatter_dollar_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                    }

                    if(special_sound == false)
                    {
                        using (WaveOutEvent roller_stop = new WaveOutEvent())
                        {
                            roller_stop.Init(new WaveFileReader(Properties.Resources.roller_stop));
                            roller_stop.Play();
                            while (roller_stop.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }),
                new Task(async () => {
                    for (int i = 0; i < 40 && cancellationToken.IsCancellationRequested == false; i++)
                    {
                        for (int j = 2; j >= 1; j--)
                        {
                            Rollbar_3.Controls[j].BackgroundImage = Rollbar_3.Controls[j - 1].BackgroundImage;
                        }
                        Rollbar_3.Controls[0].BackgroundImage = SymbolsPictures[rand.Next(SymbolsPictures.Count)];
                        await Task.Delay(30);
                    }
                    if(rand.NextDouble() < special_symbol_percentage)
                        Rollbar_3.Controls[rand.Next(2)].BackgroundImage = SpecialSymbolsPictures[rand.Next(SpecialSymbolsPictures.Count)];

                    bool special_sound = false;
                    for (int i = 0; i < 3; i++) {
                        if(Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[0])
                        {
                            using (WaveOutEvent crown_sound = new WaveOutEvent())
                            {
                                crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance));
                                crown_sound.Play();
                                while (crown_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[1])
                        {
                            using (WaveOutEvent  scatter_dollar_sound = new WaveOutEvent())
                            {
                                scatter_dollar_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_ding));
                                scatter_dollar_sound.Play();
                                while (scatter_dollar_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[2])
                        {
                            using (WaveOutEvent  scatter_star_sound = new WaveOutEvent())
                            {
                                scatter_star_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_TONE_2));
                                scatter_star_sound.Play();
                                while (scatter_star_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                    }

                    if(special_sound == false)
                    {
                        using (WaveOutEvent roller_stop = new WaveOutEvent())
                        {
                            roller_stop.Init(new WaveFileReader(Properties.Resources.roller_stop));
                            roller_stop.Play();
                            while (roller_stop.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }),
                new Task(async () => {
                    for (int i = 0; i < 36 && cancellationToken.IsCancellationRequested == false; i++)
                    {
                        for (int j = 2; j >= 1; j--)
                        {
                            Rollbar_4.Controls[j].BackgroundImage = Rollbar_4.Controls[j - 1].BackgroundImage;
                        }
                        Rollbar_4.Controls[0].BackgroundImage = SymbolsPictures[rand.Next(SymbolsPictures.Count)];
                        await Task.Delay(33);
                    }
                    if(rand.NextDouble() < special_symbol_percentage)
                        Rollbar_4.Controls[rand.Next(2)].BackgroundImage = SpecialSymbolsPictures[rand.Next(2)];

                    bool special_sound = false;
                    for (int i = 0; i < 3; i++) {
                        if(Rollbar_4.Controls[i].BackgroundImage == SpecialSymbolsPictures[0])
                        {
                            using (WaveOutEvent crown_sound = new WaveOutEvent())
                            {
                                crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance));
                                crown_sound.Play();
                                while (crown_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_4.Controls[i].BackgroundImage == SpecialSymbolsPictures[1])
                        {
                            using (WaveOutEvent  scatter_dollar_sound = new WaveOutEvent())
                            {
                                scatter_dollar_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_ding));
                                scatter_dollar_sound.Play();
                                while (scatter_dollar_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                    }

                    if(special_sound == false)
                    {
                        using (WaveOutEvent roller_stop = new WaveOutEvent())
                        {
                            roller_stop.Init(new WaveFileReader(Properties.Resources.roller_stop));
                            roller_stop.Play();
                            while (roller_stop.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }),
                new Task(async () => {
                    for (int i = 0; i < 43 && cancellationToken.IsCancellationRequested == false; i++)
                    {
                        for (int j = 2; j >= 1; j--)
                        {
                            Rollbar_5.Controls[j].BackgroundImage = Rollbar_5.Controls[j - 1].BackgroundImage;
                        }
                        Rollbar_5.Controls[0].BackgroundImage = SymbolsPictures[rand.Next(SymbolsPictures.Count)];
                        await Task.Delay(33);
                    }
                    reels_rolling_sound.Stop();
                    lock(reels_rolling_sound) reels_rolling_sound.Dispose();
                    if(rand.NextDouble() < special_symbol_percentage)
                        Rollbar_5.Controls[rand.Next(2)].BackgroundImage = SpecialSymbolsPictures[rand.Next(1, SpecialSymbolsPictures.Count)];

                    bool special_sound = false;
                    for (int i = 0; i < 3; i++)
                    {
                        if(Rollbar_5.Controls[i].BackgroundImage == SpecialSymbolsPictures[1])
                        {
                            using (WaveOutEvent  scatter_dollar_sound = new WaveOutEvent())
                            {
                                scatter_dollar_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_ding));
                                scatter_dollar_sound.Play();
                                while (scatter_dollar_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                        else if(Rollbar_5.Controls[i].BackgroundImage == SpecialSymbolsPictures[2])
                        {
                            using (WaveOutEvent  scatter_star_sound = new WaveOutEvent())
                            {
                                scatter_star_sound.Init(new WaveFileReader(Properties.Resources.SE_scatter_TONE_2));
                                scatter_star_sound.Play();
                                while (scatter_star_sound.PlaybackState == PlaybackState.Playing)
                                    await Task.Delay(100);
                            }
                            special_sound = true;
                            break;
                        }
                    }

                    if(special_sound == false)
                    {
                        using (WaveOutEvent roller_stop = new WaveOutEvent())
                        {
                            roller_stop.Init(new WaveFileReader(Properties.Resources.roller_stop));
                            roller_stop.Play();
                            while (roller_stop.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }),
            };

            try
            {
                foreach (var task in tasks)
                    task.Start();

                await Task.WhenAll(Task.WhenAll(tasks), Task.Delay(2000, cancellationToken));
            }
            catch (OperationCanceledException)
            {
                // Animation was cancelled.
                // Handle any cleanup or additional logic if needed.
                Debug.WriteLine("[Spinning Animation] was cancelled");
                cancellationTokenSource = null;
            }
            finally
            {
                button_sound.Dispose();
                await Task.Delay(100); // Initial value: 200
                cancellationTokenSource = null;
                CheckWin();
                await Task.Delay(250);
                BTN_Spin.Visible = true;
                Settings.CanSpin = true;
            }
        }

        /// <summary>
        /// Set the betting amount by pressing on the buttons on the bottom page.
        /// </summary>
        public void Set_Bet_Amount(object sender, EventArgs e)
        {
            if (Settings.CanSpin == false) { BTN_Spin_Click(sender, e); return; }

            BTN_Bet_1.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_2.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_3.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_4.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_5.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            //Logo_Picture.Focus();

            BTN_Bet_1.Text = Math.Round(Settings.Credit_Value * 20, 2).ToString("F2");
            BTN_Bet_2.Text = Math.Round(Settings.Credit_Value * 50, 2).ToString("F2");
            BTN_Bet_3.Text = Math.Round(Settings.Credit_Value * 100, 2).ToString("F2");
            BTN_Bet_4.Text = Math.Round(Settings.Credit_Value * 300, 2).ToString("F2");
            BTN_Bet_5.Text = Math.Round(Settings.Credit_Value * 500, 2).ToString("F2");

            if (sender.GetHashCode() == BTN_Bet_1.GetHashCode())
            { Settings.SetBetAmount(Math.Round(Settings.Credit_Value * 20, 2)); BTN_Bet_1.BackgroundImage = Properties.Resources.Placebet_Buttons_Marked_Background; }
            else if (sender.GetHashCode() == BTN_Bet_2.GetHashCode())
            { Settings.SetBetAmount(Math.Round(Settings.Credit_Value * 50, 2)); BTN_Bet_2.BackgroundImage = Properties.Resources.Placebet_Buttons_Marked_Background; }
            else if (sender.GetHashCode() == BTN_Bet_3.GetHashCode())
            { Settings.SetBetAmount(Math.Round(Settings.Credit_Value * 100, 2)); BTN_Bet_3.BackgroundImage = Properties.Resources.Placebet_Buttons_Marked_Background; }
            else if (sender.GetHashCode() == BTN_Bet_4.GetHashCode())
            { Settings.SetBetAmount(Math.Round(Settings.Credit_Value * 300, 2)); BTN_Bet_4.BackgroundImage = Properties.Resources.Placebet_Buttons_Marked_Background; }
            else if (sender.GetHashCode() == BTN_Bet_5.GetHashCode())
            { Settings.SetBetAmount(Math.Round(Settings.Credit_Value * 500, 2)); BTN_Bet_5.BackgroundImage = Properties.Resources.Placebet_Buttons_Marked_Background; }

            #region Menu Symbols Info
            game_menu.Scatter_Star_3.Text = $"{Math.Round(Settings.Bet_Amount * 20, 2):F2} RON";

            game_menu.Scatter_Dollar_3.Text = $"{Math.Round(Settings.Bet_Amount * 5, 2):F2} RON";
            game_menu.Scatter_Dollar_4.Text = $"{Math.Round(Settings.Bet_Amount * 20, 2):F2} RON";
            game_menu.Scatter_Dollar_5.Text = $"{Math.Round(Settings.Bet_Amount * 100, 2):F2} RON";

            game_menu.Symbol1_2.Text = $"{Math.Round(Settings.Bet_Amount, 2):F2} RON";
            game_menu.Symbol1_3.Text = $"{Math.Round(Settings.Bet_Amount * 5, 2):F2} RON";
            game_menu.Symbol1_4.Text = $"{Math.Round(Settings.Bet_Amount * 25, 2):F2} RON";
            game_menu.Symbol1_5.Text = $"{Math.Round(Settings.Bet_Amount * 500, 2):F2} RON";

            game_menu.Symbol2_3.Text = $"{Math.Round(Settings.Bet_Amount * 4, 2):F2} RON";
            game_menu.Symbol2_4.Text = $"{Math.Round(Settings.Bet_Amount * 12, 2):F2} RON";
            game_menu.Symbol2_5.Text = $"{Math.Round(Settings.Bet_Amount * 70, 2):F2} RON";

            game_menu.Symbol3_3.Text = $"{Math.Round(Settings.Bet_Amount * 4, 2):F2} RON";
            game_menu.Symbol3_4.Text = $"{Math.Round(Settings.Bet_Amount * 12, 2):F2} RON";
            game_menu.Symbol3_5.Text = $"{Math.Round(Settings.Bet_Amount * 70, 2):F2} RON";

            game_menu.Symbol4_3.Text = $"{Math.Round(Settings.Bet_Amount * 2, 2):F2} RON";
            game_menu.Symbol4_4.Text = $"{Math.Round(Settings.Bet_Amount * 4, 2):F2} RON";
            game_menu.Symbol4_5.Text = $"{Math.Round(Settings.Bet_Amount * 20, 2):F2} RON";

            game_menu.Symbols5_3.Text = $"{Math.Round(Settings.Bet_Amount * 1, 2):F2} RON";
            game_menu.Symbols5_4.Text = $"{Math.Round(Settings.Bet_Amount * 3, 2):F2} RON";
            game_menu.Symbols5_5.Text = $"{Math.Round(Settings.Bet_Amount * 15, 2):F2} RON";
            #endregion

            BTN_Spin_Click(sender, e);
        }

        /// <summary>
        /// Draw the symbol's border in a winning line.
        /// </summary>
        private void SymbolPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            PictureBox symbolPictureBox = (PictureBox)sender!;

            var borderRect = new Rectangle(
                symbolPictureBox.ClientRectangle.Left,
                symbolPictureBox.ClientRectangle.Top,
                symbolPictureBox.ClientRectangle.Width - 1,
                symbolPictureBox.ClientRectangle.Height - 1
            );

            using (var pen = new Pen(Color.Magenta, 10))
            {
                e.Graphics.DrawRectangle(pen, borderRect);
            }
        }

        /// <summary>
        /// Keep track of the last amount won.
        /// </summary>
        public static double last_amount_won = 0;
        /// <summary>
        /// After rolling and scrambling the lines, check for win.
        /// </summary>
        private async void CheckWin()
        {
            // Amount won from a winning line.
            double amount_won = 0;
            // Total winning amount from all lines.
            double total_winning = 0;
            // Number of connected symbols from a winning line.
            int number_of_symbols = 0;
            // Checks if there is at least one winning line.
            bool winning_hand = false;
            // Fast reply for animation.
            WinningLinesAnimation.Interval = 10;
            WinningLines.Clear();
            bool crown_roll_1_line = false, crown_roll_2_line = false, crown_roll_3_line = false;
            bool[] crown_roll = new bool[3] { false, false, false };
            for (int i = 0; i < 3; i++)
            {
                if (Rollbar_2.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) crown_roll[0] = true;
                if (Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) crown_roll[1] = true;
                if (Rollbar_4.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) crown_roll[2] = true;
            }
            bool[] dollar_roll = new bool[3] { false, false, false };
            for (int i = 0; i < 3; i++)
            {
                if (Rollbar_1.Controls[i].BackgroundImage == SpecialSymbolsPictures[1]) dollar_roll[0] = true;
                if (Rollbar_2.Controls[i].BackgroundImage == SpecialSymbolsPictures[1]) dollar_roll[1] = true;
                if (Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[1]) dollar_roll[2] = true;
            }
            bool[] star_roll = new bool[3] { false, false, false };
            for (int i = 0; i < 3; i++)
            {
                if (Rollbar_1.Controls[i].BackgroundImage == SpecialSymbolsPictures[2]) star_roll[0] = true;
                if (Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[2]) star_roll[1] = true;
                if (Rollbar_5.Controls[i].BackgroundImage == SpecialSymbolsPictures[2]) star_roll[2] = true;
            }

            #region Check Winning Lines
            // Check Dollars Roll win.
            amount_won = 0;
            if (dollar_roll.Contains(true))
            {
                List<PictureBox> dollars = new List<PictureBox>();
                // Roll 1.
                if (Symbol_1.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_1);
                else if (Symbol_2.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_2);
                else if (Symbol_3.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_3);
                // Roll 2.
                if (Symbol_4.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_4);
                else if (Symbol_5.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_5);
                else if (Symbol_6.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_6);
                // Roll 3.
                if (Symbol_7.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_7);
                else if (Symbol_8.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_8);
                else if (Symbol_9.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_9);
                // Roll 4.
                if (Symbol_10.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_10);
                else if (Symbol_11.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_11);
                else if (Symbol_12.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_12);
                // Roll 5.
                if (Symbol_13.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_13);
                else if (Symbol_14.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_14);
                else if (Symbol_15.BackgroundImage == SpecialSymbolsPictures[1]) dollars.Add(Symbol_15);

                number_of_symbols = dollars.Count;
                amount_won = new Symbol(SpecialSymbolsPictures[1]!).GetValue(number_of_symbols);
                total_winning += amount_won;
                if (number_of_symbols >= 3 && amount_won != 0) { WinningLines.Add(new WinningLine(11, dollars, number_of_symbols, amount_won)); winning_hand = true; }
            }
            // Check Star Roll win.
            amount_won = 0;
            if (star_roll.Contains(true))
            {
                List<PictureBox> stars = new List<PictureBox>();
                // Roll 1.
                if (Symbol_1.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_1);
                else if (Symbol_2.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_2);
                else if (Symbol_3.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_3);
                // Roll 3.
                if (Symbol_7.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_7);
                else if (Symbol_8.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_8);
                else if (Symbol_9.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_9);
                // Roll 5.
                if (Symbol_13.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_13);
                else if (Symbol_14.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_14);
                else if (Symbol_15.BackgroundImage == SpecialSymbolsPictures[2]) stars.Add(Symbol_15);

                number_of_symbols = stars.Count;
                amount_won = new Symbol(SpecialSymbolsPictures[2]!).GetValue(number_of_symbols);
                total_winning += amount_won;
                if (number_of_symbols == 3 && amount_won != 0) { WinningLines.Add(new WinningLine(11, stars, number_of_symbols, amount_won)); winning_hand = true; }
            }

            // Line 1.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_2.Controls[1].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_3.Controls[1].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_4.Controls[1].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_5.Controls[1].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[1].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(1, new List<PictureBox>() { Symbol_2, Symbol_5, Symbol_8, Symbol_11, Symbol_14 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Line 2.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_2.Controls[0].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_3.Controls[0].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_4.Controls[0].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_5.Controls[0].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[0].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(2, new List<PictureBox>() { Symbol_1, Symbol_4, Symbol_7, Symbol_10, Symbol_13 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Line 3.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_2.Controls[2].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_3.Controls[2].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_4.Controls[2].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_5.Controls[2].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[2].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(3, new List<PictureBox>() { Symbol_3, Symbol_6, Symbol_9, Symbol_12, Symbol_15 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 4.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_2.Controls[1].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_3.Controls[2].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_4.Controls[1].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_5.Controls[0].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[0].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(4, new List<PictureBox>() { Symbol_1, Symbol_5, Symbol_9, Symbol_11, Symbol_13 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 5.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_2.Controls[1].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_3.Controls[0].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_4.Controls[1].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_5.Controls[2].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[2].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(5, new List<PictureBox>() { Symbol_3, Symbol_5, Symbol_7, Symbol_11, Symbol_15 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 6.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_2.Controls[0].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_3.Controls[1].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_4.Controls[2].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_5.Controls[2].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[0].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(6, new List<PictureBox>() { Symbol_1, Symbol_4, Symbol_8, Symbol_12, Symbol_15 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 7.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_2.Controls[2].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[2].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_3.Controls[1].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_4.Controls[0].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[2].BackgroundImage == Rollbar_5.Controls[0].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[2].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(7, new List<PictureBox>() { Symbol_3, Symbol_6, Symbol_8, Symbol_10, Symbol_13 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 8.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_2.Controls[2].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_3.Controls[2].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_4.Controls[2].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[2].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_5.Controls[1].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[1].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(8, new List<PictureBox>() { Symbol_2, Symbol_6, Symbol_9, Symbol_12, Symbol_14 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 9.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_2.Controls[0].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[1].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_3.Controls[0].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_4.Controls[0].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[0].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[1].BackgroundImage == Rollbar_5.Controls[1].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[1].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(9, new List<PictureBox>() { Symbol_2, Symbol_4, Symbol_7, Symbol_10, Symbol_14 }, number_of_symbols, amount_won)); winning_hand = true; }

            // Linie 10.
            number_of_symbols = 1;
            amount_won = 0;
            if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_2.Controls[1].BackgroundImage || (crown_roll[0] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[1] && Rollbar_1.Controls[0].BackgroundImage != SpecialSymbolsPictures[2]))
            {
                if (crown_roll[0]) crown_roll_1_line = true;
                number_of_symbols = 2;
                if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_3.Controls[1].BackgroundImage || (crown_roll[1] && Rollbar_2.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                {
                    if (crown_roll[1]) crown_roll_2_line = true;
                    number_of_symbols = 3;
                    if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_4.Controls[1].BackgroundImage || (crown_roll[2] && Rollbar_3.Controls[1].BackgroundImage != SpecialSymbolsPictures[1]))
                    {
                        if (crown_roll[2]) crown_roll_3_line = true;
                        number_of_symbols = 4;
                        if (Rollbar_1.Controls[0].BackgroundImage == Rollbar_5.Controls[0].BackgroundImage)
                        {
                            number_of_symbols = 5;
                        }
                    }
                }
            }
            amount_won = new Symbol(Rollbar_1.Controls[0].BackgroundImage!).GetValue(number_of_symbols);
            total_winning += amount_won;
            if (number_of_symbols >= 2 && amount_won != 0) { WinningLines.Add(new WinningLine(10, new List<PictureBox>() { Symbol_1, Symbol_5, Symbol_8, Symbol_11, Symbol_13 }, number_of_symbols, amount_won)); winning_hand = true; }
            #endregion

            // If there is a winning line.
            if (winning_hand == true)
            {
                BTN_Spin.Enabled = false;
                BTN_Spin.Visible = false;
                if (crown_roll_1_line || crown_roll_2_line || crown_roll_3_line) KeypressEvents.crownAnimation = true;
                if (crown_roll[0] && crown_roll_1_line)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Rollbar_2.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) continue;
                        Rollbar_2.Controls[i].BackgroundImage = SpecialSymbolsPictures[0];
                        using (WaveOutEvent crown_sound = new WaveOutEvent())
                        {
                            crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance_2));
                            crown_sound.Play();

                            while (crown_sound.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }
                if (crown_roll[1] && crown_roll_2_line)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Rollbar_3.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) continue;
                        Rollbar_3.Controls[i].BackgroundImage = SpecialSymbolsPictures[0];
                        using (WaveOutEvent crown_sound = new WaveOutEvent())
                        {
                            crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance_2));
                            crown_sound.Play();

                            while (crown_sound.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }
                if (crown_roll[2] && crown_roll_3_line)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Rollbar_4.Controls[i].BackgroundImage == SpecialSymbolsPictures[0]) continue;
                        Rollbar_4.Controls[i].BackgroundImage = SpecialSymbolsPictures[0];
                        using (WaveOutEvent crown_sound = new WaveOutEvent())
                        {
                            crown_sound.Init(new WaveFileReader(Properties.Resources.crown_appearance_2));
                            crown_sound.Play();

                            while (crown_sound.PlaybackState == PlaybackState.Playing)
                                await Task.Delay(100);
                        }
                    }
                }
                KeypressEvents.crownAnimation = false;
                BTN_Spin.Image = Properties.Resources.Cash_In;
                BTN_Spin.Enabled = true;
                BTN_Spin.Visible = true;
                Logo_Picture.Focus();

                LB_Winning.Text = "CÂȘTIG:";
                last_amount_won = total_winning;
                LB_AmountWon.Visible = true;
                LB_LeiWinning.Visible = true;
                // Start the timer for winning animations (draw&burn the winning lines).
                WinningLinesAnimation.Enabled = true;
                BurningLinesAnimation();

                cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;

                using (WaveOutEvent winning_sound = new WaveOutEvent())
                {
                    // Play winning sound.
                    _ = Task.Run(async () =>
                    {
                        winning_sound.Init(new WaveFileReader(Properties.Resources.win));
                        winning_sound.Play();
                        while (winning_sound.PlaybackState == PlaybackState.Playing)
                            await Task.Delay(100);
                    }, cancellationToken);
                    // Play money-growing animation on AmountWon.
                    await Task.Run(async () =>
                  {
                      if (LB_AmountWon.InvokeRequired)
                          await LB_AmountWon.Invoke((async () =>
                          {
                              double startAmount = 0.1;
                              double endAmount = total_winning;
                              int numIncrements = 100; // Number of increments in the animation

                              // Calculate the increment value based on total_winning
                              double incrementValue = (endAmount - startAmount) / numIncrements;

                              double sum = 0;
                              for (int i = 0; i <= numIncrements && !cancellationToken.IsCancellationRequested; i++)
                              {
                                  sum = startAmount + i * incrementValue;
                                  LB_AmountWon.Text = sum.ToString("F2");
                                  UpdateTextsLocation();
                                  if (sum >= total_winning - 0.001)
                                      break;

                                  await Task.Delay(30);
                              }

                              cancellationTokenSource = null;
                              LB_AmountWon.Text = total_winning.ToString("F2");
                              UpdateTextsLocation();

                              BTN_Spin.Image = Properties.Resources.Spin_Button1;
                              BTN_CashIn.Visible = true;
                              BTN_Gamble.Visible = true;
                              KeypressEvents.gamblingAvailable = true;

                              winning_sound.Stop();
                              // Play bank-in sound.
                              winning_sound.Init(new WaveFileReader(Properties.Resources.bank_in));
                              winning_sound.Play();

                              while (winning_sound.PlaybackState == PlaybackState.Playing)
                                  await Task.Delay(100);
                          }));
                  }, cancellationToken);
                }
            }
            else LB_Status.Text = "VĂ RUGĂM PLASAȚI PARIUL";
        }

        /// <summary>
        /// Text labels always are dynamic and self-aligning to the center.
        /// </summary>
        private void UpdateTextsLocation()
        {
            LB_Balance.Location = new Point(LB_BalanceText.Location.X - ((LB_Balance.Width - LB_BalanceText.Width) / 2), LB_Balance.Location.Y);
            LB_LeiBalance.Location = new Point(LB_BalanceText.Location.X + ((LB_BalanceText.Width - LB_LeiBalance.Width) / 2), LB_LeiBalance.Location.Y);

            LB_AmountWon.Location = new Point(LB_LeiWinning.Location.X - ((LB_AmountWon.Width - LB_LeiWinning.Width) / 2), LB_AmountWon.Location.Y);
            LB_LeiWinning.Location = new Point(LB_AmountWon.Location.X + ((LB_AmountWon.Width - LB_LeiWinning.Width) / 2), LB_LeiWinning.Location.Y);
            LB_Winning.Location = new Point(LB_AmountWon.Location.X - ((LB_Winning.Width - LB_AmountWon.Width) / 2), LB_Winning.Location.Y);
        }

        /// <summary>
        /// Burning winning line animation.
        /// </summary>
        private void BurningLinesAnimation()
        {
            foreach (var line in WinningLines)
            {
                for (int i = 0; i < line.symbols_count; i++)
                {
                    line.Symbols[i].Image = Properties.Resources.fire_burning;
                    line.Symbols[i].Invalidate();
                }
            }
        }

        /// <summary>
        /// Draw a specific winning line.
        /// </summary>
        /// <param name="line">Winning line.</param>
        private void DrawLine(int line)
        {
            var item = WinningLines[line];
            for (int i = 0; i < item.symbols_count; i++)
            {
                //item.Symbols[i].Paint += SymbolPictureBox_Paint;
                item.Symbols[i].Image = Properties.Resources.animated_outline;
                item.Symbols[i].Invalidate();
            }

            LB_Status.Text = $"CÂȘTIG LINIA {WinningLines[line].line} - {item.amount_won} LEI";
        }

        /// <summary>
        /// Clear the drawn lines.
        /// </summary>
        /// <param name="clear_fires">Set to <b>TRUE</b> to clear the fire effect.</param>
        private void ClearLines(bool clear_fires = false)
        {
            foreach (var line in WinningLines)
            {
                for (int i = 0; i < line.symbols_count; i++)
                {
                    //line.Symbols[i].Paint -= SymbolPictureBox_Paint;
                    line.Symbols[i].Image = Properties.Resources.fire_burning;
                    if (clear_fires) line.Symbols[i].Image = null;
                    line.Symbols[i].Invalidate();
                }
            }
        }

        private int line_index = 0;
        /// <summary>
        /// Timer starts and every 2 seconds it draws and burns the winning lines.
        /// </summary>
        private void WinningLinesDrawingAnimation(object sender, EventArgs e)
        {
            if (WinningLines.Count == 0)
                return;

            if (WinningLinesAnimation.Interval != 2200)
            { WinningLinesAnimation.Interval = 2200; line_index = 0; }

            if (line_index == WinningLines.Count)
                line_index = 0;

            ClearLines();
            DrawLine(line_index++);
        }

        public async void BTN_Gamble_Click(object sender, EventArgs e)
        {
            LB_Status.Focus();
            KeypressEvents.gamblingAvailable = false;
            Settings.CanSpin = false;

            BTN_CashIn.Visible = false;
            BTN_Gamble.Visible = false;
            BTN_Spin.Visible = false;

            WinningLinesAnimation.Enabled = false;
            ClearLines(clear_fires: true);

            await Task.Delay(200);
            gamble_Winning.Visible = true;
        }

        private void BTN_CashIn_Click(object sender, EventArgs e)
        {
            double balance = Math.Round(Double.Parse(LB_Balance.Text), 2);
            BTN_CashIn.Visible = false;
            BTN_Gamble.Visible = false;
            KeypressEvents.gamblingAvailable = false;
            BTN_Spin.Image = Properties.Resources.Cash_In;
            Logo_Picture.Focus();

            if (last_amount_won == 0) { LB_AmountWon.Visible = LB_LeiWinning.Visible = false; return; }

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task.Run(async () =>
            {
                if (LB_AmountWon.InvokeRequired)
                    await LB_AmountWon.Invoke(async () =>
                    {
                        double startAmount = 0.1;
                        double endAmount = last_amount_won;
                        int numIncrements = 100; // Number of increments in the animation

                        // Calculate the increment value based on total_winning
                        double incrementValue = (endAmount - startAmount) / numIncrements;

                        double sum = 0;
                        for (int i = 0; i <= numIncrements && !cancellationToken.IsCancellationRequested; i++)
                        {
                            sum = startAmount + i * incrementValue;
                            LB_AmountWon.Text = Math.Round(last_amount_won - sum, 2).ToString("F2");
                            LB_Balance.Text = Math.Round(balance + sum, 2).ToString("F2");
                            UpdateTextsLocation();
                            if (sum >= last_amount_won - 0.001)
                                break;

                            await Task.Delay(30);
                        }

                        cancellationTokenSource = null;
                        BTN_Spin.Image = Properties.Resources.Spin_Button1;
                        LB_AmountWon.Text = Math.Round(last_amount_won, 2).ToString("F2");
                        LB_Balance.Text = Math.Round(balance + last_amount_won, 2).ToString("F2");
                        last_amount_won = balance = 0;
                        UpdateTextsLocation();
                    });
            }, cancellationToken);
        }

        private void ReturnFromGamble(object sender, EventArgs e)
        {
            if (gamble_Winning.Visible == true) { Settings.CanSpin = BTN_Spin.Visible = false; return; }
            LB_Status.Text = "VĂ RUGĂM PLASAȚI PARIUL";
            Settings.CanSpin = BTN_Spin.Visible = true;
            Logo_Picture.Focus();

            if (last_amount_won == 0) { LB_Winning.Text = "ULTIMUL CÂȘTIG:"; LB_AmountWon.Visible = LB_LeiWinning.Visible = false; UpdateTextsLocation(); return; }
            UpdateTextsLocation();
            BTN_CashIn_Click(sender, e);
        }

        public void BTN_Menu_Click(object sender, EventArgs e)
        {
            if (game_menu.Visible == false)
            {
                Settings.CanSpin = BTN_Spin.Visible = false;
                game_menu.Visible = true;
                game_menu.Focus();
                return;
            }
            game_menu.Visible = false;
        }

        private void BTN_Volume_Click(object sender, EventArgs e)
        {
            Logo_Picture.Focus();

            switch (Settings.Volume_Level)
            {
                case 1.0f:
                    BTN_Volume.BackgroundImage = Properties.Resources.Volume_Mid;
                    Settings.Volume_Level = 0.65f;
                    break;

                case 0.65f:
                    BTN_Volume.BackgroundImage = Properties.Resources.Volume_Min;
                    Settings.Volume_Level = 0.35f;
                    break;

                case 0.35f:
                    BTN_Volume.BackgroundImage = Properties.Resources.Volume_Mute;
                    Settings.Volume_Level = 0;
                    Settings.Volume_Mute = true;
                    break;

                case 0:
                    BTN_Volume.BackgroundImage = Properties.Resources.Volume_Sound;
                    Settings.Volume_Level = 1.0f;
                    Settings.Volume_Mute = false;
                    break;

                default:
                    Settings.Volume_Level = 1.0f;
                    break;
            }
        }

        private void StopAnimationsByClick(object sender, MouseEventArgs e)
        {
            if (cancellationTokenSource != null) BTN_Spin_Click(sender, e);
        }
    }
}