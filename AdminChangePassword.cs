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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace IOTAssignment
{
    public partial class AdminChangePassword : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        string email = Account.Email;

        private static Regex PasswordValidation()
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return new Regex(pattern);
        }

        static Regex vaildate_password = PasswordValidation();

        static string Encrypt(string value)
        {
            //Using MD5 to encrypt a string
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //Hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public AdminChangePassword()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string hashtbNewpwd = Encrypt(tbNewPwd.Text);
                string hashtbCurrentpwd = Encrypt(tbCurrentPwd.Text);

                if (tbCurrentPwd.Text == "" || tbNewPwd.Text == "" || tbCfmPwd.Text == "")
                {
                    MessageBox.Show("Empty Fields Detected ! Please fill up all the fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (vaildate_password.IsMatch(tbNewPwd.Text) != true)
                {
                    MessageBox.Show("Password must be 8 or more characters, with a mixture of upper and lower case letters, numbers and special characters !", "Invalid Password Requirement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbNewPwd.Focus();
                    return;
                }
                else if (tbNewPwd.Text != tbCfmPwd.Text)
                {
                    MessageBox.Show("Both passwords do not match ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbCfmPwd.Focus();
                    return;
                }
                else if (tbCurrentPwd.Text == tbNewPwd.Text)
                {
                    MessageBox.Show("Current password cannot be the same as New password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(strConnectionString);
                    if (hashtbCurrentpwd == Account.Password)
                    {
                       
                        SqlCommand cmd2 = new SqlCommand("UPDATE Admin SET [Password] = '" + hashtbNewpwd + "' WHERE Email='" + email + "' AND Password='" + Account.Password + "'", con);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Password updated successfully !");
                        AdminMain login = new AdminMain();
                        this.Hide();
                        login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect current password ! Please try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMain admRead = new AdminMain();
            admRead.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbCurrentPwd.UseSystemPasswordChar = false;
                tbNewPwd.UseSystemPasswordChar = false;
                tbCfmPwd.UseSystemPasswordChar = false;
            }
            else
            {
                tbCurrentPwd.UseSystemPasswordChar = true;
                tbNewPwd.UseSystemPasswordChar = true;
                tbCfmPwd.UseSystemPasswordChar = true;
            }
        }
    }
}
