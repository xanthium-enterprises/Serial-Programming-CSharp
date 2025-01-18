// Code to Setup Transmit data to Arduino 
// 
// www.xanthium.in (c)2025
// https://www.youtube.com/@XanthiumIndustries

using System;
using System.IO.Ports;
using System.Threading;

namespace SerialPortTutorialCSharp
{
    class SetupReadTimeOutsSerialPort
    {
        public static void Main()
        {
            SerialPort COMPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            COMPort.Open();     // Open the port,Arduino Resets here

            COMPort.DiscardInBuffer(); //Clears the input buffer of the serial port                   

            Thread.Sleep(1500); //wait for 1.5 second for Arduino to stabilize

            COMPort.Write("A");
            String EchoedBack = COMPort.ReadLine();
            Console.WriteLine(EchoedBack);

            COMPort.Write("B");
            EchoedBack = COMPort.ReadLine();
            Console.WriteLine(EchoedBack);

            COMPort.Write("#");
            EchoedBack = COMPort.ReadLine();
            Console.WriteLine(EchoedBack);

            COMPort.Close();


        }
    }
}
