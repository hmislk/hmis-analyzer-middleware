using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Web;

namespace Middleware
{
    public partial class FormMain : Form
    {

        SerialPort com = new SerialPort();

        private readonly HttpClient client = new HttpClient();
        List<byte> temMessage = new List<byte>();
        List<byte> message = new List<byte>();

        string url = "";
        string username = "";
        string password = "";
        string status = "";

        int progressBarValue;

        List<byte> messageInBytes = new List<byte>();

        DateTime msgStartat;
        Boolean arrayListBlocked;
       
        private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com.BytesToRead;
            byte[] buffer = new byte[bytes];
            com.Read(buffer, 0, bytes);

            if (arrayListBlocked)
            {
                temMessage.AddRange(buffer);
            }
            else
            {
                arrayListBlocked = true;
                temMessage.AddRange(buffer);
                message.AddRange(temMessage);
                temMessage = new List<byte>();
                arrayListBlocked = false;
            }
           
        }


        private async Task sendDataToLimsAsync()
        {
            if (!arrayListBlocked)
            {
                arrayListBlocked = true;
                Boolean arrayEmpty = !message.Any();
                if(message!=null && !arrayEmpty)
                {
                    status += "Sending data LIMS" + Environment.NewLine;
                    await SendDataToLimsAsync(message);
                    this.Invoke(new EventHandler(DisplayText));
                }
                arrayListBlocked = false;
            }
            
           
            
        }


        private void com_DataReceivedWorking1(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com.BytesToRead;
            byte[] buffer = new byte[bytes];
            com.Read(buffer, 0, bytes);
            if (ContainEnd(buffer))
            {
                status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Message Received From Analyzer." + Environment.NewLine;
                temMessage.AddRange(buffer);
                message.AddRange(temMessage);
                String ts = "";
                foreach (byte b in temMessage)
                {
                    ts += b + " ";
                }
                status += ts + Environment.NewLine;
                SendDataToLimsAsync(temMessage);
                temMessage = new List<byte>();
                status += "End of a Message " + Environment.NewLine;
            }
            else
            {
                temMessage.AddRange(buffer);
                String ts = "";
                foreach (byte b in buffer)
                {
                    ts += b + "|";
                }
                status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Part of a Message " + ts + Environment.NewLine;
            }

            this.Invoke(new EventHandler(DisplayText));

        }


        private void com_DataReceivedOld(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com.BytesToRead;
            byte[] buffer = new byte[bytes];
            com.Read(buffer, 0, bytes);
            if (bytes == 1)
            {
                String temAscii = System.Text.Encoding.ASCII.GetString(new[] { buffer[0] });
                if (buffer[0] == byteEnq())
                {
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " ENQ Received" + Environment.NewLine;
                    com.Write(ASCII.ACK.ToString());
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " ACK Sent" + Environment.NewLine;
                }
                if (buffer[0] == byteAck())
                {
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Ack Received" + Environment.NewLine;
                }
            }
            else
            {
                if (ContainEnd(buffer))
                {
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Message Received From Analyzer." + Environment.NewLine;
                    temMessage.AddRange(buffer);
                    message.AddRange(temMessage);
                    status += bytesToString(temMessage) + Environment.NewLine;
                    SendDataToLimsAsync(temMessage);
                    temMessage = new List<byte>();
                    status += "End of a Message " + Environment.NewLine;
                    com.Write(Ack());
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " ACK sent to Analyzer." + Environment.NewLine;
                }
                else
                {
                    temMessage.AddRange(buffer);
                    String ts = "";
                    foreach (byte b in buffer)
                    {
                        ts += b + "|";
                    }
                    status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Part of a Message " + ts + Environment.NewLine;
                }
            }
            this.Invoke(new EventHandler(DisplayText));

        }

        public byte byteEnq()
        {
            return 5;
        }

        public byte byteStx()
        {
            return 2;
        }

        public byte byteAck()
        {
            return 6;
        }

        public byte byteEtx()
        {
            return 3;
        }

        public byte byteEot()
        {
            return 4;
        }

