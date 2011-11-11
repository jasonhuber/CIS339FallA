using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDBProgram
{
    class Student
    {
        //sid, name, email
        private string _sid;
        private string _name;
        private string _email;

        public string SID { 
            
            get{
                return _sid;
            }
            
             set
             {
                 string sval = value;
                 if (!sval.ToUpper().StartsWith("D"))
                 {
                     throw new Exception("Sorry the SID must start with D");
                 }
                 else if (sval.Length != 10)
                 {
                     throw new Exception("Sorry the SID must contain 9 characters and start with D");
                 }
                 else
                 {
                     _sid = value;
                 }
             }
        
        }

        public string name { get { return _name; } set { _name = value; } }
        public string email { get { return _email; } set { _email = value; } }

        public void getbyid(string sid)
        {
            //connection, command, dataset
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = @"Data Source=AZ54123YZ\SQLEXPRESS;Initial Catalog=JoshSnyder;Trusted_Connection=True;";

            conn.Open();

            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.CommandText = "select SID, Name, Email from student where SID  = @sid";
            comm.Parameters.AddWithValue("@sid", sid);
            comm.Connection = conn;

            System.Data.SqlClient.SqlDataReader dr;
            
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                this.SID = dr["SID"].ToString();
                this.name= dr["name"].ToString();
                this.email = dr["email"].ToString();
            }

        }

    }
}
