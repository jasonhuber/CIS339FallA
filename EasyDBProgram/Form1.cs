using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyDBProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //connection, command, dataset
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = @"Data Source=AZ54123YZ\SQLEXPRESS;Initial Catalog=JoshSnyder;Trusted_Connection=True;";
            
            conn.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.CommandText = "select SID, Name, Email from student";
            comm.Connection = conn;

            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.DataSet DS = new DataSet();
            DA.SelectCommand = comm;
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
            
           
        }
    }
}