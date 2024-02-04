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
    public partial class AdminSearchStud : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;

        DataTable transTable = new DataTable();
        DataGridViewRow currentRow = null;
        SqlDataAdapter adapter;

        public AdminSearchStud()
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

        private void timerDateandTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("F");
        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            bool blnfound = false;
            transTable.Clear();
            try
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                string strCommandText = "SELECT Name, UniqueRFID, Contact, Email FROM [User] ";
                strCommandText += "WHERE AdminNo=@AdmNo";
                SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
                cmd.Parameters.AddWithValue("@AdmNo", tbAdmNo.Text);

                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (tbAdmNo.Text == "")
                {
                    MessageBox.Show("Please enter Admin Number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbName.Text = "";
                    tbRFID.Text = "";
                    tbContact.Text = "";
                    tbEmail.Text = "";
                }
                else if (reader.Read())
                {
                    tbName.Text = reader["Name"].ToString();
                    tbRFID.Text = reader["UniqueRFID"].ToString();
                    tbContact.Text = reader["Contact"].ToString();
                    tbEmail.Text = reader["Email"].ToString();
                    blnfound = true;
                }
                else
                {
                    MessageBox.Show("Student Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbAdmNo.Text = "";
                    tbName.Text = "";
                    tbRFID.Text = "";
                    tbContact.Text = "";
                    tbEmail.Text = "";
                    tbAdmNo.Focus();
                }
                reader.Close();
                myConnect.Close();
                if (blnfound)
                {
                    RetrieveRecords();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RetrieveRecords()
        {
            try
            {
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                myConnect.Open();
                using (SqlCommand cmd2 = new SqlCommand("UPDATE [User] SET Status = 'Present' FROM [User] INNER JOIN MySensor on [User].UniqueRFID = MySensor.SensorValue WHERE [User].AdminNo = @AdmNo", myConnect))
                {
                    cmd2.Parameters.AddWithValue("@AdmNo", SqlDbType.VarChar).Value = tbAdmNo.Text;
                    cmd2.ExecuteNonQuery();
                }

                string strCommandText = "SELECT TimeOccurred as Time, [User].Name, [User].Status FROM MySensor INNER JOIN [User] ON MySensor.SensorValue=[User].UniqueRFID";
                //strCommandText += string.Format("Where [User].AdminNo = '{0}'", tbAdmNo.Text.Trim());
                strCommandText += " Where [User].AdminNo = @AdmNo";
                //string strCommandText2 = "SELECT DISTINCT([User].UniqueRFID) as RFID, TimeOccurred AS Time, [User].Name, Status FROM MySensor INNER JOIN[User] ON MySensor.SensorValue =[User].UniqueRFID ORDER BY Time DESC";

                adapter = new SqlDataAdapter(strCommandText, myConnect);
                adapter.SelectCommand.Parameters.AddWithValue("@AdmNo", tbAdmNo.Text);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                
                adapter.Fill(transTable);
                if (transTable.Rows.Count == 0)
                {
                    MessageBox.Show("No Records Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdUser.DataSource = transTable;
                    grdUser.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdUser.Columns[0].ReadOnly = true;
                    grdUser.Columns[1].ReadOnly = true;
                    grdUser.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);
                    grdUser.Columns[2].ReadOnly = true;
                }
    
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdUser_Click(object sender, EventArgs e)
        {
            currentRow = grdUser.CurrentRow;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbAdmNo.Text == "")
            {
                MessageBox.Show("Please enter Admin Number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbName.Text == "")
            {
                MessageBox.Show("Please Get Student first !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (modifyStudentDetails() > 0)
            {
                MessageBox.Show("Update Successful");
            }
            else
            {
                MessageBox.Show("Update Fail");
            }


            //if (tbAdmNo.Text == "")
            //{
            //    MessageBox.Show("Please enter Admin Number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (tbName.Text == "")
            //{
            //    MessageBox.Show("Please Get Student first !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    int modifiedRows = 0;
            //    DataTable UpdatedTable = transTable.GetChanges();
            //    if (UpdatedTable != null)
            //    {
            //        modifiedRows = adapter.Update(UpdatedTable);
            //        transTable.AcceptChanges();
            //    }
            //    else
            //    {
            //        MessageBox.Show("There are no changes to update.", "Error", MessageBoxButtons.OK);
            //    }
            //    if (modifiedRows > 0)
            //    {
            //        MessageBox.Show("There are " + modifiedRows + " records updated !");
            //    }
            //    RetrieveRecords();
            //}
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMain dash = new AdminMain();
            dash.Show();
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
            AdminAddStud addstud = new AdminAddStud();
            addstud.Show();
            this.Hide();
        }

        private int modifyStudentDetails()
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            string strCommandText = "UPDATE [User] SET UniqueRFID=@NewRFID, Contact=@NewContact, Email=@email WHERE AdminNo=@admno";
            SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);

            updateCmd.Parameters.AddWithValue("@admno", tbAdmNo.Text);
            updateCmd.Parameters.AddWithValue("@NewRFID", tbRFID.Text);
            updateCmd.Parameters.AddWithValue("@NewContact", tbContact.Text);
            updateCmd.Parameters.AddWithValue("@email", tbEmail.Text);

            myConnect.Open();

            int result = updateCmd.ExecuteNonQuery();

            myConnect.Close();
            return result;
        }

        private void tbContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !e.KeyChar.Equals("."))
                e.Handled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbAdmNo.Text == "")
            {
                MessageBox.Show("Please enter Admin Number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbName.Text == "")
            {
                MessageBox.Show("Please Get Student first !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this student?", "Deleting Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection myConnect = new SqlConnection(strConnectionString);
                    myConnect.Open();
                    string strCommandText = "DELETE FROM [User] WHERE AdminNo=@admno";
                    SqlCommand delCmd = new SqlCommand(strCommandText, myConnect);
                    delCmd.Parameters.AddWithValue("@admno", tbAdmNo.Text);
                    delCmd.ExecuteNonQuery();
                    myConnect.Close();
                    MessageBox.Show("Student Deleted Successfully !");
                    tbAdmNo.Text = "";
                    tbName.Text = "";
                    tbRFID.Text = "";
                    tbContact.Text = "";
                    tbEmail.Text = "";
                }
            }
        }
    }
}
