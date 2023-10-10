namespace Joy_Slots
{
    partial class Game_UI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Right_Panel = new Panel();
            BTN_CashIn = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Gamble = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Spin = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Menu = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            Left_Panel = new Panel();
            BTN_Volume = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            Bottom_Panel = new Panel();
            LB_LeiWinning = new Label();
            LB_AmountWon = new Label();
            BTN_Bet_5 = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Bet_4 = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Bet_3 = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Bet_2 = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            BTN_Bet_1 = new Keyboard_HeatMap.Toolbox.RoundEdgesButton();
            LB_LeiBalance = new Label();
            LB_Balance = new Label();
            LB_Winning = new Label();
            LB_BalanceText = new Label();
            LB_Status = new Label();
            Top_Panel = new Panel();
            Logo_Picture = new PictureBox();
            Rollbar_1 = new Panel();
            Symbol_1 = new PictureBox();
            Symbol_2 = new PictureBox();
            Symbol_3 = new PictureBox();
            Rollbar_3 = new Panel();
            Symbol_7 = new PictureBox();
            Symbol_8 = new PictureBox();
            Symbol_9 = new PictureBox();
            Rollbar_2 = new Panel();
            Symbol_4 = new PictureBox();
            Symbol_5 = new PictureBox();
            Symbol_6 = new PictureBox();
            Rollbar_4 = new Panel();
            Symbol_10 = new PictureBox();
            Symbol_11 = new PictureBox();
            Symbol_12 = new PictureBox();
            Rollbar_5 = new Panel();
            Symbol_13 = new PictureBox();
            Symbol_14 = new PictureBox();
            Symbol_15 = new PictureBox();
            WinningLinesAnimation = new System.Windows.Forms.Timer(components);
            Right_Panel.SuspendLayout();
            Left_Panel.SuspendLayout();
            Bottom_Panel.SuspendLayout();
            Top_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo_Picture).BeginInit();
            Rollbar_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Symbol_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_3).BeginInit();
            Rollbar_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Symbol_7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_9).BeginInit();
            Rollbar_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Symbol_4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_6).BeginInit();
            Rollbar_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Symbol_10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_12).BeginInit();
            Rollbar_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Symbol_13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_15).BeginInit();
            SuspendLayout();
            // 
            // Right_Panel
            // 
            Right_Panel.BackColor = Color.Transparent;
            Right_Panel.Controls.Add(BTN_CashIn);
            Right_Panel.Controls.Add(BTN_Gamble);
            Right_Panel.Controls.Add(BTN_Spin);
            Right_Panel.Controls.Add(BTN_Menu);
            Right_Panel.Location = new Point(1438, 0);
            Right_Panel.Name = "Right_Panel";
            Right_Panel.Size = new Size(228, 916);
            Right_Panel.TabIndex = 0;
            Right_Panel.MouseClick += StopAnimationsByClick;
            // 
            // BTN_CashIn
            // 
            BTN_CashIn.BackColor = Color.Transparent;
            BTN_CashIn.BackgroundImage = Properties.Resources.Cash_In;
            BTN_CashIn.BackgroundImageLayout = ImageLayout.Center;
            BTN_CashIn.BorderRadius = 20;
            BTN_CashIn.FlatAppearance.BorderSize = 0;
            BTN_CashIn.FlatStyle = FlatStyle.Flat;
            BTN_CashIn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_CashIn.ForeColor = Color.Black;
            BTN_CashIn.Location = new Point(50, 620);
            BTN_CashIn.Margin = new Padding(0);
            BTN_CashIn.Name = "BTN_CashIn";
            BTN_CashIn.Size = new Size(128, 128);
            BTN_CashIn.TabIndex = 0;
            BTN_CashIn.TabStop = false;
            BTN_CashIn.UseVisualStyleBackColor = false;
            BTN_CashIn.Click += BTN_CashIn_Click;
            // 
            // BTN_Gamble
            // 
            BTN_Gamble.BackColor = Color.Transparent;
            BTN_Gamble.BackgroundImage = Properties.Resources.Gamble_CashIn_Background;
            BTN_Gamble.BackgroundImageLayout = ImageLayout.Center;
            BTN_Gamble.BorderRadius = 20;
            BTN_Gamble.FlatAppearance.BorderSize = 0;
            BTN_Gamble.FlatStyle = FlatStyle.Flat;
            BTN_Gamble.Font = new Font("Segoe UI Semibold", 40F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Gamble.ForeColor = Color.Black;
            BTN_Gamble.Location = new Point(50, 215);
            BTN_Gamble.Margin = new Padding(0);
            BTN_Gamble.Name = "BTN_Gamble";
            BTN_Gamble.Size = new Size(131, 87);
            BTN_Gamble.TabIndex = 0;
            BTN_Gamble.TabStop = false;
            BTN_Gamble.Text = "X2";
            BTN_Gamble.UseVisualStyleBackColor = false;
            BTN_Gamble.Click += BTN_Gamble_Click;
            // 
            // BTN_Spin
            // 
            BTN_Spin.BackColor = Color.Transparent;
            BTN_Spin.BackgroundImage = Properties.Resources.Spin_BTN_Background;
            BTN_Spin.BackgroundImageLayout = ImageLayout.Center;
            BTN_Spin.BorderRadius = 20;
            BTN_Spin.FlatAppearance.BorderSize = 0;
            BTN_Spin.FlatStyle = FlatStyle.Flat;
            BTN_Spin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Spin.ForeColor = Color.White;
            BTN_Spin.Image = Properties.Resources.Spin_Button1;
            BTN_Spin.Location = new Point(19, 311);
            BTN_Spin.Margin = new Padding(0);
            BTN_Spin.Name = "BTN_Spin";
            BTN_Spin.Size = new Size(183, 297);
            BTN_Spin.TabIndex = 0;
            BTN_Spin.TabStop = false;
            BTN_Spin.UseVisualStyleBackColor = false;
            BTN_Spin.Click += BTN_Spin_Click;
            // 
            // BTN_Menu
            // 
            BTN_Menu.BackColor = Color.Transparent;
            BTN_Menu.BackgroundImage = Properties.Resources.Menu_Button;
            BTN_Menu.BackgroundImageLayout = ImageLayout.Center;
            BTN_Menu.BorderRadius = 20;
            BTN_Menu.FlatAppearance.BorderSize = 0;
            BTN_Menu.FlatStyle = FlatStyle.Flat;
            BTN_Menu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Menu.ForeColor = Color.White;
            BTN_Menu.Location = new Point(173, 861);
            BTN_Menu.Margin = new Padding(0);
            BTN_Menu.Name = "BTN_Menu";
            BTN_Menu.Size = new Size(50, 50);
            BTN_Menu.TabIndex = 0;
            BTN_Menu.TabStop = false;
            BTN_Menu.UseVisualStyleBackColor = false;
            BTN_Menu.Click += BTN_Menu_Click;
            // 
            // Left_Panel
            // 
            Left_Panel.BackColor = Color.Transparent;
            Left_Panel.Controls.Add(BTN_Volume);
            Left_Panel.Location = new Point(0, 0);
            Left_Panel.Name = "Left_Panel";
            Left_Panel.Size = new Size(228, 916);
            Left_Panel.TabIndex = 0;
            Left_Panel.MouseClick += StopAnimationsByClick;
            // 
            // BTN_Volume
            // 
            BTN_Volume.BackColor = Color.Transparent;
            BTN_Volume.BackgroundImage = Properties.Resources.Volume_Sound;
            BTN_Volume.BackgroundImageLayout = ImageLayout.Center;
            BTN_Volume.BorderRadius = 20;
            BTN_Volume.FlatAppearance.BorderSize = 0;
            BTN_Volume.FlatStyle = FlatStyle.Flat;
            BTN_Volume.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Volume.ForeColor = Color.White;
            BTN_Volume.Location = new Point(5, 861);
            BTN_Volume.Margin = new Padding(0);
            BTN_Volume.Name = "BTN_Volume";
            BTN_Volume.Size = new Size(50, 50);
            BTN_Volume.TabIndex = 0;
            BTN_Volume.TabStop = false;
            BTN_Volume.UseVisualStyleBackColor = false;
            BTN_Volume.Click += BTN_Volume_Click;
            // 
            // Bottom_Panel
            // 
            Bottom_Panel.BackColor = Color.Transparent;
            Bottom_Panel.Controls.Add(LB_LeiWinning);
            Bottom_Panel.Controls.Add(LB_AmountWon);
            Bottom_Panel.Controls.Add(BTN_Bet_5);
            Bottom_Panel.Controls.Add(BTN_Bet_4);
            Bottom_Panel.Controls.Add(BTN_Bet_3);
            Bottom_Panel.Controls.Add(BTN_Bet_2);
            Bottom_Panel.Controls.Add(BTN_Bet_1);
            Bottom_Panel.Controls.Add(LB_LeiBalance);
            Bottom_Panel.Controls.Add(LB_Balance);
            Bottom_Panel.Controls.Add(LB_Winning);
            Bottom_Panel.Controls.Add(LB_BalanceText);
            Bottom_Panel.Controls.Add(LB_Status);
            Bottom_Panel.Location = new Point(228, 803);
            Bottom_Panel.Name = "Bottom_Panel";
            Bottom_Panel.Size = new Size(1210, 113);
            Bottom_Panel.TabIndex = 0;
            Bottom_Panel.MouseClick += StopAnimationsByClick;
            // 
            // LB_LeiWinning
            // 
            LB_LeiWinning.AutoSize = true;
            LB_LeiWinning.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LB_LeiWinning.ForeColor = Color.White;
            LB_LeiWinning.Location = new Point(1025, 69);
            LB_LeiWinning.Name = "LB_LeiWinning";
            LB_LeiWinning.Size = new Size(23, 15);
            LB_LeiWinning.TabIndex = 0;
            LB_LeiWinning.Text = "LEI";
            LB_LeiWinning.MouseClick += StopAnimationsByClick;
            // 
            // LB_AmountWon
            // 
            LB_AmountWon.AutoSize = true;
            LB_AmountWon.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_AmountWon.ForeColor = Color.White;
            LB_AmountWon.Location = new Point(980, 28);
            LB_AmountWon.Name = "LB_AmountWon";
            LB_AmountWon.Size = new Size(119, 40);
            LB_AmountWon.TabIndex = 0;
            LB_AmountWon.Text = "123456";
            LB_AmountWon.TextAlign = ContentAlignment.MiddleCenter;
            LB_AmountWon.MouseClick += StopAnimationsByClick;
            // 
            // BTN_Bet_5
            // 
            BTN_Bet_5.BackColor = Color.Transparent;
            BTN_Bet_5.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_5.BackgroundImageLayout = ImageLayout.Center;
            BTN_Bet_5.BorderRadius = 20;
            BTN_Bet_5.FlatAppearance.BorderSize = 0;
            BTN_Bet_5.FlatStyle = FlatStyle.Flat;
            BTN_Bet_5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Bet_5.ForeColor = Color.White;
            BTN_Bet_5.Location = new Point(745, 28);
            BTN_Bet_5.Margin = new Padding(0);
            BTN_Bet_5.Name = "BTN_Bet_5";
            BTN_Bet_5.Size = new Size(85, 75);
            BTN_Bet_5.TabIndex = 0;
            BTN_Bet_5.TabStop = false;
            BTN_Bet_5.Text = "5.00";
            BTN_Bet_5.UseVisualStyleBackColor = false;
            BTN_Bet_5.Click += Set_Bet_Amount;
            // 
            // BTN_Bet_4
            // 
            BTN_Bet_4.BackColor = Color.Transparent;
            BTN_Bet_4.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_4.BackgroundImageLayout = ImageLayout.Center;
            BTN_Bet_4.BorderRadius = 20;
            BTN_Bet_4.FlatAppearance.BorderSize = 0;
            BTN_Bet_4.FlatStyle = FlatStyle.Flat;
            BTN_Bet_4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Bet_4.ForeColor = Color.White;
            BTN_Bet_4.Location = new Point(654, 28);
            BTN_Bet_4.Margin = new Padding(0);
            BTN_Bet_4.Name = "BTN_Bet_4";
            BTN_Bet_4.Size = new Size(85, 75);
            BTN_Bet_4.TabIndex = 0;
            BTN_Bet_4.TabStop = false;
            BTN_Bet_4.Text = "3.00";
            BTN_Bet_4.UseVisualStyleBackColor = false;
            BTN_Bet_4.Click += Set_Bet_Amount;
            // 
            // BTN_Bet_3
            // 
            BTN_Bet_3.BackColor = Color.Transparent;
            BTN_Bet_3.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_3.BackgroundImageLayout = ImageLayout.Center;
            BTN_Bet_3.BorderRadius = 20;
            BTN_Bet_3.FlatAppearance.BorderSize = 0;
            BTN_Bet_3.FlatStyle = FlatStyle.Flat;
            BTN_Bet_3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Bet_3.ForeColor = Color.White;
            BTN_Bet_3.Location = new Point(563, 28);
            BTN_Bet_3.Margin = new Padding(0);
            BTN_Bet_3.Name = "BTN_Bet_3";
            BTN_Bet_3.Size = new Size(85, 75);
            BTN_Bet_3.TabIndex = 0;
            BTN_Bet_3.TabStop = false;
            BTN_Bet_3.Text = "1.00";
            BTN_Bet_3.UseVisualStyleBackColor = false;
            BTN_Bet_3.Click += Set_Bet_Amount;
            // 
            // BTN_Bet_2
            // 
            BTN_Bet_2.BackColor = Color.Transparent;
            BTN_Bet_2.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_2.BackgroundImageLayout = ImageLayout.Center;
            BTN_Bet_2.BorderRadius = 20;
            BTN_Bet_2.FlatAppearance.BorderSize = 0;
            BTN_Bet_2.FlatStyle = FlatStyle.Flat;
            BTN_Bet_2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Bet_2.ForeColor = Color.White;
            BTN_Bet_2.Location = new Point(472, 28);
            BTN_Bet_2.Margin = new Padding(0);
            BTN_Bet_2.Name = "BTN_Bet_2";
            BTN_Bet_2.Size = new Size(85, 75);
            BTN_Bet_2.TabIndex = 0;
            BTN_Bet_2.TabStop = false;
            BTN_Bet_2.Text = "0.50";
            BTN_Bet_2.UseVisualStyleBackColor = false;
            BTN_Bet_2.Click += Set_Bet_Amount;
            // 
            // BTN_Bet_1
            // 
            BTN_Bet_1.BackColor = Color.Transparent;
            BTN_Bet_1.BackgroundImage = Properties.Resources.Placebet_Buttons_Background;
            BTN_Bet_1.BackgroundImageLayout = ImageLayout.Center;
            BTN_Bet_1.BorderRadius = 20;
            BTN_Bet_1.FlatAppearance.BorderSize = 0;
            BTN_Bet_1.FlatStyle = FlatStyle.Flat;
            BTN_Bet_1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Bet_1.ForeColor = Color.White;
            BTN_Bet_1.Location = new Point(381, 28);
            BTN_Bet_1.Margin = new Padding(0);
            BTN_Bet_1.Name = "BTN_Bet_1";
            BTN_Bet_1.Size = new Size(85, 75);
            BTN_Bet_1.TabIndex = 0;
            BTN_Bet_1.TabStop = false;
            BTN_Bet_1.Text = "0.20";
            BTN_Bet_1.UseVisualStyleBackColor = false;
            BTN_Bet_1.Click += Set_Bet_Amount;
            // 
            // LB_LeiBalance
            // 
            LB_LeiBalance.AutoSize = true;
            LB_LeiBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LB_LeiBalance.ForeColor = Color.White;
            LB_LeiBalance.Location = new Point(164, 69);
            LB_LeiBalance.Name = "LB_LeiBalance";
            LB_LeiBalance.Size = new Size(23, 15);
            LB_LeiBalance.TabIndex = 0;
            LB_LeiBalance.Text = "LEI";
            LB_LeiBalance.MouseClick += StopAnimationsByClick;
            // 
            // LB_Balance
            // 
            LB_Balance.AutoSize = true;
            LB_Balance.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            LB_Balance.ForeColor = Color.White;
            LB_Balance.Location = new Point(135, 39);
            LB_Balance.Name = "LB_Balance";
            LB_Balance.Size = new Size(85, 30);
            LB_Balance.TabIndex = 0;
            LB_Balance.Text = "123456";
            LB_Balance.MouseClick += StopAnimationsByClick;
            // 
            // LB_Winning
            // 
            LB_Winning.AutoSize = true;
            LB_Winning.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LB_Winning.ForeColor = Color.White;
            LB_Winning.Location = new Point(980, 5);
            LB_Winning.Name = "LB_Winning";
            LB_Winning.Size = new Size(141, 21);
            LB_Winning.TabIndex = 0;
            LB_Winning.Text = "ULTIMUL CÂȘTIG:";
            LB_Winning.MouseClick += StopAnimationsByClick;
            // 
            // LB_BalanceText
            // 
            LB_BalanceText.AutoSize = true;
            LB_BalanceText.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LB_BalanceText.ForeColor = Color.White;
            LB_BalanceText.Location = new Point(143, 5);
            LB_BalanceText.Name = "LB_BalanceText";
            LB_BalanceText.Size = new Size(87, 21);
            LB_BalanceText.TabIndex = 0;
            LB_BalanceText.Text = "BALANȚĂ:";
            LB_BalanceText.MouseClick += StopAnimationsByClick;
            // 
            // LB_Status
            // 
            LB_Status.AutoSize = true;
            LB_Status.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LB_Status.ForeColor = Color.White;
            LB_Status.Location = new Point(496, 5);
            LB_Status.Name = "LB_Status";
            LB_Status.Size = new Size(220, 21);
            LB_Status.TabIndex = 0;
            LB_Status.Text = "VĂ RUGĂM PLASAȚI PARIUL";
            // 
            // Top_Panel
            // 
            Top_Panel.BackColor = Color.Transparent;
            Top_Panel.Controls.Add(Logo_Picture);
            Top_Panel.Location = new Point(228, 0);
            Top_Panel.Name = "Top_Panel";
            Top_Panel.Size = new Size(1210, 113);
            Top_Panel.TabIndex = 0;
            Top_Panel.MouseClick += StopAnimationsByClick;
            // 
            // Logo_Picture
            // 
            Logo_Picture.BackgroundImage = Properties.Resources.Logo;
            Logo_Picture.BackgroundImageLayout = ImageLayout.Stretch;
            Logo_Picture.Location = new Point(435, 0);
            Logo_Picture.Name = "Logo_Picture";
            Logo_Picture.Size = new Size(340, 125);
            Logo_Picture.TabIndex = 0;
            Logo_Picture.TabStop = false;
            // 
            // Rollbar_1
            // 
            Rollbar_1.Controls.Add(Symbol_1);
            Rollbar_1.Controls.Add(Symbol_2);
            Rollbar_1.Controls.Add(Symbol_3);
            Rollbar_1.Location = new Point(228, 113);
            Rollbar_1.Name = "Rollbar_1";
            Rollbar_1.Size = new Size(230, 690);
            Rollbar_1.TabIndex = 0;
            // 
            // Symbol_1
            // 
            Symbol_1.Location = new Point(0, 0);
            Symbol_1.Name = "Symbol_1";
            Symbol_1.Size = new Size(230, 230);
            Symbol_1.TabIndex = 0;
            Symbol_1.TabStop = false;
            Symbol_1.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_2
            // 
            Symbol_2.Location = new Point(0, 230);
            Symbol_2.Name = "Symbol_2";
            Symbol_2.Size = new Size(230, 230);
            Symbol_2.TabIndex = 1;
            Symbol_2.TabStop = false;
            Symbol_2.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_3
            // 
            Symbol_3.Location = new Point(0, 460);
            Symbol_3.Name = "Symbol_3";
            Symbol_3.Size = new Size(230, 230);
            Symbol_3.TabIndex = 2;
            Symbol_3.TabStop = false;
            Symbol_3.MouseClick += StopAnimationsByClick;
            // 
            // Rollbar_3
            // 
            Rollbar_3.Controls.Add(Symbol_7);
            Rollbar_3.Controls.Add(Symbol_8);
            Rollbar_3.Controls.Add(Symbol_9);
            Rollbar_3.Location = new Point(718, 113);
            Rollbar_3.Name = "Rollbar_3";
            Rollbar_3.Size = new Size(230, 690);
            Rollbar_3.TabIndex = 0;
            // 
            // Symbol_7
            // 
            Symbol_7.Location = new Point(0, 0);
            Symbol_7.Name = "Symbol_7";
            Symbol_7.Size = new Size(230, 230);
            Symbol_7.TabIndex = 0;
            Symbol_7.TabStop = false;
            Symbol_7.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_8
            // 
            Symbol_8.Location = new Point(0, 230);
            Symbol_8.Name = "Symbol_8";
            Symbol_8.Size = new Size(230, 230);
            Symbol_8.TabIndex = 1;
            Symbol_8.TabStop = false;
            Symbol_8.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_9
            // 
            Symbol_9.Location = new Point(0, 460);
            Symbol_9.Name = "Symbol_9";
            Symbol_9.Size = new Size(230, 230);
            Symbol_9.TabIndex = 2;
            Symbol_9.TabStop = false;
            Symbol_9.MouseClick += StopAnimationsByClick;
            // 
            // Rollbar_2
            // 
            Rollbar_2.Controls.Add(Symbol_4);
            Rollbar_2.Controls.Add(Symbol_5);
            Rollbar_2.Controls.Add(Symbol_6);
            Rollbar_2.Location = new Point(473, 113);
            Rollbar_2.Name = "Rollbar_2";
            Rollbar_2.Size = new Size(230, 690);
            Rollbar_2.TabIndex = 0;
            // 
            // Symbol_4
            // 
            Symbol_4.Location = new Point(0, 0);
            Symbol_4.Name = "Symbol_4";
            Symbol_4.Size = new Size(230, 230);
            Symbol_4.TabIndex = 0;
            Symbol_4.TabStop = false;
            Symbol_4.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_5
            // 
            Symbol_5.Location = new Point(0, 230);
            Symbol_5.Name = "Symbol_5";
            Symbol_5.Size = new Size(230, 230);
            Symbol_5.TabIndex = 1;
            Symbol_5.TabStop = false;
            Symbol_5.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_6
            // 
            Symbol_6.Location = new Point(0, 460);
            Symbol_6.Name = "Symbol_6";
            Symbol_6.Size = new Size(230, 230);
            Symbol_6.TabIndex = 2;
            Symbol_6.TabStop = false;
            Symbol_6.MouseClick += StopAnimationsByClick;
            // 
            // Rollbar_4
            // 
            Rollbar_4.Controls.Add(Symbol_10);
            Rollbar_4.Controls.Add(Symbol_11);
            Rollbar_4.Controls.Add(Symbol_12);
            Rollbar_4.Location = new Point(963, 113);
            Rollbar_4.Name = "Rollbar_4";
            Rollbar_4.Size = new Size(230, 690);
            Rollbar_4.TabIndex = 0;
            // 
            // Symbol_10
            // 
            Symbol_10.Location = new Point(0, 0);
            Symbol_10.Name = "Symbol_10";
            Symbol_10.Size = new Size(230, 230);
            Symbol_10.TabIndex = 0;
            Symbol_10.TabStop = false;
            Symbol_10.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_11
            // 
            Symbol_11.Location = new Point(0, 230);
            Symbol_11.Name = "Symbol_11";
            Symbol_11.Size = new Size(230, 230);
            Symbol_11.TabIndex = 1;
            Symbol_11.TabStop = false;
            Symbol_11.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_12
            // 
            Symbol_12.Location = new Point(0, 460);
            Symbol_12.Name = "Symbol_12";
            Symbol_12.Size = new Size(230, 230);
            Symbol_12.TabIndex = 2;
            Symbol_12.TabStop = false;
            Symbol_12.MouseClick += StopAnimationsByClick;
            // 
            // Rollbar_5
            // 
            Rollbar_5.Controls.Add(Symbol_13);
            Rollbar_5.Controls.Add(Symbol_14);
            Rollbar_5.Controls.Add(Symbol_15);
            Rollbar_5.Location = new Point(1208, 113);
            Rollbar_5.Name = "Rollbar_5";
            Rollbar_5.Size = new Size(230, 690);
            Rollbar_5.TabIndex = 0;
            // 
            // Symbol_13
            // 
            Symbol_13.Location = new Point(0, 0);
            Symbol_13.Name = "Symbol_13";
            Symbol_13.Size = new Size(230, 230);
            Symbol_13.TabIndex = 0;
            Symbol_13.TabStop = false;
            Symbol_13.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_14
            // 
            Symbol_14.Location = new Point(0, 230);
            Symbol_14.Name = "Symbol_14";
            Symbol_14.Size = new Size(230, 230);
            Symbol_14.TabIndex = 1;
            Symbol_14.TabStop = false;
            Symbol_14.MouseClick += StopAnimationsByClick;
            // 
            // Symbol_15
            // 
            Symbol_15.Location = new Point(0, 460);
            Symbol_15.Name = "Symbol_15";
            Symbol_15.Size = new Size(230, 230);
            Symbol_15.TabIndex = 2;
            Symbol_15.TabStop = false;
            Symbol_15.MouseClick += StopAnimationsByClick;
            // 
            // WinningLinesAnimation
            // 
            WinningLinesAnimation.Interval = 10;
            WinningLinesAnimation.Tick += WinningLinesDrawingAnimation;
            // 
            // Game_UI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(Rollbar_5);
            Controls.Add(Rollbar_4);
            Controls.Add(Rollbar_2);
            Controls.Add(Rollbar_3);
            Controls.Add(Top_Panel);
            Controls.Add(Bottom_Panel);
            Controls.Add(Left_Panel);
            Controls.Add(Right_Panel);
            Controls.Add(Rollbar_1);
            DoubleBuffered = true;
            Margin = new Padding(0);
            Name = "Game_UI";
            Size = new Size(1666, 916);
            MouseClick += StopAnimationsByClick;
            Right_Panel.ResumeLayout(false);
            Left_Panel.ResumeLayout(false);
            Bottom_Panel.ResumeLayout(false);
            Bottom_Panel.PerformLayout();
            Top_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Logo_Picture).EndInit();
            Rollbar_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Symbol_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_3).EndInit();
            Rollbar_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Symbol_7).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_8).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_9).EndInit();
            Rollbar_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Symbol_4).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_5).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_6).EndInit();
            Rollbar_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Symbol_10).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_11).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_12).EndInit();
            Rollbar_5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Symbol_13).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_14).EndInit();
            ((System.ComponentModel.ISupportInitialize)Symbol_15).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel Right_Panel;
        private Panel Left_Panel;
        private Panel Bottom_Panel;
        private Panel Top_Panel;
        private PictureBox Symbol_1;
        private PictureBox Symbol_2;
        private PictureBox Symbol_3;
        private PictureBox Symbol_4;
        private PictureBox Symbol_5;
        private PictureBox Symbol_6;
        private PictureBox Symbol_7;
        private PictureBox Symbol_8;
        private PictureBox Symbol_9;
        private PictureBox Symbol_10;
        private PictureBox Symbol_11;
        private PictureBox Symbol_12;
        private PictureBox Symbol_13;
        private PictureBox Symbol_14;
        private PictureBox Symbol_15;
        public Panel Rollbar_1;
        public Panel Rollbar_2;
        public Panel Rollbar_3;
        public Panel Rollbar_4;
        public Panel Rollbar_5;
        private Label LB_Winning;
        private Label LB_BalanceText;
        private Label LB_Status;
        private Label LB_LeiBalance;
        private PictureBox Logo_Picture;
        private Label LB_LeiWinning;
        private System.Windows.Forms.Timer WinningLinesAnimation;
        private Label LB_Balance;
        private Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Menu;
        private Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Volume;
        private Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Gamble;
        private Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_CashIn;
        private Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Spin;
        public Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Bet_1;
        public Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Bet_5;
        public Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Bet_4;
        public Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Bet_3;
        public Keyboard_HeatMap.Toolbox.RoundEdgesButton BTN_Bet_2;
        public static Label LB_AmountWon;
    }
}
