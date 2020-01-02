using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Market
{
    public partial class reslt : Form
    {
        public reslt()
        {
            InitializeComponent();
        }
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string dbname = "abc.mdf";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yc049\Documents\bajar2.mdf;Integrated Security=True;Connect Timeout=30");
        public void execute(String iquery)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(iquery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //  MessageBox.Show("error");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ery1 = "CREATE VIEW v2 AS SELECT sum(amount) as '" + "ta" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "'";
            execute(ery1);


            string query6 = "select * from v2";
            con.Open();
            SqlCommand cmd = new SqlCommand(query6, con);
            cmd.ExecuteNonQuery();
            DataTable dt6 = new DataTable();
            SqlDataAdapter sda6 = new SqlDataAdapter(cmd);

            sda6.Fill(dt6);
            foreach (DataRow dr in dt6.Rows)
            {
                textBox1.Text = dr["ta"].ToString();
            }

            con.Close();

            string ery2 = "CREATE VIEW v5 AS SELECT sum(amount) as '" + "ta" + "' FROM win where date = '" + dateTimePicker1.Text + "'";
            execute(ery2);


            string query10 = "select * from v5";
            con.Open();
            SqlCommand cmd10 = new SqlCommand(query10, con);
            cmd10.ExecuteNonQuery();
            DataTable dt10 = new DataTable();
            SqlDataAdapter sda10 = new SqlDataAdapter(cmd10);

            sda10.Fill(dt10);
            foreach (DataRow dr in dt10.Rows)
            {
                textBox2.Text = dr["ta"].ToString();
            }

            con.Close();

            Int32 v1 = Convert.ToInt32(textBox1.Text);
            Int32 v2 = Convert.ToInt32(textBox2.Text);
            Int32 v3 = v1 - v2;
            textBox3.Text = v3.ToString();
            if(v3>0)
            {
                label1.Text = "PROFIT !!";
                label1.ForeColor = System.Drawing.Color.Green;
            
            }
            else
            {
                label1.Text = "LOSS !!";
                label1.ForeColor = System.Drawing.Color.Red;
            }
            string view1 = "drop view v5";
            execute(view1);
            string view2 = "drop view v2";
            execute(view2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reslt_Load(object sender, EventArgs e)
        {
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v1' AND type = 'V') DROP VIEW v1");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v2' AND type = 'V') DROP VIEW v2");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v3' AND type = 'V') DROP VIEW v3");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v5' AND type = 'V') DROP VIEW v5");

        }
    }
}
