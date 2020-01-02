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

namespace Market
{
    public partial class newwin : Form
    {
        public newwin()
        {
            InitializeComponent();
        }
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

            string iquery1 = "CREATE VIEW v2 AS SELECT sum(amount) as '" + "ta" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "'";
            execute(iquery1);
            string iquery2 = "CREATE VIEW v3 AS SELECT num,((sum(amount)*" + textBox2.Text + ")*(1-(" + textBox4.Text + "/100))) as '" + "tan" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "' group by num";
            execute(iquery2);
            //execute("update v3 set tan=tan*(1-" + textBox4.Text + "/100)");
            float n2 = Convert.ToInt32(textBox4.Text);
            n2 = n2 / 100;
            string temp = Convert.ToString(n2);
            string view3 = "CREATE VIEW v1 AS SELECT name,((amount*" + textBox2.Text + ")*(1-" + temp + ")) as '" + "taa" + "' FROM nclient where dt='" + dateTimePicker1.Text + "'" + "AND" + " market = '" + comboBox1.Text + "'" + "AND" + " num = '" + textBox1.Text + "'  ";
            execute(view3);
            string view5 = "CREATE VIEW V5 AS SELECT sum(taa) as tan FROM v1";
            execute(view5);
            string query1 = "select * from v2 ";


            con.Open();
            SqlCommand cmd12 = new SqlCommand(query1, con);
            cmd12.ExecuteNonQuery();
            DataTable dt12 = new DataTable();
            SqlDataAdapter sda12 = new SqlDataAdapter(cmd12);

            sda12.Fill(dt12);
            foreach (DataRow dr in dt12.Rows)
            {
                textBox5.Text = dr["ta"].ToString();

            }


            con.Close();

            /* string query3 = "select tan from v3 where num = '"+textBox1.Text+"'";
             execute(query3);
             con.Open();
             SqlDataAdapter sd = new SqlDataAdapter(query3, con);
             DataTable dt3 = new DataTable();
             sd.Fill(dt3);
             dataGridView3.DataSource = dt3;
             con.Close();
             */
            /* string query8 = "select tan from v3 where num = '"+textBox1.Text+"'";
             con.Open();
             SqlCommand cmd8 = new SqlCommand(query8, con);
             cmd8.ExecuteNonQuery();
             DataTable dt1 = new DataTable();
             SqlDataAdapter sd = new SqlDataAdapter(cmd8);
             string a;
             sda.Fill(dt1);
             foreach (DataRow dr in dt1.Rows)
             {
                 a = dr["tan"].ToString();
             }

             con.Close();
             */

            //string query6 = "select tan from v3 where num='" + textBox1.Text + "'";
            string query6 = "select * from v5 ";

            con.Open();
            SqlCommand cmd = new SqlCommand(query6, con);
            cmd.ExecuteNonQuery();
            DataTable dt6 = new DataTable();
            SqlDataAdapter sda6 = new SqlDataAdapter(cmd);

            sda6.Fill(dt6);
            foreach (DataRow dr in dt6.Rows)
            {
                textBox3.Text = dr["tan"].ToString();

            }
            /*float n = Convert.ToInt32(textBox3.Text);
            float m = Convert.ToInt32(textBox4.Text);
            n = n * (1 - m / 100);*/
            // textBox3.Text = Convert.ToString(n);


            con.Close();

            string iquery0 = "INSERT INTO nwin VALUES('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "')";
            execute(iquery0);

            string query = "SELECT * FROM v1";
            execute(query);
            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();

            string view = "drop view v2";
            execute(view);
            string view1 = "drop view v3";
            execute(view1);
            string view4 = "drop view v1";
            execute(view4);
            string view6 = "drop view V5";
            execute(view6);

            MessageBox.Show("complete");


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string iquery1 = "CREATE VIEW v2 AS SELECT sum(amount) as '" + "ta" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "'";
            execute(iquery1);
            string iquery2 = "CREATE VIEW v3 AS SELECT num,(sum(amount)*'" + textBox2.Text + "') as '" + "tan" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "' group by num";
            execute(iquery2);
            string view3 = "CREATE VIEW v1 AS SELECT name,(amount*'" + textBox2.Text + "') as '" + "taa" + "' FROM nclient where dt='" + dateTimePicker1.Text + "'" + "AND" + " market = '" + comboBox1.Text + "'" + "AND" + " num = '" + textBox1.Text + "'  ";
            execute(view3);
            string query1 = "select * from v2";


            string query = "SELECT * FROM v1";
            execute(query);
            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
            string view = "drop view v2";
            execute(view);
            string view1 = "drop view v3";
            execute(view1);
            string view4 = "drop view v1";
            execute(view4);

            MessageBox.Show("complete");


        }

        private void newwin_Load(object sender, EventArgs e)
        {
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v1' AND type = 'V') DROP VIEW v1");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v2' AND type = 'V') DROP VIEW v2");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v3' AND type = 'V') DROP VIEW v3");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v5' AND type = 'V') DROP VIEW v5");

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ForeColor = Color.Black;
        }
    }
}
