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
        char[] eepromFlashChar = { 'e' };
        //char[] logOnChar = { 'l', '1' };
        //char[] logOffChar = { 'l', '0' };

        bool isDebugging = false;
        bool isConnect = false;
        bool isLogging = false;
        int duty;
        double freq;
        int counterTextBoxPwmOut;
        string dutyString, freqString;
        string dutyReal, freqReal;
        string lastSelectedComPort;
        int timerSerialPortCount;

        int countRecive;

        ComboBox commandsComboBoxPwm;

        TextBox textBoxFake;

        //Constructor
        public FormArdman()
        {
            commandsComboBoxPwm = new ComboBox();
            

            InitializeComponent();

            //textBoxFake = new TextBox();
            ////textBoxFake.Multiline = true;
            ////this.textBoxFake.Location = new System.Drawing.Point(237, 24);
            ////this.textBoxFake.Size = new System.Drawing.Size(272, 201);
            ////this.textBoxFake.TabIndex = 10;
            //textBoxFake.Visible = false;
            //this.tabPagePwm.Controls.Add(textBoxFake);
            //Task.Factory.StartNew(() => textBoxPwmOut.DataBindings.Add("Text", textBoxFake, "Text"));


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
            

            string[] commands = new string[] {"reboot","eeprom", "sleep", "test" };
            commandsComboBoxPwm.DataSource = commands;
            commandsComboBoxPwm.Location = textBoxPwmSet.Location;
            commandsComboBoxPwm.Margin = textBoxPwmSet.Margin;
            commandsComboBoxPwm.Size = textBoxPwmSet.Size;
            commandsComboBoxPwm.Visible = false;
            this.tabPagePwm.Controls.Add(commandsComboBoxPwm);

            
        }
               

        //Methods
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
            countRecive++;
            countReciveLabel.Invoke(new Action(() => countReciveLabel.Text = countRecive.ToString()));
            isLogging = true;
            int incomingByte = serialPort1.ReadChar();
            //serialPort1.ReadLine();             //!!!Чтение лишнего байта. Необходимо для корректного считывания

            if (incomingByte == 'l')
            {
                //Необходимо соблюдать прием всех строк, иначе будут ошибки приема
                counterTextBoxPwmOut++;
                freqString = serialPort1.ReadLine();
                dutyString = serialPort1.ReadLine();
                ///                
                freqReal = serialPort1.ReadLine();
                dutyReal = serialPort1.ReadLine();

                labelPwmDutyValue.Invoke(new Action(() => labelPwmDutyValue.Text = dutyString));
                labelPwmFreqValue.Invoke(new Action(() => labelPwmFreqValue.Text = freqString));
                if (counterTextBoxPwmOut > 1)
                {
                    if (isLogging)
                    {
                        
                        textBoxPwmOut.Invoke(new Action(() =>
                        {
                            textBoxPwmOut.AppendText("Real Freq: " + freqReal + Environment.NewLine);
                            textBoxPwmOut.AppendText("Real Duty: " + dutyReal + Environment.NewLine);
                        }));
                    }
                    //Console.WriteLine(icr);
                    counterTextBoxPwmOut = 0;
                }
                try
                {
                    freq = Convert.ToDouble(freqString.Substring(0, freqString.Length - 4));
                    duty = Convert.ToInt32(dutyString);
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    textBoxPwmOut.Invoke(new Action(() => textBoxPwmOut.AppendText("Недопустимое значение принятых данных \n")));
                }
            

            }
            else if (incomingByte == 'd')
            {
                //string debugString = serialPort1.ReadExisting();
                string debugString = serialPort1.ReadLine();

                //textBoxFake.Invoke(new Action(() => textBoxFake.AppendText(debugString + Environment.NewLine)));
                textBoxPwmOut.Invoke(new Action(() =>
                {
                    //if (isDebugging)
                    textBoxPwmOut.AppendText(debugString + Environment.NewLine);
                }));
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
