namespace AC1999Launcher
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblName;
        private Label lblHost;
        private Label lblPort;
        private Label lblGamePath;

        private TextBox txtName;
        private TextBox txtHost;
        private TextBox txtPort;
        private TextBox txtGamePath;

        private Button btnBrowse;
        private CheckBox chkDatabase;

        private Button btnSave;
        private Button btnCancel;

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
            lblName = new Label();
            lblHost = new Label();
            lblPort = new Label();
            lblGamePath = new Label();

            txtName = new TextBox();
            txtHost = new TextBox();
            txtPort = new TextBox();
            txtGamePath = new TextBox();

            btnBrowse = new Button();
            chkDatabase = new CheckBox();

            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(25, 25);
            lblName.Text = "Profile Name:";

            // 
            // txtName
            // 
            txtName.Location = new Point(130, 22);
            txtName.Size = new Size(300, 27);

            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(25, 70);
            lblHost.Text = "Host:";

            // 
            // txtHost
            // 
            txtHost.Location = new Point(130, 67);
            txtHost.Size = new Size(400, 27);

            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(25, 115);
            lblPort.Text = "Port:";

            // 
            // txtPort
            // 
            txtPort.Location = new Point(130, 112);
            txtPort.Size = new Size(100, 27);

            // 
            // lblGamePath
            // 
            lblGamePath.AutoSize = true;
            lblGamePath.Location = new Point(25, 160);
            lblGamePath.Text = "Game Path:";

            // 
            // txtGamePath
            // 
            txtGamePath.Location = new Point(130, 157);
            txtGamePath.Size = new Size(400, 27);

            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(540, 154);
            btnBrowse.Size = new Size(75, 32);
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;

            // 
            // chkDatabase
            // 
            chkDatabase.AutoSize = true;
            chkDatabase.Location = new Point(130, 205);
            chkDatabase.Text = "Use -db";
            chkDatabase.Checked = true;
            chkDatabase.CheckState = CheckState.Checked;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(435, 250);
            btnSave.Size = new Size(85, 35);
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(530, 250);
            btnCancel.Size = new Size(85, 35);
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(640, 315);

            Controls.Add(lblName);
            Controls.Add(txtName);

            Controls.Add(lblHost);
            Controls.Add(txtHost);

            Controls.Add(lblPort);
            Controls.Add(txtPort);

            Controls.Add(lblGamePath);
            Controls.Add(txtGamePath);

            Controls.Add(btnBrowse);
            Controls.Add(chkDatabase);

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AC1999 Server Profile";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}