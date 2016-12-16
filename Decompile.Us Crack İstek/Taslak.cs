using CodeKicker.BBCode;
using System;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    public partial class Taslak : Form
    {
        private string içerik;
        private BBCodeParser BBcode;

        public Taslak(string içerik)
        {
            BBCodeParser BBcode = new BBCodeParser(new[] {
                new BBTag("p","<p>","</p>"),
                new BBTag("b", "<b>", "</b>"),
                new BBTag("i", "<span style=\"font-style:italic;\">", "</span>"),
                new BBTag("u", "<span style=\"text-decoration:underline;\">", "</span>"),
                new BBTag("code", "<pre class=\"prettyprint\">", "</pre>"),
                new BBTag("img", "<img src=\"${content}\" />", "", false, true),
                new BBTag("quote", "<blockquote>", "</blockquote>"),
                new BBTag("list", "<ul>", "</ul>"),
                new BBTag("*", "<li>", "</li>", true, false),
                new BBTag("color", "<font color=\"${color}\">", "</font>", new BBAttribute("color", ""), new BBAttribute("color", "color")),
                new BBTag("url", "<a href=\"${href}\">", "</a>", new BBAttribute("href", ""), new BBAttribute("href", "href"))
            });
            içerik = BBcode.ToHtml(içerik);
            this.içerik = içerik;
            InitializeComponent();
        }

        private void Taslak_Load(object sender, EventArgs e)
        {
            this.htmlTextbox1.Text = içerik;
        }

        private void kaydetveçık_Click(object sender, EventArgs e)
        {
            Form1 anaform = new Form1();
            anaform.taslak = BBcode.ToString();
            base.Close();
        }

        private void kaydetmedençık_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}