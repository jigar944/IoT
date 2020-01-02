using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nclientEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void nclientEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            entry f2 = new entry();
            f2.ShowDialog();
        }

        private void amountSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            amnt f3 = new amnt();
            f3.ShowDialog();
        }

        private void winnerEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            winn f4 = new winn();
            f4.ShowDialog();
        }

        private void viewWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reslt f5 = new reslt();
            f5.ShowDialog();
        }

        private void partyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adprty f5 = new adprty();
            f5.ShowDialog();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.E)
            {
                entry f2 = new entry();
                f2.ShowDialog();
            }
            if (e.Control == true && e.KeyCode == Keys.W)
            {
                winn f4 = new winn();
                f4.ShowDialog();
            }
            if (e.Control == true && e.KeyCode == Keys.A)
            {
                adprty f5 = new adprty();
                f5.ShowDialog();
            }

        }

        private void nclientEntry2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newentry f2 = new newentry();
            f2.ShowDialog();
        }

        private void winEntry2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newwin f = new Market.newwin();
            f.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            amnt f3 = new amnt();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newentry f2 = new newentry();
            f2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            winn f4 = new winn();
            f4.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             entry f2 = new entry();
            f2.ShowDialog();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adprty f5 = new adprty();
            f5.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reslt f5 = new reslt();
            f5.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            newwin f = new Market.newwin();
            f.ShowDialog();

        }





        //page2
        //page2






    }
}
