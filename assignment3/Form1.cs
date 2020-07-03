using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace assignment3
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }

        

       
        

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\visual basics practical\assignment3\assignment3\Database1.mdf;Integrated Security=True");
            string Name = textBox2.Text;
            string Username = textBox3.Text;
            string Password = textBox4.Text;
            string UserRole = comboBox1.SelectedItem.ToString();
            SqlDataAdapter adp = new SqlDataAdapter("select * from assignment", con);
            SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();
            adp.Fill(ds, "assignment");
            DataRow rw = ds.Tables[0].NewRow();

            rw[1] = Name;
            rw[2] = Username;
            rw[3] = Password;
            rw[4] = UserRole;


            ds.Tables[0].Rows.Add(rw);

            int i = adp.Update(ds.Tables[0]);
            if (i == 1)
                Console.Write(i + " New row added.");
            else
                Console.Write("Insertion Failed.");
        }

        public static void main(string[] args)
        {

            Application.Run(new Form1());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}  

    