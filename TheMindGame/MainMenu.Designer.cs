namespace TheMindGame
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.characterButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // characterButton
            // 
            this.characterButton.BackColor = System.Drawing.Color.Transparent;
            this.characterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.characterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.characterButton.Location = new System.Drawing.Point(478, 214);
            this.characterButton.Name = "characterButton";
            this.characterButton.Size = new System.Drawing.Size(250, 350);
            this.characterButton.TabIndex = 0;
            this.characterButton.UseVisualStyleBackColor = false;
            this.characterButton.Click += new System.EventHandler(this.characterButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImage = global::TheMindGame.Properties.Resources.startButton;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Location = new System.Drawing.Point(478, 628);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(250, 83);
            this.startButton.TabIndex = 1;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheMindGame.Properties.Resources.mainMenuBackground;
            this.ClientSize = new System.Drawing.Size(1200, 790);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.characterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheMindGame";
            this.VisibleChanged += new System.EventHandler(this.MainMenu_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button characterButton;
        private System.Windows.Forms.Button startButton;
    }
}

