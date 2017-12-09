namespace EquipMaintSys1
{
    partial class Login_Screen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblLoginTitle = new System.Windows.Forms.Label();
            this.lbl_User = new System.Windows.Forms.Label();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Tbx_User = new System.Windows.Forms.TextBox();
            this.Tbx_Password = new System.Windows.Forms.TextBox();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Lbl_LoginTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblLoginTitle
            // 
            this.LblLoginTitle.AutoSize = true;
            this.LblLoginTitle.Location = new System.Drawing.Point(66, 57);
            this.LblLoginTitle.Name = "LblLoginTitle";
            this.LblLoginTitle.Size = new System.Drawing.Size(147, 13);
            this.LblLoginTitle.TabIndex = 0;
            this.LblLoginTitle.Text = "Please enter your login details";
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Location = new System.Drawing.Point(47, 92);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(60, 13);
            this.lbl_User.TabIndex = 1;
            this.lbl_User.Text = "User Name";
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Location = new System.Drawing.Point(47, 113);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.Lbl_Password.TabIndex = 3;
            this.Lbl_Password.Text = "Password";
            // 
            // Tbx_User
            // 
            this.Tbx_User.Location = new System.Drawing.Point(126, 85);
            this.Tbx_User.Name = "Tbx_User";
            this.Tbx_User.Size = new System.Drawing.Size(100, 20);
            this.Tbx_User.TabIndex = 2;
            // 
            // Tbx_Password
            // 
            this.Tbx_Password.Location = new System.Drawing.Point(126, 110);
            this.Tbx_Password.Name = "Tbx_Password";
            this.Tbx_Password.Size = new System.Drawing.Size(100, 20);
            this.Tbx_Password.TabIndex = 4;
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(50, 141);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(176, 23);
            this.Btn_Login.TabIndex = 5;
            this.Btn_Login.Text = "Login";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(50, 170);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(176, 23);
            this.Btn_Cancel.TabIndex = 6;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Lbl_LoginTitle
            // 
            this.Lbl_LoginTitle.AutoSize = true;
            this.Lbl_LoginTitle.Location = new System.Drawing.Point(15, 10);
            this.Lbl_LoginTitle.Name = "Lbl_LoginTitle";
            this.Lbl_LoginTitle.Size = new System.Drawing.Size(62, 13);
            this.Lbl_LoginTitle.TabIndex = 7;
            this.Lbl_LoginTitle.Text = "EMSystems";
            // 
            // Login_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lbl_LoginTitle);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.Tbx_Password);
            this.Controls.Add(this.Tbx_User);
            this.Controls.Add(this.Lbl_Password);
            this.Controls.Add(this.lbl_User);
            this.Controls.Add(this.LblLoginTitle);
            this.Name = "Login_Screen";
            this.Size = new System.Drawing.Size(281, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblLoginTitle;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.TextBox Tbx_User;
        private System.Windows.Forms.TextBox Tbx_Password;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label Lbl_LoginTitle;
    }
}
