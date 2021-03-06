﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web;
using System.Timers;

namespace Middleware
{
    public partial class FormMain : Form
    {

        #region classVariables

        SerialPort comDim = new SerialPort();
        SerialPort comSm = new SerialPort();
        private readonly HttpClient client = new HttpClient();
        List<byte> msgDim = new List<byte>();
        List<byte> msgSm = new List<byte>();

        string url = "";
        string status = "";
        string output = "";
        Color color;

        List<byte> msgBytesDim = new List<byte>();
        List<byte> msgBytesSm = new List<byte>();

        #endregion

        #region getData

        private String Cr()
        {
            return Character(ByteCr());
        }


        private String Etb()
        {
            return Character(ByteEtb());
        }

        private String Lf()
        {
            return Character(ByteLf());
        }

        private String Ack()
        {
            return Character(ByteAck());
        }

        private String Nak()
        {
            return Character(ByteNak());
        }

        private String Stx()
        {
            return Character(ByteStx());
        }

        private String Etx()
        {
            return Character(ByteEtx());
        }

        private String Enq()
        {
            return Character(ByteEnq());
        }

        public byte ByteEnq()
        {
            return 5;
        }

        public byte ByteStx()
        {
            return 2;
        }

        public byte ByteAck()
        {
            return 6;
        }

        public byte ByteEtx()
        {
            return 3;
        }

        public byte ByteEot()
        {
            return 4;
        }

        public byte ByteNak()
        {
            return 21;
        }


        public byte ByteFs()
        {
            return 28;
        }

        public byte ByteLf()
        {
            return 10;
        }

        public byte ByteCr()
        {
            return 13;
        }

        public byte ByteEtb()
        {
            return 23;
        }

        public byte ByteGs()
        {
            return 29;
        }

        public byte ByteRs()
        {
            return 30;
        }

        public byte ByteUs()
        {
            return 31;
        }

        #endregion

        #region mainFunctions

