using SMB.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace SMB
{
    public partial class MainForm : Form
    {
        private int sendRequests = 0;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
            resultGridView.ClearSelection();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    if (e.ColumnIndex == resultGridView.Columns.Count - 1) // Assuming the button column is the last one
                    {
                        // Perform action based on the row where the button was clicked
                        int rowIndex = e.RowIndex;
                        // You can access row data like this:

                        // Show info or perform any other action
                        MessageBox.Show($"Info for {SMBBruteForce.getInfo(resultGridView.Rows[rowIndex].Cells[1].Value.ToString())}");
                    }
                }
                catch (Exception ex)
                {
                }
            }).Start();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resultGridView.Rows.Add("","", "", "", "", "", "");
            resultGridView.ClearSelection();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Perform cleanup operations here

            Application.Exit();
            Environment.Exit(0);
        }


        private void usernamesBtn_Click(object sender, EventArgs e)
        {
            if (usernamesOFD.ShowDialog() == DialogResult.OK)
            {
                usersFileAnalyze();

            }
        }

        private void passwordsBtn_Click(object sender, EventArgs e)
        {
            if (passwordsOFD.ShowDialog() == DialogResult.OK)
            {
                passwordsFileAnalyze();
            }
        }


        private void startStopScan_Click(object sender, EventArgs e)
        {

            startStopScan.Enabled = false;
            cancellationTokenSource = new CancellationTokenSource();

            if (startStopScan.Text == "Start Scan")
            {
                if (string.IsNullOrEmpty(this.hostsList.Text))
                {
                    MessageBox.Show("Hosts list must be filled.");
                    startStopScan.Enabled = true;
                    return;
                }

                if (string.IsNullOrEmpty(this.usernamesOFD.FileName))
                {
                    MessageBox.Show("Please select users file.");
                    startStopScan.Enabled = true;
                    return;
                }
                if (string.IsNullOrEmpty(this.passwordsOFD.FileName))
                {
                    MessageBox.Show("Please select passwords file.");
                    startStopScan.Enabled = true;
                    return;
                }
                resultGridView.Rows.Clear();
                resultGridView.RowCount = hostsList.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray().Length;
                sendRequestsCount.Text = "";
                sendRequestsCount.Text = "0";
                sendRequests = 0;
                loadingLabel.Text = "Analyzing...";
                usersFileAnalyze();
                passwordsFileAnalyze();
                SMBBruteForce.parseArguments(usernamesOFD.FileName, passwordsOFD.FileName, hostsList.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray());
                new Thread(() =>
                {
                    if (SMBBruteForce.start())
                    {


                    }
                }).Start();
                new Thread(() =>
                {
                    Thread.Sleep(1000);
                    this.Invoke(new MethodInvoker(delegate { startStopScan.Text = "Stop Scan"; }));

                    while (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        
                       
                        SMBResult? smbResult;
                        smbResult = SMBBruteForce.getResult();
                        if (smbResult == null && SMBBruteForce.allResultGetted()) break;
                        else if (smbResult == null) continue;



                        if (smbResult == null && SMBBruteForce.allResultGetted())
                        {
                            break;
                        }
                        else if (smbResult == null)
                        {
                            continue;
                        }
                        resultGridView.Invoke(new Action(() =>
                        {
                            if (smbResult != null)
                            {

                                if (!smbResult.Status)
                                {
                                    UpdateLoadingLabel("");
                                }
                            
                                Interlocked.Increment(ref sendRequests);
                                


                            }
                            UpdateRequestCount(this.sendRequests.ToString());
                            if (this.sendRequests == 1)
                            {
                                UpdateLoadingLabel("");
                            }
                        }));
                        UpdateRequestCount(this.sendRequests.ToString());
                        if (this.sendRequests == 1)
                        {
                            UpdateLoadingLabel("");
                        }
                    }
                    if (!cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        this.Invoke(new MethodInvoker(
                            delegate
                            {
                                startStopScan.Text = "Start Scan";
                                startStopScan.Enabled = true;
                                UpdateRequestCount(this.sendRequests.ToString());
                                UpdateLoadingLabel("");
                                MessageBox.Show("Scan finished.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }));
                    }
                    else
                    {
                        MessageBox.Show("Scan Canceled.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }).Start();
            }
            else
            {
                if (SMBBruteForce.stop())
                {
                    cancellationTokenSource.Cancel();
                    SMBBruteForce.stop();
                    startStopScan.Text = "Start Scan";
                }
            }
            Thread.Sleep(5000);
            startStopScan.Enabled = true;
        }
        private void UpdateRequestCount(string text)
        {
            if (sendRequestsCount.InvokeRequired)
            {
                sendRequestsCount.Invoke(new MethodInvoker(() => UpdateRequestCount(text)));
            }
            else
            {
                sendRequestsCount.Text = text;
            }
        }
       
        private void UpdateLoadingLabel(string text)
        {
            if (loadingLabel.InvokeRequired)
            {
                loadingLabel.Invoke(new MethodInvoker(() => UpdateLoadingLabel(text)));
            }
            else
            {
                loadingLabel.Text = text;
            }
        }
        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void portsList_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_2(object sender, EventArgs e)
        {

        }

        private void hostsList_TextChanged(object sender, EventArgs e)
        {
            calculateRequests();
        }

        private void sendRequestsCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void portsList_TextChanged_1(object sender, EventArgs e)
        {
            calculateRequests();
        }

        private void calculateRequests()
        {
            List<string> hostLinesList = new List<string>(hostsList.Lines);
            hostLinesList.RemoveAll(string.IsNullOrWhiteSpace);

            ipCount.Text = hostLinesList.Count.ToString();
            totalRequestCount.Text = (int.Parse(usernameCount.Text)
                    * int.Parse(passwordCount.Text) *
                    hostLinesList.Count).ToString();
        }

        private void usersFileAnalyze()
        {
            usernameTextBox.Text = usernamesOFD.FileName.ToString();
            string contentFile = String.Join(", ", Utils.FileUtils.
                readFile(usernamesOFD.FileName.ToString()));
            usernameCount.Text = contentFile.Split(", ").Length.ToString();
            calculateRequests();
        }

        private void passwordsFileAnalyze()
        {
            passwordsTextBox.Text = passwordsOFD.FileName.ToString();


            string contentFile = String.Join(", ", Utils.FileUtils.
                readFile(passwordsOFD.FileName.ToString()));

            string output = Utils.Handy.stringKeepOneEmptyLine(contentFile);
            passwordCount.Text = output.Split(",").Length.ToString();
            calculateRequests();
        }

        private void sendRequestsCount_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericThreads_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ipCountLabel_Click_3(object sender, EventArgs e)
        {

        }

        private void ipCount_Click_3(object sender, EventArgs e)
        {

        }

        private void label10_Click_3(object sender, EventArgs e)
        {

        }

        private void numericTimeout_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
