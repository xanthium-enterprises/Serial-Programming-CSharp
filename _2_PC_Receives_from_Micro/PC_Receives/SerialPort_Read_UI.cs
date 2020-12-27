    //====================================================================================================//
	// Serial Port Programming using C# and .NET Framework                                                //
	// (Reads data from serial port)                                                                      //
	//====================================================================================================//
	
	//====================================================================================================//
	// www.xanthium.in										                                              //
	// Copyright (C) 2015 Rahul.S                                                                         //
	//====================================================================================================//
	
	//====================================================================================================//
	// The Program runs on the PC side and communicate with the serial port or USB2SERIAL board  and      //
	// reads the data from it.                                                                            //       
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
	// Date	         :	04-March-2014                                                                     //
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

	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using System.IO.Ports;

	namespace SerialPort_Tutorial
	{
		class SerialPort_Read
		{
			static void Main(string[] args)
			{
				String RxedData;                         // String to store received data
                String COM_PortName;                     // String to store the name of the serial port  
				SerialPort MyCOMPort = new SerialPort(); // Create a new SerialPort Object

                Console.WriteLine("\t+------------------------------------------+");
                Console.WriteLine("\t|    Reading from Serial Port using C#     |");
                Console.WriteLine("\t+------------------------------------------+");
                Console.WriteLine("\t|          (c) www.xanthium.in             |");
                Console.WriteLine("\t+------------------------------------------+");
                Console.Write("\n\t  Enter the COM port [eg COM32] -> ");
                COM_PortName = Console.ReadLine();

                COM_PortName = COM_PortName.Trim();     // Remove any extra spaces
                COM_PortName = COM_PortName.ToUpper();  // convert the string to upper case

				//------------ COM port settings to 8N1 mode ------------------//

                MyCOMPort.PortName = COM_PortName;       // Name of the COM port 
				MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
				MyCOMPort.Parity   = Parity.None;        // Parity bits = none  
				MyCOMPort.DataBits = 8;                  // No of Data bits = 8
				MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1

				MyCOMPort.Open();                                 // Open the port
                Console.WriteLine("\n\t  Waiting for Data....");
				RxedData = MyCOMPort.ReadLine();                  // Wait for data reception
				Console.WriteLine("\n\t  \" {0} \"",RxedData);    // Write the data to console
                Console.WriteLine("\n\t  Press any Key to Exit");
				Console.Read();                                   // Press any key to exit

				MyCOMPort.Close();                       // Close port
			}//end of main
		}//end of class
	}//end of namespace
