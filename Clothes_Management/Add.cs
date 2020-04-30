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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        connection con = new connection();
        DataSet ds = new DataSet();
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand("Insert into Clothes([Clothcode],[BrandID],[Gender],[Size],[Price],[Quantity],[Material]) values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text+"','" + textBox7.Text+"')",con.Connect());
            com.ExecuteNonQuery();           
            MessageBox.Show("One record has been added");
        }
       
        private void Add_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from Clothes", con.Connect());
            adap.Fill(ds, "Clothes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand("Delete from Clothes where Clothcode='" + textBox1.Text + "'", con.Connect());
            com.ExecuteNonQuery();
            MessageBox.Show("Record Deleted!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();
            OleDbDataAdapter adquan = new OleDbDataAdapter("Select Quantity from Clothes where Clothcode='" + textBox1.Text + "'", con.Connect());
            adquan.Fill(ds3, "Clothes");
            int quantity = Convert.ToInt32(ds3.Tables[0].Rows[0]["Quantity"].ToString());
            int qminus = Convert.ToInt32(textBox6.Text.ToString());
            quantity = quantity + qminus;
            OleDbCommand cmd = new OleDbCommand("Update Clothes set Quantity='"+quantity+ "' where Clothcode='" + textBox1.Text+"'",con.Connect());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Item Updated!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Selection s = new Selection("0");
            s.Show();
            this.Hide();
        }
    }
}
