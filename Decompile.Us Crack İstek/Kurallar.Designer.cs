namespace Decompile.Us_Crack_İstek
{
    partial class Kurallar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kurallar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kurallartext = new System.Windows.Forms.TextBox();
            this.kabulediyorum = new System.Windows.Forms.Button();
            this.kabuletmiyorum = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kurallartext);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yasaklı Program Listesi ve Kurallar";
            // 
            // kurallartext
            // 
            this.kurallartext.Location = new System.Drawing.Point(3, 18);
            this.kurallartext.Multiline = true;
            this.kurallartext.Name = "kurallartext";
            this.kurallartext.ReadOnly = true;
            this.kurallartext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kurallartext.Size = new System.Drawing.Size(667, 408);
            this.kurallartext.TabIndex = 0;
            this.kurallartext.Text = resources.GetString("kurallartext.Text");
            // 
            // kabulediyorum
            // 
            this.kabulediyorum.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.kabulediyorum.ForeColor = System.Drawing.Color.DarkGreen;
            this.kabulediyorum.Location = new System.Drawing.Point(0, 441);
            this.kabulediyorum.Name = "kabulediyorum";
            this.kabulediyorum.Size = new System.Drawing.Size(330, 25);
            this.kabulediyorum.TabIndex = 1;
            this.kabulediyorum.Text = "Kabul ediyorum";
            this.kabulediyorum.UseVisualStyleBackColor = false;
            this.kabulediyorum.Click += new System.EventHandler(this.kabulediyorum_Click);
            // 
            // kabuletmiyorum
            // 
            this.kabuletmiyorum.ForeColor = System.Drawing.Color.Red;
            this.kabuletmiyorum.Location = new System.Drawing.Point(346, 441);
            this.kabuletmiyorum.Name = "kabuletmiyorum";
            this.kabuletmiyorum.Size = new System.Drawing.Size(330, 25);
            this.kabuletmiyorum.TabIndex = 2;
            this.kabuletmiyorum.Text = "Kabul etmiyorum ";
            this.kabuletmiyorum.UseVisualStyleBackColor = true;
            this.kabuletmiyorum.Click += new System.EventHandler(this.kabuletmiyorum_Click);
            // 
            // Kurallar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 479);
            this.Controls.Add(this.kabuletmiyorum);
            this.Controls.Add(this.kabulediyorum);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kurallar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kurallar";
            this.Load += new System.EventHandler(this.Kurallar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox kurallartext;
        private System.Windows.Forms.Button kabulediyorum;
        private System.Windows.Forms.Button kabuletmiyorum;
    }
}