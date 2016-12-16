using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    public partial class Kurallar : Form
    {
        private HTTP istemci;

        public Kurallar(HTTP istemci)
        {
            this.istemci = istemci;
            InitializeComponent();
        }

        private void kabuletmiyorum_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kuralları kabul etmezseniz program kapanacaktır. Kabul ediyor musunuz?", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void kabulediyorum_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void Kurallar_Load(object sender, EventArgs e)
        {
            string yasaklılar = istemci.YolAl("/Cwt-Yasakl%C4%B1-Program-Listesi");
            int nereden = yasaklılar.LastIndexOf("<div class=\"post_body scaleimages\" id=\"pid_20104\">");
            string yeniyasaklı = yasaklılar.Substring(nereden, yasaklılar.Length - nereden);
            int nereye = yeniyasaklı.LastIndexOf("<div class=\"post_meta\" id=\"post_meta_20104\">");
            yasaklılar = yeniyasaklı.Substring(0, nereye);
            yasaklılar = Regex.Replace(yasaklılar, "(<br />|<br/>|</ br>|</br>)", Environment.NewLine);
            this.kurallartext.Text = Regex.Replace(yasaklılar, "<.*?>", String.Empty).Trim();
        }
    }
}