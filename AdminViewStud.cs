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
    public partial class AdminViewStud : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        DataTable UserTable = new DataTable();
        SqlDataAdapter UserAdapter;

        public AdminViewStud()
        {
            InitializeComponent();
            timerDateandTime.Start();
        }

        private void LoadUserRecords()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT Name, AdminNo, Contact, UniqueRFID, Email FROM [User]";
            UserAdapter = new SqlDataAdapter(strCommandText, myConnect);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(UserAdapter);
            UserTable.Clear();
            UserAdapter.Fill(UserTable);

            if (UserTable.Rows.Count > 0)
                grdStud.DataSource = UserTable;

            grdStud.Columns["AdminNo"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
            grdStud.Columns["Contact"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
            grdStud.Columns["UniqueRFID"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
            grdStud.Columns["Email"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
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
            AdminMain main = new AdminMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminAttendance attendance = new AdminAttendance();
            attendance.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminAddStud addStud = new AdminAddStud();
            addStud.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSearchStud search = new AdminSearchStud();
            search.Show();
            this.Hide();
        }

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
        }

        private void AdminViewStud_Load(object sender, EventArgs e)
        {
            lblname.Text = Account.Email;
            LoadUserRecords();
        }

        private void grdStud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UserTable.Clear();
                if (tbSearch.Text != "")
                {
                    SqlConnection myConnect2 = new SqlConnection(strConnectionString);
                    string strCommandText2 = "SELECT Name, AdminNo, Contact, UniqueRFID, Email FROM [User] WHERE AdminNo LIKE '%" + tbSearch.Text + "%' OR Name LIKE '%" + tbSearch.Text + "%'";
                    myConnect2.Open();
                    UserAdapter = new SqlDataAdapter(strCommandText2, myConnect2);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(UserAdapter);
                    UserAdapter.Fill(UserTable);

                    if (UserTable.Rows.Count > 0)
                        grdStud.DataSource = UserTable;

                    grdStud.Columns["AdminNo"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdStud.Columns["Contact"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdStud.Columns["UniqueRFID"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdStud.Columns["Email"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    myConnect2.Close();
                }
                else
                {
                    LoadUserRecords();
                }
                    
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
