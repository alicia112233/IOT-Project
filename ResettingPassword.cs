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
    public partial class ResettingPassword : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        string email = ForgetPassword.to;

        private static Regex PasswordValidation()
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return new Regex(pattern);
        }

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

        static Regex vaildate_password = PasswordValidation();

        public ResettingPassword()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (tbPwd.Text == "" || tbCfmPwd.Text == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string hashtbPwd = Encrypt(tbPwd.Text);

                    if (tbPwd.Text == tbCfmPwd.Text)
                    {
                        SqlConnection con = new SqlConnection(strConnectionString);
                        SqlCommand cmd = new SqlCommand("UPDATE Admin SET [Password] = '" + hashtbPwd + "', [Status] = 'Unlock' WHERE Email='" + email + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Password reset successfully ! Please proceed to login.");
                        frmAdmLogin login = new frmAdmLogin();
                        this.Hide();
                        login.Show();
                    }
                    else if (vaildate_password.IsMatch(tbPwd.Text) != true)
                    {
                        MessageBox.Show("Password must be 8 or more characters, with a mixture of upper and lower case letters, numbers and special characters !", "Invalid Password Requirement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbPwd.Focus();
                        return;
                    }
                    else if (tbPwd.Text != tbCfmPwd.Text)
                    {
                        MessageBox.Show("Both passwords do not match ! Please check again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbCfmPwd.Focus();
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResettingPassword_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbPwd.UseSystemPasswordChar = false;
                tbCfmPwd.UseSystemPasswordChar = false;
            }
            else
            {
                tbPwd.UseSystemPasswordChar = true;
                tbCfmPwd.UseSystemPasswordChar = true;
            }
        }
    }
}
