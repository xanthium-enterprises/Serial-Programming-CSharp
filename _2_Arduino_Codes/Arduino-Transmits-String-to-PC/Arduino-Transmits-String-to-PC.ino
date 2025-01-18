// Arduino Uno Transmits a string to PC through serial port 
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
  char TextToSend[] = "Hello to C# Serial Program from Arduino UNO";
  Serial.println(TextToSend); // sends a \n with text
  //Serial.print(TextToSend); // No \n with text
  delay(1000);
}