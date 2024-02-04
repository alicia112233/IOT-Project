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
using System.Security.Cryptography;
using System.IO;

namespace IOTAssignment
{
    public partial class frmAdmLogin : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        public static string email;
        static int attempts = 3;

        public frmAdmLogin()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void lnklblForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgetPassword forgetPass = new ForgetPassword();
            forgetPass.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            Account.Email = tbEmail.Text.ToString();
            Account.Password = Encrypt(tbPassword.Text.ToString());
            if (Account.Email == "" || Account.Password == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (account.EmailCheck(Account.Email))
            {
                if (attempts > 3)
                {
                    attempts = 3;
                }
                if (account.PasswordCheck(Account.Password))
                {
                    string strCommandText = "SELECT * FROM Admin WHERE Email=@email and Status='Unlock'";
                    SqlConnection myConnect = new SqlConnection(strConnectionString);
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                    cmd.Parameters.AddWithValue("@email", Account.Email);
                    myConnect.Open();
                    SqlDataReader pwdCheck = cmd.ExecuteReader();
                    if (pwdCheck.Read())
                    {
                        attempts -= 1;
                        if (attempts > 0)
                        {
                            MessageBox.Show(Account.Password.ToString());
                            MessageBox.Show("Incorrect Email Address/Password ! " + attempts, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (attempts <= 0)
                        {
                            MessageBox.Show("Your Account has been locked ! Please reset your password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string strCommandtext = "UPDATE Admin SET Status='Lock' WHERE Email=@email2";
                            SqlConnection myConnect3 = new SqlConnection(strConnectionString);
                            SqlCommand cmd3 = new SqlCommand(strCommandtext, myConnect3);
                            cmd3.Parameters.AddWithValue("@email2", Account.Email);
                            myConnect3.Open();
                            cmd3.ExecuteNonQuery();
                            myConnect3.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Account has been locked ! Please reset your password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (account.Authorize(Account.Email, Account.Password))
                    {
                        string strCommandtext = "UPDATE Admin SET Password=@pwd WHERE Email=@email2";
                        SqlConnection myConnect3 = new SqlConnection(strConnectionString);
                        SqlCommand cmd3 = new SqlCommand(strCommandtext, myConnect3);
                        cmd3.Parameters.AddWithValue("@email2", Account.Email);
                        cmd3.Parameters.AddWithValue("@pwd", Account.Password);
                        myConnect3.Open();
                        cmd3.ExecuteNonQuery();
                        myConnect3.Close();
                        MessageBox.Show("Login Successful !");
                        this.Hide();
                        AdminMain read = new AdminMain();
                        read.Show();
                        attempts = 3;
                    }
                    else
                    {
                        MessageBox.Show("Your Account has been locked ! Please reset your password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strCommandtext = "UPDATE Admin SET Status='Lock' WHERE Email=@email2";
                        SqlConnection myConnect3 = new SqlConnection(strConnectionString);
                        SqlCommand cmd3 = new SqlCommand(strCommandtext, myConnect3);
                        cmd3.Parameters.AddWithValue("@email2", Account.Email);
                        myConnect3.Open();
                        cmd3.ExecuteNonQuery();
                        myConnect3.Close();
                    }
                }
            }

            // wrong email
            else
            {
                MessageBox.Show("Incorrect Email Address/Password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                attempts += 1;
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin userLogin = new frmLogin();
            userLogin.Show();
            this.Hide();
        }
    }
}
