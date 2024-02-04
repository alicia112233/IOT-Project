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
    public partial class AdminAttendance : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;

        DataTable UserTable = new DataTable();
        SqlDataAdapter UserAdapter;

        private void LoadUserRecords()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT Name, AdminNo, UniqueRFID, Status FROM [User]";
            UserAdapter = new SqlDataAdapter(strCommandText, myConnect);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(UserAdapter);
            UserTable.Clear();
            UserAdapter.Fill(UserTable);

            if (UserTable.Rows.Count > 0)
            {
                grdAllRecords.DataSource = UserTable;
            }
        }

        private void clearStatus()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            myConnect.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET Status = 'Absent'", myConnect);
            cmd.ExecuteNonQuery();
        }

        private void studentStatus()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            myConnect.Open();
            SqlCommand cmd = new SqlCommand("SELECT TimeOccurred, SensorValue, SensorStatus FROM MySensor WHERE SensorStatus = 'True' and CONVERT(DATE, MySensor.TimeOccurred) = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", myConnect);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    using (SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET Status = 'Present' FROM [User] INNER JOIN MySensor ON [User].UniqueRFID = MySensor.SensorValue WHERE CONVERT(DATE, MySensor.TimeOccurred) = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", myConnect))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlCommand cmd3 = new SqlCommand("UPDATE [User] SET Status = 'Absent' FROM [User] INNER JOIN MySensor ON [User].UniqueRFID = MySensor.SensorValue WHERE (SensorStatus = 'True' or SensorStatus = 'Valid') and CONVERT(DATE, MySensor.TimeOccurred) = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'", myConnect))
                    {
                        cmd3.ExecuteNonQuery();
                    } // command disposed here
                }
            } // reader closed and disposed up here

            LoadUserRecords();
            myConnect.Close();
        }

        public AdminAttendance()
        {
            InitializeComponent();
            timerDateandTime.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clearStatus();
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Monday)
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommandText = "SELECT * FROM Admin WHERE Module = 'IT2661' and Email=@email";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@email", Account.Email);
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    studentStatus();
                    LoadUserRecords();
                }

                else
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserTable.Clear();
                }

                reader.Close();
                myConnect.Close();
            }

            else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Tuesday)
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommandText = "SELECT * FROM Admin WHERE Module = 'IT2662' and Email=@email";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@email", Account.Email);
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    studentStatus();
                    LoadUserRecords();
                }

                else
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserTable.Clear();
                }

                reader.Close();
                myConnect.Close();
            }

            else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Wednesday)
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommandText = "SELECT * FROM Admin WHERE Module = 'IT2663' and Email=@email";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@email", Account.Email);
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    studentStatus();
                    LoadUserRecords();
                }
                else
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserTable.Clear();
                }

                reader.Close();
                myConnect.Close();
            }

            else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Thursday)
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommandText = "SELECT * FROM Admin WHERE Module = 'IT2664' and Email=@email";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@email", Account.Email);
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    studentStatus();
                    LoadUserRecords();
                }

                else
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserTable.Clear();
                }

                reader.Close();
                myConnect.Close();
            }

            else if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
            {
                SqlConnection myConnect3 = new SqlConnection(strConnectionString);
                string strCommandText3 = "SELECT * FROM Admin WHERE Module = 'IT2665' and Email=@email";
                SqlCommand cmd3 = new SqlCommand(strCommandText3, myConnect3);
                cmd3.Parameters.AddWithValue("@email", Account.Email);
                myConnect3.Open();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    studentStatus();
                    LoadUserRecords();
                }
                else
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserTable.Clear();
                }

                reader3.Close();
                myConnect3.Close();
            }

            else
            {
                MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserTable.Clear();
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            LoadUserRecords();
            UserTable.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMain admMain = new AdminMain();
            admMain.Show();
            this.Hide();
        }

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminAddStud addStud = new AdminAddStud();
            addStud.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSearchStud getstud = new AdminSearchStud();
            getstud.Show();
            this.Hide();
        }
    }
}
