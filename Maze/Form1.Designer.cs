namespace Maze
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
            this.IronMan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IronMan)).BeginInit();
            this.SuspendLayout();
            // 
            // IronMan
            // 
            this.IronMan.Image = global::Maze.Resources.iconfinder_ironman_III_52378;
            this.IronMan.Location = new System.Drawing.Point(296, 145);
            this.IronMan.Name = "IronMan";
            this.IronMan.Size = new System.Drawing.Size(80, 74);
            this.IronMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IronMan.TabIndex = 1;
            this.IronMan.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 594);
            this.Controls.Add(this.IronMan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.IronMan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IronMan;
    }
}

