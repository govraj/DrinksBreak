using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;



namespace DrinksBreak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            string message = "Please Take Drink Break?";
            string title = "Drinks Break Remainder";
            MessageBox.Show(message, title);
           
            listBox1.Items.Add("Drinks Break at "+DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString());
            SqlConnection con = new SqlConnection("Data Source=ASUS-PC\\SQLEXPRESS;Initial Catalog=DrinkBreak;Integrated Security=sspi");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into DrinkBreakData (Date,Time) values('" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.ToLongTimeString() + "')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