        private async Task SendDataToLimsAsync(List<byte> bytes, Analyzer machine)
        {
            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            String initialPoll        = "2 80 28 68 73 77 49 28 49 28 49 28 48 28 55 57 3 ";
            String conversationalPoll = "2 80 28 68 73 77 49 28 48 28 49 28 48 28 55 56 3 ";
            String noRequestPoll = "2+78+28+54+65+3+";

            //MessageBox.Show("|" + sendingStr + "|");

            if (sendingStr.Equals(initialPoll) || sendingStr.Equals(conversationalPoll))
            {
                
                List<byte> lstBytes = GetBytesFromMessage(noRequestPoll,true);
                Console.Write("lstBytes = " + lstBytes);
                if (lstBytes != null && lstBytes.Count > 0)
                {
                    byte[] temBytesToWrite = lstBytes.ToArray();
                    comDim.Write(temBytesToWrite, 0, temBytesToWrite.Length);
                }
                String temStatus = "";
                if (sendingStr == initialPoll)
                {
                    temStatus += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Received Initial Poll Message. No Request Message Sent." + Environment.NewLine;
                }
                else if (sendingStr == conversationalPoll)
                {
                    temStatus += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Received Conversational Poll Message. No Request Message Sent." + Environment.NewLine;
                }
                //MessageBox.Show(temStatus);
                status += temStatus;
                this.Invoke(new EventHandler(DisplayOutput));
            }
            else
            {
                #region sendingDataToLims

                string longurl = url + "faces/requests/mwapi.xhtml";
                var uriBuilder = new UriBuilder(longurl);

                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["machine"] = machine.ToString();
                query["username"] = txtUsername.Text;
                query["password"] = txtPassword.Text;
                query["msg"] = sendingStr;

                uriBuilder.Query = query.ToString();
                longurl = uriBuilder.ToString();

                status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Data to LIMS" + Environment.NewLine + longurl + Environment.NewLine;

                var response = await client.GetAsync(longurl);
                var responseString = await response.Content.ReadAsStringAsync();
                responseString = ExtractMessageFromHtml(responseString);

                if (responseString == "Error in LIMS Response. Please check.")
                {
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));

                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + " " + machine + " Error. Please send results again." + Environment.NewLine;
                    color = Color.Red;
                    this.Invoke(new EventHandler(DisplayOutput));
                    if (machine == Analyzer.Dimension)
                    {
                        comDim.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        comSm.Write(Nak());
                    }

                }
                else if (responseString.Contains("success=false"))
                {
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));

                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + " " + machine + " Error. Please send results again." + Environment.NewLine;
                    color = Color.Red;
                    this.Invoke(new EventHandler(DisplayOutput));
                    if (machine == Analyzer.Dimension)
                    {
                        comDim.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        comSm.Write(Nak());
                    }

                }
                else if (responseString.Contains("success=true"))
                {
                    Console.WriteLine("Success = true");
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));

                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh: mm:ss tt") + Environment.NewLine + " " + machine + " Results added. " + Environment.NewLine;
                    color = Color.Green;
                    this.Invoke(new EventHandler(DisplayOutput));
                    Console.WriteLine("machine = " + machine);
                    if (machine == Analyzer.Dimension)
                    {
                        List<byte> lstBytes = GetBytesFromMessage(responseString);
                        Console.Write("lstBytes = " + lstBytes);
                        if (lstBytes != null && lstBytes.Count > 0)
                        {
                            byte[] temBytesToWrite = lstBytes.ToArray();
                            comDim.Write(temBytesToWrite, 0, temBytesToWrite.Length);
                        }
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        comSm.Write(Ack());
                    }
                }
                else
                {
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh: mm:ss tt") + Environment.NewLine + " Can't send data from " + machine + " to LIMS. Please check LIMS." + Environment.NewLine;
                    color = Color.Red;
                    this.Invoke(new EventHandler(DisplayOutput));
                    if (machine == Analyzer.Dimension)
                    {
                        comDim.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        comSm.Write(Nak());
                    }
                }

                #endregion

            }

        }

        public List<byte> GetBytesFromMessage(String msg)
        {
            String[] temSs = msg.Split(Convert.ToChar(124));
            String temMsg = "";
            foreach (String temS in temSs)
            {
                Console.WriteLine("temS=" + temS);
                if (temS.Contains("toAnalyzer="))
                {
                    if (temS.Length > 11)
                    {
                        temMsg = temS.Substring(11, temS.Length - 11);
                        Console.WriteLine(temMsg);
                    }

                }
            }
            if (temMsg == "")
            {
                return null;
            }
            List<byte> bytesList = new List<byte>();
            String[] temBytesAsString = temMsg.Split(Convert.ToChar(43));
            foreach (String temS in temBytesAsString)
            {
                byte temByte;
                Console.WriteLine("temS=" + temS);
                try
                {
                    temByte = Byte.Parse(temS);
                }
                catch (Exception e)
                {
                    temByte = 0;
                }
                bytesList.Add(temByte);
            }
            return bytesList;
        }

        public List<byte> GetBytesFromMessage(String msg, Boolean bytesOnly)
        {
            List<byte> bytesList = new List<byte>();
            String[] temBytesAsString = msg.Split(Convert.ToChar(43));
            foreach (String temS in temBytesAsString)
            {
                byte temByte;
                Console.WriteLine("temS=" + temS);
                try
                {
                    temByte = Byte.Parse(temS);
                    bytesList.Add(temByte);
                }
                catch (Exception e)
                {
                    temByte = 0;
                }

            }
            return bytesList;
        }

        private void Com_DataReceived_Dim(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = comDim.BytesToRead;
            byte[] buffer = new byte[bytes];
            comDim.Read(buffer, 0, bytes);
            msgDim.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    comDim.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from Dimension. <ACK> sent." + Environment.NewLine;
                    msgDim = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from Dimension. " + Environment.NewLine;
                    msgDim = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteNak())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <NAK> from Dimension. " + Environment.NewLine;
                    msgDim = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    comDim.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from Dimension. <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msgDim) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msgDim, Analyzer.Dimension).Wait();
                    msgDim = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_Sm(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = comSm.BytesToRead;
            byte[] buffer = new byte[bytes];
            comSm.Read(buffer, 0, bytes);
            msgSm.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    comSm.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from SysMex. <ACK> sent." + Environment.NewLine;
                    msgSm = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from SysMex. " + Environment.NewLine;
                    msgSm = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    comSm.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from SysMex. <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msgSm) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msgSm, Analyzer.SysMex).Wait();
                    msgSm = new List<byte>();

                }
            }

        }

        #endregion

        #region supportiveFunctions

        private void DisplayText(object sender, EventArgs e)
        {
            txtStatus.Text = status;
        }

        private void DisplayOutput(object sender, EventArgs e)
        {
            int from = txtOutput.Text.Length;
            txtOutput.AppendText(output);
            int to = txtOutput.Text.Length;
            txtOutput.Select(from, (to - from));
            txtOutput.SelectionColor = color;
        }


        private String Character(int charNo)
        {
            char ack = (char)charNo;
            String m = ack.ToString();
            return m;
        }

        private byte[] StringsToBytes(String value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            return bytes;
        }

        private String ExtractMessageFromHtml(String html)
        {
            String s = html;
            int pFrom = s.IndexOf("#{") + "#{".Length;
            int pTo = s.LastIndexOf("}");
            String result = s.Substring(pFrom, pTo - pFrom);
            if (result.Length > 1500)
            {
                result = "Error in LIMS Response. Please check.";
            }
            return result;
        }

        private String BytesToString(List<byte> bytesToConvert)
        {
            Byte[] temBytes = bytesToConvert.ToArray();
            String temStr = "";
            temStr = Encoding.ASCII.GetString(temBytes, 0, temBytes.Length);
            return temStr;
        }

        #endregion

        #region FormEvents

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormDimensionSettings_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            cmbDimPort.Items.AddRange(ports);
            cmbDimPort.SelectedIndex = 0;


            cmbSysMexPort.Items.AddRange(ports);
            cmbSysMexPort.SelectedIndex = 0;
            BtnClose.Enabled = false;

            try
            {

           
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Middleware");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Dimension");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Sysmex");

                RegistryKey KeyMiddleware = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Middleware", true);
                RegistryKey KeyDimension = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Dimension", true);
                RegistryKey KeySysmex = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Sysmex", true);


                if (KeyMiddleware != null)
                {
                    txtUrl.Text = (String)KeyMiddleware.GetValue("url", "");
                }
                if (KeyDimension != null)
                {
                    cmbDimPort.Text = (String)KeyDimension.GetValue("port", "");
                }
                if (KeySysmex != null)
                {
                    cmbSysMexPort.Text = (String)KeySysmex.GetValue("port", "");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDimensionSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey KeyMiddleware = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Middleware", true);
            RegistryKey KeyDimension = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Dimension", true);
            RegistryKey KeySysmex = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Sysmex", true);

            KeyMiddleware.SetValue("url", txtUrl.Text);
            KeyDimension.SetValue("port", cmbDimPort.Text);
            KeySysmex.SetValue("port", cmbSysMexPort.Text);
        }

        private void BtnClearStatus_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            txtStatus.Text = "";
            msgDim = new List<Byte>();
            msgSm = new List<byte>();
            status = "";
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            BtnOpen.Enabled = true;
            BtnClose.Enabled = false;

            url = txtUrl.Text;

            if (chkSysmex.Checked)
            {

                try
                {
                    comSm.PortName = cmbSysMexPort.Text;
                    comSm.BaudRate = 9600;
                    comSm.DataBits = 8;
                    comSm.ReadBufferSize = 10000000;
                    comSm.StopBits = StopBits.One;
                    comSm.Parity = Parity.None;
                    comSm.DtrEnable = true;
                    comSm.RtsEnable = true;
                    comSm.Open();
                    status += "SysMex Port Opened";
                    txtStatus.Text = status;
                    MessageBox.Show("Connected", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    status += "Error in connecting";
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comSm.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_Sm);
                comSm.Write(Enq());
                status += "Enq Sent";
                txtStatus.Text = status;
            }

            if (chkDim.Checked)
            {

                try
                {
                    comDim.PortName = cmbDimPort.Text;
                    comDim.BaudRate = 9600;
                    comDim.DataBits = 8;
                    comDim.ReadBufferSize = 10000000;
                    comDim.StopBits = StopBits.One;
                    comDim.Parity = Parity.None;
                    comDim.DtrEnable = true;
                    comDim.RtsEnable = true;
                    comDim.Open();
                }
                catch (Exception ex)
                {
                    comSm.Close();
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comDim.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_Dim);
                comDim.Write(Enq());

            }


            BtnOpen.Enabled = false;
            BtnClose.Enabled = true;

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnOpen.Enabled = true;
            BtnClose.Enabled = false;
            try
            {
                comSm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                comDim.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
    }
}
