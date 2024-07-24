using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectPeachtree.Controller;


namespace ConnectPeachtree
{
    public partial class Form1 : Form
    {
        DataSet1TableAdapters.CustomersTableAdapter tbl_customer = new DataSet1TableAdapters.CustomersTableAdapter();
        DataSet1TableAdapters.General_GLTableAdapter General_GL = new DataSet1TableAdapters.General_GLTableAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            //string query = "SELECT RecordNumber FROM CompanySession";
            //dataGridView1.DataSource = tbl_customer.GetData();

            string query = "select * from customers";
            dataGridView1.DataSource = OdbcData.Execute(query);
        }


    }
}
