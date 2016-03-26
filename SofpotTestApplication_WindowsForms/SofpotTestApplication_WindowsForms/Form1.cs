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
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Management;

namespace SofpotTestApplication_WindowsForms
{
    public partial class Form1 : Form
    {
        #region FIELDS 
        static private SerialPort myPort;
        private string incomingMessage;
        private SpeechSynthesizer testSubject;
        private string currentEmotion;

        delegate void setArduinoMessage(string text);
        //private Thread arduinoMessageThread;
        private Thread getPortThread;
        private string portName1 = "";
        SerialPort sp;
        string[] availablePorts;
        Boolean isClosed = false;
        BackgroundWorker back;
        string arduinoPort = "";
        List<string> portList = new List<string>();
        #endregion

        public Form1()
        {
            InitializeComponent();
            myPort = new SerialPort();
            currentEmotion = string.Empty;
            //arduinoMessageThread = null;
            getPortThread = null;

            //this.arduinoMessageThread = new Thread(new ThreadStart(this.MessageFromArduino));
            //this.arduinoMessageThread.Start();
        }

        private void SetText(string text)
        {
            if (this.listBox1.InvokeRequired)
            {
                setArduinoMessage d = new setArduinoMessage(SetText);
                listBox1.Invoke(d, new object[] { text });
            }
            else
            {
                try
                {
                    string state = getPortThread.ThreadState.ToString();
                    if (!isClosed)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add(text);
                    }
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message+"2");
                }
                
            }
        }

        private void MessageFromArduino()
        {

            //myPort.BaudRate = 9600;
            //myPort.Parity = Parity.None;
            //myPort.StopBits = StopBits.One;
            //myPort.DataBits = 8;
            //myPort.Handshake = Handshake.None;
            //myPort.RtsEnable = true;
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.Handshake = Handshake.None;
            sp.RtsEnable = true;
            //try
            //{
            //    sp.Open();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Port open problem");
            //}


            while (true)
            {
                SetText(SelectedEmotion());
            }
            
        }

        private string SelectedEmotion()
        {

            testSubject = new SpeechSynthesizer();
            EmotionList selectedEmotion;

            //string check = sp.ReadLine();

            //if (sp.ReadLine() == "")
            //{
            //    incomingMessage =  "NORMAL\r";
            //}
            //else if (sp.ReadLine().IndexOf("NORMAL") >= 0)
            //{
            //    incomingMessage = "NORMAL\r";
            //}
            //else if (sp.ReadLine().IndexOf("HAPPY") >= 0)
            //{
            //    incomingMessage = "HAPPY\r";
            //}
            //else if (sp.ReadLine().IndexOf("SAD") >= 0)
            //{
            //    incomingMessage = "SAD\r";
            //}
            //else if (sp.ReadLine().IndexOf("MAD") >= 0)
            //{
            //    incomingMessage = "MAD\r";
            //}


            incomingMessage = "";
            try
            {
               // sp.Open();
                incomingMessage = sp.ReadLine().Substring(14);
            }
            catch (Exception d)
            {
                //MessageBox.Show("No port");
                incomingMessage = "NORMAL\r";
                //MessageBox.Show(d.Message+"4");
            }

            //incomingMessage = portName1.Substring(14);
            if (!Enum.TryParse(incomingMessage, true, out selectedEmotion))
            {
                selectedEmotion = EmotionList.normal;
            }

            if (incomingMessage == "\r\n")
            {
                incomingMessage = currentEmotion;
            }

            if (incomingMessage != currentEmotion)
            {
                switch (selectedEmotion)
                {
                    case EmotionList.happy:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Honeydew;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Happy");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "HAPPY\r";
                            break;
                        }
                    case EmotionList.sad:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Honeydew;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Sad");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "SAD\r";
                            break;
                        }
                    case EmotionList.mad:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Honeydew;
                            normal1.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Mad");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "MAD\r";
                            break;
                        }
                    case EmotionList.irretated:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Honeydew;
                            normal3.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Irretated");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "IRRETATED\r";
                            break;
                        }
                    case EmotionList.normal:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal3.BackColor = Color.Honeydew;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "NORMAL\r";
                            break;
                        }
                    default:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Honeydew;
                            normal3.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 1");
                            //currentEmotion = incomingMessage;
                            currentEmotion = "NORMAL\r";
                            break;
                        }
                }
            }

            return currentEmotion;
        }
               
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //arduinoMessageThread.Abort();
            getPortThread.Abort();
        }

        public int count;
        
        private void GetComPort()
        {
            int count = 0;
            availablePorts = null;
            arduinoPort = "";

            //List<string> strPort = new List<string>();
            //strPort.Add("hello");
            //strPort.RemoveRange(0, strPort.Count);
            while (count < 3)
            {
                availablePorts = SerialPort.GetPortNames();
                if (availablePorts.Length == 0)
                {
                    count++;
                }
                else 
                {
                    count = 3;
                }
                
            }
          
            foreach (var item in availablePorts)
            {
                if (portList.IndexOf(item) < 0)
                {
                    portList.Add(item);
                }
            }
            
            foreach (string port in portList)
            {
                sp = new SerialPort(port);
                bool iState = sp.IsOpen;
                try
                {
                    if (portList.Count() >= 0 && arduinoPort.Length == 0)// && count < 1)
                    {
                        sp.Open();
                        sp.DiscardOutBuffer();
                        sp.DiscardInBuffer();

                        portName1 = sp.ReadLine();
                        sp.DiscardInBuffer();


                        if (portName1.IndexOf("ArduinoSensor") >= 0)
                        {
                            arduinoPort = port;
                            
                        }

                        sp.Close();
                    }
                }
                catch (Exception e)
                {
                    //portName1 = sp.ReadLine();
                    portName1 = "Port busy";
                    MessageBox.Show(e.Message+"3");
                }
            }
        
            if (arduinoPort.Length > 0)
            {
                sp = new SerialPort(arduinoPort);
                sp.Open();
                MessageFromArduino();
            }
            else
            {
                MessageBox.Show("No Arduino port found");
            }

        }

        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            //this.getPortThread = new Thread(new ThreadStart(this.GetComPort));
            //this.getPortThread.Start();
            //Thread.Sleep(100);

            //if (getPortThread.ThreadState.ToString() == "Aborted")
            //{
            //    this.getPortThread = new Thread(new ThreadStart(this.GetComPort));
            //    this.getPortThread.Start();
            //}

            currentEmotion = "";
            isClosed = false;
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            //foreach (var property in instance.Properties)
            //{
                //GetComPort();

            try
            {
                //if (sp != null && !sp.IsOpen)
                //{
                //    sp.Open();
                //}

                //if (availablePorts.Length == 0)
                //{
                //    GetComPort();
                //}

                string state = this.getPortThread.ThreadState.ToString();
                if (state == "Aborted" || state == "Stopped")
                {
                    this.getPortThread = new Thread(new ThreadStart(this.GetComPort));
                    this.getPortThread.Start();
                }

                //MessageFromArduino();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message+"4");
            }
            
            
            //}
        }

        void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        { 
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
           // foreach (var property in instance.Properties)
            //{
//Close the port that was unplugged --------------------------------------------------------------------------------------------------------------------------------------
            try
            {
                int num = 0;
                foreach (var item in availablePorts)
                {
                    availablePorts[num] = "";
                    num++;
                }

                portList.RemoveRange(0, portList.Count);
               // availablePorts = null;
                sp.Close();
                isClosed = true;
                getPortThread.Abort();
                //this.getPortThread.Abort();
                
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message+"1");
            } 
            //sp.Open();
                //Write property.Name and property.Value
                //getPortThread.Abort();
            //}
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            //WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_SerialPort'");

            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_SerialPort'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();

            // Do something while waiting for events
            Thread.Sleep(20000000);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getPortThread = new Thread(new ThreadStart(this.GetComPort));
            this.getPortThread.Start();

            back = new BackgroundWorker();
            back.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            back.RunWorkerAsync();

            count = 0;

        }

    }
}
