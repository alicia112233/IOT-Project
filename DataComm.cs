using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace IOTAssignment
{
    public partial class frmDataComms : Form
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["AssignmentDBConnection"].ConnectionString;
        DataComms dataComms;

        public delegate void myprocessDataDelegate(String strData);

        //To save sensor data to DB, you need to change to suite your project needs
        

        private void saveSensorDataToDB (string strTime, string strSensorValue, string strStatus)
        {
            //Step 1: Create Connection
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            //Step 2: Create Command
            String strCommandText = "INSERT MySensor (TimeOccurred, SensorValue, SensorStatus)" + "VALUES (@time, @value, @status)";

            SqlCommand updateCmd = new SqlCommand(strCommandText, myConnect);

            updateCmd.Parameters.AddWithValue("@time", strTime);
            updateCmd.Parameters.AddWithValue("@value", strSensorValue);
            updateCmd.Parameters.AddWithValue("@status", strStatus);

            //Step 3: Open Connection
            myConnect.Open();

            //Step 4: ExecuteCommand
            int result = updateCmd.ExecuteNonQuery();

            //Step 5: Close Connection
            myConnect.Close();
        }

        


        //utility method, you should not need to edit this
        private string extractStringValue(string strData, string ID)
        {
            string result = strData.Substring(strData.IndexOf(ID) + ID.Length);
            return result;
        }

        //utility method, you should not need to edit this
        private float extractFloatValue(string strData, string ID)
        {
            return (float.Parse(extractStringValue(strData, ID)));
        }

        //create your own data handler for your project needs
        private void handleRFIDSensorData(string strData, string strTime, string ID)
        {
            string strRFIDValue = extractStringValue(strData, ID);

            //update GUI component in any tabs
            tbRFIDValue.Text = strRFIDValue;
            tbRFID.Text = strRFIDValue;

            string fRFIDValue = extractStringValue(strData, ID);
            string status = "";
            if (fRFIDValue.Equals("6A003E631A2D"))
                status = "Valid";
            else if (fRFIDValue.Equals("6A003E3B325D"))
                status = "Valid";
            else if (fRFIDValue.Equals("6A003E653405"))
                status = "Valid";
            else if (fRFIDValue.Equals("6A003E82E036"))
                status = "Non-Valid";
            tbRFIDStatus.Text = status;

            saveSensorDataToDB(strTime, strRFIDValue, status);

        }



        private void handleDistanceSensorData(string strData, string strTime, string ID)
        {
            string strDistanceValue = extractStringValue(strData, ID);

            //update GUI component in any tabs
            tbDistanceValue.Text = strDistanceValue;
            tbDistance.Text = strDistanceValue;

            float fDistanceValue = extractFloatValue(strData, ID);
            string status = "";
            if (fDistanceValue < 60)
                status = "True";
            else
                status = "False";

            tbDistanceStatus.Text = status;

            saveSensorDataToDB(strTime, strDistanceValue, status);
        }

        //you need to edit here to suite your project needs
        private void extractSensorData(string strData, string strTime)
        {
            //Any type of data may be send over by hardware
            //so need to always check what data is received
            //before extracting the information

            //check whether RFID Value is send
            if (strData.IndexOf("RFID=") != -1)
                handleRFIDSensorData(strData, strTime, "RFID=");
            else if (strData.IndexOf("DISTANCE=") != -1) //check distance status
                handleDistanceSensorData(strData, strTime, "DISTANCE=");
        }

        //Raw data received from Hardware comes here
        public void handleSensorData(String strData)
        {
            string dt = DateTime.Now.ToString("s"); //get curent time
            extractSensorData(strData, dt); //get sensor values out

            //update raw data received to listbox
            string strMessage = dt + ":" + strData;
            lbDataComms.Items.Insert(0, strMessage);
        }

        //This method is automoatically called when data is received
        public void processDataReceive(String strData)
        {
            myprocessDataDelegate d = new myprocessDataDelegate(handleSensorData);
            lbDataComms.Invoke(d, new object[] { strData });
        }

        //This method is automatically called when data is received
        public void commsDataReceive(string dataReceived)
        {
            processDataReceive(dataReceived);
        }

        //This method is automatically called when there is error
        public void commsSendError(string errMsg)
        {
            MessageBox.Show(errMsg);
            processDataReceive(errMsg);
        }

        private void InitComms()
        {
            dataComms = new DataComms();
            dataComms.dataReceiveEvent += new DataComms.DataReceivedDelegate(commsDataReceive);
            dataComms.dataSendErrorEvent += new DataComms.DataSendErrorDelegate(commsSendError);
        }


        public frmDataComms()
        {
            InitializeComponent();
        }

        private void frmDataComms_Load(object sender, EventArgs e)
        {
            //InitComms();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbDataComms.Items.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdmLogin adminLogin = new frmAdmLogin();
            adminLogin.Show();
            this.Hide();
            
        }
    }
}
