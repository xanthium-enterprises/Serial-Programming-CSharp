// Code to Setup Read Time outs while receiving data from the Arduino 
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

            COMPort.ReadTimeout = 2000; //Set Read Timeout for 2 seconds 

            try
            {
                String RecievedText = COMPort.ReadLine(); // Read Data from SerialPort
                Console.WriteLine($" {RecievedText} ");    //Display received data                                       // 
            }
            catch (TimeoutException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            finally
            {
                COMPort.Close();
            }
        }
    }
}
