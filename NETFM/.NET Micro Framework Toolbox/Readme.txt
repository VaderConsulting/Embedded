This is a compilation of .NET Micro Framework libraries.
All drivers are written in Visual C# 2010 but since Netduino is also open to the Visual Basic community, there are code samples for VB2010 as well.

The compilation contains five folders:
- Framework: The library sourcecode can be found here
- Release: This folder contains the latest DLL of the framework for the .NET Micro Framework 4.1
- Release (4.2): This folder contains the latest DLL of the framework for the .NET Micro Framework 4.2 to be used in Visual Basic
- Samples: Contains samples to work with the library for both VB and C#
- Schematics: Fritzing schematics and PDFs used for the samples. Download Fritzing at www.fritzing.org

If you like to see some more documentation, see http://netmftoolbox.codeplex.com/documentation

Current samples:
- 7-Segment counter: Counting from 0 to 9 with a 7-segment display and 74HC595 IC
- Auto-Repeat Button: A great way to handle buttons
- Bar Graph Breakout Kit: A sample for Sparkfun's Bar Graph Breakout Kit
- Basic Speaker: An easy way to drive a PC-speaker and output monophonic sounds
- BitBang Buzzer: When all PWM-pins are occupied and you want to add a buzzer, check this!
- Dangershield: Have got the shield? Here's a sample code for NETMF
- DFRobot Motorshield: A sample for the L298N and L293 DFRobot motorshields
- H-Bridge Motor Driver: Driving two DC motors using a H-bridge DC motordriver
- Joystick Shield: A sample for the famous joystick shield
- Matrix KeyPad: Using a matrix keypad
- Micro Serial Servo Controller: Using the pololu serial servo controller with a .NET Microcontroller
- Multiplexing GPIOs: Expanding the amount of GPIO ports by adding 74HC595 and/or 74HC165 IC's
- POP3 Client: Reading your mailbox with a networking-enabled device
- Rdm630 RFID Reader: Reading RFID tags with a Rdm630 breakout board
- RGB Led: Using 'HTML-like' hex-numbers to drive an RGB-led
- Rotary DIP Switch: Using binary rotary DIP switches
- Sharp GP2Y0A02YK Proximity Sensor: A cheap sensor to measure distance, not very accurate
- Simple socket: Requesting a web page with a simple TCP socket
- SMTP Client: Sending mail through your ISP's SMTP-server
- Thumb joystick: A simple piece of code for the popular Sparkfun Thumb Joystick
- TMP36 Temperature sensor: A temperature sensor in celcius, fahrenheit and kelvin
- Wearable Keypad: A driver for Sparkfun's Wearable Keypad
- Web client: Requesting the latest headers from Cnn.com over HTTP

The library is maintained by Stefan Thoolen with a lot of thanks from:
- Steven Don for his help with writing Speaker.cs and his C# expertise
- Mario Vernari for his help with understanding the 74HC595 and 74HC165
- Daniel Loughmiller for the 74HC595 bitbang code
