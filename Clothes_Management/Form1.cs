using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Clothes_Management
{
    public partial class Form1 : Form
    {
        public int recptno;
        public Form1(int i)
        {
            InitializeComponent();
            recptno = i;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           

            connection con = new connection();
            DataSet d1 = new DataSet();
            string query = "Select * from Receipts where ReceiptNo=" + recptno;
            OleDbDataAdapter adap = new OleDbDataAdapter(query, con.Connect());         
            adap.Fill(d1,"Receipts");
            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDataSource(d1);
            this.crystalReportViewer1.ReportSource = cr1;
            this.crystalReportViewer1.Refresh();
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
