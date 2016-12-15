using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decompile.Us_Crack_İstek
{
    public partial class TaslakForm : Form
    {
        public TaslakForm()
        {
            InitializeComponent();
        }

        private void kapat_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.taslakx.Text);
            base.Close();
        }
    }
}
