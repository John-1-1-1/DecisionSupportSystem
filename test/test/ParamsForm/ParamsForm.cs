using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class ParamsForm : Form
    {
        PanelParams panel = null;

        public ParamsForm(Node n)
        {
            InitializeComponent();
            panel = new PanelParams(listView1);
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            panel.add_data_paramsform(textBoxName.Text,
                textBoxOID.Text);
        }
    }
}
