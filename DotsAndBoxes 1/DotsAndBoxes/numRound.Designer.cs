namespace DotsAndBoxes
{
    partial class numRound
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrRunda = new System.Windows.Forms.Label();
            this.timer123 = new System.Windows.Forms.Timer(this.components);
            this.lblBroj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Рунда број";
            // 
            // lblBrRunda
            // 
            this.lblBrRunda.AutoSize = true;
            this.lblBrRunda.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBrRunda.Location = new System.Drawing.Point(148, 24);
            this.lblBrRunda.Name = "lblBrRunda";
            this.lblBrRunda.Size = new System.Drawing.Size(69, 73);
            this.lblBrRunda.TabIndex = 1;
            this.lblBrRunda.Text = "1";
            // 
            // timer123
            // 
            this.timer123.Interval = 1000;
            this.timer123.Tick += new System.EventHandler(this.timer123_Tick);
            // 
            // lblBroj
            // 
            this.lblBroj.AutoSize = true;
            this.lblBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBroj.Location = new System.Drawing.Point(74, 9);
            this.lblBroj.Name = "lblBroj";
            this.lblBroj.Size = new System.Drawing.Size(0, 91);
            this.lblBroj.TabIndex = 2;
            this.lblBroj.Visible = false;
            // 
            // numRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 120);
            this.Controls.Add(this.lblBrRunda);
            this.Controls.Add(this.lblBroj);
            this.Controls.Add(this.label1);
            this.Name = "numRound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "numRound";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrRunda;
        private System.Windows.Forms.Timer timer123;
        private System.Windows.Forms.Label lblBroj;
    }
}