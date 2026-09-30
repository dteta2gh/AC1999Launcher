namespace AC1999Launcher
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblProfile;
        private ComboBox cboProfile;

        private GroupBox grpServer;
        private Label lblHost;
        private Label lblPort;
        private Label lblGamePath;

        private TextBox txtHost;
        private TextBox txtPort;
        private TextBox txtGamePath;

        private Button btnBrowse;
        private Button btnNewProfile;
        private Button btnEditProfile;
        private Button btnDeleteProfile;

        private GroupBox grpAccount;
        private Label lblUsername;
        private Label lblPassword;

        private TextBox txtUsername;
        private TextBox txtPassword;

        private CheckBox chkDatabase;

        private Button btnLaunch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblProfile = new Label();
            cboProfile = new ComboBox();

            grpServer = new GroupBox();

            lblHost = new Label();
            lblPort = new Label();
            lblGamePath = new Label();

            txtHost = new TextBox();
            txtPort = new TextBox();
            txtGamePath = new TextBox();

            btnBrowse = new Button();
            btnNewProfile = new Button();
            btnEditProfile = new Button();
            btnDeleteProfile = new Button();

            grpAccount = new GroupBox();

            lblUsername = new Label();
            lblPassword = new Label();

            txtUsername = new TextBox();
            txtPassword = new TextBox();

            chkDatabase = new CheckBox();

            btnLaunch = new Button();

            grpServer.SuspendLayout();
            grpAccount.SuspendLayout();
            SuspendLayout();

            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Location = new Point(20, 20);
            lblProfile.Text = "Server Profile:";

            // 
            // cboProfile
            // 
            cboProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProfile.FormattingEnabled = true;
            cboProfile.Location = new Point(120, 16);
            cboProfile.Size = new Size(360, 28);
            cboProfile.SelectedIndexChanged +=
                cboProfile_SelectedIndexChanged;

            // 
            // grpServer
            // 
            grpServer.Controls.Add(btnDeleteProfile);
            grpServer.Controls.Add(btnEditProfile);
            grpServer.Controls.Add(btnNewProfile);
            grpServer.Controls.Add(btnBrowse);

            grpServer.Controls.Add(txtGamePath);
            grpServer.Controls.Add(txtPort);
            grpServer.Controls.Add(txtHost);

            grpServer.Controls.Add(lblGamePath);
            grpServer.Controls.Add(lblPort);
            grpServer.Controls.Add(lblHost);

            grpServer.Location = new Point(20, 60);
            grpServer.Size = new Size(610, 190);
            grpServer.Text = "Server";

            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(20, 35);
            lblHost.Text = "Host:";

            // 
            // txtHost
            // 
            txtHost.Location = new Point(120, 32);
            txtHost.Size = new Size(440, 27);

            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(20, 75);
            lblPort.Text = "Port:";

            // 
            // txtPort
            // 
            txtPort.Location = new Point(120, 72);
            txtPort.Size = new Size(100, 27);

            // 
            // lblGamePath
            // 
            lblGamePath.AutoSize = true;
            lblGamePath.Location = new Point(20, 115);
            lblGamePath.Text = "Game Path:";

            // 
            // txtGamePath
            // 
            txtGamePath.Location = new Point(120, 112);
            txtGamePath.Size = new Size(360, 27);

            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(490, 110);
            btnBrowse.Size = new Size(70, 32);
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;

            // 
            // btnNewProfile
            // 
            btnNewProfile.Location = new Point(20, 150);
            btnNewProfile.Size = new Size(105, 30);
            btnNewProfile.Text = "New Profile";
            btnNewProfile.UseVisualStyleBackColor = true;
            btnNewProfile.Click += btnNewProfile_Click;

            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(135, 150);
            btnEditProfile.Size = new Size(105, 30);
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;

            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Location = new Point(250, 150);
            btnDeleteProfile.Size = new Size(105, 30);
            btnDeleteProfile.Text = "Delete";
            btnDeleteProfile.UseVisualStyleBackColor = true;
            btnDeleteProfile.Click += btnDeleteProfile_Click;

            // 
            // grpAccount
            // 
            grpAccount.Controls.Add(chkDatabase);
            grpAccount.Controls.Add(txtPassword);
            grpAccount.Controls.Add(txtUsername);
            grpAccount.Controls.Add(lblPassword);
            grpAccount.Controls.Add(lblUsername);

            grpAccount.Location = new Point(20, 265);
            grpAccount.Size = new Size(610, 115);
            grpAccount.Text = "Account";

            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(20, 35);
            lblUsername.Text = "Username:";

            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 32);
            txtUsername.Size = new Size(250, 27);

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 72);
            lblPassword.Text = "Password:";

            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 69);
            txtPassword.Size = new Size(250, 27);
            txtPassword.UseSystemPasswordChar = true;

            // 
            // chkDatabase
            // 
            chkDatabase.AutoSize = true;
            chkDatabase.Location = new Point(410, 50);
            chkDatabase.Text = "Use -db";
            chkDatabase.Checked = true;
            chkDatabase.CheckState = CheckState.Checked;

            // 
            // btnLaunch
            // 
            btnLaunch.Location = new Point(490, 395);
            btnLaunch.Size = new Size(140, 40);
            btnLaunch.Text = "LAUNCH";
            btnLaunch.UseVisualStyleBackColor = true;
            btnLaunch.Click += btnLaunch_Click;

            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(650, 455);

            Controls.Add(btnLaunch);
            Controls.Add(grpAccount);
            Controls.Add(grpServer);
            Controls.Add(cboProfile);
            Controls.Add(lblProfile);

            StartPosition = FormStartPosition.CenterScreen;
            Text = "AC1999 Launcher";

            grpServer.ResumeLayout(false);
            grpServer.PerformLayout();

            grpAccount.ResumeLayout(false);
            grpAccount.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}