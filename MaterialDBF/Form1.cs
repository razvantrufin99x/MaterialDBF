using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace MaterialDBF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void connectToDB()
        {

            //connect 1
            SqlCeConnection co = new SqlCeConnection();

            //conect 2
            co.ConnectionString = "Data Source=dbMaterialDBF.sdf;";

            //open
            co.Open();

            //add new data
            string insertString = "Insert INTO materialeTabel(cod,denumire,cantitate,unit_mas,valoare,ultim_misc,cond_spec,informatii) values ('1','nisip','100','kg','2','01012021','f','nisip de rau pentru constructii')";
           
            //string insertString = "";
            
            // insertString = "Insert INTO materialeTabel (cod) values ('8')";
            // insertString = "Insert INTO materialeTabel (denumire) values ('30')";
            // insertString = "Insert INTO materialeTabel (cantitate) values ('10')";
            // insertString = "Insert INTO materialeTabel (unit_mas) values ('3')";
            // insertString = "Insert INTO materialeTabel (valoare) values ('10')";
            // insertString = "Insert INTO materialeTabel (ultim_misc) values ('8')";
            // insertString = "Insert INTO materialeTabel (cond_spec) values ('1')";
            // insertString = "Insert INTO materialeTabel (informatii) values ('200')";

            SqlCeCommand insert = new SqlCeCommand(insertString, co);
            insert.ExecuteNonQuery();

            //read datata and write
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM materialeTabel", co);
            SqlCeDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine("{0} - {1}", reader.GetString(0),reader.GetString(1));
                textBox1.Text += "\r\n";
                textBox1.Text += reader.GetValue(0).ToString() + " : " + reader.GetValue(1).ToString();
                textBox1.Text += reader.GetValue(2).ToString() + " : " + reader.GetValue(3).ToString();
                textBox1.Text += reader.GetValue(4).ToString() + " : " + reader.GetValue(5).ToString();
                textBox1.Text += reader.GetValue(6).ToString() + " : " + reader.GetValue(7).ToString();
             
            }
            //get nr of records

            textBox1.Text += " \r\n" + GetNumberOfRecords(ref co).ToString();

            //close
            reader.Close();
        
        }

        public int GetNumberOfRecords(ref SqlCeConnection  _co)
        {
            int count = -1;
            try
            {
                //co.Open();
                SqlCeCommand countall = new SqlCeCommand("select count(*) from materialeTabel", _co);
                count = (int)countall.ExecuteScalar();
            }
            finally
            {
                //if (co!= null){co.Close();}
            }
            return count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectToDB();
        }
    }
}
