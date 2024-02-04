using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace IOTAssignment
{
    class Account
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        static int attempts = 3;

        //UserName
        public static string strUserName;
        public static string Email
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
            }
        }

        //Password
        public static string strPassword;
        public static string Password
        {
            get
            {
                return strPassword;
            }
            set
            {
                strPassword = value;
            }
        }

        public bool EmailCheck(string email)
        {
            string strCommandText = "SELECT * FROM Admin WHERE Email=@email";
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@email", email);
            myConnect.Open();
            SqlDataReader emailCheck = cmd.ExecuteReader();
            if (emailCheck.Read())
            {
                return true;
            }
            else
            {
                myConnect.Close();
                return false;
            }
        }

        public bool PasswordCheck(string password)
        {
            string strCommandText = "SELECT * FROM Admin WHERE Password=@pwd";
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@pwd", password);
            myConnect.Open();
            SqlDataReader pwdCheck = cmd.ExecuteReader();
            if (pwdCheck.Read())
            {
                return false;
            }
            else
            {
                myConnect.Close();
                return true;
            }
        }

        public bool Authorize(string Admemail, string AdmPwd)
        {
            string strCmdText = "SELECT * FROM Admin WHERE Email=@email and Password=@pwd COLLATE SQL_Latin1_General_CP1_CS_AS and Status = 'Unlock'";
            SqlConnection myCon = new SqlConnection(strConnectionString);
            SqlCommand cmd2 = new SqlCommand(strCmdText, myCon);
            cmd2.Parameters.AddWithValue("@email", Admemail);
            cmd2.Parameters.AddWithValue("@pwd", AdmPwd);
            myCon.Open();
            SqlDataReader login = cmd2.ExecuteReader();
            try
            {
                if (attempts > 3)
                {
                    attempts = 3;
                }

                if (login.Read())
                {
                    return true;  
                }
                
                myCon.Close();
                return false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
