using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

class MForm : Form
{
    private StatusBar sb;

    public MForm()
    {
        Text = "ListView Test";
        Size = new Size(350, 300);

        List<Actress> actress = new List<Actress>();
        actress.Add(new Actress("AAA", 1981));
        actress.Add(new Actress("BBB", 1980));
        actress.Add(new Actress("CCC", 1978));
        actress.Add(new Actress("DDD", 1979));
        actress.Add(new Actress("EEE", 1981));
        actress.Add(new Actress("FFF", 1982));

        ColumnHeader h1 = new ColumnHeader();
        h1.Text = "Name";
        h1.Width = 150;

        ColumnHeader h2 = new ColumnHeader();
        h2.Text = "Year";
        h2.Width = 150;

        SuspendLayout();

        ListView lv = new ListView();
        lv.Parent = this;
        lv.FullRowSelect = true;
        lv.GridLines = true;
        lv.AllowColumnReorder = false;
        //lv.Sorting = SortOrder.Ascending;
        lv.Width = 300;
        lv.Height = 800;        
        lv.Columns.AddRange(new ColumnHeader[] { h1, h2 });
        lv.ColumnClick += ColumnClick;

        foreach(Actress act in actress)
        {
            ListViewItem item = new ListViewItem();
            item.Text = act.name;
            item.SubItems.Add(act.year.ToString());
            lv.Items.Add(item);
        }

        lv.Dock = DockStyle.Fill;
        lv.Click += OnChange;

        sb = new StatusBar();
        sb.Parent = this;
        lv.View = View.Details;

        ResumeLayout();
        CenterToScreen();

    }

    void ColumnClick(Object sender, ColumnClickEventArgs e)
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

    void OnChange(object o, EventArgs e)
    {
        ListView lv = (ListView)o;
        string name = lv.SelectedItems[0].SubItems[0].Text;
        string year = lv.SelectedItems[0].SubItems[1].Text;

        sb.Text = name + "," + year;
    }
}


class TestMain
{
    public static void Main()
    {
        Application.Run(new MForm());
    }
}

