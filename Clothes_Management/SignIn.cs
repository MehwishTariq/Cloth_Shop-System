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
    public partial class SignIn : Form
    {
        connection con = new connection();       
        DataSet ds = new DataSet();
         public SignIn()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from UserId",con.Connect());
            adap.Fill(ds,"UserId");
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["UserId"].Rows.Count - 1;i++ )
            {
                if (textBox1.Text == ds.Tables["UserId"].Rows[i]["Username"].ToString())
                {
                    if (textBox2.Text == ds.Tables["UserId"].Rows[i]["Password"].ToString())
                    {
                        //Sell se = new Sell(textBox1.Text);
                        Selection s = new Selection(textBox1.Text);
                        s.Show();
                        this.Hide();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Correct Information!");
                        break;
                    }
                }
            }          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
