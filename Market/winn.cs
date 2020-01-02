using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.IO;
using System.Data.SqlClient;
namespace Market
{
    public partial class winn : Form
    {
        public winn()
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
            
            string iquery1 = "CREATE VIEW v2 AS SELECT sum(amount) as '" + "ta" + "' FROM client where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "'";
           execute(iquery1);
            string iquery2 = "CREATE VIEW v3 AS SELECT num,((sum(amount)*" + textBox2.Text + ")*(1-("+textBox4.Text+"/100))) as '" + "tan" + "' FROM client where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "' group by num";
            execute(iquery2);
            //execute("update v3 set tan=tan*(1-" + textBox4.Text + "/100)");
            float n2 = Convert.ToInt32(textBox4.Text);
            n2 = n2 / 100;
            string temp = Convert.ToString(n2);
            string view3 = "CREATE VIEW v1 AS SELECT name,((amount*"+textBox2.Text+")*(1-"+temp+")) as '"+"taa"+"' FROM client where dt='" + dateTimePicker1.Text + "'" + "AND" + " market = '" + comboBox1.Text + "'" + "AND" + " num = '" + textBox1.Text + "'  ";
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

            string iquery0 = "INSERT INTO win VALUES('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','"+textBox3.Text+"')";
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

        private void button2_Click(object sender, EventArgs e)
        {
          //  if (textBox1.Text == "128" || textBox1.Text == "129" || textBox1.Text == "120" || textBox1.Text == "130" || textBox1.Text == "140" || textBox1.Text == "790" || textBox1.Text == "124" || textBox1.Text == "125" || textBox1.Text == "126" || textBox1.Text == "127" ||
             //   textBox1.Text == "137" || textBox1.Text == "138" || textBox1.Text == "139" || textBox1.Text == "149" || textBox1.Text == "159" || textBox1.Text == "367" || textBox1.Text == "160" || textBox1.Text == "134" || textBox1.Text == "135" || textBox1.Text == "136" ||
               // textBox1.Text == "146" || textBox1.Text == "147" || textBox1.Text == "148" || textBox1.Text == "158" || textBox1.Text == "168" || textBox1.Text == "457" || textBox1.Text == "179" || textBox1.Text == "170" || textBox1.Text == "180" || textBox1.Text == "190" ||
            //textBox1.Text == "236" || textBox1.Text == "156" || textBox1.Text == "157" || textBox1.Text == "167" || textBox1.Text == "230" || textBox1.Text == "358" || textBox1.Text == "250" || textBox1.Text == "189" || textBox1.Text == "234" || textBox1.Text == "235" ||
              //  textBox1.Text == "245" || textBox1.Text == "237" || textBox1.Text == "238" || textBox1.Text == "239" || textBox1.Text == "249" || textBox1.Text == "349" || textBox1.Text == "269" || textBox1.Text == "260" || textBox1.Text == "270" || textBox1.Text == "280" ||
              //  textBox1.Text == "290" || textBox1.Text == "246" || textBox1.Text == "247" || textBox1.Text == "248" || textBox1.Text == "258" || textBox1.Text == "268" || textBox1.Text == "278" || textBox1.Text == "279" || textBox1.Text == "289" || textBox1.Text == "279" ||
              //  textBox1.Text == "380" || textBox1.Text == "345" || textBox1.Text == "256" || textBox1.Text == "257" || textBox1.Text == "267" || textBox1.Text == "259" || textBox1.Text == "340" || textBox1.Text == "350" || textBox1.Text == "360" || textBox1.Text == "370" ||
              //  textBox1.Text == "470" || textBox1.Text == "390" || textBox1.Text == "346" || textBox1.Text == "347" || textBox1.Text == "348" || textBox1.Text == "240" || textBox1.Text == "359" || textBox1.Text == "369" || textBox1.Text == "379" || textBox1.Text == "479" ||
               // textBox1.Text == "489" || textBox1.Text == "480" || textBox1.Text == "490" || textBox1.Text == "356" || textBox1.Text == "357" || textBox1.Text == "178" || textBox1.Text == "368" || textBox1.Text == "378" || textBox1.Text == "450" || textBox1.Text == "460" ||
              //  textBox1.Text == "560" || textBox1.Text == "570" || textBox1.Text == "580" || textBox1.Text == "590" || textBox1.Text == "456" || textBox1.Text == "169" || textBox1.Text == "458" || textBox1.Text == "459" || textBox1.Text == "469" || textBox1.Text == "569" ||
               // textBox1.Text == "678" || textBox1.Text == "679" || textBox1.Text == "670" || textBox1.Text == "680" || textBox1.Text == "690" || textBox1.Text == "150" || textBox1.Text == "467" || textBox1.Text == "567" || textBox1.Text == "478" || textBox1.Text == "578" ||
              //  textBox1.Text == "579" || textBox1.Text == "589" || textBox1.Text == "689" || textBox1.Text == "789" || textBox1.Text == "780" || textBox1.Text == "123" || textBox1.Text == "890" || textBox1.Text == "468" || textBox1.Text == "568" || textBox1.Text == "389")
            {
                // string iquery3 = "update nclient set amount = amount*150 where num = '"+textBox1.Text+"'";
                // execute(iquery3);
                string iquery1 = "CREATE VIEW v2 AS SELECT sum(amount) as '" + "ta" + "' FROM nclient where dt = '" + dateTimePicker1.Text + "' " + "AND" + " market = '" + comboBox1.Text + "'";
                execute(iquery1);
                string query1 = "select * from v2 ";
                con.Open();
                SqlCommand cmd12 = new SqlCommand(query1, con);
                cmd12.ExecuteNonQuery();
                DataTable dt12 = new DataTable();
                SqlDataAdapter sda12 = new SqlDataAdapter(cmd12);

                sda12.Fill(dt12);
                foreach (DataRow dr in dt12.Rows)
                {
                    textBox5.Text = dr["tan"].ToString();

                }


                con.Close();
                string view = "CREATE VIEW v1 AS SELECT name,amount FROM nclient where dt='"+dateTimePicker1.Text+ "'"+ "AND"+" market = '"+comboBox1.Text+ "'" + "AND" + " num = '" + textBox1.Text + "'  ";
                execute(view);
                string query = "SELECT * FROM v1";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                 string view1 = "drop view v1";
                 execute(view1);
                string view2 = "drop view v2";
                execute(view2);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void winn_Load(object sender, EventArgs e)
        {
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v1' AND type = 'V') DROP VIEW v1");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v2' AND type = 'V') DROP VIEW v2");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v3' AND type = 'V') DROP VIEW v3");
            execute("IF EXISTS (SELECT * FROM sys.views WHERE name = 'v5' AND type = 'V') DROP VIEW v5");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
