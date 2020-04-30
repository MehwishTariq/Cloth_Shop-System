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
    public partial class Exchange : Form
    {
        public Exchange()
        {
            InitializeComponent();
        }
        connection con = new connection();
        DataSet ds = new DataSet();
        DataSet d = new DataSet();
        private void Exchange_Load(object sender, EventArgs e)
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

            OleDbDataAdapter dps = new OleDbDataAdapter("Select Quantity from Clothes where Clothcode='" + textBox3.Text + "'", con.Connect());
            dps.Fill(d, "Clothes");
            int quantity1 = Convert.ToInt32(d.Tables[0].Rows[0]["Quantity"].ToString());
             quantity1 = quantity1 - qplus;
            if(quantity1<5)
            {
                MessageBox.Show("Stock running Out!");
            }
            OleDbCommand cmds = new OleDbCommand("Update Clothes set Quantity='" + quantity1 + "' where Clothcode='" + textBox3.Text + "'", con.Connect());
            cmds.ExecuteNonQuery();
            MessageBox.Show("Quantity added and subtracted!");


            OleDbCommand com = new OleDbCommand("Insert into Exchange([Clothcode],[ClothExchanged],[DateOfExchange],[ReceiptNo]) values('" + textBox1.Text + "','" + textBox3.Text +"','" + DateTime.Now.ToShortDateString() + "','" + textBox4.Text + "')", con.Connect());
            com.ExecuteNonQuery();
            MessageBox.Show("Item has been exchanged!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selection s = new Selection("0");
            s.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
