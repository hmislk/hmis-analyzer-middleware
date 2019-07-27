using Microsoft.Win32;
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

        SerialPort com1 = new SerialPort();
        SerialPort com2 = new SerialPort();
        SerialPort com3 = new SerialPort();
        SerialPort com4 = new SerialPort();
        SerialPort com5 = new SerialPort();
        SerialPort com6 = new SerialPort();

        private readonly HttpClient client = new HttpClient();
        List<byte> msg1 = new List<byte>();
        List<byte> msg2 = new List<byte>();
        List<byte> msg3 = new List<byte>();
        List<byte> msg4 = new List<byte>();
        List<byte> msg5 = new List<byte>();
        List<byte> msg6 = new List<byte>();

        string url = "";
        string status = "";
        string output = "";
        string portStatus = "";
        Color color;

        List<byte> msgBytes1 = new List<byte>();
        List<byte> msgBytes2 = new List<byte>();
        List<byte> msgBytes3 = new List<byte>();
        List<byte> msgBytes4 = new List<byte>();
        List<byte> msgBytes5 = new List<byte>();
        List<byte> msgBytes6 = new List<byte>();

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

        private async Task SendRequestToLimsAsync(List<byte> bytes, String machine, SerialPort com)
        {

            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            String initialPoll = "2 80 28 68 73 77 49 28 49 28 49 28 48 28 55 57 3 ";
            String conversationalPoll = "2 80 28 68 73 77 49 28 48 28 49 28 48 28 55 56 3 ";
            String noRequestPoll = "2+78+28+54+65+3+";

            //MessageBox.Show("|" + sendingStr + "|");

            if (sendingStr.Equals(initialPoll) || sendingStr.Equals(conversationalPoll))
            {

                List<byte> lstBytes = GetBytesFromMessage(noRequestPoll, true);
                Console.Write("lstBytes = " + lstBytes);
                if (lstBytes != null && lstBytes.Count > 0)
                {
                    byte[] temBytesToWrite = lstBytes.ToArray();
                    com1.Write(temBytesToWrite, 0, temBytesToWrite.Length);
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

                    com2.Write(Nak());


                }
                else if (responseString.Contains("success=false"))
                {
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));

                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + " " + machine + " Error. Please send results again." + Environment.NewLine;
                    color = Color.Red;
                    this.Invoke(new EventHandler(DisplayOutput));
                    com.Write(Nak());
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

                    List<byte> lstBytes = GetBytesFromMessage(responseString);
                    Console.Write("lstBytes = " + lstBytes);
                    if (lstBytes != null && lstBytes.Count > 0)
                    {
                        byte[] temBytesToWrite = lstBytes.ToArray();
                        com.Write(temBytesToWrite, 0, temBytesToWrite.Length);
                    }
                }
                else
                {
                    status += responseString + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    output = Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh: mm:ss tt") + Environment.NewLine + " Can't send data from " + machine + " to LIMS. Please check LIMS." + Environment.NewLine;
                    color = Color.Red;
                    this.Invoke(new EventHandler(DisplayOutput));
                    com.Write(Nak());
                }

                #endregion

            }

        }



        [Obsolete("SendDataToLimsAsync is deprecated, please use SendRequestToLimsAsync instead.")]
        private async Task SendDataToLimsAsync(List<byte> bytes, Analyzer machine)
        {
            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            String initialPoll = "2 80 28 68 73 77 49 28 49 28 49 28 48 28 55 57 3 ";
            String conversationalPoll = "2 80 28 68 73 77 49 28 48 28 49 28 48 28 55 56 3 ";
            String noRequestPoll = "2+78+28+54+65+3+";

            //MessageBox.Show("|" + sendingStr + "|");

            if (sendingStr.Equals(initialPoll) || sendingStr.Equals(conversationalPoll))
            {

                List<byte> lstBytes = GetBytesFromMessage(noRequestPoll, true);
                Console.Write("lstBytes = " + lstBytes);
                if (lstBytes != null && lstBytes.Count > 0)
                {
                    byte[] temBytesToWrite = lstBytes.ToArray();
                    com1.Write(temBytesToWrite, 0, temBytesToWrite.Length);
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
                        com2.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        com1.Write(Nak());
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
                        com2.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        com1.Write(Nak());
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
                            com2.Write(temBytesToWrite, 0, temBytesToWrite.Length);
                        }
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        com1.Write(Ack());
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
                        com2.Write(Nak());
                    }
                    else if (machine == Analyzer.SysMex)
                    {
                        com2.Write(Nak());
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

        private void Com_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com1.BytesToRead;
            byte[] buffer = new byte[bytes];
            com1.Read(buffer, 0, bytes);
            msg1.AddRange(buffer);

            foreach (Byte b in buffer)
            {

                if (b == ByteEnq())
                {
                    com1.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from " + txtAnalyzer1.Text + ". <ACK> sent." + Environment.NewLine;
                    msg1 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer1.Text + ". " + Environment.NewLine;
                    msg1 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteNak())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <NAK> from  " + txtAnalyzer1.Text + ". " + Environment.NewLine;
                    msg1 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com1.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer1.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg1) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                   // SendRequestToLimsAsync(msg1, txtAnalyzer1.Text, com1).Wait();
                    msg1 = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_2(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com2.BytesToRead;
            byte[] buffer = new byte[bytes];
            com2.Read(buffer, 0, bytes);
            msg2.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com2.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from " + txtAnalyzer2.Text + " <ACK> sent." + Environment.NewLine;
                    msg2 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer2.Text + ". " + Environment.NewLine;
                    msg2 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com2.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer2.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg2) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendRequestToLimsAsync(msg2, txtAnalyzer2.Text, com2).Wait();
                    msg2 = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_3(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com3.BytesToRead;
            byte[] buffer = new byte[bytes];
            com3.Read(buffer, 0, bytes);
            msg3.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com3.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from  " + txtAnalyzer3.Text + ". <ACK> sent." + Environment.NewLine;
                    msg3 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer3.Text + ". " + Environment.NewLine;
                    msg3 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteNak())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <NAK> from  " + txtAnalyzer3.Text + ". " + Environment.NewLine;
                    msg3 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com3.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer3.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg3) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msg3, Analyzer.Dimension).Wait();
                    msg3 = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_4(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com4.BytesToRead;
            byte[] buffer = new byte[bytes];
            com4.Read(buffer, 0, bytes);
            msg4.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com4.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from  " + txtAnalyzer4.Text + ". <ACK> sent." + Environment.NewLine;
                    msg4 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer4.Text + ". " + Environment.NewLine;
                    msg4 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com4.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer2.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg2) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msg2, Analyzer.SysMex).Wait();
                    msg4 = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_5(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com5.BytesToRead;
            byte[] buffer = new byte[bytes];
            com5.Read(buffer, 0, bytes);
            msg5.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com5.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from  " + txtAnalyzer5.Text + ". <ACK> sent." + Environment.NewLine;
                    msg5 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer5.Text + ". " + Environment.NewLine;
                    msg5 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteNak())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <NAK> from  " + txtAnalyzer5.Text + ". " + Environment.NewLine;
                    msg5 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com5.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer5.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg1) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msg1, Analyzer.Dimension).Wait();
                    msg1 = new List<byte>();

                }
            }

        }

        private void Com_DataReceived_6(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com6.BytesToRead;
            byte[] buffer = new byte[bytes];
            com6.Read(buffer, 0, bytes);
            msg6.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com6.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ> from  " + txtAnalyzer6.Text + ". <ACK> sent." + Environment.NewLine;
                    msg6 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK> from  " + txtAnalyzer6.Text + ". " + Environment.NewLine;
                    msg6 = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    com6.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from  " + txtAnalyzer6.Text + ". <ACK> sent." + Environment.NewLine;
                    status += BytesToString(msg2) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SendDataToLimsAsync(msg2, Analyzer.SysMex).Wait();
                    msg6 = new List<byte>();

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


            cmbPort1.Items.AddRange(ports);
            cmbPort1.SelectedIndex = 0;

            cmbPort2.Items.AddRange(ports);
            cmbPort2.SelectedIndex = 0;

            cmbPort3.Items.AddRange(ports);
            cmbPort3.SelectedIndex = 0;

            cmbPort4.Items.AddRange(ports);
            cmbPort4.SelectedIndex = 0;

            cmbPort5.Items.AddRange(ports);
            cmbPort5.SelectedIndex = 0;

            cmbPort6.Items.AddRange(ports);
            cmbPort6.SelectedIndex = 0;




            try
            {


                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Middleware");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer1");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer2");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer3");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer4");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer5");
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\SSS\\Middleware\\Analyzer6");

                RegistryKey KeyMiddleware = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Middleware", true);

                RegistryKey Analyzer1 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer1", true);

                RegistryKey Analyzer2 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer2", true);

                RegistryKey Analyzer3 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer3", true);

                RegistryKey Analyzer4 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer4", true);

                RegistryKey Analyzer5 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer5", true);

                RegistryKey Analyzer6 = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\SSS\\Middleware\\Analyzer6", true);


                if (KeyMiddleware != null)
                {
                    txtUrl.Text = (String)KeyMiddleware.GetValue("url", "");
                }
                if (Analyzer1 != null)
                {
                    cmbPort1.Text = (String)Analyzer1.GetValue("port", "");
                    txtAnalyzer1.Text = (String)Analyzer1.GetValue("name", "");
                }
                if (Analyzer2 != null)
                {
                    cmbPort2.Text = (String)Analyzer2.GetValue("port", "");
                    txtAnalyzer2.Text = (String)Analyzer2.GetValue("name", "");
                }
                if (Analyzer3 != null)
                {
                    cmbPort3.Text = (String)Analyzer3.GetValue("port", "");
                    txtAnalyzer3.Text = (String)Analyzer3.GetValue("name", "");
                }
                if (Analyzer4 != null)
                {
                    cmbPort4.Text = (String)Analyzer4.GetValue("port", "");
                    txtAnalyzer4.Text = (String)Analyzer4.GetValue("name", "");
                }
                if (Analyzer5 != null)
                {
                    cmbPort5.Text = (String)Analyzer5.GetValue("port", "");
                    txtAnalyzer5.Text = (String)Analyzer5.GetValue("name", "");
                }
                if (Analyzer6 != null)
                {
                    cmbPort6.Text = (String)Analyzer6.GetValue("port", "");
                    txtAnalyzer6.Text = (String)Analyzer6.GetValue("name", "");
                }



            }
            catch (Exception er)
            {
                MessageBox.Show("Error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            portStatus = "No Ports Open Yet.";
            txtPortStatus.Text = portStatus;

        }

        private void FormDimensionSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey KeyLimsUrl = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Middleware", true);

            RegistryKey Analyzer1 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer1", true);
            RegistryKey Analyzer2 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer2", true);
            RegistryKey Analyzer3 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer3", true);
            RegistryKey Analyzer4 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer4", true);
            RegistryKey Analyzer5 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer5", true);
            RegistryKey Analyzer6 = Registry.CurrentUser.OpenSubKey
                        ("SOFTWARE\\SSS\\Middleware\\Analyzer6", true);


            KeyLimsUrl.SetValue("url", txtUrl.Text);

            Analyzer1.SetValue("port", cmbPort1.Text);
            Analyzer2.SetValue("port", cmbPort2.Text);
            Analyzer3.SetValue("port", cmbPort3.Text);
            Analyzer4.SetValue("port", cmbPort4.Text);
            Analyzer5.SetValue("port", cmbPort5.Text);
            Analyzer6.SetValue("port", cmbPort6.Text);

            Analyzer1.SetValue("name", txtAnalyzer1.Text);
            Analyzer2.SetValue("name", txtAnalyzer2.Text);
            Analyzer3.SetValue("name", txtAnalyzer3.Text);
            Analyzer4.SetValue("name", txtAnalyzer4.Text);
            Analyzer5.SetValue("name", txtAnalyzer5.Text);
            Analyzer6.SetValue("name", txtAnalyzer6.Text);

        }

        private void BtnClearStatus_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            txtStatus.Text = "";
            msg1 = new List<Byte>();
            msg2 = new List<byte>();
            msg3 = new List<byte>();
            msg4 = new List<byte>();
            msg5 = new List<byte>();
            msg6 = new List<byte>();
            status = "";
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {

            portStatus = "";

            url = txtUrl.Text;

            if (!cmbPort1.Text.Equals("") && !txtAnalyzer1.Text.Equals(""))
            {

                try
                {
                    com1.PortName = cmbPort1.Text;
                    com1.BaudRate = 9600;
                    com1.DataBits = 8;
                    com1.ReadBufferSize = 10000000;
                    com1.StopBits = StopBits.One;
                    com1.Parity = Parity.None;
                    com1.DtrEnable = true;
                    com1.RtsEnable = true;
                    com1.Open();
                    status += "Port One Opened";
                    txtStatus.Text = status;
                    MessageBox.Show("Connected", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    portStatus += cmbPort1.Text + " is Open.";
                    com1.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_1);
                    com1.Write(Enq());
                }
                catch (Exception ex)
                {
                    portStatus += cmbPort1.Text + " can NOT Open. " + ex.Message;
                }

            }

            if (!cmbPort2.Text.Equals("") && !txtAnalyzer2.Text.Equals(""))
            {
                try
                {
                    com2.PortName = cmbPort2.Text;
                    com2.BaudRate = 9600;
                    com2.DataBits = 8;
                    com2.ReadBufferSize = 10000000;
                    com2.StopBits = StopBits.One;
                    com2.Parity = Parity.None;
                    com2.DtrEnable = true;
                    com2.RtsEnable = true;
                    com2.Open();
                    portStatus += Environment.NewLine + cmbPort2.Text + " is Open";
                    com2.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_2);
                    com2.Write(Enq());
                }
                catch (Exception ex)
                {
                    portStatus += Environment.NewLine + cmbPort2.Text + " can NOT Open. Aborting Connection. Please retry." + ex.Message;

                }


            }

            if (!cmbPort3.Text.Equals("") && !txtAnalyzer3.Text.Equals(""))
            {

                try
                {
                    com3.PortName = cmbPort3.Text;
                    com3.BaudRate = 9600;
                    com3.DataBits = 8;
                    com3.ReadBufferSize = 10000000;
                    com3.StopBits = StopBits.One;
                    com3.Parity = Parity.None;
                    com3.DtrEnable = true;
                    com3.RtsEnable = true;
                    com3.Open();
                    portStatus += Environment.NewLine + cmbPort3.Text + " is Open.";
                    com3.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_3);
                    com3.Write(Enq());
                }
                catch (Exception ex)
                {
                    portStatus += Environment.NewLine + cmbPort3.Text + " can NOT Open. Aborting Connection. Please retry." + ex.Message;

                }


            }

            if (!cmbPort4.Text.Equals("") && !txtAnalyzer4.Text.Equals(""))
            {

                try
                {
                    com4.PortName = cmbPort4.Text;
                    com4.BaudRate = 9600;
                    com4.DataBits = 8;
                    com4.ReadBufferSize = 10000000;
                    com4.StopBits = StopBits.One;
                    com4.Parity = Parity.None;
                    com4.DtrEnable = true;
                    com4.RtsEnable = true;
                    com4.Open();
                    portStatus += Environment.NewLine + cmbPort4.Text + " is Open.";
                    com4.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_4);
                    com4.Write(Enq());
                }
                catch (Exception ex)
                {
                    portStatus += Environment.NewLine + cmbPort4.Text + " can NOT Open. Aborting Connection. Please retry." + ex.Message;

                }


            }

            if (!cmbPort5.Text.Equals("") && !txtAnalyzer5.Text.Equals(""))
            {

                try
                {
                    com5.PortName = cmbPort5.Text;
                    com5.BaudRate = 9600;
                    com5.DataBits = 8;
                    com5.ReadBufferSize = 10000000;
                    com5.StopBits = StopBits.One;
                    com5.Parity = Parity.None;
                    com5.DtrEnable = true;
                    com5.RtsEnable = true;
                    com5.Open();
                    com5.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_5);
                    com5.Write(Enq());
                    portStatus += Environment.NewLine + cmbPort5.Text + " is Open.";

                }
                catch (Exception ex)
                {
                    portStatus += Environment.NewLine + cmbPort5.Text + " can NOT Open. Aborting Connection. Please retry." + ex.Message;

                }


            }

            if (!cmbPort6.Text.Equals("") && !txtAnalyzer6.Text.Equals(""))
            {

                try
                {
                    com6.PortName = cmbPort6.Text;
                    com6.BaudRate = 9600;
                    com6.DataBits = 8;
                    com6.ReadBufferSize = 10000000;
                    com6.StopBits = StopBits.One;
                    com6.Parity = Parity.None;
                    com6.DtrEnable = true;
                    com6.RtsEnable = true;
                    com6.Open();
                    com6.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived_6);
                    com6.Write(Enq());
                    portStatus += Environment.NewLine + cmbPort6.Text + " is Open.";
                }
                catch (Exception ex)
                {
                    portStatus += Environment.NewLine + cmbPort6.Text + " can NOT Open. Aborting Connection. Please retry." + ex.Message;

                }


            }

            txtPortStatus.Text = portStatus;


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            portStatus = "";
            try
            {
                if (com1.IsOpen)
                {
                    com1.Close();
                    portStatus += cmbPort1.Text + " closed.";

                }
                if (com2.IsOpen)
                {
                    com2.Close();
                    portStatus += Environment.NewLine + cmbPort2.Text + " closed.";
                }
                if (com3.IsOpen)
                {
                    com3.Close();
                    portStatus += Environment.NewLine + cmbPort3.Text + " closed.";
                }
                if (com4.IsOpen)
                {
                    com4.Close();
                    portStatus += Environment.NewLine + cmbPort4.Text + " closed.";
                }
                if (com5.IsOpen)
                {
                    com5.Close();
                    portStatus += Environment.NewLine + cmbPort5.Text + " closed.";
                }
                if (com6.IsOpen)
                {
                    com6.Close();
                    portStatus += Environment.NewLine + cmbPort6.Text + " closed.";
                }
                MessageBox.Show("All Opend Ports were closed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPortStatus.Text = portStatus;

        }

        private void btnEnq1_Click(object sender, EventArgs e)
        {
            if (com1.IsOpen)
            {
                String s = Stx() + txtCmd1 + Etx();
                com1.Write(s);
            }
        }

        private void btnEnq3_Click(object sender, EventArgs e)
        {
            if (com3.IsOpen)
            {
                com3.Write(Enq());
            }
        }

        private void btnEnq2_Click(object sender, EventArgs e)
        {
            if (com2.IsOpen)
            {
                com2.Write(Enq());
            }

        }

        private void btnEnq4_Click(object sender, EventArgs e)
        {
            if (com4.IsOpen)
            {
                com4.Write(Enq());
            }
        }

        private void btnEnq5_Click(object sender, EventArgs e)
        {
            if (com5.IsOpen)
            {
                com5.Write(Enq());
            }
        }

        private void btnEnq6_Click(object sender, EventArgs e)
        {
            if (com6.IsOpen)
            {
                com6.Write(Enq());
            }
        }

        #endregion




    }
}
