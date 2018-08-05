using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardman
{
    public partial class FormArdman : Form
    {
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
                        SendCommand(commandsComboBoxPwm.Text.Substring(0,1));
                    }
                }
                catch
                {
                    MessageBox.Show("Недопустимый формат");
                }
            }
            else MessageBox.Show("Соединение не установлено");
        }

        private void textBoxPwmSet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonPwmSet_Click(new object(), new EventArgs());
        }

        private void comboBoxPwmMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPwmSet.Text = "";
            if (comboBoxPwmMode.SelectedItem.ToString() == "Duty")
            {
                buttonPwmSet.Text = "Set";
                labelPwmMode.Text = "%";
                commandsComboBoxPwm.Visible = false;
                textBoxPwmSet.Visible = true;
            }
            else if (comboBoxPwmMode.SelectedItem.ToString() == "Freq")
            {
                buttonPwmSet.Text = "Set";
                labelPwmMode.Text = "Hz";
                commandsComboBoxPwm.Visible = false;
                textBoxPwmSet.Visible = true;
            }
            else
            {
                buttonPwmSet.Text = "Send command";
                labelPwmMode.Text = "";
                textBoxPwmSet.Visible = false;
                //textBoxPwmSet.Invoke(new Action(() => textBoxPwmSet.Visible = false));
                commandsComboBoxPwm.Visible = true;


            }
        }

        private void buttonPwmClearTextBox_Click(object sender, EventArgs e)
        {
            textBoxPwmOut.Text = "";
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

        private void comboBoxPwmRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            rate = comboBoxPwmRate.SelectedItem.ToString();
        }

        public void SetDuty(int duty)
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

        public void SetFreq(double freq)
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

        private void PwmPlus()
        {
            if (duty < 100)
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
        }

        private void PwmMinus()
        {
            if (duty > 0)
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
        }

        private void FreqPlus()
        {
            if (freq < 8000000)
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
        }

        private void FreqMinus()
        {
            if (freq > 0)
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
        }

        private void SendCommand(string command)
        {
            serialPort1.Write(commandChar, 0, 1);
            serialPort1.Write(command);
        }

    }
}
