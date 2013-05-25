namespace DotsAndBoxes
{
    partial class KraenRezultat
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRez = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPobednik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 189);
            this.textBox1.TabIndex = 0;
            // 
            // lblRez
            // 
            this.lblRez.AutoSize = true;
            this.lblRez.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRez.Location = new System.Drawing.Point(12, 205);
            this.lblRez.Name = "lblRez";
            this.lblRez.Size = new System.Drawing.Size(55, 31);
            this.lblRez.TabIndex = 1;
            this.lblRez.Text = "rez";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Победник е: ";
            // 
            // lblPobednik
            // 
            this.lblPobednik.AutoSize = true;
            this.lblPobednik.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPobednik.Location = new System.Drawing.Point(12, 259);
            this.lblPobednik.Name = "lblPobednik";
            this.lblPobednik.Size = new System.Drawing.Size(49, 29);
            this.lblPobednik.TabIndex = 3;
            this.lblPobednik.Text = "rez";
            // 
            // KraenRezultat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(176, 297);
            this.Controls.Add(this.lblPobednik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRez);
            this.Controls.Add(this.textBox1);
            this.Name = "KraenRezultat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Крај";
            //this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KraenRezultat_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRez;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPobednik;
    }
}