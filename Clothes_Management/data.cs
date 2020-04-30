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
    public partial class data : Form
    {
        public int recptno;
        public data(int j)
        {
            InitializeComponent();
            recptno = j;
        }
        private void data_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            connection db = new connection();
            string query = "Select * from SoldItem where ReceiptNo=" + recptno;
            OleDbDataAdapter ad = new OleDbDataAdapter(query, db.Connect());
            ad.Fill(ds, "SoldItem");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selection s = new Selection("0");
            s.Show();
            this.Hide();
        }
    }
}
