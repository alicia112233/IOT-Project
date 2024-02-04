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
    public partial class AdminAddStud : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;

        public AdminAddStud()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAdmNo.Text == "" || tbContact.Text == "" || tbRFID.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbRFID.Text == "6A003E82E036")
            {
                MessageBox.Show("RFID is invalid ! Please input a valid RFID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection(strConnectionString);
                String strCommandText = "SELECT * FROM User WHERE AdminNo=@admno OR UniqueRFID=@rfid";
                SqlCommand checking = new SqlCommand(strCommandText, con);
                checking.Parameters.AddWithValue("@admno", tbAdmNo.Text);
                checking.Parameters.AddWithValue("@rfid", tbRFID.Text);

                con.Open();
                SqlDataReader reader = checking.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Admin Number or RFID already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int result = 0;
                    SqlConnection myConnect = new SqlConnection(strConnectionString);
                    String strCommandText2 = "INSERT User (Name, AdminNo, Contact, UniqueRFID, Email)" + " VALUES (@NewName, @NewAdmNo, @NewContact, @NewRFID, @NewEmail)";
                    SqlCommand updateCmd = new SqlCommand(strCommandText2, myConnect);
                    updateCmd.Parameters.AddWithValue("@NewName", tbName.Text);
                    updateCmd.Parameters.AddWithValue("@NewAdmNo", tbAdmNo.Text);
                    updateCmd.Parameters.AddWithValue("@NewContact", tbContact.Text);
                    updateCmd.Parameters.AddWithValue("@NewRFID", tbRFID.Text);
                    updateCmd.Parameters.AddWithValue("@NewEmail", tbEmail.Text);

                    myConnect.Open();

                    result = updateCmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("New Student Record Added Successfully !");
                    }
                    else
                    {
                        MessageBox.Show("New Student Record Failed to Add, Try Again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    myConnect.Close();
                    Close();
                }
                con.Close();
            }
        }

        private void tbContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminAttendance attendance = new AdminAttendance();
            attendance.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMain main = new AdminMain();
            main.Show();
            this.Hide();
        }

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSearchStud getstud = new AdminSearchStud();
            getstud.Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbAdmNo.Text = "";
            tbRFID.Text = "";
            tbContact.Text = "";
            tbEmail.Text = "";
        }
    }
}
