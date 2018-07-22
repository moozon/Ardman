namespace Ardman
{
    partial class FormArdman
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePwm = new System.Windows.Forms.TabPage();
            this.buttonPwmReset = new System.Windows.Forms.Button();
            this.checkBoxPwmDebug = new System.Windows.Forms.CheckBox();
            this.checkBoxPwmLogs = new System.Windows.Forms.CheckBox();
            this.buttonPwmClearTextBox = new System.Windows.Forms.Button();
            this.labelPwmHz = new System.Windows.Forms.Label();
            this.labelPwmLogs = new System.Windows.Forms.Label();
            this.comboBoxPwmRate = new System.Windows.Forms.ComboBox();
            this.buttonPwnOnOff = new System.Windows.Forms.Button();
            this.textBoxPwmOut = new System.Windows.Forms.TextBox();
            this.labelPwmFreqValue = new System.Windows.Forms.Label();
            this.labelPwmDutyValue = new System.Windows.Forms.Label();
            this.labelPwmFreq = new System.Windows.Forms.Label();
            this.labelPwmDuty = new System.Windows.Forms.Label();
            this.buttonPwmMin = new System.Windows.Forms.Button();
            this.buttonPwmPlus = new System.Windows.Forms.Button();
            this.labelPwmMode = new System.Windows.Forms.Label();
            this.textBoxPwmSet = new System.Windows.Forms.TextBox();
            this.comboBoxPwmMode = new System.Windows.Forms.ComboBox();
            this.buttonPwmSet = new System.Windows.Forms.Button();
            this.tabPagePulse = new System.Windows.Forms.TabPage();
            this.tabPageElectronicLoad = new System.Windows.Forms.TabPage();
            this.tabPagePlot = new System.Windows.Forms.TabPage();
            this.tabPageSerialMonitor = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPageProgramming = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRefreshPorts = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerSerialPort = new System.Windows.Forms.Timer(this.components);
            this.labelPwmMode2 = new System.Windows.Forms.Label();
            this.labelPwmRate = new System.Windows.Forms.Label();
            this.labelConnection = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPagePwm.SuspendLayout();
            this.tabPageSerialMonitor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePwm);
            this.tabControl.Controls.Add(this.tabPagePulse);
            this.tabControl.Controls.Add(this.tabPageElectronicLoad);
            this.tabControl.Controls.Add(this.tabPagePlot);
            this.tabControl.Controls.Add(this.tabPageSerialMonitor);
            this.tabControl.Controls.Add(this.tabPageProgramming);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(150, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(520, 272);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            this.tabControl.Click += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPagePwm
            // 
            this.tabPagePwm.Controls.Add(this.labelPwmRate);
            this.tabPagePwm.Controls.Add(this.labelPwmMode2);
            this.tabPagePwm.Controls.Add(this.buttonPwmReset);
            this.tabPagePwm.Controls.Add(this.checkBoxPwmDebug);
            this.tabPagePwm.Controls.Add(this.checkBoxPwmLogs);
            this.tabPagePwm.Controls.Add(this.buttonPwmClearTextBox);
            this.tabPagePwm.Controls.Add(this.labelPwmHz);
            this.tabPagePwm.Controls.Add(this.labelPwmLogs);
            this.tabPagePwm.Controls.Add(this.comboBoxPwmRate);
            this.tabPagePwm.Controls.Add(this.buttonPwnOnOff);
            this.tabPagePwm.Controls.Add(this.textBoxPwmOut);
            this.tabPagePwm.Controls.Add(this.labelPwmFreqValue);
            this.tabPagePwm.Controls.Add(this.labelPwmDutyValue);
            this.tabPagePwm.Controls.Add(this.labelPwmFreq);
            this.tabPagePwm.Controls.Add(this.labelPwmDuty);
            this.tabPagePwm.Controls.Add(this.buttonPwmMin);
            this.tabPagePwm.Controls.Add(this.buttonPwmPlus);
            this.tabPagePwm.Controls.Add(this.labelPwmMode);
            this.tabPagePwm.Controls.Add(this.textBoxPwmSet);
            this.tabPagePwm.Controls.Add(this.comboBoxPwmMode);
            this.tabPagePwm.Controls.Add(this.buttonPwmSet);
            this.tabPagePwm.Location = new System.Drawing.Point(4, 22);
            this.tabPagePwm.Name = "tabPagePwm";
            this.tabPagePwm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePwm.Size = new System.Drawing.Size(512, 246);
            this.tabPagePwm.TabIndex = 0;
            this.tabPagePwm.Text = "PWM";
            this.tabPagePwm.UseVisualStyleBackColor = true;
            // 
            // buttonPwmReset
            // 
            this.buttonPwmReset.Location = new System.Drawing.Point(146, 202);
            this.buttonPwmReset.Name = "buttonPwmReset";
            this.buttonPwmReset.Size = new System.Drawing.Size(22, 23);
            this.buttonPwmReset.TabIndex = 19;
            this.buttonPwmReset.Text = "R";
            this.buttonPwmReset.UseVisualStyleBackColor = true;
            this.buttonPwmReset.Click += new System.EventHandler(this.buttonPwmReset_Click);
            // 
            // checkBoxPwmDebug
            // 
            this.checkBoxPwmDebug.AutoSize = true;
            this.checkBoxPwmDebug.Location = new System.Drawing.Point(61, 208);
            this.checkBoxPwmDebug.Name = "checkBoxPwmDebug";
            this.checkBoxPwmDebug.Size = new System.Drawing.Size(58, 17);
            this.checkBoxPwmDebug.TabIndex = 18;
            this.checkBoxPwmDebug.Text = "Debug";
            this.checkBoxPwmDebug.UseVisualStyleBackColor = true;
            this.checkBoxPwmDebug.CheckedChanged += new System.EventHandler(this.checkBoxPwmDebug_CheckedChanged);
            // 
            // checkBoxPwmLogs
            // 
            this.checkBoxPwmLogs.AutoSize = true;
            this.checkBoxPwmLogs.Location = new System.Drawing.Point(6, 208);
            this.checkBoxPwmLogs.Name = "checkBoxPwmLogs";
            this.checkBoxPwmLogs.Size = new System.Drawing.Size(49, 17);
            this.checkBoxPwmLogs.TabIndex = 17;
            this.checkBoxPwmLogs.Text = "Logs";
            this.checkBoxPwmLogs.UseVisualStyleBackColor = true;
            this.checkBoxPwmLogs.CheckedChanged += new System.EventHandler(this.checkBoxPwmLogs_CheckedChanged);
            // 
            // buttonPwmClearTextBox
            // 
            this.buttonPwmClearTextBox.Location = new System.Drawing.Point(189, 202);
            this.buttonPwmClearTextBox.Name = "buttonPwmClearTextBox";
            this.buttonPwmClearTextBox.Size = new System.Drawing.Size(42, 23);
            this.buttonPwmClearTextBox.TabIndex = 15;
            this.buttonPwmClearTextBox.Text = "Clear";
            this.buttonPwmClearTextBox.UseVisualStyleBackColor = true;
            this.buttonPwmClearTextBox.Click += new System.EventHandler(this.buttonPwmClearTextBox_Click);
            // 
            // labelPwmHz
            // 
            this.labelPwmHz.AutoSize = true;
            this.labelPwmHz.Location = new System.Drawing.Point(198, 76);
            this.labelPwmHz.Name = "labelPwmHz";
            this.labelPwmHz.Size = new System.Drawing.Size(20, 13);
            this.labelPwmHz.TabIndex = 14;
            this.labelPwmHz.Text = "Hz";
            // 
            // labelPwmLogs
            // 
            this.labelPwmLogs.AutoSize = true;
            this.labelPwmLogs.Location = new System.Drawing.Point(234, 7);
            this.labelPwmLogs.Name = "labelPwmLogs";
            this.labelPwmLogs.Size = new System.Drawing.Size(33, 13);
            this.labelPwmLogs.TabIndex = 13;
            this.labelPwmLogs.Text = "Logs:";
            // 
            // comboBoxPwmRate
            // 
            this.comboBoxPwmRate.FormattingEnabled = true;
            this.comboBoxPwmRate.Items.AddRange(new object[] {
            "x1",
            "x10",
            "x100",
            "x1000"});
            this.comboBoxPwmRate.Location = new System.Drawing.Point(103, 73);
            this.comboBoxPwmRate.Name = "comboBoxPwmRate";
            this.comboBoxPwmRate.Size = new System.Drawing.Size(90, 21);
            this.comboBoxPwmRate.TabIndex = 12;
            this.comboBoxPwmRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxPwmRate_SelectedIndexChanged);
            // 
            // buttonPwnOnOff
            // 
            this.buttonPwnOnOff.Location = new System.Drawing.Point(4, 7);
            this.buttonPwnOnOff.Name = "buttonPwnOnOff";
            this.buttonPwnOnOff.Size = new System.Drawing.Size(42, 23);
            this.buttonPwnOnOff.TabIndex = 11;
            this.buttonPwnOnOff.Text = "ON";
            this.buttonPwnOnOff.UseVisualStyleBackColor = true;
            // 
            // textBoxPwmOut
            // 
            this.textBoxPwmOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPwmOut.Location = new System.Drawing.Point(237, 24);
            this.textBoxPwmOut.Multiline = true;
            this.textBoxPwmOut.Name = "textBoxPwmOut";
            this.textBoxPwmOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPwmOut.Size = new System.Drawing.Size(272, 201);
            this.textBoxPwmOut.TabIndex = 10;
            // 
            // labelPwmFreqValue
            // 
            this.labelPwmFreqValue.AutoSize = true;
            this.labelPwmFreqValue.Location = new System.Drawing.Point(143, 36);
            this.labelPwmFreqValue.Name = "labelPwmFreqValue";
            this.labelPwmFreqValue.Size = new System.Drawing.Size(13, 13);
            this.labelPwmFreqValue.TabIndex = 9;
            this.labelPwmFreqValue.Text = "0";
            // 
            // labelPwmDutyValue
            // 
            this.labelPwmDutyValue.AutoSize = true;
            this.labelPwmDutyValue.Location = new System.Drawing.Point(143, 12);
            this.labelPwmDutyValue.Name = "labelPwmDutyValue";
            this.labelPwmDutyValue.Size = new System.Drawing.Size(13, 13);
            this.labelPwmDutyValue.TabIndex = 8;
            this.labelPwmDutyValue.Text = "0";
            // 
            // labelPwmFreq
            // 
            this.labelPwmFreq.AutoSize = true;
            this.labelPwmFreq.Location = new System.Drawing.Point(100, 36);
            this.labelPwmFreq.Name = "labelPwmFreq";
            this.labelPwmFreq.Size = new System.Drawing.Size(31, 13);
            this.labelPwmFreq.TabIndex = 7;
            this.labelPwmFreq.Text = "Freq:";
            // 
            // labelPwmDuty
            // 
            this.labelPwmDuty.AutoSize = true;
            this.labelPwmDuty.Location = new System.Drawing.Point(100, 12);
            this.labelPwmDuty.Name = "labelPwmDuty";
            this.labelPwmDuty.Size = new System.Drawing.Size(32, 13);
            this.labelPwmDuty.TabIndex = 6;
            this.labelPwmDuty.Text = "Duty:";
            // 
            // buttonPwmMin
            // 
            this.buttonPwmMin.Location = new System.Drawing.Point(103, 113);
            this.buttonPwmMin.Name = "buttonPwmMin";
            this.buttonPwmMin.Size = new System.Drawing.Size(90, 23);
            this.buttonPwmMin.TabIndex = 5;
            this.buttonPwmMin.Text = "-";
            this.buttonPwmMin.UseVisualStyleBackColor = true;
            this.buttonPwmMin.Click += new System.EventHandler(this.buttonPwmMin_Click);
            // 
            // buttonPwmPlus
            // 
            this.buttonPwmPlus.Location = new System.Drawing.Point(8, 113);
            this.buttonPwmPlus.Name = "buttonPwmPlus";
            this.buttonPwmPlus.Size = new System.Drawing.Size(89, 23);
            this.buttonPwmPlus.TabIndex = 4;
            this.buttonPwmPlus.Text = "+";
            this.buttonPwmPlus.UseVisualStyleBackColor = true;
            this.buttonPwmPlus.Click += new System.EventHandler(this.buttonPwmPlus_Click);
            // 
            // labelPwmMode
            // 
            this.labelPwmMode.AutoSize = true;
            this.labelPwmMode.Location = new System.Drawing.Point(198, 153);
            this.labelPwmMode.Name = "labelPwmMode";
            this.labelPwmMode.Size = new System.Drawing.Size(16, 13);
            this.labelPwmMode.TabIndex = 3;
            this.labelPwmMode.Text = "M";
            // 
            // textBoxPwmSet
            // 
            this.textBoxPwmSet.Location = new System.Drawing.Point(103, 150);
            this.textBoxPwmSet.Name = "textBoxPwmSet";
            this.textBoxPwmSet.Size = new System.Drawing.Size(90, 20);
            this.textBoxPwmSet.TabIndex = 2;
            this.textBoxPwmSet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPwmSet_KeyUp);
            // 
            // comboBoxPwmMode
            // 
            this.comboBoxPwmMode.FormattingEnabled = true;
            this.comboBoxPwmMode.Items.AddRange(new object[] {
            "Freq",
            "Duty",
            "Command"});
            this.comboBoxPwmMode.Location = new System.Drawing.Point(8, 73);
            this.comboBoxPwmMode.Name = "comboBoxPwmMode";
            this.comboBoxPwmMode.Size = new System.Drawing.Size(89, 21);
            this.comboBoxPwmMode.TabIndex = 1;
            this.comboBoxPwmMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPwmMode_SelectedIndexChanged);
            // 
            // buttonPwmSet
            // 
            this.buttonPwmSet.Location = new System.Drawing.Point(8, 148);
            this.buttonPwmSet.Name = "buttonPwmSet";
            this.buttonPwmSet.Size = new System.Drawing.Size(89, 23);
            this.buttonPwmSet.TabIndex = 0;
            this.buttonPwmSet.Text = "Set";
            this.buttonPwmSet.UseVisualStyleBackColor = true;
            this.buttonPwmSet.Click += new System.EventHandler(this.buttonPwmSet_Click);
            // 
            // tabPagePulse
            // 
            this.tabPagePulse.Location = new System.Drawing.Point(4, 22);
            this.tabPagePulse.Name = "tabPagePulse";
            this.tabPagePulse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePulse.Size = new System.Drawing.Size(512, 246);
            this.tabPagePulse.TabIndex = 1;
            this.tabPagePulse.Text = "PulseGenerator";
            this.tabPagePulse.UseVisualStyleBackColor = true;
            // 
            // tabPageElectronicLoad
            // 
            this.tabPageElectronicLoad.Location = new System.Drawing.Point(4, 22);
            this.tabPageElectronicLoad.Name = "tabPageElectronicLoad";
            this.tabPageElectronicLoad.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageElectronicLoad.Size = new System.Drawing.Size(512, 246);
            this.tabPageElectronicLoad.TabIndex = 2;
            this.tabPageElectronicLoad.Text = "ElectronicLoad";
            this.tabPageElectronicLoad.UseVisualStyleBackColor = true;
            // 
            // tabPagePlot
            // 
            this.tabPagePlot.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlot.Name = "tabPagePlot";
            this.tabPagePlot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlot.Size = new System.Drawing.Size(512, 246);
            this.tabPagePlot.TabIndex = 3;
            this.tabPagePlot.Text = "Plots";
            this.tabPagePlot.UseVisualStyleBackColor = true;
            // 
            // tabPageSerialMonitor
            // 
            this.tabPageSerialMonitor.Controls.Add(this.richTextBox1);
            this.tabPageSerialMonitor.Controls.Add(this.textBox1);
            this.tabPageSerialMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageSerialMonitor.Name = "tabPageSerialMonitor";
            this.tabPageSerialMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSerialMonitor.Size = new System.Drawing.Size(512, 246);
            this.tabPageSerialMonitor.TabIndex = 4;
            this.tabPageSerialMonitor.Text = "SerialMonitor";
            this.tabPageSerialMonitor.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 81);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(491, 51);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabPageProgramming
            // 
            this.tabPageProgramming.Location = new System.Drawing.Point(4, 22);
            this.tabPageProgramming.Name = "tabPageProgramming";
            this.tabPageProgramming.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgramming.Size = new System.Drawing.Size(512, 246);
            this.tabPageProgramming.TabIndex = 5;
            this.tabPageProgramming.Text = "Programming";
            this.tabPageProgramming.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(670, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelConnection);
            this.groupBox1.Controls.Add(this.buttonRefreshPorts);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.comboBoxBaud);
            this.groupBox1.Controls.Add(this.comboBoxPorts);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 272);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonRefreshPorts
            // 
            this.buttonRefreshPorts.Location = new System.Drawing.Point(75, 80);
            this.buttonRefreshPorts.Name = "buttonRefreshPorts";
            this.buttonRefreshPorts.Size = new System.Drawing.Size(69, 23);
            this.buttonRefreshPorts.TabIndex = 6;
            this.buttonRefreshPorts.Text = "Refresh";
            this.buttonRefreshPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshPorts.Click += new System.EventHandler(this.buttonRefreshPorts_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 80);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(69, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(6, 53);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(138, 21);
            this.comboBoxBaud.TabIndex = 0;
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(6, 26);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(138, 21);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPort1_PinChanged);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(150, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // timerSerialPort
            // 
            this.timerSerialPort.Interval = 5000;
            this.timerSerialPort.Tick += new System.EventHandler(this.timerSerialPort_Tick);
            // 
            // labelPwmMode2
            // 
            this.labelPwmMode2.AutoSize = true;
            this.labelPwmMode2.Location = new System.Drawing.Point(6, 57);
            this.labelPwmMode2.Name = "labelPwmMode2";
            this.labelPwmMode2.Size = new System.Drawing.Size(37, 13);
            this.labelPwmMode2.TabIndex = 20;
            this.labelPwmMode2.Text = "Mode:";
            // 
            // labelPwmRate
            // 
            this.labelPwmRate.AutoSize = true;
            this.labelPwmRate.Location = new System.Drawing.Point(100, 57);
            this.labelPwmRate.Name = "labelPwmRate";
            this.labelPwmRate.Size = new System.Drawing.Size(33, 13);
            this.labelPwmRate.TabIndex = 21;
            this.labelPwmRate.Text = "Rate:";
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Location = new System.Drawing.Point(6, 10);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(64, 13);
            this.labelConnection.TabIndex = 7;
            this.labelConnection.Text = "Connection:";
            // 
            // FormArdman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 296);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormArdman";
            this.Text = "Ardman";
            this.tabControl.ResumeLayout(false);
            this.tabPagePwm.ResumeLayout(false);
            this.tabPagePwm.PerformLayout();
            this.tabPageSerialMonitor.ResumeLayout(false);
            this.tabPageSerialMonitor.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePwm;
        private System.Windows.Forms.TabPage tabPagePulse;
        private System.Windows.Forms.Button buttonPwmSet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageElectronicLoad;
        private System.Windows.Forms.TabPage tabPagePlot;
        private System.Windows.Forms.TabPage tabPageSerialMonitor;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPageProgramming;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.ComboBox comboBoxPwmMode;
        private System.Windows.Forms.Label labelPwmMode;
        private System.Windows.Forms.TextBox textBoxPwmSet;
        private System.Windows.Forms.Button buttonPwmMin;
        private System.Windows.Forms.Button buttonPwmPlus;
        private System.Windows.Forms.Button buttonRefreshPorts;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label labelPwmFreqValue;
        private System.Windows.Forms.Label labelPwmDutyValue;
        private System.Windows.Forms.Label labelPwmFreq;
        private System.Windows.Forms.Label labelPwmDuty;
        private System.Windows.Forms.TextBox textBoxPwmOut;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonPwnOnOff;
        private System.Windows.Forms.ComboBox comboBoxPwmRate;
        private System.Windows.Forms.Label labelPwmLogs;
        private System.Windows.Forms.Label labelPwmHz;
        private System.Windows.Forms.Timer timerSerialPort;
        private System.Windows.Forms.Button buttonPwmClearTextBox;
        private System.Windows.Forms.CheckBox checkBoxPwmLogs;
        private System.Windows.Forms.CheckBox checkBoxPwmDebug;
        private System.Windows.Forms.Button buttonPwmReset;
        private System.Windows.Forms.Label labelPwmRate;
        private System.Windows.Forms.Label labelPwmMode2;
        private System.Windows.Forms.Label labelConnection;
    }
}

