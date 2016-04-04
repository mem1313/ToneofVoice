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
        #region FIELDS 
        static private SerialPort myPort;
        private string incomingMessage;
        private SpeechSynthesizer testSubject;
        private string currentEmotion;

        delegate void setArduinoMessage(string text);
        private Thread arduinoMessageThread;
        #endregion

        public Form1()
        {
            InitializeComponent();
            myPort = new SerialPort();
            currentEmotion = string.Empty;
            arduinoMessageThread = null;

            this.arduinoMessageThread = new Thread(new ThreadStart(this.MessageFromArduino));
            this.arduinoMessageThread.Start();
        }

        private void SetText(string text)
        {
            if (this.listBox1.InvokeRequired)
            {
                setArduinoMessage d = new setArduinoMessage(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(text);
            }
        }

        private void MessageFromArduino()
        {
            myPort.PortName = "COM5";
            myPort.BaudRate = 9600;
            myPort.Parity = Parity.None;
            myPort.StopBits = StopBits.One;
            myPort.DataBits = 8;
            myPort.Handshake = Handshake.None;
            myPort.RtsEnable = true;

            myPort.Open();

            while (true)
            {                
                SetText(SelectedEmotion());
            }
        }

        

        private string SelectedEmotion()
        {
            testSubject = new SpeechSynthesizer();
            EmotionList selectedEmotion;

            incomingMessage = myPort.ReadLine();

            if (!Enum.TryParse(incomingMessage, true, out selectedEmotion))
            {
                selectedEmotion = EmotionList.normal1;
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

            return currentEmotion;
        }
        
        private void Form1_Load_1(object sender, EventArgs e)
        {
           
        }
                  
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            arduinoMessageThread.Abort();
        }
    }
}
