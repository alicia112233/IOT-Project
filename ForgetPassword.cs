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
using System.Net;
using System.Net.Mail;


namespace IOTAssignment
{
    public partial class ForgetPassword : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        string randomCode;
        public static string to;

        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmLogin admLogin = new frmAdmLogin();
            admLogin.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomCode == tbVerCode.Text.ToString())
            {
                to = tbEmail.Text;
                ResettingPassword rp = new ResettingPassword();
                this.Hide();
                rp.Show();
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Please fill in your email address !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEmail.Focus();
            }
            else if (tbVerCode.Text == "")
            {
                MessageBox.Show("Verification code not entered !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Wrong Code, Try Again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbVerCode.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            Account.Email = tbEmail.Text.ToString();
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT * FROM Admin ";
            strCommandText += " WHERE Email=@email";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@email", Account.Email);

            try
            {
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string from, pass, messageBody;
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = Account.Email;
                    from = "secprj2022@gmail.com";
                    pass = "fjzwgqyaubidzmgo";
                    messageBody = "Your reset code is " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Password Reset Code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);

                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Code Send Successfully ! ");
                        button3.Enabled = false;
                        tbEmail.Enabled = false;
                        tbVerCode.Enabled = true;
                        tbVerCode.Focus();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (tbEmail.Text == "")
                {
                    MessageBox.Show("Please fill in your email address !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbEmail.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Email not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                myConnect.Close();
            }
        }

        private void tbVerCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals("."))
                e.Handled = true;
        }
    }
}
