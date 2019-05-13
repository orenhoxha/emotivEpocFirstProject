namespace TheMindGame
{
    partial class Gui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.timerLEFT = new System.Windows.Forms.Timer(this.components);
            this.timerRIGHT = new System.Windows.Forms.Timer(this.components);
            this.timerDOWN = new System.Windows.Forms.Timer(this.components);
            this.timerUP = new System.Windows.Forms.Timer(this.components);
            this.timerWIN = new System.Windows.Forms.Timer(this.components);
            this.bombNumberImagePB = new System.Windows.Forms.PictureBox();
            this.bombNumberPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bombNumberImagePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombNumberPB)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLEFT
            // 
            this.timerLEFT.Interval = 80;
            this.timerLEFT.Tick += new System.EventHandler(this.timerLEFT_Tick);
            // 
            // timerRIGHT
            // 
            this.timerRIGHT.Interval = 80;
            this.timerRIGHT.Tick += new System.EventHandler(this.timerRIGHT_Tick);
            // 
            // timerDOWN
            // 
            this.timerDOWN.Interval = 80;
            this.timerDOWN.Tick += new System.EventHandler(this.timerDOWN_Tick);
            // 
            // timerUP
            // 
            this.timerUP.Interval = 80;
            this.timerUP.Tick += new System.EventHandler(this.timerUP_Tick);
            // 
            // timerWIN
            // 
            this.timerWIN.Interval = 500;
            this.timerWIN.Tick += new System.EventHandler(this.timerWIN_Tick);
            // 
            // bombNumberImagePB
            // 
            this.bombNumberImagePB.BackColor = System.Drawing.Color.Silver;
            this.bombNumberImagePB.BackgroundImage = global::TheMindGame.Properties.Resources.bomb;
            this.bombNumberImagePB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bombNumberImagePB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bombNumberImagePB.Location = new System.Drawing.Point(0, 0);
            this.bombNumberImagePB.Name = "bombNumberImagePB";
            this.bombNumberImagePB.Size = new System.Drawing.Size(30, 30);
            this.bombNumberImagePB.TabIndex = 0;
            this.bombNumberImagePB.TabStop = false;
            // 
            // bombNumberPB
            // 
            this.bombNumberPB.BackColor = System.Drawing.Color.Silver;
            this.bombNumberPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bombNumberPB.Location = new System.Drawing.Point(30, 0);
            this.bombNumberPB.Name = "bombNumberPB";
            this.bombNumberPB.Size = new System.Drawing.Size(35, 30);
            this.bombNumberPB.TabIndex = 1;
            this.bombNumberPB.TabStop = false;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(753, 472);
            this.Controls.Add(this.bombNumberPB);
            this.Controls.Add(this.bombNumberImagePB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gui";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gui_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gui_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Gui_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.bombNumberImagePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bombNumberPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLEFT;
        private System.Windows.Forms.Timer timerDOWN;
        private System.Windows.Forms.Timer timerUP;
        private System.Windows.Forms.Timer timerRIGHT;
        private System.Windows.Forms.Timer timerWIN;
        private System.Windows.Forms.PictureBox bombNumberImagePB;
        private System.Windows.Forms.PictureBox bombNumberPB;
    }
}