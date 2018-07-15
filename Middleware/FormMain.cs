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

        SerialPort com = new SerialPort();
        private readonly HttpClient client = new HttpClient();
        List<byte> message = new List<byte>();

        string url = "";
        string username = "";
        string password = "";
        string status = "";

        List<byte> messageInBytes = new List<byte>();


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

        private async Task SendDataToLimsAsync(List<byte> bytes)
        {
            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            string longurl = url + "faces/requests/mwapi.xhtml";
            var uriBuilder = new UriBuilder(longurl);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["username"] = txtUsername.Text;
            query["password"] = txtPassword.Text;
            query["machine"] = "Dimension";
            query["msg"] = sendingStr;

            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Data to LIMS" + Environment.NewLine + longurl + Environment.NewLine;

            var response = await client.GetAsync(longurl);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString = ExtractMessageFromHtml(responseString);

            if (responseString == "Error in LIMS Response. Please check.")
            {
                int from = txtOutput.Text.Length;
                txtOutput.AppendText(Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + "Error. Please send results again." + Environment.NewLine);
                int to = txtOutput.Text.Length;
                txtOutput.Select(from, (to - from));
                txtOutput.SelectionColor = Color.Red;
                com.Write(Nak());

            }
            else if (responseString.Contains("success=false"))
            {
                int from = txtOutput.Text.Length;
                txtOutput.AppendText(Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + ". Error. Please send results again." + responseString + Environment.NewLine);
                int to = txtOutput.Text.Length;
                txtOutput.Select(from, (to - from));
                txtOutput.SelectionColor = Color.Red;
                com.Write(Nak());
            }
            else
            {
                int from = txtOutput.Text.Length;
                txtOutput.AppendText(Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh: mm:ss tt") + Environment.NewLine + "Results added. " + responseString + Environment.NewLine);
                int to = txtOutput.Text.Length;
                txtOutput.Select(from, (to - from));
                txtOutput.SelectionColor = Color.Green;
                com.Write(Ack());
            }
            this.Invoke(new EventHandler(DisplayText));
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com.BytesToRead;
            byte[] buffer = new byte[bytes];
            com.Read(buffer, 0, bytes);
            message.AddRange(buffer);

            foreach (Byte b in buffer)
            {
                //status += (char)b;
                if (b == ByteEnq())
                {
                    com.Write(Ack());
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ENQ>. <ACK> sent." + Environment.NewLine;
                    message = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteAck())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received <ACK>." + Environment.NewLine;
                    message = new List<byte>();
                    this.Invoke(new EventHandler(DisplayText));
                }
                else if (b == ByteEot() || b == ByteEtx())
                {
                    status += DateTime.Now.ToString("dd/MMM/yy H:mm") + " Received a message from Analyzer." + Environment.NewLine;
                    status += BytesToString(message) + Environment.NewLine;
                    this.Invoke(new EventHandler(DisplayText));
                    SentToAnalyzer();
                    message = new List<byte>();
                    com.Write(Ack());
                }
            }

        }

        private async Task SentToAnalyzer()
        {
            await SendDataToLimsAsync(message);
            message = new List<byte>();
        }

        #endregion

        #region supportiveFunctions

        private void DisplayText(object sender, EventArgs e)
        {
            txtStatus.Text = status;
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
            cmbPort.Items.AddRange(ports);
            cmbPort.SelectedIndex = 0;
            BtnClose.Enabled = false;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Middleware");
            key = key.OpenSubKey("Middleware", true);


            key.CreateSubKey("Dimension");
            key = key.OpenSubKey("Dimension", true);

            if (key == null)
            {
                cmbPort.Text = "";
            }
            else
            {
                cmbPort.Text = (String)key.GetValue("Port");
                txtUrl.Text = (String)key.GetValue("Url", "");
            }
        }

        private void FormDimensionSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("Middleware");
            key = key.OpenSubKey("Middleware", true);
            key.CreateSubKey("Dimension");
            key = key.OpenSubKey("Dimension", true);
            key.SetValue("Port", cmbPort.Text);
            key.SetValue("Url", txtUrl.Text);
        }

        private void BtnClearStatus_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            txtStatus.Text = "";
            message = new List<Byte>();
            status = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnOpen.Enabled = true;
            BtnClose.Enabled = false;
            try
            {
                com.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            BtnOpen.Enabled = false;
            BtnClose.Enabled = true;
            url = txtUrl.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            try
            {
                com.PortName = cmbPort.Text;
                com.BaudRate = 9600;
                com.DataBits = 8;
                com.ReadBufferSize = 10000000;
                com.StopBits = StopBits.One;
                com.Parity = Parity.None;
                com.DtrEnable = true;
                com.RtsEnable = true;
                com.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            com.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            com.Write(Enq());
        }

        #endregion

    }
}
