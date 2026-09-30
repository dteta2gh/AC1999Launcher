using System.Diagnostics;
using System.Text.Json;

namespace AC1999Launcher
{
    public partial class Main : Form
    {
        private readonly string profileFile =
            Path.Combine(Application.StartupPath, "profiles.json");

        private List<AC1999Profile> profiles = new();

        public Main()
        {
            InitializeComponent();

            this.Text = $"AC1999 Launcher - v{AppVersion.Version}";

            LoadProfiles();
        }

        public static class AppVersion
        {
            // v1.0.0 — Initial AC1999 Launcher release
            //           First public release.
            //           Supports server profiles, account login,
            //           AC1999 client launching, and -db option.

            public const string Version = "1.0.0";
        }

        // ------------------------------------------------------------
        // Profile Loading / Saving
        // ------------------------------------------------------------

        private void LoadProfiles()
        {
            try
            {
                if (File.Exists(profileFile))
                {
                    string json = File.ReadAllText(profileFile);

                    profiles =
                        JsonSerializer.Deserialize<List<AC1999Profile>>(json)
                        ?? new List<AC1999Profile>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load profiles.\n\n" + ex.Message,
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                profiles = new List<AC1999Profile>();
            }

            RefreshProfileList();

            if (cboProfile.Items.Count > 0)
            {
                cboProfile.SelectedIndex = 0;
            }
        }

        private void SaveProfiles()
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    WriteIndented = true
                };

                string json =
                    JsonSerializer.Serialize(profiles, options);

                File.WriteAllText(profileFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to save profiles.\n\n" + ex.Message,
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RefreshProfileList()
        {
            cboProfile.Items.Clear();

            foreach (AC1999Profile profile in profiles)
            {
                cboProfile.Items.Add(profile);
            }
        }

        private void cboProfile_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cboProfile.SelectedItem is AC1999Profile profile)
            {
                LoadProfileIntoFields(profile);
            }
        }

        private void LoadProfileIntoFields(AC1999Profile profile)
        {
            txtHost.Text = profile.Host;
            txtPort.Text = profile.Port;
            txtGamePath.Text = profile.GamePath;
            chkDatabase.Checked = profile.UseDatabase;
        }

        // ------------------------------------------------------------
        // Browse
        // ------------------------------------------------------------

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();

            dialog.Title = "Select AC1999 Client";
            dialog.Filter =
                "Executable files (*.exe)|*.exe|All files (*.*)|*.*";

            dialog.FileName = "client.exe";

            if (!string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                try
                {
                    string? directory =
                        Path.GetDirectoryName(txtGamePath.Text);

                    if (!string.IsNullOrWhiteSpace(directory) &&
                        Directory.Exists(directory))
                    {
                        dialog.InitialDirectory = directory;
                    }
                }
                catch
                {
                    // Ignore invalid path information.
                }
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtGamePath.Text = dialog.FileName;
            }
        }

        // ------------------------------------------------------------
        // New Profile
        // ------------------------------------------------------------

        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            using ProfileForm profileForm =
                new ProfileForm();

            if (profileForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            AC1999Profile profile = profileForm.Profile;

            profiles.Add(profile);

            SaveProfiles();

            RefreshProfileList();

            cboProfile.SelectedItem = profile;
        }

        // ------------------------------------------------------------
        // Edit Profile
        // ------------------------------------------------------------

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (cboProfile.SelectedItem is not AC1999Profile selectedProfile)
            {
                MessageBox.Show(
                    "Please select a profile first.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            AC1999Profile editedProfile = new AC1999Profile
            {
                Name = selectedProfile.Name,
                Host = selectedProfile.Host,
                Port = selectedProfile.Port,
                GamePath = selectedProfile.GamePath,
                UseDatabase = selectedProfile.UseDatabase
            };

            using ProfileForm profileForm =
                new ProfileForm(editedProfile);

            if (profileForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            selectedProfile.Name = profileForm.Profile.Name;
            selectedProfile.Host = profileForm.Profile.Host;
            selectedProfile.Port = profileForm.Profile.Port;
            selectedProfile.GamePath = profileForm.Profile.GamePath;
            selectedProfile.UseDatabase =
                profileForm.Profile.UseDatabase;

            SaveProfiles();

            RefreshProfileList();

            cboProfile.SelectedItem = selectedProfile;
        }

        // ------------------------------------------------------------
        // Delete Profile
        // ------------------------------------------------------------

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (cboProfile.SelectedItem is not AC1999Profile profile)
            {
                MessageBox.Show(
                    "Please select a profile first.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Delete the profile '{profile.Name}'?",
                "Delete Profile",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            profiles.Remove(profile);

            SaveProfiles();

            RefreshProfileList();

            if (cboProfile.Items.Count > 0)
            {
                cboProfile.SelectedIndex = 0;
            }
            else
            {
                ClearServerFields();
            }
        }

        private void ClearServerFields()
        {
            txtHost.Clear();
            txtPort.Clear();
            txtGamePath.Clear();
            chkDatabase.Checked = true;
        }

        // ------------------------------------------------------------
        // Launch
        // ------------------------------------------------------------

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            string gamePath = txtGamePath.Text.Trim();
            string host = txtHost.Text.Trim();
            string port = txtPort.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (!File.Exists(gamePath))
            {
                MessageBox.Show(
                    "The AC1999 client was not found.\n\n" +
                    gamePath,
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrWhiteSpace(host) ||
                string.IsNullOrWhiteSpace(port) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter the server and account information.",
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string arguments =
                $"-h {host} " +
                $"-p {port} " +
                $"-a {username}:{password}";

            if (chkDatabase.Checked)
            {
                arguments += " -db";
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = gamePath,
                    Arguments = arguments,
                    WorkingDirectory =
                        Path.GetDirectoryName(gamePath),
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to launch AC1999.\n\n" +
                    ex.Message,
                    "AC1999 Launcher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}