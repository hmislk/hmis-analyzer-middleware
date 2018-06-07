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
    public partial class FormDimensionSettings : Form
    {

        static SerialPort com = new SerialPort();
        static String receivedText = "";
        private static readonly HttpClient client = new HttpClient();
        static List<String> messageReceivedFromAnalyzerToBeProcessed = new List<string>();
        static List<String> messageReceivedFromLimsToBeProcessed = new List<string>();

        static string url = "";
        static string username = "";
        static string password = "";
        static string status = "";

        public FormDimensionSettings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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


            key.CreateSubKey("Dimention");
            key = key.OpenSubKey("Dimention", true);



            if (key == null)
            {
                cmbPort.Text = "";
            }
            else
            {
                cmbPort.Text = (String)key.GetValue("Port");
                txtBaudRate.Text = (String)key.GetValue("BaudRate", "9600");
                txtBitLength.Text = (String)key.GetValue("BitLength", "8");
                txtStopBits.Text = (String)key.GetValue("StopBits", "One");
                txtParity.Text = (String)key.GetValue("Parity", "NONE");
                txtUrl.Text = (String)key.GetValue("Url", "");
            }




        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            url = txtUrl.Text;
            username = txtUsername.Text;
            password = txtPassword.Text;

            try
            {
                com.PortName = cmbPort.Text;
                com.BaudRate = Int32.Parse(txtBaudRate.Text);
                com.DataBits = Int32.Parse(txtBitLength.Text);
                StopBits sb = StopBits.None;
                String strSb = txtStopBits.Text;

                if (strSb.Equals("None", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb = StopBits.None;
                }
                else if (strSb.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb = StopBits.One;
                }
                else if (strSb.Equals("One", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb = StopBits.One;
                }
                else if (strSb.Equals("OnePointFive", StringComparison.InvariantCultureIgnoreCase))
                {
                    sb = StopBits.OnePointFive;
                }
                else
                {
                    sb = StopBits.Two;
                }
                com.StopBits = sb;

                Parity p;
                String strParity = txtParity.Text;

                if (strSb.Equals("Even", StringComparison.InvariantCultureIgnoreCase))
                {
                    p = Parity.Even;
                }
                else if (strSb.Equals("Mark", StringComparison.InvariantCultureIgnoreCase))
                {
                    p = Parity.Mark;
                }
                else if (strSb.Equals("None", StringComparison.InvariantCultureIgnoreCase))
                {
                    p = Parity.None;
                }
                else if (strSb.Equals("Odd", StringComparison.InvariantCultureIgnoreCase))
                {
                    p = Parity.Odd;
                }
                else
                {
                    p = Parity.Space;
                }

                com.Parity = p;

                com.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (com.IsOpen)
                {
                    com.WriteLine(txtSend.Text + Environment.NewLine);
                    txtSend.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (com.IsOpen)
                {
                    txtReceive.Text += com.ReadExisting();
                    txtSend.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDimensionSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Middleware");
            key = key.OpenSubKey("Middleware", true);


            key.CreateSubKey("Dimention");
            key = key.OpenSubKey("Dimention", true);

            key.SetValue("Port", cmbPort.Text);
            key.SetValue("BaudRate", txtBaudRate.Text);
            key.SetValue("Parity", txtParity.Text);
            key.SetValue("StopBits", txtStopBits.Text);
            key.SetValue("Url", txtUrl.Text);

        }

        private static String resultAcceptanceMessage()
        {
            char stx = (char)2;
            char etx = (char)2;
            char fx = (char)63;

            String m = stx + "M" + fx + "A" + fx+fx +"E2" + etx;

            return m;
        }


        private static String noRequestMessage()
        {
            char stx = (char)2;
            char etx = (char)3;
            char fx = (char)63;
            //<STX>N<FS>6A<ETX>
            String m = stx + "N" + fx + "6A" + etx;
            return m;
        }

        private static String ack()
        {
            char ack = (char)6;
            String m = ack.ToString();
            return m;
        }

        private static void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            status += "Data Received from Port " + Environment.NewLine;
           
            try
            {
                String msg = com.ReadExisting();
                string originalMsg = msg;
                msg = stringToStringOfBytes(msg); 
                messageReceivedFromAnalyzerToBeProcessed.Add(msg);
                status += originalMsg + Environment.NewLine;
                //com.WriteLine(ack());
                //SendDataToLimsAsync().Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static String stringToStringOfBytes(String input)
        {
            String s = "";
            foreach (char c in input)
            {
                Console.WriteLine((int)c);
                s = s + "" + (int)c + "|";
            }
            return s;
        }

        private static async Task SendDataToLimsAsync()
        {
            status += "Trying to send Data to LIMS";
            foreach (String msg in messageReceivedFromAnalyzerToBeProcessed)
            {
                string longurl = url;
                var uriBuilder = new UriBuilder(longurl);
                
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["username"] = username;
                query["password"] = password;
                
                query["msg"] = stringToStringOfBytes(msg);

                status += msg;

                uriBuilder.Query = query.ToString();
                longurl = uriBuilder.ToString();

                // var values = new Dictionary<string, string> { { "username", username }, { "password", password }, { "msg", msg } };
                // var content = new FormUrlEncodedContent(values);

                var response = await client.GetAsync(longurl);
                var responseString = await response.Content.ReadAsStringAsync();
                messageReceivedFromLimsToBeProcessed.Add(responseString);
               
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (String s in messageReceivedFromAnalyzerToBeProcessed)
            {
                txtReceive.Text += s;
            }

        }

        private void btnSendNoRequest_Click(object sender, EventArgs e)
        {
            // { <DLE> , <STX> , "G" , <DLE> , <ETX> , 16 BIT CRC CCITT split into two bytes}
            byte[] byteToSend = new byte[] { 0x10, 0x02, 0x47, 0x10, 0x03, 0x42, 0x1F };
            com.Write(byteToSend, 0, byteToSend.Length);
        }

        private void btnLimsRequest_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshLims_Click(object sender, EventArgs e)
        {
            foreach (String s in messageReceivedFromLimsToBeProcessed)
            {
                txtReceive.Text += s;
            }
        }

        private void btnClearAnalyzer_Click(object sender, EventArgs e)
        {
            messageReceivedFromAnalyzerToBeProcessed = new List<string>();
            txtReceive.Text = "";
        }

        private void btnClearLims_Click(object sender, EventArgs e)
        {
            messageReceivedFromLimsToBeProcessed = new List<string>();
            txtReceive.Text = "";
        }

        private void btnListStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = txtStatus.Text + status;
        }

        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
        }

        private void btnAck_Click(object sender, EventArgs e)
        {
            try
            {
                if (com.IsOpen)
                {
                    com.Write(ack());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNr_Click(object sender, EventArgs e)
        {
            try
            {
                if (com.IsOpen)
                {
                    com.Write(noRequestMessage());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
