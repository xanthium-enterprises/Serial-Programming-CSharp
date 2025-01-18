// Code to open a serial port connection using C#
// 
// www.xanthium.in (c)2025
// https://www.youtube.com/@XanthiumIndustries

using System;
using System.IO.Ports;

namespace SerialPortTutorialCSharp
{
    class OpenSerialPortConn
    {
        public static void Main()
        {
            //SerialPort COMPort = new SerialPort("COM3",9600,Parity.None,8, StopBits.One);
            
            SerialPort COMPort = new SerialPort(); //Create a new  Serialport object called COMPort
            
            COMPort.PortName = "COM3";
            COMPort.BaudRate = 9600;
            COMPort.Parity   = Parity.None;
            COMPort.DataBits = 8;
            COMPort.StopBits = StopBits.One;

            try
            {
                COMPort.Open();
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            
            
            COMPort.Close();


            

        }
    }
}
