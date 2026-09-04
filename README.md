# Embedded

C# .NET Micro Framework working copies: FEZ Panda II Application1 (Realtag watchdog, SD config, display/keypad), Panda Encoder (GHI FEZ rotary encoder via Toolbox.NETMF.Hardware), and a Netduino Plus LED blinker. The tree also vendors `netmftoolbox-19492` (Apache License 2.0) with C# toolbox projects and many VB NETMF hardware samples. Open the individual `.csproj` / `.sln` files under each folder; toolbox code stays third-party Apache-2.0.

**Source last updated:** 2012-11-10  
**Language:** C#, VB.NET  
**Target:** v4.1, v4.2  
**Output:** Exe, Library

## What it is

C# .NET Micro Framework working copies: FEZ Panda II Application1 (Realtag watchdog, SD config, display/keypad), Panda Encoder (GHI FEZ rotary encoder via Toolbox.NETMF.Hardware), and a Netduino Plus LED blinker. The tree also vendors `netmftoolbox-19492` (Apache License 2.0) with C# toolbox projects and many VB NETMF hardware samples. Open the individual `.csproj` / `.sln` files under each folder; toolbox code stays third-party Apache-2.0.

## Solution structure

| Project | Language | Path |
|---------|----------|------|
| `Toolbox.NETMF (4.1)` | C# | `netmftoolbox-19492/Framework/Toolbox.NETMF (4.1).csproj` |
| `Toolbox.NETMF (4.2)` | C# | `netmftoolbox-19492/Framework/Toolbox.NETMF (4.2).csproj` |
| `Toolbox.NETMF.NET (4.1)` | C# | `netmftoolbox-19492/Framework/NET/Toolbox.NETMF.NET (4.1).csproj` |
| `Toolbox.NETMF.NET (4.2)` | C# | `netmftoolbox-19492/Framework/NET/Toolbox.NETMF.NET (4.2).csproj` |
| `Toolbox.NETMF.NET.Integrated (4.2)` | C# | `netmftoolbox-19492/Framework/NET/Integrated/Toolbox.NETMF.NET.Integrated (4.2).csproj` |
| `Toolbox.NETMF.NET.Integrated (4.1)` | C# | `netmftoolbox-19492/Framework/NET/Integrated/Toolbox.NETMF.NET.Integrated (4.1).csproj` |
| `Toolbox.NETMF.Hardware (4.1)` | C# | `netmftoolbox-19492/Framework/Hardware/Toolbox.NETMF.Hardware (4.1).csproj` |
| `Toolbox.NETMF.Hardware (4.2)` | C# | `netmftoolbox-19492/Framework/Hardware/Toolbox.NETMF.Hardware (4.2).csproj` |
| `Toolbox.NETMF.Hardware.WiFlyGSX (4.2)` | C# | `netmftoolbox-19492/Framework/Hardware/WiFlyGSX/Toolbox.NETMF.Hardware.WiFlyGSX (4.2).csproj` |
| `Toolbox.NETMF.Hardware.WiFlyGSX (4.1)` | C# | `netmftoolbox-19492/Framework/Hardware/WiFlyGSX/Toolbox.NETMF.Hardware.WiFlyGSX (4.1).csproj` |
| `Toolbox.NETMF.Hardware.Fez (4.1)` | C# | `netmftoolbox-19492/Framework/Hardware/Fez/Toolbox.NETMF.Hardware.Fez (4.1).csproj` |
| `Toolbox.NETMF.Hardware.Netduino (4.2)` | C# | `netmftoolbox-19492/Framework/Hardware/Netduino/Toolbox.NETMF.Hardware.Netduino (4.2).csproj` |
| `Toolbox.NETMF.Hardware.Netduino (4.1)` | C# | `netmftoolbox-19492/Framework/Hardware/Netduino/Toolbox.NETMF.Hardware.Netduino (4.1).csproj` |
| `LED RingCoder Breakout` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/LED RingCoder Breakout/LED RingCoder Breakout.vbproj` |
| `HBridge Motor Driver` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/HBridge Motor Driver/HBridge Motor Driver.vbproj` |
| `Multiplexing GPIOs` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Multiplexing GPIOs/Multiplexing GPIOs.vbproj` |
| `EL Escudo Dos Shield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/EL Escudo Dos Shield/EL Escudo Dos Shield.vbproj` |
| `7-Segment counter` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/7-Segment counter/7-Segment counter.vbproj` |
| `BlinkM Demo` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/BlinkM Demo/BlinkM Demo.vbproj` |
| `LoL Shield Driver` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/LoL Shield Driver/LoL Shield Driver.vbproj` |
| `Auto-Repeat Button` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Auto-Repeat Button/Auto-Repeat Button.vbproj` |
| `Basic Speaker` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Basic Speaker/Basic Speaker.vbproj` |
| `Adafruit Fridgelogger` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Adafruit Fridgelogger/Adafruit Fridgelogger.vbproj` |
| `Matrix KeyPad` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Matrix KeyPad/Matrix KeyPad.vbproj` |
| `IntegratedSocket sample` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/IntegratedSocket sample/IntegratedSocket sample.vbproj` |
| `Joystick Shield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Joystick Shield/Joystick Shield.vbproj` |
| `Thumb joystick` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Thumb joystick/Thumb joystick.vbproj` |
| `SNTP Client` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/SNTP Client/SNTP Client.vbproj` |
| `BitBang Buzzer` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/BitBang Buzzer/BitBang Buzzer.vbproj` |
| `Dangershield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Dangershield/Dangershield.vbproj` |
| `Rotary DIP Switch` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Rotary DIP Switch/Rotary DIP Switch.vbproj` |
| `Adafruit GPS Logger` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Adafruit GPS Logger/Adafruit GPS Logger.vbproj` |
| `DS1307 RTC Module` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/DS1307 RTC Module/DS1307 RTC Module.vbproj` |
| `IRC Client` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/IRC Client/IRC Client.vbproj` |
| `Rotary Encoder` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Rotary Encoder/Rotary Encoder.vbproj` |
| `Micro Serial Servo Controller` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Micro Serial Servo Controller/Micro Serial Servo Controller.vbproj` |
| `Wii Nunchuk` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Wii Nunchuk/Wii Nunchuk.vbproj` |
| `NMEA GPS Device` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/NMEA GPS Device/NMEA GPS Device.vbproj` |
| `Sharp GP2Y0A02YK Proximity Sensor` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Sharp GP2Y0A02YK Proximity Sensor/Sharp GP2Y0A02YK Proximity Sensor.vbproj` |
| `Bar Graph Breakout Kit` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Bar Graph Breakout Kit/Bar Graph Breakout Kit.vbproj` |
| `LPD8806 RGB Strip` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/LPD8806 RGB Strip/LPD8806 RGB Strip.vbproj` |
| `Wearable Keypad` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Wearable Keypad/Wearable Keypad.vbproj` |
| `Sound Module` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Sound Module/Sound Module.vbproj` |
| `Hd44780LcdSnake` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Hd44780LcdSnake/Hd44780LcdSnake.vbproj` |
| `RGB Led` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/RGB Led/RGB Led.vbproj` |
| `Adafruit RGB LCD Shield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Adafruit RGB LCD Shield/Adafruit RGB LCD Shield.vbproj` |
| `WiFly Socket` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/WiFly Socket/WiFly Socket.vbproj` |
| `Sparkfun Ardubot` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Sparkfun Ardubot/Sparkfun Ardubot.vbproj` |
| `SMTP Client` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/SMTP Client/SMTP Client.vbproj` |
| `DFRobot Motorshield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/DFRobot Motorshield/DFRobot Motorshield.vbproj` |
| `Web client` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Web client/Web client.vbproj` |
| `Terminal Server` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Terminal Server/Terminal Server.vbproj` |
| `TMP36 Temperature sensor` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/TMP36 Temperature sensor/TMP36 Temperature sensor.vbproj` |
| `Adafruit Motor Control Shield` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Adafruit Motor Control Shield/Adafruit Motor Control Shield.vbproj` |
| `HD44780 LCD` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/HD44780 LCD/HD44780 LCD.vbproj` |
| `POP3 Client` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/POP3 Client/POP3 Client.vbproj` |
| `Rdm630 RFID Reader` | VB.NET | `netmftoolbox-19492/Samples/Visual Basic/Rdm630 RFID Reader/Rdm630 RFID Reader.vbproj` |
| `LED RingCoder Breakout` | C# | `netmftoolbox-19492/Samples/Visual C#/LED RingCoder Breakout/LED RingCoder Breakout.csproj` |
| `HBridge Motor Driver` | C# | `netmftoolbox-19492/Samples/Visual C#/HBridge Motor Driver/HBridge Motor Driver.csproj` |
| `Multiplexing GPIOs` | C# | `netmftoolbox-19492/Samples/Visual C#/Multiplexing GPIOs/Multiplexing GPIOs.csproj` |
| `EL Escudo Dos Shield` | C# | `netmftoolbox-19492/Samples/Visual C#/EL Escudo Dos Shield/EL Escudo Dos Shield.csproj` |
| `7-Segment counter` | C# | `netmftoolbox-19492/Samples/Visual C#/7-Segment counter/7-Segment counter.csproj` |
| `BlinkM Demo` | C# | `netmftoolbox-19492/Samples/Visual C#/BlinkM Demo/BlinkM Demo.csproj` |
| `LoL Shield Driver` | C# | `netmftoolbox-19492/Samples/Visual C#/LoL Shield Driver/LoL Shield Driver.csproj` |
| `Auto-Repeat Button` | C# | `netmftoolbox-19492/Samples/Visual C#/Auto-Repeat Button/Auto-Repeat Button.csproj` |
| `Basic Speaker` | C# | `netmftoolbox-19492/Samples/Visual C#/Basic Speaker/Basic Speaker.csproj` |
| `Adafruit Fridgelogger` | C# | `netmftoolbox-19492/Samples/Visual C#/Adafruit Fridgelogger/Adafruit Fridgelogger.csproj` |
| `Matrix KeyPad` | C# | `netmftoolbox-19492/Samples/Visual C#/Matrix KeyPad/Matrix KeyPad.csproj` |
| `IntegratedSocket sample` | C# | `netmftoolbox-19492/Samples/Visual C#/IntegratedSocket sample/IntegratedSocket sample.csproj` |
| `Joystick Shield` | C# | `netmftoolbox-19492/Samples/Visual C#/Joystick Shield/Joystick Shield.csproj` |
| `Thumb joystick` | C# | `netmftoolbox-19492/Samples/Visual C#/Thumb joystick/Thumb joystick.csproj` |
| `SNTP Client` | C# | `netmftoolbox-19492/Samples/Visual C#/SNTP Client/SNTP Client.csproj` |
| `BitBang Buzzer` | C# | `netmftoolbox-19492/Samples/Visual C#/BitBang Buzzer/BitBang Buzzer.csproj` |
| `Dangershield` | C# | `netmftoolbox-19492/Samples/Visual C#/Dangershield/Dangershield.csproj` |
| `Rotary DIP Switch` | C# | `netmftoolbox-19492/Samples/Visual C#/Rotary DIP Switch/Rotary DIP Switch.csproj` |
| `Adafruit GPS Logger` | C# | `netmftoolbox-19492/Samples/Visual C#/Adafruit GPS Logger/Adafruit GPS Logger.csproj` |
| `DS1307 RTC Module` | C# | `netmftoolbox-19492/Samples/Visual C#/DS1307 RTC Module/DS1307 RTC Module.csproj` |
| `IRC Client` | C# | `netmftoolbox-19492/Samples/Visual C#/IRC Client/IRC Client.csproj` |
| `Rotary Encoder` | C# | `netmftoolbox-19492/Samples/Visual C#/Rotary Encoder/Rotary Encoder.csproj` |
| `Micro Serial Servo Controller` | C# | `netmftoolbox-19492/Samples/Visual C#/Micro Serial Servo Controller/Micro Serial Servo Controller.csproj` |
| `Wii Nunchuk` | C# | `netmftoolbox-19492/Samples/Visual C#/Wii Nunchuk/Wii Nunchuk.csproj` |
| `NMEA GPS Device` | C# | `netmftoolbox-19492/Samples/Visual C#/NMEA GPS Device/NMEA GPS Device.csproj` |
| `Sharp GP2Y0A02YK Proximity Sensor` | C# | `netmftoolbox-19492/Samples/Visual C#/Sharp GP2Y0A02YK Proximity Sensor/Sharp GP2Y0A02YK Proximity Sensor.csproj` |
| `Bar Graph Breakout Kit` | C# | `netmftoolbox-19492/Samples/Visual C#/Bar Graph Breakout Kit/Bar Graph Breakout Kit.csproj` |
| `Hd44780Lcd Snake` | C# | `netmftoolbox-19492/Samples/Visual C#/Hd44780Lcd Snake/Hd44780Lcd Snake.csproj` |
| `LPD8806 RGB Strip` | C# | `netmftoolbox-19492/Samples/Visual C#/LPD8806 RGB Strip/LPD8806 RGB Strip.csproj` |
| `Wearable Keypad` | C# | `netmftoolbox-19492/Samples/Visual C#/Wearable Keypad/Wearable Keypad.csproj` |
| `Sound Module` | C# | `netmftoolbox-19492/Samples/Visual C#/Sound Module/Sound Module.csproj` |
| `RGB Led` | C# | `netmftoolbox-19492/Samples/Visual C#/RGB Led/RGB Led.csproj` |
| `Adafruit RGB LCD Shield` | C# | `netmftoolbox-19492/Samples/Visual C#/Adafruit RGB LCD Shield/Adafruit RGB LCD Shield.csproj` |
| `WiFly Socket` | C# | `netmftoolbox-19492/Samples/Visual C#/WiFly Socket/WiFly Socket.csproj` |
| `Sparkfun Ardubot` | C# | `netmftoolbox-19492/Samples/Visual C#/Sparkfun Ardubot/Sparkfun Ardubot.csproj` |
| `SMTP Client` | C# | `netmftoolbox-19492/Samples/Visual C#/SMTP Client/SMTP Client.csproj` |
| `DFRobot Motorshield` | C# | `netmftoolbox-19492/Samples/Visual C#/DFRobot Motorshield/DFRobot Motorshield.csproj` |
| `Web client` | C# | `netmftoolbox-19492/Samples/Visual C#/Web client/Web client.csproj` |
| `Terminal Server` | C# | `netmftoolbox-19492/Samples/Visual C#/Terminal Server/Terminal Server.csproj` |
| `TMP36 Temperature sensor` | C# | `netmftoolbox-19492/Samples/Visual C#/TMP36 Temperature sensor/TMP36 Temperature sensor.csproj` |
| `Adafruit Motor Control Shield` | C# | `netmftoolbox-19492/Samples/Visual C#/Adafruit Motor Control Shield/Adafruit Motor Control Shield.csproj` |
| `HD44780 LCD` | C# | `netmftoolbox-19492/Samples/Visual C#/HD44780 LCD/HD44780 LCD.csproj` |
| `POP3 Client` | C# | `netmftoolbox-19492/Samples/Visual C#/POP3 Client/POP3 Client.csproj` |
| `Rdm630 RFID Reader` | C# | `netmftoolbox-19492/Samples/Visual C#/Rdm630 RFID Reader/Rdm630 RFID Reader.csproj` |
| `FEZ Panda II Application2` | C# | `FEZ Panda II Application2/FEZ Panda II Application2/FEZ Panda II Application2.csproj` |
| `NetduinoPlusApplication1` | C# | `NetduinoPlusApplication1/NetduinoPlusApplication1/NetduinoPlusApplication1.csproj` |
| `FEZ Panda II Application1` | C# | `FEZ Panda II Application1/FEZ Panda II Application1/FEZ Panda II Application1.csproj` |
| `Panda Encoder` | C# | `Panda Encoder/Panda Encoder/Panda Encoder.csproj` |

## How to open

Open `netmftoolbox-19492/Framework/.NET Micro Framework Toolbox (4.2).sln` in Visual Studio.

## Requirements

- Visual Studio 2010, .NET Framework 4.1, .NET Framework 4.2

## Attribution and provenance

- **Assembly company:** Microsoft, Stefan.Co
- **Assembly copyright:** Copyright ©  2011, Copyright ©  2012, Copyright © Microsoft 2011, Copyright © Microsoft 2012, Copyright © Stefan.Co 2011

## License

Original license terms apply where recorded in the tree or package metadata. This repository does not claim authorship. See `THIRD_PARTY_NOTICES.md`.