        public byte byteEob()
        {
            return 17;
        }

        public byte byteNak()
        {
            return 15;
        }


        private Boolean ContainEnd(Byte[] bytesToCheck)
        {
            foreach (Byte b in bytesToCheck)
            {
                if (b == byteEtx() || b == byteEot())
                {
                    return true;
                }
            }
            return false;
        }


        private async Task SendDataToLimsAsync(List<byte> bytes)
        {
            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            string longurl = url;
            var uriBuilder = new UriBuilder(longurl);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["username"] = txtUsername.Text;
            query["password"] = txtPassword.Text;
            query["machine"] = "SysMex";
            query["msg"] = sendingStr;

            status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Data to LIMS" + Environment.NewLine;

            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();

            status += longurl + Environment.NewLine;

            // var values = new Dictionary<string, string> { { "username", username }, { "password", password }, { "msg", msg } };
            // var content = new FormUrlEncodedContent(values);

            var response = await client.GetAsync(longurl);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString = ExtractMessageFromHtml(responseString);
            status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Received Data From LIMS" + Environment.NewLine;
            status += responseString + Environment.NewLine;
            com.Write(Stx() + responseString + Etx());
            status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Data to Analyzer" + Environment.NewLine;
            this.Invoke(new EventHandler(DisplayText));

        }


        #region functions



        private String Cr()
        {
            return Character(13);
        }


        private String Etb()
        {
            return Character(23);
        }

        private String Lf()
        {
            return Character(10);
        }

        private String Ack()
        {
            return Character(6);
        }

        private String Nak()
        {
            return Character(21);
        }

        private String Stx()
        {
            return Character(2);
        }

        private String Etx()
        {
            return Character(3);
        }

        private String Enq()
        {
            return Character(5);
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
            return result;
        }

        private String bytesToString(List<byte> bytesToConvert)
        {
            Byte[] temBytes = bytesToConvert.ToArray();
            String temStr = "";
            temStr = Encoding.ASCII.GetString(temBytes, 0, temBytes.Length);
            return temStr;
        }

        #endregion


        #region FormEvents

        private void DisplayText(object sender, EventArgs e)
        {
            DisplayText();
        }

        private void DisplayText()
        {
            txtStatus.Text = status;
            if (progressBarValue < 100)
            {
                progressBarValue++;
            }
            else
            {
                progressBarValue = 0;
            }
            progressBar1.Value = progressBarValue;
            progressBar1.Update();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormDimensionSettings_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            cmbPort.Items.AddRange(ports);
            cmbPort.SelectedIndex = 0;
            btnClose.Enabled = false;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Middleware");
            key = key.OpenSubKey("Middleware", true);


            key.CreateSubKey("SysMex");
            key = key.OpenSubKey("SysMex", true);

            progressBarValue = 0;

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


            key.CreateSubKey("SysMex");
            key = key.OpenSubKey("SysMex", true);

            key.SetValue("Port", cmbPort.Text);
            key.SetValue("Url", txtUrl.Text);

        }

        private void btnListStatus_Click(object sender, EventArgs e)
        {
            DisplayText();
        }

        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            message = new List<Byte>();
            temMessage = new List<Byte>();
            status = "";
            DisplayText();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            try
            {
                com.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion



        private void btnClearMessages_Click(object sender, EventArgs e)
        {

            status = "";
            DisplayText();
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            msgStartat = DateTime.Now;
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            url = txtUrl.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;
            try
            {
                com.PortName = cmbPort.Text;
                com.BaudRate = 9600;
                com.DataBits = 8;
                com.ReadBufferSize = 100000;
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
            com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((ex) =>
            {
                sendDataToLimsAsync();
            }, null, startTimeSpan, periodTimeSpan);
        }


        private void btnEnq_Click(object sender, EventArgs e)
        {
            if (com.IsOpen)
            {
                com.Write(Enq());
                status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Enq to Analyzer" + Environment.NewLine;
                this.Invoke(new EventHandler(DisplayText));
            }
        }
    }
}
