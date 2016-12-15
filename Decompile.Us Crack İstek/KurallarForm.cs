using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    public partial class KurallarForm : Form
    {
        public KurallarForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?","???",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Kurallar_Load(object sender, EventArgs e)
        {
            HTTPWorker work = new HTTPWorker();
            string sitedekikurallar = work.navTo("http://www.decompile.us/Cwt-Yasakl%C4%B1-Program-Listesi");

            Match eslesme = Regex.Match(sitedekikurallar, "id=\"pid_20104\">(.*?)</div>", RegexOptions.Singleline);
            if (eslesme.Success)
            {
                this.textBox1.Text = Regex.Replace(eslesme.Groups[1].Value.Replace(@"<br />",Environment.NewLine).Trim(),@"<(.|\n).*?>",String.Empty);
            }
            else
            {
                if (MessageBox.Show("Kuralları çekemedik. Siteden bakmak ister misiniz?" + Environment.NewLine + "Kuralları kabul etmiyorsanız programı kapatın ! Bu adımdan sonra kabul etmiş sayılırsınız !", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("http://www.decompile.us/Cwt-Yasakl%C4%B1-Program-Listesi");
                }
                else
                {
                    MessageBox.Show("Kuralları kabul etmiş sayıldınız !", "Uyarı !", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

    }
}
