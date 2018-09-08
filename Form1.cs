using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace tsschecker_gui {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private string blobFilePath;
        private string signedIPSWFilePath;
        private string restoreToIPSWFilePath;

        public string BlobFilePath {
            get => blobFilePath;
            set => blobFilePath = value;
        }

        public string SignedIPSWFilePath {
            get => signedIPSWFilePath;
            set => signedIPSWFilePath = value;
        }

        public string RestoreToIPSWFilePath {
            get => restoreToIPSWFilePath;
            set => restoreToIPSWFilePath = value;
        }

        private void Button1_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Blob file (*.SHSH2)|*.SHSH2|All files (*.*)|*.*"
            };
            if (file.ShowDialog() == DialogResult.OK) {
                this.BlobFilePath = file.FileName;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("File added.", "File added!", buttons, MessageBoxIcon.Information);
            }
            if (this.blobFilePath != null && this.signedIPSWFilePath != null && this.restoreToIPSWFilePath != null)
            {
                this.button3.Enabled = true;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "IPSW file (*.ipsw)|*.ipsw|All files (*.*)|*.*"
            };
            if (file.ShowDialog() == DialogResult.OK) {
                this.SignedIPSWFilePath = file.FileName;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("File added.", "File added!", buttons, MessageBoxIcon.Information);
            }
            if (this.blobFilePath != null && this.signedIPSWFilePath != null && this.restoreToIPSWFilePath != null)
            {
                this.button3.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "IPSW file (*.ipsw)|*.ipsw|All files (*.*)|*.*"
            };
            if (file.ShowDialog() == DialogResult.OK) {
                this.RestoreToIPSWFilePath = file.FileName;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("File added.", "File added!", buttons, MessageBoxIcon.Information);
            }
            if (this.blobFilePath != null && this.signedIPSWFilePath != null && this.restoreToIPSWFilePath != null)
            {
                this.button3.Enabled = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedItem.ToString() == "With baseband")
            {
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "futurerestore.exe",
                        Arguments = "-t " + this.blobFilePath +
                    " -i " + this.signedIPSWFilePath +
                    "--latest-sep" +
                    "--latest-baseband" +
                    " " + this.restoreToIPSWFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    richTextBox1.Text += proc.StandardOutput.ReadLine() + "\n";
                }
            }
            if (comboBox1.SelectedItem == " " || comboBox1.SelectedItem == null || comboBox1.SelectedItem == "")
            {
                MessageBox.Show("Select a device type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBox1.SelectedItem.ToString() == "Without baseband")
            {
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "futurerestore.exe",
                        Arguments = "-t " + this.blobFilePath +
                    " -i " + this.signedIPSWFilePath +
                    "--latest-sep" +
                    "--no-baseband" +
                    " " + this.restoreToIPSWFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    richTextBox1.Text += proc.StandardOutput.ReadLine() + "\n";
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (this.blobFilePath == null)
            {
                MessageBox.Show("Add a file!", "Error", buttons, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this.blobFilePath, "Current path", buttons, MessageBoxIcon.Information);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (this.signedIPSWFilePath == null)
            {
                MessageBox.Show("Add a file!", "Error", buttons, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this.signedIPSWFilePath, "Current path", buttons, MessageBoxIcon.Information);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (this.restoreToIPSWFilePath == null)
            {
                MessageBox.Show("Add a file!", "Error", buttons, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this.restoreToIPSWFilePath, "Current path", buttons, MessageBoxIcon.Information);
            }
        }
    }
}