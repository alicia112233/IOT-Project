namespace IOTAssignment
{
    partial class resetPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.lnewPassword = new System.Windows.Forms.Label();
            this.lcfmPassword = new System.Windows.Forms.Label();
            this.tbNewpwd = new System.Windows.Forms.TextBox();
            this.tbCfmpwd = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset Password";
            // 
            // lnewPassword
            // 
            this.lnewPassword.AutoSize = true;
            this.lnewPassword.Location = new System.Drawing.Point(200, 160);
            this.lnewPassword.Name = "lnewPassword";
            this.lnewPassword.Size = new System.Drawing.Size(104, 17);
            this.lnewPassword.TabIndex = 1;
            this.lnewPassword.Text = "New Password:";
            // 
            // lcfmPassword
            // 
            this.lcfmPassword.AutoSize = true;
            this.lcfmPassword.Location = new System.Drawing.Point(179, 218);
            this.lcfmPassword.Name = "lcfmPassword";
            this.lcfmPassword.Size = new System.Drawing.Size(125, 17);
            this.lcfmPassword.TabIndex = 2;
            this.lcfmPassword.Text = "Confirm Password:";
            // 
            // tbNewpwd
            // 
            this.tbNewpwd.Location = new System.Drawing.Point(309, 158);
            this.tbNewpwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNewpwd.Name = "tbNewpwd";
            this.tbNewpwd.Size = new System.Drawing.Size(177, 22);
            this.tbNewpwd.TabIndex = 3;
            this.tbNewpwd.TextChanged += new System.EventHandler(this.tbNewpwd_TextChanged);
            // 
            // tbCfmpwd
            // 
            this.tbCfmpwd.Location = new System.Drawing.Point(309, 218);
            this.tbCfmpwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCfmpwd.Name = "tbCfmpwd";
            this.tbCfmpwd.Size = new System.Drawing.Size(177, 22);
            this.tbCfmpwd.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(309, 277);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(177, 22);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 0;
            // 
            // resetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 446);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tbCfmpwd);
            this.Controls.Add(this.tbNewpwd);
            this.Controls.Add(this.lcfmPassword);
            this.Controls.Add(this.lnewPassword);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "resetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "resetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lnewPassword;
        private System.Windows.Forms.Label lcfmPassword;
        private System.Windows.Forms.TextBox tbNewpwd;
        private System.Windows.Forms.TextBox tbCfmpwd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}