namespace IOTAssignment
{
    partial class frmDataComms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlForm = new System.Windows.Forms.TabControl();
            this.tpRpiComms = new System.Windows.Forms.TabPage();
            this.lbDataComms = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbDistanceValue = new System.Windows.Forms.TextBox();
            this.tbRFIDValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpFunctions = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbDistanceStatus = new System.Windows.Forms.TextBox();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.tbRFIDStatus = new System.Windows.Forms.TextBox();
            this.tbRFID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlForm.SuspendLayout();
            this.tpRpiComms.SuspendLayout();
            this.tpFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlForm
            // 
            this.tabControlForm.Controls.Add(this.tpRpiComms);
            this.tabControlForm.Controls.Add(this.tpFunctions);
            this.tabControlForm.Location = new System.Drawing.Point(25, 26);
            this.tabControlForm.Name = "tabControlForm";
            this.tabControlForm.SelectedIndex = 0;
            this.tabControlForm.Size = new System.Drawing.Size(610, 384);
            this.tabControlForm.TabIndex = 0;
            // 
            // tpRpiComms
            // 
            this.tpRpiComms.Controls.Add(this.lbDataComms);
            this.tpRpiComms.Controls.Add(this.btnClear);
            this.tpRpiComms.Controls.Add(this.tbDistanceValue);
            this.tpRpiComms.Controls.Add(this.tbRFIDValue);
            this.tpRpiComms.Controls.Add(this.label2);
            this.tpRpiComms.Controls.Add(this.label1);
            this.tpRpiComms.Location = new System.Drawing.Point(4, 25);
            this.tpRpiComms.Name = "tpRpiComms";
            this.tpRpiComms.Padding = new System.Windows.Forms.Padding(3);
            this.tpRpiComms.Size = new System.Drawing.Size(602, 355);
            this.tpRpiComms.TabIndex = 0;
            this.tpRpiComms.Text = "Comms";
            this.tpRpiComms.UseVisualStyleBackColor = true;
            // 
            // lbDataComms
            // 
            this.lbDataComms.FormattingEnabled = true;
            this.lbDataComms.ItemHeight = 16;
            this.lbDataComms.Location = new System.Drawing.Point(28, 124);
            this.lbDataComms.Name = "lbDataComms";
            this.lbDataComms.Size = new System.Drawing.Size(548, 196);
            this.lbDataComms.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(410, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(166, 71);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbDistanceValue
            // 
            this.tbDistanceValue.Location = new System.Drawing.Point(139, 71);
            this.tbDistanceValue.Name = "tbDistanceValue";
            this.tbDistanceValue.ReadOnly = true;
            this.tbDistanceValue.Size = new System.Drawing.Size(250, 22);
            this.tbDistanceValue.TabIndex = 3;
            // 
            // tbRFIDValue
            // 
            this.tbRFIDValue.Location = new System.Drawing.Point(139, 24);
            this.tbRFIDValue.Name = "tbRFIDValue";
            this.tbRFIDValue.ReadOnly = true;
            this.tbRFIDValue.Size = new System.Drawing.Size(250, 22);
            this.tbRFIDValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "DistanceValue:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID Value:";
            // 
            // tpFunctions
            // 
            this.tpFunctions.Controls.Add(this.linkLabel1);
            this.tpFunctions.Controls.Add(this.tbDistanceStatus);
            this.tpFunctions.Controls.Add(this.tbDistance);
            this.tpFunctions.Controls.Add(this.tbRFIDStatus);
            this.tpFunctions.Controls.Add(this.tbRFID);
            this.tpFunctions.Controls.Add(this.label3);
            this.tpFunctions.Controls.Add(this.label6);
            this.tpFunctions.Controls.Add(this.label5);
            this.tpFunctions.Controls.Add(this.label4);
            this.tpFunctions.Location = new System.Drawing.Point(4, 25);
            this.tpFunctions.Name = "tpFunctions";
            this.tpFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tpFunctions.Size = new System.Drawing.Size(602, 355);
            this.tpFunctions.TabIndex = 1;
            this.tpFunctions.Text = "Functions";
            this.tpFunctions.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(372, 306);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 18);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Proceed to Admin Login";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tbDistanceStatus
            // 
            this.tbDistanceStatus.Location = new System.Drawing.Point(418, 102);
            this.tbDistanceStatus.Name = "tbDistanceStatus";
            this.tbDistanceStatus.ReadOnly = true;
            this.tbDistanceStatus.Size = new System.Drawing.Size(157, 22);
            this.tbDistanceStatus.TabIndex = 8;
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(102, 99);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.ReadOnly = true;
            this.tbDistance.Size = new System.Drawing.Size(179, 22);
            this.tbDistance.TabIndex = 7;
            // 
            // tbRFIDStatus
            // 
            this.tbRFIDStatus.Location = new System.Drawing.Point(394, 30);
            this.tbRFIDStatus.Name = "tbRFIDStatus";
            this.tbRFIDStatus.ReadOnly = true;
            this.tbRFIDStatus.Size = new System.Drawing.Size(181, 22);
            this.tbRFIDStatus.TabIndex = 6;
            // 
            // tbRFID
            // 
            this.tbRFID.Location = new System.Drawing.Point(80, 30);
            this.tbRFID.Name = "tbRFID";
            this.tbRFID.ReadOnly = true;
            this.tbRFID.Size = new System.Drawing.Size(201, 22);
            this.tbRFID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "RFID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Distance Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Distance:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "RFID Status:";
            // 
            // frmDataComms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 439);
            this.Controls.Add(this.tabControlForm);
            this.Name = "frmDataComms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDataComms";
            this.Load += new System.EventHandler(this.frmDataComms_Load);
            this.tabControlForm.ResumeLayout(false);
            this.tpRpiComms.ResumeLayout(false);
            this.tpRpiComms.PerformLayout();
            this.tpFunctions.ResumeLayout(false);
            this.tpFunctions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlForm;
        private System.Windows.Forms.TabPage tpRpiComms;
        private System.Windows.Forms.ListBox lbDataComms;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbDistanceValue;
        private System.Windows.Forms.TextBox tbRFIDValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpFunctions;
        private System.Windows.Forms.TextBox tbDistanceStatus;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.TextBox tbRFIDStatus;
        private System.Windows.Forms.TextBox tbRFID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}