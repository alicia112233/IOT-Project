using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTAssignment
{
    public partial class UserChangePassword : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        public UserChangePassword()
        {
            InitializeComponent();
        }

        private void changePassword_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudAttendance sa = new StudAttendance();
            sa.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCfmpwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (tbNewpwd.Text == tbCfmpwd.Text)
            {
                SqlConnection myConnect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\prj\IOTAssignment\IOTAssignment\AssignmentDB.mdf; Integrated Security = True; Connect Timeout = 30");
                myConnect.Open();
                SqlCommand cmd = new SqlCommand(" update [User] set Password='" + tbNewpwd.Text + "' where Email='" + tbEmail.Text + "'", myConnect);
                cmd.ExecuteNonQuery();
                myConnect.Close();
                MessageBox.Show("Password changed.");
                this.Hide();
                frmLogin fl = new frmLogin();
                fl.Show();
            }
            else
            {
                MessageBox.Show("The new password do not match so enter same password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\prj\IOTAssignment\IOTAssignment\AssignmentDB.mdf; Integrated Security = True; Connect Timeout = 30");
            myConnect.Open();
            SqlCommand cmd = new SqlCommand(" select * from [User] WHERE Password=@pwd AND Email='" + tbEmail.Text + "'", myConnect);
            cmd.Parameters.AddWithValue("@pwd", tbPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                MessageBox.Show("Success");
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Not Matched. Pleae try again!");
            }
            reader.Close();
            myConnect.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
