using System.Xml.Linq;

namespace AC1999Launcher
{
    public partial class ProfileForm : Form
    {
        public AC1999Profile Profile { get; private set; }

        public ProfileForm()
        {
            InitializeComponent();

            Profile = new AC1999Profile();
        }

        public ProfileForm(AC1999Profile profile)
        {
            InitializeComponent();

            Profile = profile;

            txtName.Text = profile.Name;
            txtHost.Text = profile.Host;
            txtPort.Text = profile.Port;
            txtGamePath.Text = profile.GamePath;
            chkDatabase.Checked = profile.UseDatabase;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();

            dialog.Title = "Select AC1999 Client";
            dialog.Filter =
                "Executable files (*.exe)|*.exe|All files (*.*)|*.*";

            dialog.FileName = "client.exe";

            if (!string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                string? directory =
                    Path.GetDirectoryName(txtGamePath.Text);

                if (!string.IsNullOrWhiteSpace(directory) &&
                    Directory.Exists(directory))
                {
                    dialog.InitialDirectory = directory;
                }
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtGamePath.Text = dialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter a profile name.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                MessageBox.Show(
                    "Please enter the server host.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show(
                    "Please enter the server port.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                MessageBox.Show(
                    "Please select the AC1999 client.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Profile.Name = txtName.Text.Trim();
            Profile.Host = txtHost.Text.Trim();
            Profile.Port = txtPort.Text.Trim();
            Profile.GamePath = txtGamePath.Text.Trim();
            Profile.UseDatabase = chkDatabase.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}