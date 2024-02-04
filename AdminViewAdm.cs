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
    public partial class AdminViewAdm : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        DataTable UserTable = new DataTable();
        SqlDataAdapter UserAdapter;
        public static string to;

        public AdminViewAdm()
        {
            InitializeComponent();
            timerDateandTime.Start();
        }

        private void LoadUserRecords()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "SELECT UniqueStaffID, Name, Contact, Email, Status FROM Admin";
            UserAdapter = new SqlDataAdapter(strCommandText, myConnect);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(UserAdapter);
            UserTable.Clear();
            UserAdapter.Fill(UserTable);

            if (UserTable.Rows.Count > 0)
            {
                grdStud.DataSource = UserTable;
            }


            grdStud.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
            grdStud.Columns["Contact"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
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

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
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

        private void lnklblChangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminChangePassword ChangePwd = new AdminChangePassword();
            this.Hide();
            ChangePwd.Show();
        }

        private void AdminViewAdm_Load(object sender, EventArgs e)
        {
            lblname.Text = Account.Email;
            LoadUserRecords();
        }

        private void grdStud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow row = grdStud.Rows[e.RowIndex];
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                myConnect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Admin where UniqueStaffID=@id and Status='Lock'", myConnect);
                cmd.Parameters.AddWithValue("id", row.Cells["UniqueStaffID"].Value);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (MessageBox.Show(string.Format("Do you want to update the account status of this admin ?", row.Cells["UniqueStaffID"].Value), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (SqlCommand cmd2 = new SqlCommand("UPDATE [Admin] SET Status = 'Unlock' where UniqueStaffID = @id and Status != 'Unlock'", myConnect))
                            {
                                cmd2.Parameters.AddWithValue("id", row.Cells["UniqueStaffID"].Value);
                                cmd2.ExecuteNonQuery();
                                string strCommandText = "SELECT * FROM Admin ";
                                strCommandText += " WHERE Email=@email";
                                SqlCommand cmd3 = new SqlCommand(strCommandText, myConnect);
                                cmd3.Parameters.AddWithValue("@email", row.Cells["Email"].Value);
                                myConnect.Close();
                                try
                                {
                                    myConnect.Open();
                                    SqlDataReader reader2 = cmd3.ExecuteReader();
                                    if (reader2.Read())
                                    {
                                        string from, pass, messageBody;
                                        MailMessage message = new MailMessage();
                                        to = row.Cells["Email"].Value.ToString();
                                        from = "secprj2022@gmail.com";
                                        pass = "fjzwgqyaubidzmgo";
                                        messageBody = "Your account has been unlocked ! Proceed to login now !";
                                        message.To.Add(to);
                                        message.From = new MailAddress(from);
                                        message.Body = messageBody;
                                        message.Subject = "Account Unlocked";
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                        smtp.EnableSsl = true;
                                        smtp.Port = 587;
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.Credentials = new NetworkCredential(from, pass);

                                        try
                                        {
                                            smtp.Send(message);
                                            MessageBox.Show("notifying email has been sent! ");
                                        }

                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                    
                                    else
                                    {
                                        MessageBox.Show("Email not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    reader2.Close();
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
                        }
                        LoadUserRecords();
                    }
                    else
                    {
                        MessageBox.Show("Account is not locked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                UserTable.Clear();
                if (tbSearch.Text != "")
                {
                    SqlConnection myConnect2 = new SqlConnection(strConnectionString);
                    string strCommandText2 = "SELECT UniqueStaffID, Name, Contact, Email, Status FROM Admin WHERE UniqueStaffID LIKE '%" + tbSearch.Text + "%' OR Name LIKE '%" + tbSearch.Text + "%'";
                    myConnect2.Open();
                    UserAdapter = new SqlDataAdapter(strCommandText2, myConnect2);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(UserAdapter);
                    UserAdapter.Fill(UserTable);

                    if (UserTable.Rows.Count > 0)
                        grdStud.DataSource = UserTable;

                    grdStud.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdStud.Columns["Contact"].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
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
