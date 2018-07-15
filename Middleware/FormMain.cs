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
using System;
using System.Timers;

namespace Middleware
{
    public partial class FormMain : Form
    {
        private System.Timers.Timer aTimer;

        SerialPort com = new SerialPort();

        private readonly HttpClient client = new HttpClient();
        List<byte> temMessage = new List<byte>();
        List<byte> message = new List<byte>();

        string url = "";
        string username = "";
        string password = "";
        string status = "";

        List<byte> messageInBytes = new List<byte>();

        DateTime msgStartat;
        Boolean arrayListBlocked;

        private async void OnTimedEventAsync(Object source, ElapsedEventArgs e)
        {
            Boolean arrayListIsEmpty = !message.Any();
            if (message == null || arrayListIsEmpty)
            {
                return;
            }
            if (!arrayListBlocked)
            {
                arrayListBlocked = true;
                await SendDataToLimsAsync(message);
                message = new List<byte>();
                this.Invoke(new EventHandler(DisplayText));
                arrayListBlocked = false;
            }
        }

        private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = com.BytesToRead;
            byte[] buffer = new byte[bytes];
            com.Read(buffer, 0, bytes);

         

            foreach (Byte b in buffer)
            {
                status += (char)b;
                if (b == 3)
                {
                    com.Write(Ack());

                }
            }
          

            if (arrayListBlocked)
            {
                Console.WriteLine("Array List Blocked.");
                temMessage.AddRange(buffer);
            }
            else
            {
                Console.WriteLine("Array List Not Blocked.");
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
                if (message != null && !arrayEmpty && message.Count>199)
                {
                    await SendDataToLimsAsync(message);
                    message = new List<byte>();
                }
                arrayListBlocked = false;
            }
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


        private async Task SendDataToLimsAsync(List<byte> bytes)
        {
            String sendingStr = "";
            foreach (byte b in bytes)
            {
                sendingStr += b + " ";
            }

            string longurl = url +"faces/requests/mwapi.xhtml";
            var uriBuilder = new UriBuilder(longurl);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["username"] = txtUsername.Text;
            query["password"] = txtPassword.Text;
            query["machine"] = "SysMex";
            query["msg"] = sendingStr;
           
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            status += DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + " Sending Data to LIMS" + Environment.NewLine + longurl + Environment.NewLine;

            var response = await client.GetAsync(longurl);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString = ExtractMessageFromHtml(responseString);

            if(responseString== "Error in LIMS Response. Please check.")
            {
                int from = txtStatus.Text.Length;
                txtStatus.AppendText(Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") +  Environment.NewLine +  "Error. Please send results again." + Environment.NewLine);
                int to = txtStatus.Text.Length;
                txtStatus.Select(from, (to - from));
                txtStatus.SelectionColor = Color.Red;
                com.Write(Nak());

            }else if (responseString.Contains("success=false"))
            {
                int from = txtStatus.Text.Length;
                txtStatus.AppendText(Environment.NewLine + DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt") + Environment.NewLine + ". Error. Please send results again." + responseString + Environment.NewLine);
                int to = txtStatus.Text.Length;
                txtStatus.Select(from, (to - from));
                txtStatus.SelectionColor = Color.Red;
                com.Write(Nak());
            }
            else
            {
                int from = txtStatus.Text.Length;
                txtStatus.AppendText(Environment.NewLine +  DateTime.Now.ToString("dd MMM yyyy hh: mm:ss tt") + Environment.NewLine + "Results added. " + responseString + Environment.NewLine);
                int to = txtStatus.Text.Length;
                txtStatus.Select(from, (to - from));
                txtStatus.SelectionColor = Color.Green;
                com.Write(Ack());
            }
            com.DiscardInBuffer();
            com.DiscardOutBuffer();
         
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
            if (result.Length > 500)
            {
                result = "Error in LIMS Response. Please check.";
            }
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
            txtMessage.Text = status;
        }

        private void DisplayText()
        {
            txtMessage.Text = status;
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

        
        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
            txtMessage.Text = "";
            message = new List<Byte>();
            temMessage = new List<Byte>();
            status = "";
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
            txtStatus.Text = "";
            txtMessage.Text = "";
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
            com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
            SetTimer();


        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEventAsync;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
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
