using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardman
{
    public partial class FormArdman : Form
    {
        int[] baudRate = { 9600, 115200 };
        string[] comPorts;
        string rate;
        //char buffer;
        char[] upDutyChar = { '1' };
        char[] downDutyChar = { '2' };
        char[] upFreqChar = { '3' };
        char[] downFreqChar = { '4' };
        char[] setDutyChar = { 'd' };
        char[] setFreqChar = { 'f' };
        char[] logChar = { 'l' };
        char[] debugChar = { 'g' };
        char[] commandChar = { 'c' };
        char[] resetChar = { 'r' };
        //char[] logOnChar = { 'l', '1' };
        //char[] logOffChar = { 'l', '0' };

        bool isDebugging = false;
        bool isConnect = false;
        bool isLogging = false;
        int duty;
        int freq;
        int counterTextBoxPwmOut;
        string dutyString, freqString;
        string dutyReal, freqReal;

        int timerSerialPortCount;
        public FormArdman()
        {
            InitializeComponent();
            this.Text = "Ardman";
            rate = "x1";
            foreach (Control control in tabPagePwm.Controls)
                control.Enabled = false;
            comPorts = System.IO.Ports.SerialPort.GetPortNames();
            //Array.Reverse(comPorts);
            comboBoxPorts.DataSource = comPorts;
            comboBoxBaud.DataSource = baudRate;
            comboBoxPwmMode.Text = comboBoxPwmMode.Items[0].ToString();
            comboBoxPwmRate.Text = comboBoxPwmRate.Items[0].ToString();
            timerSerialPortCount = 0;
            labelPwmMode.Text = "Hz";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //serialPort1.DiscardInBuffer();
                //Thread.Sleep(50);
                serialPort1.Close();
            }
            Application.Exit();
        }

        private void buttonRefreshPorts_Click(object sender, EventArgs e)
        {
            comPorts = System.IO.Ports.SerialPort.GetPortNames();
            //Array.Reverse(comPorts);
            comboBoxPorts.DataSource = comPorts;
            if (comboBoxPorts.Items.Count == 0) comboBoxPorts.Text = "";
            else comboBoxPorts.Text = comboBoxPorts.Items[0].ToString();
            comboBoxPorts.Update();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                CloseConnection();
            }
            else
            {
                if (comboBoxPorts.Items.Count > 0)
                    serialPort1.PortName = comboBoxPorts.SelectedItem.ToString();
                else
                {
                    MessageBox.Show("Выберите порт");
                    return;
                }

                try
                {
                    serialPort1.BaudRate = (int)comboBoxBaud.SelectedItem;
                }
                catch
                {
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                }

                OpenConnection();



            }
        }

        private void PwmPlus()
        {
            switch (rate)
            {
                case "x1":
                    if (serialPort1.IsOpen)
                        serialPort1.Write(upDutyChar, 0, 1);
                    else MessageBox.Show("Соединение не установлено", "Внимание!!!");
                    break;
                case "x10":
                    SetDuty(duty + 10);
                    break;
                case "x100":
                    SetDuty(duty + 100);
                    break;
                case "x1000":
                    SetDuty(duty + 1000);
                    break;
                default:
                    break;
            }
        }

        private void PwmMinus()
        {
            switch (rate)
            {
                case "x1":
                    if (serialPort1.IsOpen)
                        serialPort1.Write(downDutyChar, 0, 1);
                    else MessageBox.Show("Соединение не установлено", "Внимание!!!");
                    break;
                case "x10":
                    SetDuty(duty - 10);
                    break;
                case "x100":
                    SetDuty(duty - 100);
                    break;
                case "x1000":
                    SetDuty(duty - 1000);
                    break;
                default:
                    break;
            }
        }

        private void FreqPlus()
        {
            switch (rate)
            {
                case "x1":
                    if (serialPort1.IsOpen)
                        serialPort1.Write(upFreqChar, 0, 1);
                    else MessageBox.Show("Соединение не установлено", "Внимание!!!");
                    break;
                case "x10":
                    SetFreq(freq + 10);
                    break;
                case "x100":
                    SetFreq(freq + 100);
                    break;
                case "x1000":
                    SetFreq(freq + 1000);
                    break;
                default:
                    break;
            }
        }

        private void FreqMinus()
        {
            switch (rate)
            {
                case "x1":
                    if (serialPort1.IsOpen)
                        serialPort1.Write(downFreqChar, 0, 1);
                    else MessageBox.Show("Соединение не установлено", "Внимание!!!");
                    break;
                case "x10":
                    SetFreq(freq - 10);
                    break;
                case "x100":
                    SetFreq(freq - 100);
                    break;
                case "x1000":
                    SetFreq(freq - 1000);
                    break;
                default:
                    break;
            }
        }

        private void buttonPwmPlus_Click(object sender, EventArgs e)
        {
            if (comboBoxPwmMode.SelectedItem.ToString() == "Duty")
                //serialPort1.Write("1");
                PwmPlus();
            else
                FreqPlus();

        }

        private void buttonPwmMin_Click(object sender, EventArgs e)
        {
            if (comboBoxPwmMode.SelectedItem.ToString() == "Duty")
                PwmMinus();
            else
                FreqMinus();
        }

        private void buttonPwmSet_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (comboBoxPwmMode.SelectedItem.ToString() == "Duty")
                    {
                        SetDuty(Convert.ToInt32(textBoxPwmSet.Text));
                    }
                    else if (comboBoxPwmMode.SelectedItem.ToString() == "Freq")
                    {
                        SetFreq(Convert.ToInt32(textBoxPwmSet.Text));
                    }
                    else if (comboBoxPwmMode.SelectedItem.ToString() == "Command")
                    {
                        SendCommand(textBoxPwmSet.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Недопустимый формат");
                }
            }
            else MessageBox.Show("Соединение не установлено");
        }

        private void comboBoxPwmMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxPwmMode.SelectedItem.ToString() == "Duty")
            {
                buttonPwmSet.Text = "Set";
                labelPwmMode.Text = "%";
            }
            else if (comboBoxPwmMode.SelectedItem.ToString() == "Freq")
            {
                buttonPwmSet.Text = "Set";
                labelPwmMode.Text = "Hz";
            }
            else
            {
                buttonPwmSet.Text = "Send command";
                labelPwmMode.Text = "";
            }
        }

        private void SetDuty(int duty)
        {
            if (serialPort1.IsOpen)
            {
                if (duty < 0 || duty > 100)
                {
                    MessageBox.Show("Значение должно быть в пределах от 0 до 100", "Внимание!!!");
                    return;
                }
                serialPort1.Write(setDutyChar, 0, 1);
                serialPort1.Write(duty.ToString() + 'e');
            }
            else MessageBox.Show("Соединение не установлено", "Внимание!!!");

        }

        private void SetFreq(int freq)
        {
            if (serialPort1.IsOpen)
            {
                if (freq < 0 || freq > 8000000)
                {
                    MessageBox.Show("Значение должно быть в пределах от 0 до 8000000", "Внимание!!!");
                    return;
                }
                serialPort1.Write(setFreqChar, 0, 1);
                serialPort1.Write(freq.ToString() + 'e');
            }
            else MessageBox.Show("Соединение не установлено", "Внимание!!!");

        }

        private void SendCommand(string command)
        {
            serialPort1.Write(commandChar, 0, 1);
            serialPort1.Write(command);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            isLogging = true;
            int incomingByte = serialPort1.ReadChar();
            serialPort1.ReadLine();             //!!!Чтение лишнего байта. Необходимо для корректного считывания

            if (incomingByte == 'l')
            {
                //Необходимо соблюдать прием всех встрок, иначе будут ошибки приема
                counterTextBoxPwmOut++;
                dutyString = serialPort1.ReadLine();
                freqString = serialPort1.ReadLine();
                ///
                dutyReal = serialPort1.ReadLine();
                freqReal = serialPort1.ReadLine();
                string test = serialPort1.ReadLine();   //Test string from Serial
                //Debug Serial
                string debugString = serialPort1.ReadExisting();
                labelPwmDutyValue.Invoke(new Action(() => labelPwmDutyValue.Text = dutyString));
                labelPwmFreqValue.Invoke(new Action(() => labelPwmFreqValue.Text = freqString));
                if (counterTextBoxPwmOut > 1)
                {
                    if (isLogging)
                    { 
                    textBoxPwmOut.Invoke(new Action(() =>
                    {
                        textBoxPwmOut.AppendText("Test: " + test + Environment.NewLine);
                        textBoxPwmOut.AppendText("Real Freq: " + freqReal + Environment.NewLine);
                        if (isDebugging)
                            textBoxPwmOut.AppendText(debugString + Environment.NewLine);

                    }));
                    }
                    //Console.WriteLine(icr);
                    counterTextBoxPwmOut = 0;
                }
                duty = Convert.ToInt32(dutyString);
                freq = Convert.ToInt32(freqString);

            }


        }

        private void textBoxPwmSet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonPwmSet_Click(new object(), new EventArgs());
        }
        /// <summary>
        /// Connect to serial port
        /// </summary>
        private void OpenConnection()
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    isConnect = true;
                    timerSerialPort.Start();
                    timerSerialPortCount = 0;
                }
                catch (Exception e)
                {
                    textBoxPwmOut.AppendText(e.Message + Environment.NewLine);
                }

                Thread.Sleep(100);
                if (isConnect)
                {
                    Task.Factory.StartNew(new Action(() =>
                    {
                        Thread.Sleep(1500);
                        if (checkBoxPwmLogs.Checked)
                        {
                            serialPort1.Write(logChar, 0, 1);
                            serialPort1.Write("1");
                            isLogging = true;
                        }
                        else
                        {
                            serialPort1.Write(logChar, 0, 1);
                            serialPort1.Write("0");
                            isLogging = false;
                        }
                        if (checkBoxPwmDebug.Checked)
                        {
                            serialPort1.Write(debugChar, 0, 1);
                            serialPort1.Write("1");
                            isDebugging = true;
                        }
                        else
                        {
                            serialPort1.Write(debugChar, 0, 1);
                            serialPort1.Write("0");
                            isDebugging = false;
                        }
                    }));
                    foreach (Control control in tabPagePwm.Controls)
                    {
                        if (control.Name == "textBoxPwmOut")
                        {
                            if (!isLogging)
                                control.Enabled = false;
                            else
                                control.Enabled = true;
                        }
                        else
                        if (control.Name == "checkBoxPwmDebug")
                        {
                            if (!isLogging)
                                control.Enabled = false;
                            else
                                control.Enabled = true;
                        }
                        else
                        control.Enabled = true;
                    }
                    //this.Text = "Ardman Connected on " + comboBoxPorts.SelectedItem.ToString();
                    buttonConnect.Text = "Disconnect";
                    toolStripStatusLabel1.Text = "Connected on " + comboBoxPorts.SelectedItem.ToString();
                }
            }
        }
        private void CloseConnection()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                isConnect = false;
                foreach (Control control in tabPagePwm.Controls)
                    control.Enabled = false;
                //this.Text = "Ardman";
                buttonConnect.Text = "Connect";
                toolStripStatusLabel1.Text = "Ready";
                timerSerialPort.Stop();
                timerSerialPortCount = 0;
            }

        }

        private void timerSerialPort_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                //timerSerialPortCount = 0;
                textBoxPwmOut.AppendText("Reconnect..." + Environment.NewLine);
                OpenConnection();
            }
        }

        private void serialPort1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            MessageBox.Show("Pin Changed");
        }

        private void buttonPwmClearTextBox_Click(object sender, EventArgs e)
        {
            textBoxPwmOut.Text = "";
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPwmLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBoxPwmLogs.Checked)
                {

                    serialPort1.Write(logChar, 0, 1);
                    //char[] onChar = { '1' };
                    //serialPort1.Write(onChar, 0, 1);
                    serialPort1.Write("1");
                    //serialPort1.Write(logOnChar, 0, 2);
                    isLogging = true;
                    foreach (Control control in tabPagePwm.Controls)
                    {
                        if (control.Name == "textBoxPwmOut")
                            control.Enabled = true;
                    }
                    checkBoxPwmDebug.Enabled = true;
                }
                else
                {
                    serialPort1.Write(logChar, 0, 1);
                    //char[] offChar = { '2' };
                    //serialPort1.Write(offChar, 0, 1);
                    serialPort1.Write("0");
                    //serialPort1.Write(logOffChar, 0, 2);
                    isLogging = false;
                    foreach (Control control in tabPagePwm.Controls)
                    {
                        if (control.Name == "textBoxPwmOut")
                            control.Enabled = false;
                    }
                    checkBoxPwmDebug.Enabled = false;
                }

            }
        }

        private void checkBoxPwmDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnect)
            {

                if (checkBoxPwmDebug.Checked)
                {
                    serialPort1.Write(debugChar, 0, 1);
                    serialPort1.Write("1");
                    isDebugging = true;
                }
                else
                {
                    serialPort1.Write(debugChar, 0, 1);
                    serialPort1.Write("0");
                    isDebugging = false;
                }

            }
        }

        private void buttonPwmReset_Click(object sender, EventArgs e)
        {
            serialPort1.Write(resetChar, 0, 1);
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                DialogResult result = MessageBox.Show("Текущее соединение будет разорвано. Вы хотите продолжить?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (result == DialogResult.Yes)
                {
                    CloseConnection();

                }
                if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    MessageBox.Show("NoC");

                }
            }
        }

        private void comboBoxPwmRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            rate = comboBoxPwmRate.SelectedItem.ToString();
        }
    }
}
