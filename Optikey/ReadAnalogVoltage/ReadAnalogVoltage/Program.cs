using System;
using System.IO.Ports;

namespace ReadAnalogVoltage
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM4";
            myport.Open();

            while(true)
            {
                double voltage = 0;
                string data = myport.ReadLine();
                Double.TryParse(data, out voltage);
                Console.WriteLine(voltage);
            }
        }
    }
}
