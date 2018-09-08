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
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK) {
                this.BlobFilePath = file.FileName;
            }
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK) {
                this.SignedIPSWFilePath = file.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK) {
                this.RestoreToIPSWFilePath = file.FileName;
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            Process proc = new Process {
                StartInfo = new ProcessStartInfo {
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
            while (!proc.StandardOutput.EndOfStream) {
                richTextBox1.Text += proc.StandardOutput.ReadLine() + "\n";
            }
        }
    }
}