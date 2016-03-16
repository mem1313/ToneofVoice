using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Speech.Synthesis;

namespace SofpotTestApplication_WindowsForms
{
    public partial class Form1 : Form
    {
        private bool isConnected;
        private bool isWaitingForConnection;
        static private SerialPort myPort;
        private string incomingMessage;
        private SpeechSynthesizer testSubject;

        public Form1()
        {
            InitializeComponent();
            isConnected = false;
            isWaitingForConnection = true;
            myPort = new SerialPort();
            //testSubject = new SpeechSynthesizer();
        }

        SerialPort mySerialPort = new SerialPort();

        private void Form1_Load_1(object sender, EventArgs e)
        {
           

            //SerialPort mySerialPort = new SerialPort("COM5");
            mySerialPort.PortName = "COM5";
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);

            mySerialPort.Open();

            isConnected = true;

            

            /*myPort.BaudRate = 9600;
            myPort.Parity = Parity.None;
            myPort.StopBits = StopBits.One;
            myPort.DataBits = 8;
            myPort.Handshake = Handshake.None;
            myPort.RtsEnable = true;

            myPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);*/
        }

        void myPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            this.Invoke(new MethodInvoker(delegate()
            {
                //listBox1.Items.Add("Data Received:");
                //listBox1.Items.Add(indata);

                incomingMessage = indata;

            }));
        }

        private void AutoDetectPort()
        {
            /*string[] portNames = SerialPort.GetPortNames();

            foreach (string name in portNames)
            {
                //myPort.PortName = name;
                //myPort.DataReceived += myPort_DataReceived;
                try
                {
                    //myPort.Open();
                    /*
                    if(myPort.IsOpen)
                    {
                        myPort.Write("connected");
                       
                        if(myPort.ReadLine() == "ping")
                        {
                            isConnected = true;
                            listBox1.Items.Add(name);
                            myPort.Write("start");
                            break;
                        }
                    }*/

                  /*  if(incomingMessage == "ping")
                    {
                        isConnected = true;
                        listBox1.Items.Add(name);
                        myPort.Write("start");
                        mySerialPort.Write("connected");
                        break;
                    }
                }
                catch (Exception)
                {
                    
                }
                //myPort.Close();
            }*/
            string msg = incomingMessage;
            listBox1.Items.Add(msg);
            if (msg.ToLower() == "ping\n")
            {
                isConnected = true;
                //listBox1.Items.Add(name);
                //myPort.Write("start");
                while (msg == "ping")
                {
                    mySerialPort.WriteLine("connected");
                }
            }
            //mySerialPort.WriteLine("testing");
        }


        void testFinc()
        {
            /*
            mySerialPort.PortName = "COM5";
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);

            mySerialPort.Open();

            if (incomingMessage != "waiting")
            {
                mySerialPort.Close();
            }
             * */

            //mySerialPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);

            //mySerialPort.Open();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            AutoDetectPort();

            //string [] names = SerialPort.GetPortNames();

            //foreach (string item in names)
	        //{
                //mySerialPort.PortName = "COM5";
	        //}

            //testFinc();

            if (isConnected)
            {
                happy.BackColor = Color.Gray;
                sad.BackColor = Color.Gray;
                angry.BackColor = Color.Gray;
                normal1.BackColor = Color.Gray;
                normal2.BackColor = Color.Gray;
                normal3.BackColor = Color.Gray;
                normal4.BackColor = Color.Gray;

                isWaitingForConnection = false;
                isConnected = false;
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
            else
            {
                if (isWaitingForConnection)
                {
                    happy.BackColor = Color.Black;
                    sad.BackColor = Color.Black;
                    angry.BackColor = Color.Black;
                    normal1.BackColor = Color.Black;
                    normal2.BackColor = Color.Black;
                    normal3.BackColor = Color.Black;
                    normal4.BackColor = Color.Black;
                    isWaitingForConnection = false;
                }
                else
                {
                    happy.BackColor = Color.Gold;
                    sad.BackColor = Color.Gold;
                    angry.BackColor = Color.Gold;
                    normal1.BackColor = Color.Gold;
                    normal2.BackColor = Color.Gold;
                    normal3.BackColor = Color.Gold;
                    normal4.BackColor = Color.Gold;
                    isWaitingForConnection = true;
                }
            }

            /*SerialPort mySerialPort = new SerialPort("COM5");
            mySerialPort.PortName = "COM5";
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(myPort_DataReceived);

            mySerialPort.Open();

            if (incomingMessage != "waiting")
                mySerialPort.Close();*/
        }

        enum EmotionList
        {
            happy,
            sad,
            angry,
            normal1,
            normal2,
            normal3,
            normal4
        }

        string currentEmotion = "";

        private void timer2_Tick(object sender, EventArgs e)
        {
            //AutoDetectPort();

           /* if(incomingMessage.ToLower() == "happy")
            {
                happy.BackColor = Color.Honeydew;
                sad.BackColor = Color.Gray;
                angry.BackColor = Color.Gray;
                normal1.BackColor = Color.Gray;
                normal2.BackColor = Color.Gray;
                normal3.BackColor = Color.Gray;
                normal4.BackColor = Color.Gray;
            }*/

            //EmotionList selectedEmotion = (EmotionList)Enum.Parse(typeof(EmotionList), incomingMessage.ToLower().TrimEnd());
            testSubject = new SpeechSynthesizer();
            EmotionList selectedEmotion;
            

            if (!Enum.TryParse(incomingMessage, true, out selectedEmotion))
            {
                selectedEmotion = EmotionList.normal1;
            }

            if(incomingMessage == "\r\n")
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
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Happy");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.sad:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Honeydew;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Sad");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.angry:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Honeydew;
                            normal1.BackColor = Color.Gray;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Angry");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.normal1:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Honeydew;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 1");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.normal2:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal2.BackColor = Color.Honeydew;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 2");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.normal3:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Honeydew;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 3");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    case EmotionList.normal4:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Gray;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Honeydew;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 4");
                            currentEmotion = incomingMessage;
                            break;
                        }
                    default:
                        {
                            testSubject.Dispose();
                            happy.BackColor = Color.Gray;
                            sad.BackColor = Color.Gray;
                            angry.BackColor = Color.Gray;
                            normal1.BackColor = Color.Honeydew;
                            normal2.BackColor = Color.Gray;
                            normal3.BackColor = Color.Gray;
                            normal4.BackColor = Color.Gray;
                            testSubject = new SpeechSynthesizer();
                            testSubject.SpeakAsync("Normal 1");
                            currentEmotion = incomingMessage;
                            break;
                        }
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.Add(incomingMessage);
        }
    }
}
