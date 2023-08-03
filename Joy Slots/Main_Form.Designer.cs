namespace Joy_Slots
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            game_ui = new Game_UI();
            SuspendLayout();
            // 
            // game_ui
            // 
            game_ui.BackgroundImage = (Image)resources.GetObject("game_ui.BackgroundImage");
            game_ui.BackgroundImageLayout = ImageLayout.Center;
            game_ui.Location = new Point(0, 0);
            game_ui.Margin = new Padding(0);
            game_ui.Name = "game_ui";
            game_ui.Size = new Size(1666, 916);
            game_ui.TabIndex = 0;
            game_ui.Load += GameUI_Load;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1666, 916);
            Controls.Add(game_ui);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(1682, 955);
            MinimumSize = new Size(1682, 955);
            Name = "Main_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Joy Slots";
            FormClosing += Main_Form_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Game_UI game_ui;
    }
}