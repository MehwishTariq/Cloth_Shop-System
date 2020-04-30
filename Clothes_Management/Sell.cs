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
    public partial class Sell : Form
    {
        private string email="";
        public Sell(string e)
        {
            InitializeComponent();
            email = e;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {            
        }
        connection db = new connection();       
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        public int recptno;
        private void Sell_Load(object sender, EventArgs e)
        {            
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from Clothes as c,Brands as b where c.BrandID=b.BrandID", db.Connect());
            adap.Fill(ds,"Clothes");
            OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from Receipts", db.Connect());
            ad1.Fill(ds2, "Receipts");
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * from SoldItem", db.Connect());
            ad.Fill(ds1, "SoldItems");
          int j = ds2.Tables["Receipts"].Rows.Count;
          j++;
           OleDbCommand com = new OleDbCommand("Insert into Receipts([ReceiptNo],[Date],[Username]) values('" + j + "','" + DateTime.Now.ToShortDateString() + "','"+email+"')", db.Connect());
           com.ExecuteNonQuery();
        }
        private void button1_Click(object sender, EventArgs e)                              
        {           
            for (int i = 0; i < ds.Tables["Clothes"].Rows.Count - 1;)
            {
                if (textBox1.Text == ds.Tables["Clothes"].Rows[i]["Clothcode"].ToString())
                {
                    textBox3.Text = ds.Tables["Clothes"].Rows[i]["Price"].ToString();
                    textBox4.Text = ds.Tables["Clothes"].Rows[i]["Size"].ToString();
                    textBox5.Text = ds.Tables["Clothes"].Rows[i]["Gender"].ToString();
                    textBox6.Text = ds.Tables["Clothes"].Rows[i]["BrandName"].ToString();
                    break;
                }
                else
                i++;
            }
            int a = Convert.ToInt32(textBox2.Text);
            textBox7.Text=Convert.ToString(Convert.ToInt32(textBox3.Text)*a);
        }        
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            recptno = ds2.Tables["Receipts"].Rows.Count;
            recptno++;
            DataSet ds1 = new DataSet();
            OleDbDataAdapter dps = new OleDbDataAdapter("Select Quantity from Clothes where Clothcode='" + textBox1.Text + "'", db.Connect());
            dps.Fill(ds1, "Clothes");
            int quantity1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"].ToString());
            int qplus = Convert.ToInt32(textBox2.Text.ToString());
            if (quantity1 >0)
            {
                quantity1 = quantity1 - qplus;
                OleDbCommand cmds = new OleDbCommand("Update Clothes set Quantity='" + quantity1 + "' where Clothcode='" + textBox1.Text + "'", db.Connect());
                cmds.ExecuteNonQuery();
                OleDbCommand com1 = new OleDbCommand("Insert into SoldItem([Clothcode],[Quantity],[ReceiptNo],[Price]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + recptno + "','" + textBox7.Text + "')", db.Connect());
                com1.ExecuteNonQuery();
                //string query = "Select Price from SoldItem where ReceiptNo=" + recptno;
                //OleDbDataAdapter ad = new OleDbDataAdapter(query, db.Connect());
                //ad.Fill(ds3);
                MessageBox.Show("Item Entered!");
            }           
           else
            {
                MessageBox.Show("Stock Finished!");
            }
           
        }
        public int price=0;
        
        private void button2_Click(object sender, EventArgs e)
        {
            DataSet d4 = new DataSet();
            string query = "Select Price from SoldItem where ReceiptNo=" + recptno;
            OleDbDataAdapter ads = new OleDbDataAdapter(query, db.Connect());
            ads.Fill(d4);
            for (int i = 0; i < d4.Tables[0].Rows.Count;i++)
            {
                price += Convert.ToInt32(d4.Tables[0].Rows[i]["Price"].ToString());
            }
            string qq=" Update Receipts set TotalPrice ='"+price+"' where ReceiptNo="+ recptno;
            OleDbCommand com3 = new OleDbCommand(qq, db.Connect());
            com3.ExecuteNonQuery();
            MessageBox.Show("Total Price is:" + price.ToString());
            Form1 s = new Form1(recptno);
            s.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = ""; ;
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
    }
}

