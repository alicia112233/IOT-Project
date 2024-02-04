namespace IOTAssignment
{
    partial class UserChangePassword
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
            this.btnReset = new System.Windows.Forms.Button();
            this.tbCfmpwd = new System.Windows.Forms.TextBox();
            this.tbNewpwd = new System.Windows.Forms.TextBox();
            this.lcfmPassword = new System.Windows.Forms.Label();
            this.lnewPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(158, 121);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(177, 22);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbCfmpwd
            // 
            this.tbCfmpwd.Location = new System.Drawing.Point(158, 73);
            this.tbCfmpwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCfmpwd.Name = "tbCfmpwd";
            this.tbCfmpwd.Size = new System.Drawing.Size(177, 22);
            this.tbCfmpwd.TabIndex = 10;
            this.tbCfmpwd.TextChanged += new System.EventHandler(this.tbCfmpwd_TextChanged);
            // 
            // tbNewpwd
            // 
            this.tbNewpwd.Location = new System.Drawing.Point(158, 25);
            this.tbNewpwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNewpwd.Name = "tbNewpwd";
            this.tbNewpwd.Size = new System.Drawing.Size(177, 22);
            this.tbNewpwd.TabIndex = 9;
            // 
            // lcfmPassword
            // 
            this.lcfmPassword.AutoSize = true;
            this.lcfmPassword.Location = new System.Drawing.Point(21, 73);
            this.lcfmPassword.Name = "lcfmPassword";
            this.lcfmPassword.Size = new System.Drawing.Size(125, 17);
            this.lcfmPassword.TabIndex = 8;
            this.lcfmPassword.Text = "Confirm Password:";
            // 
            // lnewPassword
            // 
            this.lnewPassword.AutoSize = true;
            this.lnewPassword.Location = new System.Drawing.Point(43, 27);
            this.lnewPassword.Name = "lnewPassword";
            this.lnewPassword.Size = new System.Drawing.Size(104, 17);
            this.lnewPassword.TabIndex = 7;
            this.lnewPassword.Text = "New Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Change Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(331, 150);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(177, 22);
            this.tbPassword.TabIndex = 13;
            this.tbPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Old Password:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(33, 26);
            this.backBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(67, 25);
            this.backBtn.TabIndex = 14;
            this.backBtn.Text = "< Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email:";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(331, 194);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(177, 22);
            this.btnVerify.TabIndex = 17;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbNewpwd);
            this.panel1.Controls.Add(this.lnewPassword);
            this.panel1.Controls.Add(this.lcfmPassword);
            this.panel1.Controls.Add(this.tbCfmpwd);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Location = new System.Drawing.Point(173, 221);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 188);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(331, 106);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(177, 22);
            this.tbEmail.TabIndex = 19;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 0;
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 446);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEmail);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "changePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "changePassword";
            this.Load += new System.EventHandler(this.changePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbCfmpwd;
        private System.Windows.Forms.TextBox tbNewpwd;
        private System.Windows.Forms.Label lcfmPassword;
        private System.Windows.Forms.Label lnewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}