using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ListViewSample
{  

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "ListView Test";
            Size = new Size(350, 300);

            ColumnHeader h1 = new ColumnHeader();
            h1.Text = "Name";
            h1.Width = 150;
            h1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "Year";
            h2.Width = 150;
            h2.TextAlign = HorizontalAlignment.Center;
            //listView1.Columns.AddRange(new ColumnHeader[] { h1, h2 });
            listView1.Columns.Add(h1);
            listView1.Columns.Add(h2);

            List<Actress> actress = new List<Actress>();
            actress.Add(new Actress("AAA", 1981));
            actress.Add(new Actress("BBB", 1980));
            actress.Add(new Actress("CCC", 1978));
            actress.Add(new Actress("DDD", 1979));
            actress.Add(new Actress("EEE", 1981));
            actress.Add(new Actress("FFF", 1982));

            foreach (Actress act in actress)
            {
                ListViewItem item = new ListViewItem();
                item.Text = act.name;
                item.SubItems.Add(act.year.ToString());
                listView1.Items.Add(item);
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string name = lv.SelectedItems[0].SubItems[0].Text;
            string year = lv.SelectedItems[0].SubItems[1].Text;

            toolStripStatusLabel1.Text = name + "," + year;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Console.WriteLine("컬럼 클릭~");
            //ListView lv = (ListView)sender;
            ListView lv = sender as ListView;
            if (lv.Sorting == SortOrder.Ascending)
            {
                Console.WriteLine("오름차순으로 되어 있었군~");
                lv.Sorting = SortOrder.Descending;
            }
            else
            {
                Console.WriteLine("내림차순으로 되어 있었군~");
                lv.Sorting = SortOrder.Ascending;
            }
        }
    }
    public class Actress
    {
        public string name;
        public int year;

        public Actress(string name, int year)
        {
            this.name = name;
            this.year = year;
        }
    }

}
