//====================================================================================================//
// Serial Port Programming using C# and .NET Framework                                                //
// (Controls the RTS and DTR pins of serial port)                                                     //
//====================================================================================================//

//====================================================================================================//
// www.xanthium.in										                                              //
// Copyright (C) 2015 Rahul.S                                                                         //
//====================================================================================================//

//====================================================================================================//
// The Program runs on the PC side and communicate with the serial port or USB2SERIAL board  and      //
// manipulates the RTS and DTR lines                                                                  //       
//----------------------------------------------------------------------------------------------------//
//                                                                                                    //
//----------------------------------------------------------------------------------------------------// 
// BaudRate     -> 9600                                                                               //
// Data formt   -> 8 databits,No parity,1 Stop bit (8N1)                                              //
// Flow Control -> None                                                                               //
//----------------------------------------------------------------------------------------------------//


//====================================================================================================//
// Compiler/IDE  :	Microsoft Visual Studio Express 2013 for Windows Desktop(Version 12.0)            //
//               :  SharpDevelop                                                                      //
//                                                                                                    //
// Library       :  .NET Framework                                                                    //
// Commands      :                                                                                    //
// OS            :	Windows(Windows 7)                                                                //
// Programmer    :	Rahul.S                                                                           //
// Date	         :	05-March-2014                                                                     //
//====================================================================================================//

using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;

namespace SerialPort_Tutorial
{
    class SerialPort_Write
    {
        static void Main(string[] args)
        {
            SerialPort MyCOMPort = new SerialPort(); // Create a new SerialPort Object
            String COM_PortName;

            Console.WriteLine("\t+--------------------------------------------------------+");
            Console.WriteLine("\t|Controlling the RTS and DTR lines Serial Port using C#  |");
            Console.WriteLine("\t+--------------------------------------------------------+");
            Console.WriteLine("\t|                (c) www.xanthium.in                     |");
            Console.WriteLine("\t+--------------------------------------------------------+");
            Console.Write("\t   Enter the COM Port Number [eg COM32] ->");
            COM_PortName = Console.ReadLine();

            COM_PortName = COM_PortName.Trim();     // remove the trailing and leading spaces 
            COM_PortName = COM_PortName.ToUpper();  // convert to upper case

            MyCOMPort.PortName = COM_PortName;      // Assign the name of the serial port to be opened
            MyCOMPort.Open();                       // Open the port
            
            //make both RTS and DTR LED's on USB2SERIAL off
            MyCOMPort.RtsEnable = true;              // RTS = 1,~RTS = 0(USB2SERIAL)
            MyCOMPort.DtrEnable = true;              // DTR = 1,~DTR = 0(USB2SERIAL)

            Console.Write("\n\t  RTS = 1, (~RTS = 0 in USB2SERIAL)");
            MyCOMPort.RtsEnable = true;              // RTS pin = 1 ,~RTS = 0
            Console.Write("\n\t  Press Any Key to continue");
            Console.ReadLine();

            Console.Write("\n\t  RTS = 0, (~RTS = 1 in USB2SERIAL)");
            MyCOMPort.RtsEnable = false;             // RTS pin = 0 ,~RTS = 1
            Console.Write("\n\t  Press Any Key to continue");
            Console.ReadLine();
            
            Console.Write("\n\t  DTR = 1, (~DTR = 0 in USB2SERIAL)");
            MyCOMPort.DtrEnable = true;              // DTR pin = 1, ~DTR = 0
            Console.Write("\n\t  Press Any Key to continue");
            Console.ReadLine();
            
            Console.Write("\n\t  DTR = 0, (~DTR = 1 in USB2SERIAL)");
            MyCOMPort.DtrEnable = false;             // DTR pin = 0, ~DTR = 1
            Console.Write("\n\t  Press Any Key to continue");
            Console.ReadLine();

            Console.Write("\n\t  Press Any Key to Exit");
            Console.ReadLine();
            MyCOMPort.Close();                       // Close port
        }//end of Main
    }//end of class
}//end of namespace
