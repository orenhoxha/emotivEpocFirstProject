namespace MentalMaze
{
    partial class Form1
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
            this.ironManIcon = new System.Windows.Forms.PictureBox();
            this.timerUP = new System.Windows.Forms.Timer(this.components);
            this.timerDOWN = new System.Windows.Forms.Timer(this.components);
            this.timerRIGHT = new System.Windows.Forms.Timer(this.components);
            this.timerLEFT = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ironManIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ironManIcon
            // 
            this.ironManIcon.BackColor = System.Drawing.Color.Transparent;
            this.ironManIcon.Image = global::MentalMaze.Properties.Resources.iconfinder_ironman_III_52378;
            this.ironManIcon.Location = new System.Drawing.Point(311, 116);
            this.ironManIcon.Name = "ironManIcon";
            this.ironManIcon.Size = new System.Drawing.Size(40, 40);
            this.ironManIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ironManIcon.TabIndex = 0;
            this.ironManIcon.TabStop = false;
            // 
            // timerUP
            // 
            this.timerUP.Interval = 80;
            this.timerUP.Tick += new System.EventHandler(this.timerUP_Tick);
            // 
            // timerDOWN
            // 
            this.timerDOWN.Interval = 80;
            this.timerDOWN.Tick += new System.EventHandler(this.timerDOWN_Tick);
            // 
            // timerRIGHT
            // 
            this.timerRIGHT.Interval = 80;
            this.timerRIGHT.Tick += new System.EventHandler(this.timerRIGHT_Tick);
            // 
            // timerLEFT
            // 
            this.timerLEFT.Interval = 80;
            this.timerLEFT.Tick += new System.EventHandler(this.timerLEFT_Tick);
            // 
            // Form1
            // 
            this.BackgroundImage = global::MentalMaze.Properties.Resources.superMaze;
            this.ClientSize = new System.Drawing.Size(1146, 637);
            this.Controls.Add(this.ironManIcon);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ironManIcon)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.PictureBox ironManIcon;
        private System.Windows.Forms.Timer timerUP;
        private System.Windows.Forms.Timer timerDOWN;
        private System.Windows.Forms.Timer timerRIGHT;
        private System.Windows.Forms.Timer timerLEFT;
    }
}

