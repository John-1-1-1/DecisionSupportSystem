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

        public int countItems()
        {
            return lw.Items.Count;
        }

        public void clear_list()
        {
            if (countItems() != 0)
            { 
                listView.Clear();
                lw.Items.Clear();
            }
        }

        public void add_data_paramsform(string name, string oid)
        {

        }

        internal void add_data(Node nodeIsClick)
        {

            ListViewItem item1 = new ListViewItem("Имя", 0);
                item1.SubItems.Add(nodeIsClick.name);
                listView.Add(item1);
            
            ListViewItem item2 = new ListViewItem("IP", 0);
                item2.SubItems.Add(nodeIsClick.ip);
                listView.Add(item2);
            //Web web = new Web();
            //var r = web.get_requests().Split('|').ToArray();

            //    ListViewItem item3 = new ListViewItem("Нагруженность", 0);
            //    item3.SubItems.Add(r[0]);
            //    listView.Add(item3);

            //    ListViewItem item4 = new ListViewItem("Температура", 0);
            //    item4.SubItems.Add(r[1]);
            //    listView.Add(item4);


            lw.Items.AddRange(listView.ToArray());
        }
    }
}
