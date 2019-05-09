namespace TheMindGame
{
    partial class CharacterSelection
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
            this.arrowLeft = new System.Windows.Forms.PictureBox();
            this.arrowRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxCenter = new System.Windows.Forms.PictureBox();
            this.selectCharacterOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // arrowLeft
            // 
            this.arrowLeft.BackColor = System.Drawing.Color.Transparent;
            this.arrowLeft.BackgroundImage = global::TheMindGame.Properties.Resources.arrowleft;
            this.arrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowLeft.Location = new System.Drawing.Point(111, 270);
            this.arrowLeft.Name = "arrowLeft";
            this.arrowLeft.Size = new System.Drawing.Size(128, 128);
            this.arrowLeft.TabIndex = 7;
            this.arrowLeft.TabStop = false;
            this.arrowLeft.Click += new System.EventHandler(this.arrowLeft_Click);
            // 
            // arrowRight
            // 
            this.arrowRight.BackColor = System.Drawing.Color.Transparent;
            this.arrowRight.BackgroundImage = global::TheMindGame.Properties.Resources.arrowright;
            this.arrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arrowRight.Location = new System.Drawing.Point(1052, 270);
            this.arrowRight.Name = "arrowRight";
            this.arrowRight.Size = new System.Drawing.Size(128, 128);
            this.arrowRight.TabIndex = 6;
            this.arrowRight.TabStop = false;
            this.arrowRight.Click += new System.EventHandler(this.arrowRight_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackColor = System.Drawing.Color.Black;
            this.pictureBoxRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRight.Location = new System.Drawing.Point(801, 191);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(200, 280);
            this.pictureBoxRight.TabIndex = 5;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Click += new System.EventHandler(this.pictureBoxRight_Click);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackColor = System.Drawing.Color.Black;
            this.pictureBoxLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxLeft.Location = new System.Drawing.Point(282, 191);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(200, 280);
            this.pictureBoxLeft.TabIndex = 4;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBoxLeft_Click);
            // 
            // pictureBoxCenter
            // 
            this.pictureBoxCenter.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCenter.Location = new System.Drawing.Point(513, 156);
            this.pictureBoxCenter.Name = "pictureBoxCenter";
            this.pictureBoxCenter.Size = new System.Drawing.Size(250, 350);
            this.pictureBoxCenter.TabIndex = 3;
            this.pictureBoxCenter.TabStop = false;
            // 
            // selectCharacterOk
            // 
            this.selectCharacterOk.BackColor = System.Drawing.Color.Transparent;
            this.selectCharacterOk.BackgroundImage = global::TheMindGame.Properties.Resources.selectButton;
            this.selectCharacterOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectCharacterOk.Location = new System.Drawing.Point(513, 549);
            this.selectCharacterOk.Name = "selectCharacterOk";
            this.selectCharacterOk.Size = new System.Drawing.Size(250, 83);
            this.selectCharacterOk.TabIndex = 0;
            this.selectCharacterOk.UseVisualStyleBackColor = false;
            this.selectCharacterOk.Click += new System.EventHandler(this.selectCharacterOk_Click);
            // 
            // CharacterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheMindGame.Properties.Resources.mainMenuBackground;
            this.ClientSize = new System.Drawing.Size(1318, 724);
            this.Controls.Add(this.arrowLeft);
            this.Controls.Add(this.arrowRight);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxCenter);
            this.Controls.Add(this.selectCharacterOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CharacterSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CharacterSelection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CharacterSelection_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCenter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectCharacterOk;
        private System.Windows.Forms.PictureBox pictureBoxCenter;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox arrowRight;
        private System.Windows.Forms.PictureBox arrowLeft;
    }
}