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
    public partial class amnt : Form
    {
        public amnt()
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
            public void button1_Click(object sender, EventArgs e)
            {
                string view = "CREATE VIEW v1 AS SELECT name,num,sum(amount) as '" + "ta" + "' FROM client where dt between '" + dateTimePicker1.Text + "' " + "AND" + " '" + dateTimePicker2.Text + "' " + "AND" + " market ='" + comboBox1.Text + "' GROUP BY num,name";
                execute(view);
 
                 con.Open();
            //string view = "CREATE VIEW v1 AS SELECT num,sum(amount) as '"+"ta"+"' FROM t3 where dt='"+dateTimePicker2.Text+"' GROUP BY num";
            // execute(view);
            string query = "SELECT num,ta FROM v1 where name='" + comboBox2.Text + "' order by ta desc";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                string view1 = "drop view v1";
                execute(view1);

        }

        private void amnt_Load(object sender, EventArgs e)
        {
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v1' AND type = 'V') DROP VIEW v1");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v2' AND type = 'V') DROP VIEW v2");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v3' AND type = 'V') DROP VIEW v3");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v5' AND type = 'V') DROP VIEW v5");
            try
            {
                comboBox2.Items.Clear();
                string query1 = "select * from party";
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["name"].ToString());
                }

                con.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
