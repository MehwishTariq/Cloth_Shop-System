using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Clothes_Management
{
    public partial class Selection : Form
    {
        public string email="";
        public Selection(string e)
        {
            InitializeComponent();
            email = e;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            Sell sell = new Sell(email);
            sell.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Add a = new Add();
            a.Show();
            this.Hide();
        }

        private void Selection_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refund r = new Refund();
            r.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exchange ex = new Exchange();
            ex.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            si.Show();
            this.Hide();
        }
    }
}
