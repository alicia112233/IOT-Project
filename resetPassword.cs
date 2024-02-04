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
    public partial class resetPassword : Form
    {
        string email = sendCode.to;
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        public resetPassword()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (tbNewpwd.Text == tbCfmpwd.Text)
            {
                SqlConnection con = new SqlConnection(strConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET [password] = '" + tbCfmpwd.Text + "' WHERE email='" + email + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reset successfully");
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
            else
            {
                MessageBox.Show("the new password do not match so enter same password");
            }
        }

        private void tbNewpwd_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
