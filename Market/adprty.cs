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
    public partial class adprty : Form
    {
        entry en1;
        public adprty()
        {
            InitializeComponent();
            en1 = new entry();
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
            /* en1.Visible = true;
             en1.comboBox2.Items.Add("jigar");
             MessageBox.Show("added");
             */
            try
            {
                string iquery0 = "INSERT INTO party VALUES('" + textBox1.Text + "')";
                execute(iquery0);
                MessageBox.Show("Added Succesfully !");
          }
            catch
            {
                MessageBox.Show("Party is Already Exist !!!!");
            }
        }

        private void adprty_Load(object sender, EventArgs e)
        {

        }
    }
}
