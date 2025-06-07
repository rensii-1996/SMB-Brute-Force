using System.Windows.Forms;

namespace SMB
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            startStopScan = new Button();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            hostsList = new RichTextBox();
            label5 = new Label();
            resultGridView = new DataGridView();
            index = new DataGridViewTextBoxColumn();
            Hostname = new DataGridViewTextBoxColumn();
            Port = new DataGridViewTextBoxColumn();
            User = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Error = new DataGridViewTextBoxColumn();
            usernameTextBox = new TextBox();
            passwordsTextBox = new TextBox();
            usernamesBtn = new Button();
            passwordsBtn = new Button();
            label6 = new Label();
            label7 = new Label();
            usernamesOFD = new OpenFileDialog();
            passwordsOFD = new OpenFileDialog();
            usernameRowCountLabel = new Label();
            passwordRowCountLabel = new Label();
            usernameCount = new Label();
            passwordCount = new Label();
            totalRequestsCountLabel = new Label();
            totalRequestCount = new Label();
            sendRequestsCountLabel = new Label();
            sendRequestsCount = new Label();
            ipCountLabel = new Label();
            ipCount = new Label();
            loadingLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultGridView).BeginInit();
            SuspendLayout();
            // 
            // startStopScan
            // 
            startStopScan.Location = new Point(12, 12);
            startStopScan.Name = "startStopScan";
            startStopScan.Size = new Size(100, 23);
            startStopScan.TabIndex = 0;
            startStopScan.Text = "Start Scan";
            startStopScan.UseVisualStyleBackColor = true;
            startStopScan.Click += startStopScan_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = SMB.Properties.Resources.fastsmb;
            pictureBox1.Location = new Point(12, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(156, 77);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 9;
            label4.Text = "Port 139/445";
            label4.Click += label4_Click;
            // 
            // hostsList
            // 
            hostsList.Location = new Point(346, 30);
            hostsList.Name = "hostsList";
            hostsList.Size = new Size(200, 111);
            hostsList.TabIndex = 10;
            hostsList.Text = "";
            hostsList.TextChanged += hostsList_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(354, 9);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 11;
            label5.Text = "IP / Hostname to scan";
            label5.Click += label5_Click;
            // 
            // resultGridView
            // 
            resultGridView.AllowUserToAddRows = false;
            resultGridView.AllowUserToDeleteRows = false;
            resultGridView.AllowUserToOrderColumns = true;
            resultGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            resultGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resultGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGridView.Columns.AddRange(new DataGridViewColumn[] { index, Hostname, Port, User, Password, Status, Error, infoButtonColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            resultGridView.DefaultCellStyle = dataGridViewCellStyle2;
            resultGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            resultGridView.Location = new Point(6, 286);
            resultGridView.Name = "resultGridView";
            resultGridView.ReadOnly = true;
            resultGridView.RowHeadersVisible = false;
            resultGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            resultGridView.Size = new Size(784, 291);
            resultGridView.TabIndex = 12;
            resultGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // index
            // 
            index.FillWeight = 106.598984F;
            index.HeaderText = "#";
            index.Name = "index";
            index.ReadOnly = true;
            // 
            // Hostname
            // 
            Hostname.FillWeight = 98.90017F;
            Hostname.HeaderText = "IP/Hostname";
            Hostname.Name = "Hostname";
            Hostname.ReadOnly = true;
            // 
            // Port
            // 
            Port.FillWeight = 98.90017F;
            Port.HeaderText = "Port";
            Port.Name = "Port";
            Port.ReadOnly = true;
            // 
            // User
            // 
            User.FillWeight = 98.90017F;
            User.HeaderText = "User";
            User.Name = "User";
            User.ReadOnly = true;
            // 
            // Password
            // 
            Password.FillWeight = 98.90017F;
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.ReadOnly = true;
            // 
            // Status
            // 
            Status.FillWeight = 98.90017F;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // Error
            // 
            Error.FillWeight = 98.90017F;
            Error.HeaderText = "Error";
            Error.Name = "Error";
            Error.ReadOnly = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(552, 56);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.ReadOnly = true;
            usernameTextBox.Size = new Size(129, 23);
            usernameTextBox.TabIndex = 13;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // passwordsTextBox
            // 
            passwordsTextBox.Location = new Point(552, 134);
            passwordsTextBox.Name = "passwordsTextBox";
            passwordsTextBox.ReadOnly = true;
            passwordsTextBox.Size = new Size(129, 23);
            passwordsTextBox.TabIndex = 14;
            // 
            // usernamesBtn
            // 
            usernamesBtn.Location = new Point(687, 56);
            usernamesBtn.Name = "usernamesBtn";
            usernamesBtn.Size = new Size(75, 23);
            usernamesBtn.TabIndex = 15;
            usernamesBtn.Text = "Open";
            usernamesBtn.UseVisualStyleBackColor = true;
            usernamesBtn.Click += usernamesBtn_Click;
            // 
            // passwordsBtn
            // 
            passwordsBtn.Location = new Point(687, 134);
            passwordsBtn.Name = "passwordsBtn";
            passwordsBtn.Size = new Size(75, 23);
            passwordsBtn.TabIndex = 16;
            passwordsBtn.Text = "Open";
            passwordsBtn.UseVisualStyleBackColor = true;
            passwordsBtn.Click += passwordsBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(552, 30);
            label6.Name = "label6";
            label6.Size = new Size(115, 15);
            label6.TabIndex = 17;
            label6.Text = "Select users file (.txt)";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(552, 116);
            label7.Name = "label7";
            label7.Size = new Size(143, 15);
            label7.TabIndex = 18;
            label7.Text = "Select passwords file (.txt)";
            // 
            // usernamesOFD
            // 
            usernamesOFD.Filter = "Text files (*.txt)|*.txt";
            // 
            // passwordsOFD
            // 
            passwordsOFD.Filter = "Text files (*.txt)|*.txt";
            // 
            // usernameRowCountLabel
            // 
            usernameRowCountLabel.AutoSize = true;
            usernameRowCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameRowCountLabel.Location = new Point(552, 87);
            usernameRowCountLabel.Margin = new Padding(3, 5, 3, 5);
            usernameRowCountLabel.Name = "usernameRowCountLabel";
            usernameRowCountLabel.Size = new Size(131, 15);
            usernameRowCountLabel.TabIndex = 18;
            usernameRowCountLabel.Text = "usernameRowsCount: ";
            usernameRowCountLabel.Click += label10_Click;
            // 
            // passwordRowCountLabel
            // 
            passwordRowCountLabel.AutoSize = true;
            passwordRowCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordRowCountLabel.Location = new Point(552, 165);
            passwordRowCountLabel.Margin = new Padding(3, 5, 3, 5);
            passwordRowCountLabel.Name = "passwordRowCountLabel";
            passwordRowCountLabel.Size = new Size(128, 15);
            passwordRowCountLabel.TabIndex = 21;
            passwordRowCountLabel.Text = "passwordRowsCount: ";
            // 
            // usernameCount
            // 
            usernameCount.AutoSize = true;
            usernameCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameCount.Location = new Point(681, 87);
            usernameCount.Margin = new Padding(3, 5, 3, 5);
            usernameCount.Name = "usernameCount";
            usernameCount.Size = new Size(14, 15);
            usernameCount.TabIndex = 22;
            usernameCount.Text = "0";
            usernameCount.Click += label10_Click_1;
            // 
            // passwordCount
            // 
            passwordCount.AutoSize = true;
            passwordCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordCount.Location = new Point(679, 165);
            passwordCount.Margin = new Padding(3, 5, 3, 5);
            passwordCount.Name = "passwordCount";
            passwordCount.Size = new Size(14, 15);
            passwordCount.TabIndex = 23;
            passwordCount.Text = "0";
            // 
            // totalRequestsCountLabel
            // 
            totalRequestsCountLabel.AutoSize = true;
            totalRequestsCountLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalRequestsCountLabel.ForeColor = SystemColors.MenuHighlight;
            totalRequestsCountLabel.Location = new Point(12, 199);
            totalRequestsCountLabel.Margin = new Padding(3, 5, 3, 5);
            totalRequestsCountLabel.Name = "totalRequestsCountLabel";
            totalRequestsCountLabel.Size = new Size(137, 17);
            totalRequestsCountLabel.TabIndex = 24;
            totalRequestsCountLabel.Text = "totalRequestsCount: ";
            // 
            // totalRequestCount
            // 
            totalRequestCount.AutoSize = true;
            totalRequestCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalRequestCount.ForeColor = SystemColors.MenuHighlight;
            totalRequestCount.Location = new Point(144, 199);
            totalRequestCount.Margin = new Padding(3, 5, 3, 5);
            totalRequestCount.Name = "totalRequestCount";
            totalRequestCount.Size = new Size(15, 17);
            totalRequestCount.TabIndex = 25;
            totalRequestCount.Text = "0";
            totalRequestCount.Click += label10_Click_2;
            // 
            // sendRequestsCountLabel
            // 
            sendRequestsCountLabel.AutoSize = true;
            sendRequestsCountLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sendRequestsCountLabel.ForeColor = Color.ForestGreen;
            sendRequestsCountLabel.Location = new Point(12, 226);
            sendRequestsCountLabel.Margin = new Padding(3, 5, 3, 5);
            sendRequestsCountLabel.Name = "sendRequestsCountLabel";
            sendRequestsCountLabel.Size = new Size(137, 17);
            sendRequestsCountLabel.TabIndex = 26;
            sendRequestsCountLabel.Text = "sendRequestsCount: ";
            sendRequestsCountLabel.Click += sendRequestsCountLabel_Click;
            // 
            // sendRequestsCount
            // 
            sendRequestsCount.AutoSize = true;
            sendRequestsCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sendRequestsCount.ForeColor = Color.ForestGreen;
            sendRequestsCount.Location = new Point(143, 226);
            sendRequestsCount.Margin = new Padding(3, 5, 3, 5);
            sendRequestsCount.Name = "sendRequestsCount";
            sendRequestsCount.Size = new Size(15, 17);
            sendRequestsCount.TabIndex = 27;
            sendRequestsCount.Text = "0";
            sendRequestsCount.Click += sendRequestsCount_Click;
            // 
            // ipCountLabel
            // 
            ipCountLabel.AutoSize = true;
            ipCountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ipCountLabel.Location = new Point(354, 149);
            ipCountLabel.Margin = new Padding(3, 5, 3, 5);
            ipCountLabel.Name = "ipCountLabel";
            ipCountLabel.Size = new Size(86, 15);
            ipCountLabel.TabIndex = 28;
            ipCountLabel.Text = "ipRowsCount: ";
            ipCountLabel.Click += ipCountLabel_Click_3;
            // 
            // ipCount
            // 
            ipCount.AutoSize = true;
            ipCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ipCount.Location = new Point(436, 149);
            ipCount.Margin = new Padding(3, 5, 3, 5);
            ipCount.Name = "ipCount";
            ipCount.Size = new Size(14, 15);
            ipCount.TabIndex = 29;
            ipCount.Text = "0";
            ipCount.Click += ipCount_Click_3;
            // 
            // loadingLabel
            // 
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loadingLabel.Location = new Point(305, 257);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(0, 15);
            loadingLabel.TabIndex = 30;
            loadingLabel.Click += label10_Click_3;
            //
            // Info
            // 
            infoButtonColumn.HeaderText = "Info";
            infoButtonColumn.Name = "Info";
            infoButtonColumn.Text = "info";
            infoButtonColumn.UseColumnTextForButtonValue = true;
            infoButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(800, 565);
            Controls.Add(loadingLabel);
            Controls.Add(ipCount);
            Controls.Add(ipCountLabel);
            Controls.Add(sendRequestsCount);
            Controls.Add(sendRequestsCountLabel);
            Controls.Add(totalRequestCount);
            Controls.Add(totalRequestsCountLabel);
            Controls.Add(passwordCount);
            Controls.Add(usernameCount);
            Controls.Add(passwordRowCountLabel);
            Controls.Add(usernameRowCountLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(passwordsBtn);
            Controls.Add(usernamesBtn);
            Controls.Add(passwordsTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(resultGridView);
            Controls.Add(label5);
            Controls.Add(hostsList);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(startStopScan);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FastSMB";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button startStopScan;
        private PictureBox pictureBox1;
        private Label label4;
        private RichTextBox hostsList;
        private Label label5;
        private DataGridView resultGridView;
        DataGridViewButtonColumn infoButtonColumn = new DataGridViewButtonColumn();
        private TextBox usernameTextBox;
        private TextBox passwordsTextBox;
        private Button usernamesBtn;
        private Button passwordsBtn;
        private Label label6;
        private Label label7;
        private OpenFileDialog usernamesOFD;
        private OpenFileDialog passwordsOFD;
        private Label usernameRowCountLabel;
        private Label passwordRowCountLabel;
        private Label usernameCount;
        private Label passwordCount;
        private Label totalRequestsCountLabel;
        private Label totalRequestCount;
        private Label sendRequestsCountLabel;
        private Label sendRequestsCount;
        private Label ipCountLabel;
        private Label ipCount;
        private Label loadingLabel;
        private DataGridViewTextBoxColumn index;
        private DataGridViewTextBoxColumn Hostname;
        private DataGridViewTextBoxColumn Port;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Error;
    }
}
