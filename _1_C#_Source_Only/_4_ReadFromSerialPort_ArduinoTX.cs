// Code to Read SerialPort data send by Arduino 
// 
// www.xanthium.in (c)2025
// https://www.youtube.com/@XanthiumIndustries

using System;
using System.IO.Ports;
using System.Threading;

namespace SerialPortTutorialCSharp
{
    class ReadFromSerialPort
    {
        public static void Main()
        {
            SerialPort COMPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            COMPort.Open();     // Open the port,Arduino Resets here

            COMPort.DiscardInBuffer(); //Clears the input buffer of the serial port                   
            
            Thread.Sleep(1500); //wait for 1.5 second for Arduino to stabilize

            String RecievedText = COMPort.ReadLine(); // Read Data from SerialPort 

            Console.WriteLine(" Receiving Data from Arduino using C#  \n"); //Display received data
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine($" {RecievedText} "); //Display received data
            Console.WriteLine("+------------------------------------------+\n");
            COMPort.Close(); // Close port


        }
    }
}
