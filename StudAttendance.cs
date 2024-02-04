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
    public partial class StudAttendance : Form
    {
        SqlConnection myConnect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\prj\IOTAssignment\IOTAssignment\AssignmentDB.mdf; Integrated Security = True; Connect Timeout = 30");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        private string sql;
        //private SqlConnection con;

        public StudAttendance()
        {
            InitializeComponent();
        }

        private void StudAttendance_Load(object sender, EventArgs e)
        {
            lbldateTime.Text = DateTime.Now.ToLongDateString();
            // TODO: This line of code loads data into the 'assignmentDBDataSet.MySensor' table. You can move, or remove it, as needed.
            this.mySensorTableAdapter.Fill(this.assignmentDBDataSet.MySensor);
            sql = "SELECT * FROM MySensor";
            retrieveData(sql, dataGridView1);
        }
        private void retrieveData(string sql, DataGridView dtg)
        {
            try
            {
                myConnect.Open();
 
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();
 
                cmd.Connection = myConnect;
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                da.Fill(dt);
 
                dtg.DataSource = dt;
 
 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnect.Close();
                da.Dispose();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbldateTime_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateToday = dateTimePicker.Value;

            string strDate = dateToday.ToString("yyyy-MM-dd");

            sql = "SELECT * FROM MySensor WHERE Date('TimeOccured)=" + strDate +"'";
            retrieveData(sql, dataGridView1);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void llchangePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UserChangePassword fl = new UserChangePassword();
            fl.Show();
        }
    }
}
