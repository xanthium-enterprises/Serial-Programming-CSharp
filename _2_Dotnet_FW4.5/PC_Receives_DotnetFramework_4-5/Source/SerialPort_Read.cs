//====================================================================================================//
// Serial Port Programming using C# and .NET Framework                                                //
// (Reads data from serial port)                                                                      //
//====================================================================================================//

//====================================================================================================//
// www.xanthium.in										                                              //
// Copyright (C) 2020 Rahul.S                                                                         //
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
// Compiler/IDE  :	Microsoft Visual Studio Community                                                 //
//               :                                                                                    //
//                                                                                                    //
// Library       :  .NET Framework 4.5                                                                //
// Commands      :                                                                                    //
// OS            :	Windows(Windows 7) (Windows 10)                                                   //
// Programmer    :	Rahul.S                                                                           //
// Date	         :	04-March-2014                                                                     //
//               :  28-December-2020(updated)                                                         //
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
    using System.IO;

	namespace SerialPort_Tutorial
	{
		class SerialPort_Read
		{
			static void Main(string[] args)
			{
				String RxedData;                         // String to store received data
                String COM_PortName;                     // String to store the name of the serial port  
				int BaudRate = 9600;

				Display_Banner();


				SerialPort MyCOMPort = new SerialPort(); // Create a new SerialPort Object


				Console.WriteLine("\n\tVersion: {0}", Environment.Version.ToString());
				Console.Write("\n\t  Enter the COM port [eg COM32] -> ");
                COM_PortName = Console.ReadLine();

                COM_PortName = COM_PortName.Trim();     // Remove any extra spaces
                COM_PortName = COM_PortName.ToUpper();  // convert the string to upper case

				//Setup the SerialPort using Given info
				try
				{
					//COM port settings to 8N1 mode 
					MyCOMPort.PortName = COM_PortName;       // Name of your COM port 
					MyCOMPort.BaudRate = BaudRate;           // Baudrate
					MyCOMPort.Parity = Parity.None;          // Parity bits = none  
					MyCOMPort.DataBits = 8;                  // No of Data bits = 8
				    MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1
				    
				    // Set the read/write timeouts
					MyCOMPort.ReadTimeout  = 1500;     
					MyCOMPort.WriteTimeout = 1500;

					MyCOMPort.Open();                        // Open the port
				}
				catch (UnauthorizedAccessException Ex)
				{
					Console.WriteLine("\tAccess is denied to the port.");
					Console.WriteLine("\tA process on the system, already has the specified COM port open");
					//Console.WriteLine(Ex.ToString());
					Console.WriteLine("\tPress ENTER Key to Exit");
					Console.Read();
					MyCOMPort.Close();
					Environment.Exit(0);

			}
				catch (ArgumentOutOfRangeException Ex)
				{
					Console.WriteLine("\tOne or more of the properties for this instance are invalid");
					Console.WriteLine("\tFor Eg,Parity, DataBits,Baudrate are not valid values");
					//Console.WriteLine(Ex.ToString());
					Console.WriteLine("\tPress ENTER Key to Exit");
					Console.Read();
					MyCOMPort.Close();
					Environment.Exit(0);
			}
				catch (ArgumentException Ex)
				{
					Console.WriteLine("\tThe port name does not begin with \"COM\". ");
					//Console.WriteLine(Ex.ToString());
				    Console.WriteLine("\tPress ENTER Key to Exit");
                    Console.Read();
					MyCOMPort.Close();
					Environment.Exit(0);
			    }
				catch (IOException Ex) //IOException is in System.io;
				{
					Console.WriteLine("\tThe port is in an invalid state");
					//Console.WriteLine(Ex.ToString());
					Console.WriteLine("\tPress ENTER Key to Exit");
					Console.Read();
					MyCOMPort.Close();
					Environment.Exit(0);
				}
				catch (InvalidOperationException Ex)
				{
					Console.WriteLine("\tThe specified port on the current instance of the SerialPort is already open");
					//Console.WriteLine(Ex.ToString());
					Console.WriteLine("\tPress ENTER Key to Exit");
					Console.Read();
					MyCOMPort.Close();
					Environment.Exit(0);
			}
			


                Console.WriteLine("\n\t  Waiting for Data....");
			    try
				{
					RxedData = MyCOMPort.ReadLine();                  // Wait for data reception
				                                                      // Microcontroller should send a \n so that ReadLine() will return
				    Console.WriteLine("\n\t  \" {0} \"", RxedData);    // Write the data to console
			}
				catch(TimeoutException Ex)
				{
				//Console.WriteLine(Ex.ToString());
				Console.WriteLine($"\tRead  timeout happened, Time Out value = {MyCOMPort.ReadTimeout}mS");
				Console.WriteLine("\tPress ENTER Key to Exit");
				Console.Read();
				MyCOMPort.Close();
				Environment.Exit(0);
			}
				

				

                Console.WriteLine("\n\t  Press any Key to Exit");
				Console.Read();                                   // Press any key to exit

				MyCOMPort.Close();                       // Close port
			}//end of main
			private static void Display_Banner()
			{
				Console.WriteLine("\t+------------------------------------------+");
				Console.WriteLine("\t|    Reading from Serial Port using C#     |");
				Console.WriteLine("\t+------------------------------------------+");
				Console.WriteLine("\t|          (c) www.xanthium.in             |");
				Console.WriteLine("\t+------------------------------------------+");
			}

		}//end of class
	}//end of namespace
