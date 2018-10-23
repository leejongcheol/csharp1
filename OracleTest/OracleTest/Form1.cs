using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace OracleTest
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = null;
        OleDbDataAdapter adapter = null;
        DataSet ds = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form_Load OK~");
            MessageBox.Show("Form_Load OK~");
            try
            {
                ds = new DataSet("emp");
                //아래 onj는 $ORACLE_HOME/network/admin에 있는 tnsnames.ora 파일에 정의된 이름!
                //64비트
string conStr = "Provider=OraOLEDB.Oracle;data source=topcredu;" +
                    "User ID = scott; Password = tiger";
conn = new OleDbConnection(conStr);
                conn.Open();
                adapter = new OleDbDataAdapter("select * from emp", conn);
                adapter.Fill(ds, "EMP");
                dataGridView1.DataSource = ds.Tables["EMP"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "emp Table Loading Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
