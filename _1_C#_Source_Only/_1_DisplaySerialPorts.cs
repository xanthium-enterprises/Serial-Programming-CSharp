// Code to display available Serial Ports in a PC using C# 
// 
// www.xanthium.in (c)2025
// https://www.youtube.com/@XanthiumIndustries

using System;
using System.IO.Ports;

namespace SerialPortTutorialCSharp
{
    class DisplaySerialPorts
    {
        public static void Main()
        {
            String[] AvailableSerialPorts = SerialPort.GetPortNames(); // static method to get all the available serial ports on a  system 

            Console.WriteLine("Available COM Ports on Windows\n");
            foreach (String COMPort in AvailableSerialPorts)
            {
                Console.WriteLine(COMPort);
            }
            
        }
    }
}