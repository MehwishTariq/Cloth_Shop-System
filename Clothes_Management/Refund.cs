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
    public partial class Refund : Form
    {
        public Refund()
        {
            InitializeComponent();
        }
        connection con = new connection();
        DataSet ds = new DataSet();
        DataSet d = new DataSet();
        private void Refund_Load(object sender, EventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter dp = new OleDbDataAdapter("Select Quantity from Clothes where Clothcode='" + textBox1.Text + "'", con.Connect());
            dp.Fill(d, "Clothes");
            int quantity = Convert.ToInt32(d.Tables[0].Rows[0]["Quantity"].ToString());
            int qplus = Convert.ToInt32(textBox2.Text.ToString());
            quantity = quantity + qplus;
            OleDbCommand cmd = new OleDbCommand("Update Clothes set Quantity='" + quantity + "' where Clothcode='" + textBox1.Text + "'", con.Connect());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Quantity added!");
            OleDbCommand com = new OleDbCommand("Insert into refund([Clothcode],[Quantity],[DateOfRefund],[ReceiptNo]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + DateTime.Now.ToShortDateString() + "','" + textBox4.Text+"')", con.Connect());
            com.ExecuteNonQuery();
            MessageBox.Show("Item has been refunded!");
                  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selection s = new Selection("0");
            s.Show();
            this.Hide();
        }
    }
}
