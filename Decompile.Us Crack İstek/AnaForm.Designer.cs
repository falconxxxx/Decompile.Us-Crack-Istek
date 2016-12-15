
namespace Decompile.Us_Crack_İstek
{
    partial class AnaForm
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
            this.girişyap = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.bilgi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resimYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıBilgilerimiSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenidenBaşlatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yayinlabtn = new System.Windows.Forms.Button();
            this.onizlemebtn = new System.Windows.Forms.Button();
            this.kuraltamam = new System.Windows.Forms.CheckBox();
            this.not = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kısıtlamalar = new System.Windows.Forms.TextBox();
            this.dosyaac = new System.Windows.Forms.Button();
            this.programboyutu = new System.Windows.Forms.TextBox();
            this.taramasonucu = new System.Windows.Forms.TextBox();
            this.programurl = new System.Windows.Forms.TextBox();
            this.programadi = new System.Windows.Forms.TextBox();
            this.programboyutulabel = new System.Windows.Forms.Label();
            this.taramasonuculabel = new System.Windows.Forms.Label();
            this.programurllabel = new System.Windows.Forms.Label();
            this.programadılabel = new System.Windows.Forms.Label();
            this.hatirla = new System.Windows.Forms.CheckBox();
            this.dosyaacdialog = new System.Windows.Forms.OpenFileDialog();
            this.taramaarkaplan = new System.ComponentModel.BackgroundWorker();
            this.resimyukledialog = new System.Windows.Forms.OpenFileDialog();
            this.girisyaparkaplan = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.altbilgi = new System.Windows.Forms.ToolStripStatusLabel();
            this.yuklemedosyadialog = new System.Windows.Forms.OpenFileDialog();
            this.yayınlaarkaplan = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // girişyap
            // 
            this.girişyap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.girişyap.Location = new System.Drawing.Point(111, 95);
            this.girişyap.Name = "girişyap";
            this.girişyap.Size = new System.Drawing.Size(188, 26);
            this.girişyap.TabIndex = 1;
            this.girişyap.Text = "Giriş Yap";
            this.girişyap.UseVisualStyleBackColor = true;
            this.girişyap.Click += new System.EventHandler(this.girişyap_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(111, 34);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(188, 22);
            this.username.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(111, 67);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(188, 22);
            this.password.TabIndex = 3;
            // 
            // bilgi
            // 
            this.bilgi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bilgi.Enabled = false;
            this.bilgi.Location = new System.Drawing.Point(6, 21);
            this.bilgi.Multiline = true;
            this.bilgi.Name = "bilgi";
            this.bilgi.Size = new System.Drawing.Size(272, 303);
            this.bilgi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Şifre :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bilgi);
            this.groupBox1.Location = new System.Drawing.Point(12, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 330);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgi Ekranı";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resimYükleToolStripMenuItem,
            this.programYükleToolStripMenuItem,
            this.kullanıcıBilgilerimiSilToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.yenidenBaşlatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1107, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resimYükleToolStripMenuItem
            // 
            this.resimYükleToolStripMenuItem.Name = "resimYükleToolStripMenuItem";
            this.resimYükleToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.resimYükleToolStripMenuItem.Text = "Resim Yükle";
            this.resimYükleToolStripMenuItem.Click += new System.EventHandler(this.resimYükleToolStripMenuItem_Click);
            // 
            // programYükleToolStripMenuItem
            // 
            this.programYükleToolStripMenuItem.Name = "programYükleToolStripMenuItem";
            this.programYükleToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.programYükleToolStripMenuItem.Text = "Program Yükle";
            this.programYükleToolStripMenuItem.Click += new System.EventHandler(this.programYükleToolStripMenuItem_Click);
            // 
            // kullanıcıBilgilerimiSilToolStripMenuItem
            // 
            this.kullanıcıBilgilerimiSilToolStripMenuItem.Name = "kullanıcıBilgilerimiSilToolStripMenuItem";
            this.kullanıcıBilgilerimiSilToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.kullanıcıBilgilerimiSilToolStripMenuItem.Text = "Kullanıcı Bilgilerimi Sil";
            this.kullanıcıBilgilerimiSilToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıBilgilerimiSilToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // yenidenBaşlatToolStripMenuItem
            // 
            this.yenidenBaşlatToolStripMenuItem.Name = "yenidenBaşlatToolStripMenuItem";
            this.yenidenBaşlatToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.yenidenBaşlatToolStripMenuItem.Text = "Yeniden Başlat";
            this.yenidenBaşlatToolStripMenuItem.Click += new System.EventHandler(this.yenidenBaşlatToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yayinlabtn);
            this.groupBox2.Controls.Add(this.onizlemebtn);
            this.groupBox2.Controls.Add(this.kuraltamam);
            this.groupBox2.Controls.Add(this.not);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.kısıtlamalar);
            this.groupBox2.Controls.Add(this.dosyaac);
            this.groupBox2.Controls.Add(this.programboyutu);
            this.groupBox2.Controls.Add(this.taramasonucu);
            this.groupBox2.Controls.Add(this.programurl);
            this.groupBox2.Controls.Add(this.programadi);
            this.groupBox2.Controls.Add(this.programboyutulabel);
            this.groupBox2.Controls.Add(this.taramasonuculabel);
            this.groupBox2.Controls.Add(this.programurllabel);
            this.groupBox2.Controls.Add(this.programadılabel);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(305, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 423);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program Bilgileri";
            // 
            // yayinlabtn
            // 
            this.yayinlabtn.Location = new System.Drawing.Point(584, 384);
            this.yayinlabtn.Name = "yayinlabtn";
            this.yayinlabtn.Size = new System.Drawing.Size(180, 33);
            this.yayinlabtn.TabIndex = 14;
            this.yayinlabtn.Text = "Yayınla";
            this.yayinlabtn.UseVisualStyleBackColor = true;
            this.yayinlabtn.Click += new System.EventHandler(this.yayinlabtn_Click);
            // 
            // onizlemebtn
            // 
            this.onizlemebtn.Location = new System.Drawing.Point(384, 384);
            this.onizlemebtn.Name = "onizlemebtn";
            this.onizlemebtn.Size = new System.Drawing.Size(180, 33);
            this.onizlemebtn.TabIndex = 13;
            this.onizlemebtn.Text = "Önizleme";
            this.onizlemebtn.UseVisualStyleBackColor = true;
            this.onizlemebtn.Click += new System.EventHandler(this.onizlemebtn_Click);
            // 
            // kuraltamam
            // 
            this.kuraltamam.AutoSize = true;
            this.kuraltamam.Location = new System.Drawing.Point(441, 349);
            this.kuraltamam.Name = "kuraltamam";
            this.kuraltamam.Size = new System.Drawing.Size(259, 21);
            this.kuraltamam.TabIndex = 12;
            this.kuraltamam.Text = "Kuralları okudum ve kabul ediyorum.";
            this.kuraltamam.UseVisualStyleBackColor = true;
            this.kuraltamam.CheckedChanged += new System.EventHandler(this.kuraltamam_CheckedChanged);
            // 
            // not
            // 
            this.not.Location = new System.Drawing.Point(384, 27);
            this.not.Multiline = true;
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(380, 316);
            this.not.TabIndex = 11;
            this.not.Text = "Varsa notunuzu yazın";
            this.not.MouseLeave += new System.EventHandler(this.not_MouseLeave);
            this.not.MouseHover += new System.EventHandler(this.not_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kısıtlamalar : ";
            // 
            // kısıtlamalar
            // 
            this.kısıtlamalar.Location = new System.Drawing.Point(134, 145);
            this.kısıtlamalar.Multiline = true;
            this.kısıtlamalar.Name = "kısıtlamalar";
            this.kısıtlamalar.Size = new System.Drawing.Size(244, 272);
            this.kısıtlamalar.TabIndex = 9;
            // 
            // dosyaac
            // 
            this.dosyaac.Location = new System.Drawing.Point(300, 86);
            this.dosyaac.Name = "dosyaac";
            this.dosyaac.Size = new System.Drawing.Size(78, 25);
            this.dosyaac.TabIndex = 8;
            this.dosyaac.Text = "Tara";
            this.dosyaac.UseVisualStyleBackColor = true;
            this.dosyaac.Click += new System.EventHandler(this.dosyaac_Click);
            // 
            // programboyutu
            // 
            this.programboyutu.Enabled = false;
            this.programboyutu.Location = new System.Drawing.Point(134, 117);
            this.programboyutu.Name = "programboyutu";
            this.programboyutu.Size = new System.Drawing.Size(244, 22);
            this.programboyutu.TabIndex = 7;
            // 
            // taramasonucu
            // 
            this.taramasonucu.Location = new System.Drawing.Point(134, 87);
            this.taramasonucu.Name = "taramasonucu";
            this.taramasonucu.Size = new System.Drawing.Size(160, 22);
            this.taramasonucu.TabIndex = 6;
            // 
            // programurl
            // 
            this.programurl.Location = new System.Drawing.Point(134, 57);
            this.programurl.Name = "programurl";
            this.programurl.Size = new System.Drawing.Size(244, 22);
            this.programurl.TabIndex = 5;
            // 
            // programadi
            // 
            this.programadi.Location = new System.Drawing.Point(134, 27);
            this.programadi.Name = "programadi";
            this.programadi.Size = new System.Drawing.Size(244, 22);
            this.programadi.TabIndex = 4;
            this.programadi.Leave += new System.EventHandler(this.programadi_Leave);
            // 
            // programboyutulabel
            // 
            this.programboyutulabel.AutoSize = true;
            this.programboyutulabel.Location = new System.Drawing.Point(6, 120);
            this.programboyutulabel.Name = "programboyutulabel";
            this.programboyutulabel.Size = new System.Drawing.Size(122, 17);
            this.programboyutulabel.TabIndex = 3;
            this.programboyutulabel.Text = "Program Boyutu : ";
            // 
            // taramasonuculabel
            // 
            this.taramasonuculabel.AutoSize = true;
            this.taramasonuculabel.Location = new System.Drawing.Point(6, 90);
            this.taramasonuculabel.Name = "taramasonuculabel";
            this.taramasonuculabel.Size = new System.Drawing.Size(121, 17);
            this.taramasonuculabel.TabIndex = 2;
            this.taramasonuculabel.Text = "Tarama Sonucu : ";
            // 
            // programurllabel
            // 
            this.programurllabel.AutoSize = true;
            this.programurllabel.Location = new System.Drawing.Point(6, 60);
            this.programurllabel.Name = "programurllabel";
            this.programurllabel.Size = new System.Drawing.Size(117, 17);
            this.programurllabel.TabIndex = 1;
            this.programurllabel.Text = "Programın Urlsi : ";
            // 
            // programadılabel
            // 
            this.programadılabel.AutoSize = true;
            this.programadılabel.Location = new System.Drawing.Point(6, 30);
            this.programadılabel.Name = "programadılabel";
            this.programadılabel.Size = new System.Drawing.Size(109, 17);
            this.programadılabel.TabIndex = 0;
            this.programadılabel.Text = "Programın Adı : ";
            // 
            // hatirla
            // 
            this.hatirla.AutoSize = true;
            this.hatirla.Checked = true;
            this.hatirla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hatirla.Location = new System.Drawing.Point(34, 96);
            this.hatirla.Name = "hatirla";
            this.hatirla.Size = new System.Drawing.Size(71, 21);
            this.hatirla.TabIndex = 0;
            this.hatirla.Text = "Hatırla";
            this.hatirla.UseVisualStyleBackColor = true;
            // 
            // taramaarkaplan
            // 
            this.taramaarkaplan.WorkerReportsProgress = true;
            this.taramaarkaplan.WorkerSupportsCancellation = true;
            this.taramaarkaplan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taramaarkaplan_DoWork);
            this.taramaarkaplan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taramaarkaplan_RunWorkerCompleted);
            // 
            // girisyaparkaplan
            // 
            this.girisyaparkaplan.WorkerReportsProgress = true;
            this.girisyaparkaplan.WorkerSupportsCancellation = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.altbilgi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1107, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Crimson;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 20);
            this.toolStripStatusLabel1.Text = "Program Durum Mesajı : ";
            // 
            // altbilgi
            // 
            this.altbilgi.ForeColor = System.Drawing.Color.Black;
            this.altbilgi.Name = "altbilgi";
            this.altbilgi.Size = new System.Drawing.Size(120, 20);
            this.altbilgi.Text = "İşlem bekleniyor.";
            // 
            // yayınlaarkaplan
            // 
            this.yayınlaarkaplan.WorkerReportsProgress = true;
            this.yayınlaarkaplan.WorkerSupportsCancellation = true;
            this.yayınlaarkaplan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.yayınlaarkaplan_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 485);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.hatirla);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.girişyap);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button girişyap;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox bilgi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resimYükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programYükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıBilgilerimiSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox hatirla;
        private System.Windows.Forms.Label programadılabel;
        private System.Windows.Forms.Label programurllabel;
        private System.Windows.Forms.Label taramasonuculabel;
        private System.Windows.Forms.Label programboyutulabel;
        private System.Windows.Forms.TextBox taramasonucu;
        private System.Windows.Forms.TextBox programurl;
        private System.Windows.Forms.TextBox programadi;
        private System.Windows.Forms.TextBox programboyutu;
        private System.Windows.Forms.Button dosyaac;
        private System.Windows.Forms.OpenFileDialog dosyaacdialog;
        private System.ComponentModel.BackgroundWorker taramaarkaplan;
        private System.Windows.Forms.OpenFileDialog resimyukledialog;
        private System.Windows.Forms.TextBox kısıtlamalar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox not;
        private System.Windows.Forms.CheckBox kuraltamam;
        private System.Windows.Forms.Button yayinlabtn;
        private System.Windows.Forms.Button onizlemebtn;
        private System.ComponentModel.BackgroundWorker girisyaparkaplan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel altbilgi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem yenidenBaşlatToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog yuklemedosyadialog;
        private System.ComponentModel.BackgroundWorker yayınlaarkaplan;

    }
}

