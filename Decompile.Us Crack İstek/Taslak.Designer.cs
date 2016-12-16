namespace Decompile.Us_Crack_İstek
{
    partial class Taslak
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
            this.htmlTextbox1 = new GvS.Controls.HtmlTextbox();
            this.kaydetveçık = new System.Windows.Forms.Button();
            this.kaydetmedençık = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // htmlTextbox1
            // 
            this.htmlTextbox1.Fonts = new string[] {
        "Corbel",
        "Corbel, Verdana, Arial, Helvetica, sans-serif",
        "Georgia, Times New Roman, Times, serif",
        "Consolas, Courier New, Courier, monospace"};
            this.htmlTextbox1.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextbox1.Location = new System.Drawing.Point(0, 0);
            this.htmlTextbox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlTextbox1.Name = "htmlTextbox1";
            this.htmlTextbox1.Padding = new System.Windows.Forms.Padding(1);
            this.htmlTextbox1.ShowHtmlSource = false;
            this.htmlTextbox1.Size = new System.Drawing.Size(1230, 400);
            this.htmlTextbox1.TabIndex = 1;
            this.htmlTextbox1.ToolbarStyle = GvS.Controls.ToolbarStyles.Internal;
            // 
            // kaydetveçık
            // 
            this.kaydetveçık.Location = new System.Drawing.Point(355, 401);
            this.kaydetveçık.Name = "kaydetveçık";
            this.kaydetveçık.Size = new System.Drawing.Size(248, 27);
            this.kaydetveçık.TabIndex = 2;
            this.kaydetveçık.Text = "Kaydet ve Çık";
            this.kaydetveçık.UseVisualStyleBackColor = true;
            this.kaydetveçık.Click += new System.EventHandler(this.kaydetveçık_Click);
            // 
            // kaydetmedençık
            // 
            this.kaydetmedençık.Location = new System.Drawing.Point(609, 401);
            this.kaydetmedençık.Name = "kaydetmedençık";
            this.kaydetmedençık.Size = new System.Drawing.Size(248, 27);
            this.kaydetmedençık.TabIndex = 3;
            this.kaydetmedençık.Text = "Kaydetmeden Çık";
            this.kaydetmedençık.UseVisualStyleBackColor = true;
            this.kaydetmedençık.Click += new System.EventHandler(this.kaydetmedençık_Click);
            // 
            // Taslak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 429);
            this.ControlBox = false;
            this.Controls.Add(this.kaydetmedençık);
            this.Controls.Add(this.kaydetveçık);
            this.Controls.Add(this.htmlTextbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Taslak";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taslak";
            this.Load += new System.EventHandler(this.Taslak_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GvS.Controls.HtmlTextbox htmlTextbox1;
        private System.Windows.Forms.Button kaydetveçık;
        private System.Windows.Forms.Button kaydetmedençık;
    }
}