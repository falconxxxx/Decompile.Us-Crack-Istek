
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Gerekliler
        private int basilma = 0;
        HTTPWorker httpworker;
        private readonly UTF8Encoding utf8 = new UTF8Encoding();
        public string ToAscii(string dirty)
        {
            byte[] bytes = utf8.GetBytes(dirty);
            string clean = utf8.GetString(bytes);
            return clean;
        }
        public string taslak = "[p][color=#FFA500][b]Program Adı: [/b][/color][color=#87CEFA][b]{0}[/b][/color][/p]" +
            "[p][color=#FFA500][b]Programın indirme linki: [/b][/color][url]{1}[/url][/p]" +
            "[p][color=#FFA500][b]Dosya Boyutu: [/b][/color][color=#9370DB][b]{2}[/b][/color][/p]" +
            "[p][color=#FFA500][b]Tarama Sonucu:[/b][/color][color=#32CD32][img]{3}[/img][/color][/p]" +
            "[p][color=#FFA500][b]Kısıtlamalar:[/b][/color][/p][p][color=#FFDAB9]{4}[/color][/p]" +
            "[p][color=#FFA500][b]Varsa Notunuz:[/b][/color][/p][p][color=#FFDAB9]{5}[/color][/p]";

        #endregion Gerekliler

        #region TaramaİçinGerekliler

        private static string BytesToString(long byteCount)
        {
            string[] array = new string[]
            {
                "B",
                "KB",
                "MB",
                "GB",
                "TB",
                "PB",
                "EB"
            };
            string result;
            if (byteCount == 0L)
            {
                result = "0" + array[0];
            }
            else
            {
                long num = Math.Abs(byteCount);
                int num2 = Convert.ToInt32(Math.Floor(Math.Log((double) num, 1024.0)));
                double num3 = Math.Round((double) num / Math.Pow(1024.0, (double) num2), 1);
                result = ((double) Math.Sign(byteCount) * num3).ToString() + " " + array[num2];
            }
            return result;
        }

        #endregion TaramaİçinGerekliler

        #region DeğiştirmeİçinGerekli

        private delegate void taramasonucdegis(string newText);

        private void taramasdegis(string newText)
        {
            if (this.taramasonucu.InvokeRequired)
            {
                Form1.taramasonucdegis method = new Form1.taramasonucdegis(this.taramasdegis);
                this.taramasonucu.Invoke(method, new object[]
        {
            newText
        });
            }
            else
            {
                this.taramasonucu.Text = newText;
            }
        }

        private delegate void programboyutudegis(string newText);

        private void boyutdegis(string newText)
        {
            if (this.programboyutu.InvokeRequired)
            {
                Form1.programboyutudegis method = new Form1.programboyutudegis(this.boyutdegis);
                this.programboyutu.Invoke(method, new object[]
        {
            newText
        });
            }
            else
            {
                this.programboyutu.Text = newText;
            }
        }

        private void bilgiekrani(string text)
        {
            if (String.IsNullOrEmpty(this.bilgi.Text))
            {
                this.bilgi.Text = text;
            }
            else
            {
                this.bilgi.Text += Environment.NewLine + text;
            }
        }

        #endregion DeğiştirmeİçinGerekli

        private void Form1_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Ayarlar.Default.kullanıcı) && String.IsNullOrEmpty(Ayarlar.Default.şifre))
            {
                bilgiekrani("Kullanıcı adı ve şifre bekleniyor...");
            }
            else
            {
                this.username.Text = Ayarlar.Default.kullanıcı;
                this.password.Text = Ayarlar.Default.şifre;
                this.girişyap.PerformClick();
            }

            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                this.resimyukledialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", this.resimyukledialog.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            this.resimyukledialog.Filter = String.Format("{0}{1}{2} ({3})|{3}", this.resimyukledialog.Filter, sep, "Tüm dosyalar", "*.*");
            this.resimyukledialog.DefaultExt = ".png";
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.programadi, "Örnek: Internet Download Manager v6.26 Build 14");
            toolTip.SetToolTip(this.programurl, "Örnek: http://mirror2.internetdownloadmanager.com/idman626build14.exe?b=1&filename=idman626build14.exe");
            toolTip.SetToolTip(this.taramasonucu, "Tarama sonucu");
            toolTip.SetToolTip(this.programboyutu, "Program dosya boyutu.");
            toolTip.SetToolTip(this.kısıtlamalar, "Program kullanırken karşılaştığınız kısıtlamaları yazın.");
            toolTip.SetToolTip(this.username, "Forum kullanıcı adı");
            toolTip.SetToolTip(this.password, "Forum şifre");
            toolTip.SetToolTip(this.not, "Program hakkında ekstra istekleriniz varsa belirtiniz.");
            toolTip.SetToolTip(this.yayinlabtn, "Foruma konuyu gönderir.");
            toolTip.SetToolTip(this.onizlemebtn, "Foruma gönderilecek konuyu gösterir.");
        }

        private string ManuelRegex(string desen, string veri, int dizi)
        {
            return Regex.Match(veri, desen).Groups[dizi].Value.ToString();
        }

        private void kullanıcıBilgilerimiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ayarlar.Default.şifre = "";
                Ayarlar.Default.kullanıcı = "";
                Ayarlar.Default.Save();
                MessageBox.Show("Kullanıcı bilgileriniz programdan silindi.", "İşlem tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu ! Ek bilgi : Kullanıcı Bilgileri Silme", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dosyaac_Click(object sender, EventArgs e)
        {
            if (this.basilma == 0)
            {
                this.dosyaacdialog.Title = "Lütfen Dosya Seçiniz";
                this.dosyaacdialog.Filter = "(*.exe)|*.exe|(*.dll)|*.dll";
                this.dosyaacdialog.ShowDialog();
                if ((this.dosyaacdialog.FileName != "") || File.Exists(this.dosyaacdialog.FileName))
                {
                    try
                    {
                        this.basilma = 1;
                        Cursor.Current = Cursors.WaitCursor;
                        this.taramaarkaplan.RunWorkerAsync();
                    }
                    catch
                    {
                        MessageBox.Show("Hata oluştu. Lütfen forumdan bildirin. Ek bilgi : Dosya aç", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Şuan tarama yapılıyor bekleyin..", "!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void taramaarkaplan_DoWork(object sender, DoWorkEventArgs e)
        {
            Tarama t = new Tarama();
            t.TaramaYap(this.dosyaacdialog.FileName);
            this.altbilgi.Text = "Tarama sonucu yükleniyor lütfen bekleyin...";
            ResimYükle r = new ResimYükle();
            string resimurl = r.Yükle(Application.StartupPath + @"\taramasonucu.jpg");
            this.taramasdegis(resimurl);
            FileInfo fileInfo = new FileInfo(this.dosyaacdialog.FileName);
            this.boyutdegis(Form1.BytesToString(fileInfo.Length));
            this.altbilgi.Text = "Bekleniyor...";
        }

        private void taramaarkaplan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            File.Delete(Application.StartupPath + @"\tarmaasonucu.jpg");
            Cursor.Current = Cursors.Default;
            this.basilma = 0;
        }

        private void resimYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.resimyukledialog.ShowDialog();
            if (this.resimyukledialog.FileName != "" || File.Exists(this.resimyukledialog.FileName))
            {
                ResimYükle r = new ResimYükle();
                Cursor.Current = Cursors.WaitCursor;
                string resimyolu = r.Yükle(this.resimyukledialog.FileName);
                try
                {
                    Clipboard.SetText(resimyolu);
                    MessageBox.Show("Link hafızaya kopyalandı. Ctrl + V yaparak kullanabilirsiniz.", "Resim Yükleme Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    this.not.Text += Environment.NewLine + resimyolu;
                    MessageBox.Show("Link hafızaya kopyalanamadı. Not kısmında resim urlsini bulabilirsiniz.", "Resim Yükleme Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void girişyap_Click(object sender, EventArgs e)
        {
            ÜyeBilgileri üyebilgi = new ÜyeBilgileri();
            üyebilgi.quick_username = ToAscii(this.username.Text);
            üyebilgi.quick_password = this.password.Text;
            if (this.hatirla.Checked)
            {
                Ayarlar.Default.kullanıcı = this.username.Text;
                Ayarlar.Default.şifre = this.password.Text;
                Ayarlar.Default.Save();
            }
            httpworker = new HTTPWorker();
            if (httpworker.GirişYap("http://www.decompile.us", üyebilgi))
            {
                bilgiekrani("Giriş yapıldı... Hoşgeldin " + this.username.Text + " :)");
                this.girişyap.Enabled = false;
                this.username.Enabled = false;
                this.password.Enabled = false;
                this.hatirla.Enabled = false;
                this.groupBox2.Enabled = true;
            }
            else
            {
                bilgiekrani("Hatalı bilgiler girdiniz !");
            }
        }

        private void not_MouseLeave(object sender, EventArgs e)
        {
            if (this.not.Text.Trim() == "")
            {
                this.not.Text = "Varsa notunuzu yazın";
            }
        }

        private void not_MouseHover(object sender, EventArgs e)
        {
            if (this.not.Text == "Varsa notunuzu yazın")
            {
                this.not.Text = "";
            }
        }

        private void kuraltamam_CheckedChanged(object sender, EventArgs e)
        {
            Form kurallar = new Kurallar(httpworker);
            kurallar.ShowDialog();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hakkinda = new Hakkında();
            hakkinda.Show();
        }

        private void yayinlabtn_Click(object sender, EventArgs e)
        {
            if (this.kuraltamam.Checked)
            {
            }
            else
            {
                MessageBox.Show("Önce kuralları kabul etmelisiniz !", "Uyarı !!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void FormKüçült(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                altaatma.Visible = true;
                altaatma.ShowBalloonTip(10000);
            }
        }

        private void altaatma_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void onizlemebtn_Click(object sender, EventArgs e)
        {
            if(this.kuraltamam.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("Lütfen kuralları okuyup kabul edin !", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(Control kontrol in this.groupBox2.Controls)
            {
                if(kontrol is TextBox)
                {
                    TextBox textbox = kontrol as TextBox;
                    if(textbox.Text == string.Empty)
                    {
                        MessageBox.Show("Lütfen boş alan bırakmayın !", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textbox.Focus();
                        return;
                    }
                }
            }

            this.taslak = string.Format(taslak, this.programadi.Text, this.programurl.Text, this.programboyutu.Text, this.taramasonucu.Text, this.kısıtlamalar.Text, this.not.Text);

            Form form = new Taslak(httpworker.OnIzleme(taslak, this.programadi.Text));
            form.ShowDialog();
            
        }

        private void ekstraDosyaTaratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (dosyaacdialog as OpenFileDialog)
            {
                dosyaacdialog.ShowDialog();
                if (dosyaacdialog.FileName == null) return;
                Tarama t = new Tarama();
                t.TaramaYap(this.dosyaacdialog.FileName);
                this.altbilgi.Text = "Tarama sonucu yükleniyor lütfen bekleyin...";
                ResimYükle r = new ResimYükle();
                string resimurl = r.Yükle(Application.StartupPath + @"\taramasonucu.jpg");
                if(this.not.Text == "Varsa notunuzu yazın")
                {
                    this.not.Text = "";
                }
                else
                {

                }
                this.not.Text += "[IMG]" + resimurl + @"[\IMG]";
                this.altbilgi.Text = "Bekleniyor...";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void programYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dosya = new OpenFileDialog())
            {
                dosya.ShowDialog();
                if (dosya.FileName == null) return;
                this.altbilgi.Text = "Program yükleniyor lütfen bekleyin...";
                ProgramYükle program = new ProgramYükle();
                string cevap = program.Yükle(dosya.FileName);
                if(cevap != "hata")
                {
                    try
                    {
                        Clipboard.SetText(cevap);
                        MessageBox.Show("Link hafızaya kopyalandı. Ctrl + V yaparak kullanabilirsiniz.", "Program Yükleme Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        this.not.Text += Environment.NewLine + cevap;
                        MessageBox.Show("Link hafızaya kopyalanamadı. Not kısmında resim urlsini bulabilirsiniz.", "Program Yükleme Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Program yüklenirken hata oluştu. Lütfen forumdan hatayı bildirin.", "Program Yükleme Tamamlanamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.altbilgi.Text = "Bekliyor...";

            }
        }
    }
}