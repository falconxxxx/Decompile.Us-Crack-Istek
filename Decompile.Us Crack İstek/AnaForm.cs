using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Collections.Specialized;

namespace Decompile.Us_Crack_İstek
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        #region Gerekliler

        int basilma = 0;

        private readonly UTF8Encoding utf8 = new UTF8Encoding();

        public string ToAscii(string dirty)
        {
            byte[] bytes = utf8.GetBytes(dirty);
            string clean = utf8.GetString(bytes);
            return clean;
        }

        private string ManuelRegex(string desen, string veri, int dizi)
        {
            return Regex.Match(veri, desen).Groups[dizi].Value.ToString();
        }

        public string htmltemizle(string text)
        {
            return Regex.Replace(text, "<(.|\\n)*?>", string.Empty);
        }

        #endregion

        #region Tarama İçin Gerekliler

        private static Bitmap MakeSnapshot(IntPtr AppWndHandle, bool IsClientWnd, Win32API.WindowShowStyle nCmdShow)
        {

            if (AppWndHandle == IntPtr.Zero || !Win32API.IsWindow(AppWndHandle) || !Win32API.IsWindowVisible(AppWndHandle))
                return null;
            if (Win32API.IsIconic(AppWndHandle))
                Win32API.ShowWindow(AppWndHandle, nCmdShow);//show it
            if (!Win32API.SetForegroundWindow(AppWndHandle))
                return null;//can't bring it to front
            Thread.Sleep(1000);//give it some time to redraw
            RECT appRect;
            bool res = IsClientWnd ? Win32API.GetClientRect(AppWndHandle, out appRect) : Win32API.GetWindowRect(AppWndHandle, out appRect);
            if (!res || appRect.Height == 0 || appRect.Width == 0)
            {
                return null;//some hidden window
            }
            if (IsClientWnd)
            {
                System.Drawing.Point lt = new System.Drawing.Point(appRect.Left, appRect.Top);
                System.Drawing.Point rb = new System.Drawing.Point(appRect.Right, appRect.Bottom);
                Win32API.ClientToScreen(AppWndHandle, ref lt);
                Win32API.ClientToScreen(AppWndHandle, ref rb);
                appRect.Left = lt.X;
                appRect.Top = lt.Y;
                appRect.Right = rb.X;
                appRect.Bottom = rb.Y;
            }
            IntPtr DesktopHandle = Win32API.GetDesktopWindow();
            RECT desktopRect;
            Win32API.GetWindowRect(DesktopHandle, out desktopRect);
            RECT visibleRect;
            if (!Win32API.IntersectRect(out visibleRect, ref desktopRect, ref appRect))
            {
                visibleRect = appRect;
            }
            if (Win32API.IsRectEmpty(ref visibleRect))
                return null;

            int Width = visibleRect.Width;
            int Height = visibleRect.Height;
            IntPtr hdcTo = IntPtr.Zero;
            IntPtr hdcFrom = IntPtr.Zero;
            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                Bitmap clsRet = null;

                hdcFrom = IsClientWnd ? Win32API.GetDC(AppWndHandle) : Win32API.GetWindowDC(AppWndHandle);

                hdcTo = Win32API.CreateCompatibleDC(hdcFrom);
                hBitmap = Win32API.CreateCompatibleBitmap(hdcFrom, Width, Height);

                if (hBitmap != IntPtr.Zero)
                {
                    int x = appRect.Left < 0 ? -appRect.Left : 0;
                    int y = appRect.Top < 0 ? -appRect.Top : 0;
                    IntPtr hLocalBitmap = Win32API.SelectObject(hdcTo, hBitmap);
                    Win32API.BitBlt(hdcTo, 0, 0, Width, Height, hdcFrom, x, y, Win32API.SRCCOPY);
                    Win32API.SelectObject(hdcTo, hLocalBitmap);
                    clsRet = Image.FromHbitmap(hBitmap);
                }
                return clsRet;
            }
            finally
            {
                if (hdcFrom != IntPtr.Zero)
                    Win32API.ReleaseDC(AppWndHandle, hdcFrom);
                if (hdcTo != IntPtr.Zero)
                    Win32API.DeleteDC(hdcTo);
                if (hBitmap != IntPtr.Zero)
                    Win32API.DeleteObject(hBitmap);
            }


        }
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
                int num2 = Convert.ToInt32(Math.Floor(Math.Log((double)num, 1024.0)));
                double num3 = Math.Round((double)num / Math.Pow(1024.0, (double)num2), 1);
                result = ((double)Math.Sign(byteCount) * num3).ToString() + " " + array[num2];
            }
            return result;
        }

        #endregion

        #region Değiştirme İçin Gerekli

        private delegate void taramasonucdegis(string newText);
        private void taramasdegis(string newText)
        {
            if (this.taramasonucu.InvokeRequired)
            {
                AnaForm.taramasonucdegis method = new AnaForm.taramasonucdegis(this.taramasdegis);
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
                AnaForm.programboyutudegis method = new AnaForm.programboyutudegis(this.boyutdegis);
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

        #endregion

        #region Yasaklı Liste Kontrol
        public bool yasaklilistekontrol(string programadi)
        {
            bool sonuc = false;
            HTTPWorker work = new HTTPWorker();
            string sitedekikurallar = work.navTo("http://www.decompile.us/Cwt-Yasakl%C4%B1-Program-Listesi");
            Match eslesme = Regex.Match(sitedekikurallar, "id=\"pid_20104\">(.*?)</div>", RegexOptions.Singleline);
            if (eslesme.Success)
            {
                string kurallistesi = Regex.Replace(eslesme.Groups[1].Value.Replace(@"<br />", Environment.NewLine).Trim(), @"<(.|\n).*?>", String.Empty);
                kurallistesi = kurallistesi.Replace("-", String.Empty).Trim();
                kurallistesi = kurallistesi.Replace("Sayın Üyelerimiz:\r\n\n\r\n\n\r\n\nSitede istenmesi ve paylaşılması yasaklı olan program listesi aşağıda sunulmuştur.\r\n\n\r\n\n", String.Empty).Trim();
                kurallistesi = kurallistesi.Replace("Programcılar için;\r\n\n\r\n\n\r\n\nKodladığınız program hakkında sitemizde herhangi bir çalışma mevcut ise bunu yönetime PM ile bildiriniz.", String.Empty).Trim();
                string[] programlar = kurallistesi.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string program in programlar)
                {
                    if (Regex.IsMatch(program, programadi, RegexOptions.IgnoreCase))
                    {
                        sonuc = true;
                        break;
                    }
                }
            }
            return sonuc;
        }

        private void programadi_Leave(object sender, EventArgs e)
        {
            if (this.programadi.Text.ToLower().Trim() != "yazılım" || this.programadi.Text.ToLower().Trim() != "yazilim" || this.programadi.Text.Trim() != "")
            {
                bool kontrol = yasaklilistekontrol(this.programadi.Text.Trim());
                if (kontrol)
                {
                    MessageBox.Show("Program yasaklı listesinde ! Lütfen istekte bulunurken dikkat edin !\nAksi halde ceza alıcaksınız." + Environment.NewLine + "Programda hata olabilir fakat lütfen kuralları kontrol edin !", "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Not Kısmı Özel

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

        #endregion

        #region kullanıcıbilgilerisil
        private void kullanıcıBilgilerimiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ayarlar.Default.şifre = "";
                Ayarlar.Default.kullanıcı = "";
                Ayarlar.Default.Save();
                MessageBox.Show("Kullanıcı bilgileriniz programdan silindi.", "İşlem tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.username.Text = "";
                this.password.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu !", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Sol Bilgi Ekranı
        public void bilgiekrani(string text)
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
        #endregion

        #region Tarama Sonucu İşlemler
        private void taramaarkaplan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            this.basilma = 0;
            this.taramasonucu.Enabled = false;
        }
        #endregion

        #region Tarama Yapılıyor
        private void taramaarkaplan_DoWork(object sender, DoWorkEventArgs e)
        {
            this.altbilgi.Text = "Tarama yapılıyor lütfen bekleyin...";
            Cursor.Current = Cursors.WaitCursor;
            
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "pid.exe";
            processStartInfo.Arguments = "-scan " + this.dosyaacdialog.FileName;
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            Thread.Sleep(4000);

            Bitmap bitmap = MakeSnapshot(process.MainWindowHandle, false, Win32API.WindowShowStyle.Restore);
            try
            {
                string filepath = Path.Combine(Path.GetTempPath(), "taramasonucu.jpg");
                bitmap.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                MessageBox.Show("Hata oluştu. Lütfen YuqseLx ile iletişime geçin." + Environment.NewLine + "Hata Bilgisi = Tarama Hatası", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            process.Kill();
            this.altbilgi.Text = "Tarama sonucu yükleniyor lütfen bekleyin...";
            Account account = new Account("duj1m9euv", "366682913616939", "sIZ_S9Zs_C00uRgAdBrUmr_aHHE");
            Cloudinary cloudinary = new Cloudinary(account);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Path.Combine(Path.GetTempPath(), "taramasonucu.jpg"))

            };

            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));

            this.taramasdegis(url);

            FileInfo fi = new FileInfo(this.dosyaacdialog.FileName);
            boyutdegis(BytesToString(fi.Length));
            this.altbilgi.Text = "İşleminize devam edebilirsiniz.";
        }
        #endregion

        #region Kural Formu Göster
        private void kuraltamam_CheckedChanged(object sender, EventArgs e)
        {
            Form kurallar = new KurallarForm();
            kurallar.Show();

            kuraltamam.Enabled = false;
        }
        #endregion

        #region Hakkında Formu Göster
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hakkinda = new HakkındaForm();
            hakkinda.Show();
        }
        #endregion

        #region Programı Yeniden Başlat
        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı yeniden başlatmak istiyor musunuz ? ", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        #endregion

        #region Resim Yükleme Üst Kısım
        private void resimYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.resimyukledialog.ShowDialog();
            if (this.resimyukledialog.FileName != "" || File.Exists(this.resimyukledialog.FileName))
            {
                Cursor.Current = Cursors.WaitCursor;

                Account account = new Account("duj1m9euv", "366682913616939", "sIZ_S9Zs_C00uRgAdBrUmr_aHHE");
                Cloudinary cloudinary = new Cloudinary(account);

                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(this.resimyukledialog.FileName)

                };

                ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));

                Clipboard.SetText(url);
                MessageBox.Show("Link hafızaya kopyalandı. Ctrl + V yaparak kullanabilirsiniz.", "Resim Yükleme Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Program Yükleme
        private void programYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu fonksiyon şuan geçerli değil.");
            //TODO : Değiştir
            /*
            this.yuklemedosyadialog.Title = "Lütfen Dosya Seçiniz";
            this.yuklemedosyadialog.Filter = "EXE Dosyası(*.exe)|*.exe|DLL Dosyası(*.dll)|*.dll|RAR Dosyası(*.rar)|*.rar|ZIP Dosyası(*.zip)|*.zip";
            this.yuklemedosyadialog.ShowDialog();

            if ((this.yuklemedosyadialog.FileName != "") || File.Exists(this.yuklemedosyadialog.FileName))
            {
                try
                {
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata oluştu lütfen bildirin ! \r\n Dosya yükleme hatası", "HATA !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }
        #endregion

        #region Form1 Load
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Giriş
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
            #endregion
            #region Resim Seçme İçin
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
            #endregion
            #region Tooltips

            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.programadi, "Örnek: Internet Download Manager v6.15");
            tip.SetToolTip(this.programurl, "Örnek: http://www.internetdownloadmanager.com");
            tip.SetToolTip(this.programboyutu, "Program dosya boyutu.");
            tip.SetToolTip(this.kısıtlamalar, "Program kullanırken karşılaştığınız kısıtlamaları yazın.");
            tip.SetToolTip(this.username, "Forum kullanıcı adı");
            tip.SetToolTip(this.password, "Forum şifre");
            tip.SetToolTip(this.not, "Program hakkında ekstra istekleriniz varsa belirtiniz.");
            tip.SetToolTip(this.yayinlabtn, "Foruma konuyu gönderir.");
            tip.SetToolTip(this.onizlemebtn, "Foruma g\x00f6nderilecek konuyu gösterir.");


            #endregion
        }
        #endregion

        #region Dosya Aç Buton
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
                        MessageBox.Show("Hata oluştu. Lütfen forumdan bildirin.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Şuan tarama yapılıyor bekleyin..", "!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
        #endregion

        #region Giriş Yap Buton
        private void girişyap_Click(object sender, EventArgs e)
        {
            if (this.username.Text.Equals("") && this.password.Text.Equals(""))
            {
                bilgiekrani("Lütfen kullanıcı adı ve şifre girin !");
            }
            else
            {
                this.altbilgi.Text = "Giriş yapılıyor lütfen bekleyin...";
                if (this.hatirla.Checked)
                {
                    Ayarlar.Default.kullanıcı = this.username.Text;
                    Ayarlar.Default.şifre = this.password.Text;
                    Ayarlar.Default.Save();
                }
                HTTPWorker httpworker = new HTTPWorker();
                myBB mybbforum = new myBB("http://www.decompile.us/", ToAscii(this.username.Text), this.password.Text);
                if (httpworker.login(mybbforum))
                {
                    bilgiekrani("Giriş yapıldı... Hoşgeldin " + this.username.Text + " :)");
                    this.girişyap.Enabled = false;
                    this.username.Enabled = false;
                    this.password.Enabled = false;
                    this.hatirla.Enabled = false;
                    this.groupBox2.Enabled = true;
                    this.altbilgi.Text = "İşleminize devam edebilirsiniz.";
                }
                else
                {
                    bilgiekrani("Hatalı bilgiler girdiniz !");
                }
            }
            this.altbilgi.Text = "İşlem bekleniyor.";
        }
        #endregion

        #region Yayınla Buton
        string taslak = "";
        private void yayinlabtn_Click(object sender, EventArgs e)
        {
            if (!this.kuraltamam.Checked)
	        {
		        if (MessageBox.Show("Kuralları kabul ediyor musunuz?", "Hata !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		        {
			        this.kuraltamam.Checked = true;
		        }
		        else
		        {
			        MessageBox.Show("Üzgünüm kuralları kabul etmelisin.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		        }
	        }
            else if (this.programurl.Text == "" || this.programadi.Text == "" || this.kısıtlamalar.Text == "" || this.programboyutu.Text == "" || this.taramasonucu.Text == "")
            {
                if (MessageBox.Show("Tüm alanları doldurduğunuza emin misiniz?", "Hata !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Lütfen YuqseLx ile iletişime geçin :(", ":( :(", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurup tekrar deneyin.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                try
                {
                    string notu = "";
                    if (this.not.Text == "Varsa notunuzu yazın") { notu = ""; } else { notu = this.not.Text; }
                    this.taslak = "[color=#FFA500][b]Program Adı:[/b][/color]" + Environment.NewLine +
                        "[code]" + this.programadi.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                        "[color=#FFA500][b]Programın indirme linki:[/b][/color]" + Environment.NewLine +
                        "[code]" + this.programurl.Text + "[/code]" + Environment.NewLine +
                        Environment.NewLine + 
                        "[color=#FFA500][b]Dosya Boyutu:[/b][/color]" + Environment.NewLine +
                        "[code]" + this.programboyutu.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                        "[color=#FFA500][b]Tarama Sonucu:[/b][/color]" + Environment.NewLine +
                        "[img]" + this.taramasonucu.Text + "[/img]" + Environment.NewLine + Environment.NewLine +
                        "[color=#FFA500][b]Kısıtlamalar:[/b][/color]" + Environment.NewLine +
                        "[code]" + this.kısıtlamalar.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                        "[color=#FFA500][b]Varsa Notunuz:[/b][/color]" + Environment.NewLine +
                        "[code]" + notu + "[/code]";

                    this.taslak = htmltemizle(this.taslak);
                    this.altbilgi.Text = "İşlem yapılıyor.";
                    this.yayınlaarkaplan.RunWorkerAsync();
                }
                catch
                {
                    MessageBox.Show("Lütfen YuqseLx ile iletişime geçin !", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }   

        private void yayınlaarkaplan_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] hashlerim = new string[2];

            HTTPWorker httpwork = new HTTPWorker();
            string giris = httpwork.navTo("http://www.decompile.us/newthread.php?fid=7");
            if (giris.Contains("my_post_key") && giris.Contains("posthash"))
            {
                hashlerim[0] = this.ManuelRegex("name=\"my_post_key\" value=\"(.*?)\"", giris, 1);
                hashlerim[1] = this.ManuelRegex("name=\"posthash\" value=\"(.*?)\"", giris, 1);

                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("my_post_key", hashlerim[0]);
                nameValueCollection.Add("posthash", hashlerim[1]);
                nameValueCollection.Add("message_new", this.taslak);
                nameValueCollection.Add("message", this.taslak);
                nameValueCollection.Add("numpolloptions", "2");
                nameValueCollection.Add("subject", this.htmltemizle(this.programadi.Text));
                nameValueCollection.Add("action", "do_newthread");
                nameValueCollection.Add("attachmentaid", "");
                nameValueCollection.Add("attachmentact", "");
                nameValueCollection.Add("quoted_ids", "");
                nameValueCollection.Add("tid", "");

                StringBuilder builder = new StringBuilder();
                string str2 = string.Empty;

                foreach (string str3 in nameValueCollection.AllKeys)
                {
                    builder.Append(str2);
                    builder.Append(System.Web.HttpUtility.UrlEncode(str3));
                    builder.Append("=");
                    builder.Append(System.Web.HttpUtility.UrlEncode(nameValueCollection[str3]));
                    str2 = "&";
                }

                string @string = httpwork.PostTo("http://www.decompile.us/newthread.php?fid=7", builder.ToString());
                if (@string.Contains("Teşekkürler, konunuz başarılı olarak gönderildi."))
                {
                    bilgiekrani(Environment.NewLine + "Konunuz başarılı bir şekilde gönderildi.");
                    if (MessageBox.Show("Konuya gitmek istiyor musunuz?", "Konu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string str = this.ManuelRegex("<meta http-equiv=\"refresh\" content=\"2;URL=(.*?)\" />", @string, 1);
                        Process.Start("http://www.recodegroup.org/forum/" + str);
                    }
                }
                else
                {

                }
            }
            else
            {
                bilgiekrani(Environment.NewLine + "Konu göndermede hata oldu. Lütfen iletişime geçin !");
            }
        }

        #endregion

        #region Önizleme Buton
        private void onizlemebtn_Click(object sender, EventArgs e)
        {
            if (!this.kuraltamam.Checked)
            {
                MessageBox.Show("Lütfen kuralları okuyup kabul edin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (this.programurl.Text == "" || this.programadi.Text == "" || this.kısıtlamalar.Text == "" || this.programboyutu.Text == "" || this.taramasonucu.Text == "")
            {
                if (MessageBox.Show("Tüm alanları dolurduğunuza emin misiniz?", "Hata !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Lütfen YuqseLx ile iletişime geçin :(", ":( :(", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Lütfen doldurup tekrar deneyin.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                try
                {
                    string notu = "";
                    if (this.not.Text == "Varsa notunuzu yazın") { notu = ""; } else { notu = this.not.Text; }
                    this.taslak = "[color=#FFA500][b]Program Adı:[/b][/color]" + Environment.NewLine +
                     "[code]" + this.programadi.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                     "[color=#FFA500][b]Programın indirme linki:[/b][/color]" + Environment.NewLine +
                     "[code]" + this.programurl.Text + "[/code]" + Environment.NewLine +
                     Environment.NewLine +
                     "[color=#FFA500][b]Dosya Boyutu:[/b][/color]" + Environment.NewLine +
                     "[code]" + this.programboyutu.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                     "[color=#FFA500][b]Tarama Sonucu:[/b][/color]" + Environment.NewLine +
                     "[img]" + this.taramasonucu.Text + "[/img]" + Environment.NewLine + Environment.NewLine +
                     "[color=#FFA500][b]Kısıtlamalar:[/b][/color]" + Environment.NewLine +
                     "[code]" + this.kısıtlamalar.Text + "[/code]" + Environment.NewLine + Environment.NewLine +
                     "[color=#FFA500][b]Varsa Notunuz:[/b][/color]" + Environment.NewLine +
                     "[code]" + notu + "[/code]";
                    new TaslakForm
                    {
                        taslakx =
                        {
                            Text = this.taslak
                        }
                    }.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Lütfen YuqseLx ile iletişime geçin !", ":(", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion
    }
}
