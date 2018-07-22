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
        //int[] baudRate = { 9600, 115200 };
        public string[] comPorts;
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
        string lastSelectedComPort;

        int timerSerialPortCount;


        public FormArdman()
        {
            InitializeComponent();

            this.Text = "Ardman";
            rate = "x1";
            labelPwmMode.Text = "Hz";
            //Выключаем контролы
            foreach (Control control in tabPagePwm.Controls)
                control.Enabled = false;
            //Поиск доступных Com портов
            //comPorts = System.IO.Ports.SerialPort.GetPortNames();
            //Array.Reverse(comPorts);
            comboBoxComPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames();  
            comboBoxComPorts.SelectedIndex = 0;
            lastSelectedComPort = comboBoxComPorts.SelectedItem.ToString();
            comboBoxPwmMode.SelectedIndex = 0;
            comboBoxPwmRate.SelectedIndex = 0;
            comboBoxBaud.SelectedIndex = 0;
            timerSerialPortCount = 0;
            timerUpdateComPorts.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {                
                serialPort1.Close();
            }
            Application.Exit();
        }

        private void buttonRefreshPorts_Click(object sender, EventArgs e)
        {
            //comboBoxPorts.Items.Clear();
            //comboBoxPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            //Array.Reverse(comPorts);
            comboBoxComPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxComPorts.SelectedItem = lastSelectedComPort;
            //if (comboBoxPorts.Items.Count == 0)
            //    comboBoxPorts.Text = "";
            //else
            //    comboBoxPorts.Text = comboBoxPorts.Items[0].ToString();
            //comboBoxPorts.Update();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                CloseConnection();
            }
            else
            {
                if (comboBoxComPorts.Items.Count > 0)
                    serialPort1.PortName = comboBoxComPorts.SelectedItem.ToString();
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
                    try
                    {

                        toolStripStatusLabel1.Text = "Connected on " + comboBoxComPorts.SelectedItem.ToString();
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
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

        private void timerUpdateComPorts_Tick(object sender, EventArgs e)
        {
            comboBoxComPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxComPorts.SelectedItem = lastSelectedComPort;
            //if (comboBoxPorts.Items.Count < System.IO.Ports.SerialPort.GetPortNames().Count())
                //comboBoxPorts.Items.Add(System.IO.Ports.SerialPort.GetPortNames()[System.IO.Ports.SerialPort.GetPortNames().Count() - 1]);
            //comboBoxPorts.Items.Clear();
            //comboBoxPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void comboBoxPorts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lastSelectedComPort = comboBoxComPorts.SelectedItem.ToString();
            //if (!timerUpdateComPorts.Enabled)
                //timerUpdateComPorts.Start();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
