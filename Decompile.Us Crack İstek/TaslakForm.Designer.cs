namespace Decompile.Us_Crack_İstek
{
    partial class TaslakForm
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
            this.taslakx = new System.Windows.Forms.TextBox();
            this.kapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taslakx
            // 
            this.taslakx.Location = new System.Drawing.Point(12, 12);
            this.taslakx.Multiline = true;
            this.taslakx.Name = "taslakx";
            this.taslakx.ReadOnly = true;
            this.taslakx.Size = new System.Drawing.Size(625, 301);
            this.taslakx.TabIndex = 0;
            // 
            // kapat
            // 
            this.kapat.Location = new System.Drawing.Point(12, 319);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(625, 57);
            this.kapat.TabIndex = 1;
            this.kapat.Text = "Kapat && Kopyala";
            this.kapat.UseVisualStyleBackColor = true;
            this.kapat.Click += new System.EventHandler(this.kapat_Click);
            // 
            // Taslak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 384);
            this.Controls.Add(this.kapat);
            this.Controls.Add(this.taslakx);
            this.Name = "Taslak";
            this.Text = "Taslak";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox taslakx;
        private System.Windows.Forms.Button kapat;
    }
}