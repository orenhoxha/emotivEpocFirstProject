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
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(753, 472);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gui";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gui_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Gui_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLEFT;
        private System.Windows.Forms.Timer timerDOWN;
        private System.Windows.Forms.Timer timerUP;
        private System.Windows.Forms.Timer timerRIGHT;
        private System.Windows.Forms.Timer timerWIN;
    }
}