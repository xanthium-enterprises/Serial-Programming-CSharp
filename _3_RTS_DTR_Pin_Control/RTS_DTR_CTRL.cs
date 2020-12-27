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

	//====================================================================================================//
	// Sellecting the COM port Number                                                                     //
	//----------------------------------------------------------------------------------------------------//
	// Use "Device Manager" in Windows to find out the COM Port number allotted to USB2SERIAL converter-  // 
	// -in your Computer and substitute in the  MyCOMPort.PortName                                        //
	//                                                                                                    //
	// for eg:-                                                                                           //
	// If your COM port number is COM32 in device manager(will change according to system)                //
	// then                                                                                               //
	//			MyCOMPort.PortName = "COM32"                                                              //
	//====================================================================================================//

using System;
using System.IO.Ports;

namespace SerialPort_Tutorial
{
    class SerialPort_Write
    {
        static void Main(string[] args)
        {
            SerialPort MyCOMPort = new SerialPort(); // Create a new SerialPort Object

            MyCOMPort.PortName = "COM46";    // Assign the name of the serial port to be opened
            MyCOMPort.Open();                // Open the port

            MyCOMPort.RtsEnable = true;      // RTS pin = 1 ,~RTS = 0
            Console.Read();
            MyCOMPort.RtsEnable = false;     // RTS pin = 0 ,~RTS = 1
            Console.Read();
            MyCOMPort.DtrEnable = true;      // DTR pin = 1, ~DTR = 0
            Console.Read();
            MyCOMPort.DtrEnable = false;     // DTR pin = 0, ~DTR = 1
            Console.Read();

            MyCOMPort.Close();               // Close port
        }//end of Main
    }//end of class
}//end of namespace
