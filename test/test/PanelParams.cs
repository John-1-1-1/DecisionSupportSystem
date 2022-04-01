using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    internal class PanelParams
    {
        List<ListViewItem> listView =
            new List<ListViewItem>();
        ListView lw;
        public PanelParams(ListView lw)
        {
            this.lw = lw;
        }

        public void clear_list()
        {
            listView =
           new List<ListViewItem>();
        }

        public void add_data(List<(string name,
            string param)> list)
        {
            foreach (var item in list)
            {
                ListViewItem item1 =
                    new ListViewItem(item.name, 0);
                item1.SubItems.Add(item.param);
                listView.Add(item1);
            }
            lw.Items.AddRange(listView.ToArray());
        }


    }
}
