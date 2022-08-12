namespace Archiver
{
    public sealed partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        private async void CheckUpdatesAsync()
        {
            DirectoryInfo tmpDir = new DirectoryInfo(@$"C:\Windows\Temp\{Application.ProductName}\");
            
            Log($"Checking for directory \"{tmpDir.FullName}\"...");
            if (!tmpDir.Exists)
            {
                tmpDir.Create();
                Log("Created temporary directory.");
            }

            FileInfo updateFile = new FileInfo(Path.Combine(tmpDir.FullName, Application.ProductName + ".exe"));
            if (updateFile.Exists)
                updateFile.Delete();



            Close();
            Dispose();
            DialogResult = DialogResult.None;
        }

        private void Log(string text)
        {
            txtLog.AppendText($"{DateTime.Now.ToString("[hh:mm:ss]")} {text}{Environment.NewLine}");
        }

        private void UpdateDialog_Shown(object sender, EventArgs e)
        {
            pgbProgress.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Checking for updates...";
            Log("Checking for updates...");
            CheckUpdatesAsync();
        }

        private void UpdateDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText("Update.log", txtLog.Text);
            DialogResult = DialogResult.Abort;
        }
    }
}
