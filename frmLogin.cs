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
using System.Configuration;

namespace IOTAssignment
{
    public partial class frmLogin : Form
    {
        public int logAttempt = 0;
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT Email, Password FROM [User]";
            strCommandText += " WHERE Email=@email AND Password=@pwd";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@email", tbEmail.Text);
            cmd.Parameters.AddWithValue("@pwd", tbPassword.Text);
            try
            {
                //step3: oepn connction & retrieve data 
                myConnect.Open();
                //step4: access data
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login Successful");
                    StudAttendance Attendance = new StudAttendance();
                    Attendance.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                    Reset();
                    tbEmail.Focus();
                    logAttempt += 1;
                    if (logAttempt == 3)
                    {
                        MessageBox.Show("You have exceeded the max number of login attempts", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        tbEmail.Enabled = false;
                        tbPassword.Enabled = false;
                    }
                    this.Show();
                    StudAttendance Attendance = new StudAttendance();
                    Attendance.Hide();
                }

                //step5: close connection
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
            finally
            {
                //step5: close connection
                myConnect.Close();
            }
        }

        public void Reset()
        {
            tbEmail.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }

        private void llforgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            sendCode sc = new sendCode();
            sc.Show();
        }

        private void llShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llShow.Text == "Show")
            {
                tbPassword.UseSystemPasswordChar = false;
                llShow.Text = "Hide";
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                llShow.Text = "Show";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdmLogin adminLogin = new frmAdmLogin();
            adminLogin.Show();
            this.Hide();
        }
    }
}
