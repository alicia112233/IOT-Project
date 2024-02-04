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
    public partial class AdminMain : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;

        public AdminMain()
        {
            InitializeComponent();
            timerDateandTime.Start();
        }

        private void lnklblLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                timerDateandTime.Stop();
                this.Hide();
                frmAdmLogin admLogin = new frmAdmLogin();
                admLogin.Show();
            }
        }

        private void lnklblChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminChangePassword ChangePwd = new AdminChangePassword();
            this.Hide();
            ChangePwd.Show();
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            lblname.Text = Account.Email;
            Count();
        }

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminAttendance attendance = new AdminAttendance();
            attendance.Show();
            this.Hide();
        }

        public void Count()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT COUNT(*) FROM Admin";
            string strCommandText2 = "SELECT COUNT(*) FROM [User]";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            SqlCommand cmd2 = new SqlCommand(strCommandText2, myConnect);
            myConnect.Open();
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());
            if (count > 0)
            {
                lblTotalAdm.Text = count.ToString();
                lblTotalStud.Text = count2.ToString();
            }
            else
            {
                lblTotalStud.Text = "0";
                lblTotalAdm.Text = "0";
            }
            myConnect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSearchStud getstud = new AdminSearchStud();
            getstud.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminAddStud addstud = new AdminAddStud();
            addstud.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminViewStud viewStud = new AdminViewStud();
            viewStud.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AdminViewAdm viewAdm = new AdminViewAdm();
            viewAdm.Show();
            this.Hide();
        }
    }
}
