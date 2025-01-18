// Arduino Uno Receives Charcter from PC and Echoes it back to PC through serial port 
// Rahul.S

// www.xanthium.in (c) 2025
// https://www.youtube.com/@XanthiumIndustries
// Tutorial - https://www.xanthium.in/serial-port-communication-programming-arduino-raspberry-pi-using-csharp-on-windows

void setup()
{
  Serial.begin(9600); // opens serial port, sets data rate to 9600 bps 8N1

}

void loop()
{
  
  char ReceivedByte = 0;
    
    if(Serial.available()>0)
    {
      ReceivedByte = Serial.read();
      
      switch(ReceivedByte)
      {
        case 'A': 
                  Serial.println("Arduino Received Charcter A");
                  break;

        case 'B': Serial.println("Arduino Received Charcter B");
                  break;

        default : Serial.print("Arduino Received Charcter ");
                  Serial.println(ReceivedByte);
      }    
    }
}