namespace Lab_24
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox textBoxMMB;
        private System.Windows.Forms.RichTextBox textBoxAR;
        private System.Windows.Forms.RichTextBox textBoxPles;
        private System.Windows.Forms.Button buttonStartMMB;
        private System.Windows.Forms.Button buttonStopMMB;
        private System.Windows.Forms.Button buttonStartAR;
        private System.Windows.Forms.Button buttonStopAR;
        private System.Windows.Forms.Button buttonStartPles;
        private System.Windows.Forms.Button buttonStopPles;
        private System.Windows.Forms.Button buttonStartAll;
        private System.Windows.Forms.Button buttonStopAll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxMMB = new System.Windows.Forms.RichTextBox();
            this.textBoxAR = new System.Windows.Forms.RichTextBox();
            this.textBoxPles = new System.Windows.Forms.RichTextBox();
            this.buttonStartMMB = new System.Windows.Forms.Button();
            this.buttonStopMMB = new System.Windows.Forms.Button();
            this.buttonStartAR = new System.Windows.Forms.Button();
            this.buttonStopAR = new System.Windows.Forms.Button();
            this.buttonStartPles = new System.Windows.Forms.Button();
            this.buttonStopPles = new System.Windows.Forms.Button();
            this.buttonStartAll = new System.Windows.Forms.Button();
            this.buttonStopAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxMMB
            // 
            this.textBoxMMB.Location = new System.Drawing.Point(12, 12);
            this.textBoxMMB.Name = "textBoxMMB";
            this.textBoxMMB.Size = new System.Drawing.Size(433, 202);
            this.textBoxMMB.TabIndex = 0;
            this.textBoxMMB.Text = "";
            // 
            // textBoxAR
            // 
            this.textBoxAR.Location = new System.Drawing.Point(12, 220);
            this.textBoxAR.Name = "textBoxAR";
            this.textBoxAR.Size = new System.Drawing.Size(433, 196);
            this.textBoxAR.TabIndex = 1;
            this.textBoxAR.Text = "";
            // 
            // textBoxPles
            // 
            this.textBoxPles.Location = new System.Drawing.Point(12, 422);
            this.textBoxPles.Name = "textBoxPles";
            this.textBoxPles.Size = new System.Drawing.Size(433, 200);
            this.textBoxPles.TabIndex = 2;
            this.textBoxPles.Text = "";
            // 
            // buttonStartMMB
            // 
            this.buttonStartMMB.Location = new System.Drawing.Point(489, 109);
            this.buttonStartMMB.Name = "buttonStartMMB";
            this.buttonStartMMB.Size = new System.Drawing.Size(100, 30);
            this.buttonStartMMB.TabIndex = 3;
            this.buttonStartMMB.Text = "Start MMB";
            // 
            // buttonStopMMB
            // 
            this.buttonStopMMB.Enabled = false;
            this.buttonStopMMB.Location = new System.Drawing.Point(622, 109);
            this.buttonStopMMB.Name = "buttonStopMMB";
            this.buttonStopMMB.Size = new System.Drawing.Size(100, 30);
            this.buttonStopMMB.TabIndex = 4;
            this.buttonStopMMB.Text = "Stop MMB";
            // 
            // buttonStartAR
            // 
            this.buttonStartAR.Location = new System.Drawing.Point(489, 292);
            this.buttonStartAR.Name = "buttonStartAR";
            this.buttonStartAR.Size = new System.Drawing.Size(100, 30);
            this.buttonStartAR.TabIndex = 5;
            this.buttonStartAR.Text = "Start AR";
            // 
            // buttonStopAR
            // 
            this.buttonStopAR.Enabled = false;
            this.buttonStopAR.Location = new System.Drawing.Point(622, 292);
            this.buttonStopAR.Name = "buttonStopAR";
            this.buttonStopAR.Size = new System.Drawing.Size(100, 30);
            this.buttonStopAR.TabIndex = 6;
            this.buttonStopAR.Text = "Stop AR";
            // 
            // buttonStartPles
            // 
            this.buttonStartPles.Location = new System.Drawing.Point(489, 514);
            this.buttonStartPles.Name = "buttonStartPles";
            this.buttonStartPles.Size = new System.Drawing.Size(100, 30);
            this.buttonStartPles.TabIndex = 7;
            this.buttonStartPles.Text = "Start Ples";
            // 
            // buttonStopPles
            // 
            this.buttonStopPles.Enabled = false;
            this.buttonStopPles.Location = new System.Drawing.Point(622, 514);
            this.buttonStopPles.Name = "buttonStopPles";
            this.buttonStopPles.Size = new System.Drawing.Size(100, 30);
            this.buttonStopPles.TabIndex = 8;
            this.buttonStopPles.Text = "Stop Ples";
            // 
            // buttonStartAll
            // 
            this.buttonStartAll.Location = new System.Drawing.Point(740, 174);
            this.buttonStartAll.Name = "buttonStartAll";
            this.buttonStartAll.Size = new System.Drawing.Size(133, 64);
            this.buttonStartAll.TabIndex = 9;
            this.buttonStartAll.Text = "Start All";
            // 
            // buttonStopAll
            // 
            this.buttonStopAll.Location = new System.Drawing.Point(740, 380);
            this.buttonStopAll.Name = "buttonStopAll";
            this.buttonStopAll.Size = new System.Drawing.Size(133, 67);
            this.buttonStopAll.TabIndex = 10;
            this.buttonStopAll.Text = "Stop All";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(884, 644);
            this.Controls.Add(this.textBoxMMB);
            this.Controls.Add(this.textBoxAR);
            this.Controls.Add(this.textBoxPles);
            this.Controls.Add(this.buttonStartMMB);
            this.Controls.Add(this.buttonStopMMB);
            this.Controls.Add(this.buttonStartAR);
            this.Controls.Add(this.buttonStopAR);
            this.Controls.Add(this.buttonStartPles);
            this.Controls.Add(this.buttonStopPles);
            this.Controls.Add(this.buttonStartAll);
            this.Controls.Add(this.buttonStopAll);
            this.Name = "Form1";
            this.Text = "Crypto Algorithms Simulator";
            this.ResumeLayout(false);

        }
    }
}