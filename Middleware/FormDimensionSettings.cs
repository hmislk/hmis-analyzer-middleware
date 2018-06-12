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
        static String previousMessage = "";
        static String nextMessage = "";
        private static readonly HttpClient client = new HttpClient();
        static List<String> messageReceivedFromAnalyzerToBeProcessed = new List<string>();
        static List<String> messageReceivedFromLimsToBeProcessed = new List<string>();

        static string url = "";
        static string username = "";
        static string password = "";
        static string status = "";
        List<String> messagesToSentToLims;
        List<String> messageSentToLims;

        static String messagesString;
        static String messagesBinary;

        static List<byte> messageInBytes = new List<byte>();

        private static byte _terminator = 0x4;
        private static string tString = string.Empty;

        private static void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            Console.WriteLine("Data Received from Port " + Environment.NewLine );
            try
            {


                byte[] buffer = new byte[com.ReadBufferSize];

                //There is no accurate method for checking how many bytes are read 
                //unless you check the return from the Read method 
                int bytesRead = com.Read(buffer, 0, buffer.Length);

                //For the example assume the data we are received is ASCII data. 
                tString += Encoding.ASCII.GetString(buffer, 0, bytesRead);
                //Check if string contains the terminator  
                if (tString.IndexOf((char)_terminator) > -1)
                {
                    //If tString does contain terminator we cannot assume that it is the last character received 
                    string workingString = tString.Substring(0, tString.IndexOf((char)_terminator));
                    //Remove the data up to the terminator from tString 
                    tString = tString.Substring(tString.IndexOf((char)_terminator));
                    //Do something with workingString 
                    Console.WriteLine(workingString);
                }



          //      String msg = "";

                
            //    msg = com.ReadExisting();
             //  Console.WriteLine(msg);

               // msg = com.ReadByte().ToString();
                //Console.WriteLine(msg);

             //   if (msg.Equals(Enq()))
              //  {
                //    com.WriteLine(Ack());
                  //  status += "Received Eng at " + DateTime.Now.ToString("h:mm:ss tt") + ". Ack Sent";
                   
               //  }
              //  else
              //  {
                //    status += "Message Received at " + DateTime.Now.ToString("h:mm:ss tt");
                  //  messagesString += msg;
                   // messageInBytes.AddRange(StringsToBytes(msg));
                   // messagesBinary += StringToStringOfBytes(msg);

               // }
                //SendDataToLimsAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region functions

        private static String EndCharsOfSysMaxXsSeries()
        {
            return (Cr() + Lf());
        }

        private static String Cr()
        {
            return Character(13);
        }


        private static String Etb()
        {
            return Character(23);
        }

        private static String Lf()
        {
            return Character(10);
        }

        private static String Ack()
        {
            return Character(6);
        }

        private static String Nak()
        {
            return Character(21);
        }

        private static String Stx()
        {
            return Character(2);
        }

        private static String Etx()
        {
            return Character(3);
        }

        private static String Enq()
        {
            return Character(5);
        }

        private static String Character(int charNo)
        {
            char ack = (char)charNo;
            String m = ack.ToString();
            return m;
        }


        private static Boolean ContainsEndCharactor(String value, String endCharacter)
        {
            return value.Contains(endCharacter);
        }

        private static String StringBeforeCharactor(String value, String c)
        {
            if (value == null)
            {
                return "";
            }
            int pos = value.IndexOf(c);
            return value.Substring(0, pos + 1);
        }

        private static String StringAfterCharactor(String value, String c)
        {
            if (value == null)
            {
                return "";
            }
            int len = value.Length;
            int pos = value.IndexOf(c);
            return value.Substring(pos, (len-pos+1));
        }

        private static String ResultAcceptanceMessage()
        {
            char stx = (char)2;
            char etx = (char)2;
            char fx = (char)63;

            String m = stx + "M" + fx + "A" + fx + fx + "E2" + etx;

            return m;
        }

        private static String NoRequestMessage()
        {
            char stx = (char)2;
            char etx = (char)3;
            char fx = (char)63;
            //<STX>N<FS>6A<ETX>
            String m = stx + "N" + fx + "6A" + etx;
            return m;
        }

        private static byte[] StringsToBytes(String value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            return bytes;
        }

        private static String StringToStringOfBytes(String input)
        {
            String s = "";
            foreach (char c in input)
            {
                s += (int)c ;
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

                query["msg"] = StringToStringOfBytes(msg);

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


        #endregion


        #region FormEvents

        public FormDimensionSettings()
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

        private void btnListStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = status;

        }

        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
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

        private void btnListMessages_Click(object sender, EventArgs e)
        {
            if (optBinary.Checked)
            {
                txtMessages.Text = messagesBinary;
            }
            else
            {
                txtMessages.Text = messagesString;
            }
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {

            txtMessages.Text = "";
            messagesString = "";
            messagesBinary = "";
            messageInBytes = new List<byte>();
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
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
    }
}
