//BLACK SHIELD DRIVER

/*
Copyright 2010 GHI Electronics LLC
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System.Threading;
using GHIElectronics.NETMF.Hardware;
using Microsoft.SPOT.Hardware;

namespace GHIElectronics.NETMF.FEZ
{
    public static partial class FEZ_Shields
    {
        static public class KeypadLCD
        {
            public enum Keys
            {
                Up,
                Down,
                Right,
                Left,
                Select,
                None,
            }

            static OutputPort LCD_RS;
            static OutputPort LCD_E;

            static OutputPort LCD_D4;
            static OutputPort LCD_D5;
            static OutputPort LCD_D6;
            static OutputPort LCD_D7;

            static AnalogIn AButton;

            static OutputPort BackLight;

            const byte DISP_ON = 0xC;       //Turn visible LCD on
            const byte CLR_DISP = 1;        //Clear display
            const byte CUR_HOME = 2;        //Move cursor home and clear screen memory
            const byte SET_CURSOR = 0x80;   //SET_CURSOR + X : Sets cursor position to X

            public static void Initialize()
            {
                LCD_RS = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di8, false);
                LCD_E = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di9, false);
                LCD_D4 = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di4, false);
                LCD_D5 = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di5, false);
                LCD_D6 = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di6, false);
                LCD_D7 = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di7, false);

                AButton = new AnalogIn((AnalogIn.Pin)FEZ_Pin.AnalogIn.An0);
                BackLight = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.Di10, false);

                LCD_RS.Write(false);

                // 4 bit data communication
                Thread.Sleep(50);

                LCD_D7.Write(false);
                LCD_D6.Write(false);
                LCD_D5.Write(true);
                LCD_D4.Write(true);

                LCD_E.Write(true);
                LCD_E.Write(false);

                Thread.Sleep(50);
                LCD_D7.Write(false);
                LCD_D6.Write(false);
                LCD_D5.Write(true);
                LCD_D4.Write(true);

                LCD_E.Write(true);
                LCD_E.Write(false);

                Thread.Sleep(50);
                LCD_D7.Write(false);
                LCD_D6.Write(false);
                LCD_D5.Write(true);
                LCD_D4.Write(true);

                LCD_E.Write(true);
                LCD_E.Write(false);

                Thread.Sleep(50);
                LCD_D7.Write(false);
                LCD_D6.Write(false);
                LCD_D5.Write(true);
                LCD_D4.Write(false);

                LCD_E.Write(true);
                LCD_E.Write(false);

                SendCmd(DISP_ON);
                SendCmd(CLR_DISP);
            }

            //Sends an ASCII character to the LCD
            private static void Putc(byte c)
            {
                LCD_D7.Write((c & 0x80) != 0);
                LCD_D6.Write((c & 0x40) != 0);
                LCD_D5.Write((c & 0x20) != 0);
                LCD_D4.Write((c & 0x10) != 0);
                LCD_E.Write(true); LCD_E.Write(false); //Toggle the Enable Pin

                LCD_D7.Write((c & 0x08) != 0);
                LCD_D6.Write((c & 0x04) != 0);
                LCD_D5.Write((c & 0x02) != 0);
                LCD_D4.Write((c & 0x01) != 0);
                LCD_E.Write(true); LCD_E.Write(false); //Toggle the Enable Pin
                //Thread.Sleep(1);
            }

            //Sends an LCD command
            private static void SendCmd(byte c)
            {
                LCD_RS.Write(false); //set LCD to data mode

                LCD_D7.Write((c & 0x80) != 0);
                LCD_D6.Write((c & 0x40) != 0);
                LCD_D5.Write((c & 0x20) != 0);
                LCD_D4.Write((c & 0x10) != 0);
                LCD_E.Write(true); LCD_E.Write(false); //Toggle the Enable Pin

                LCD_D7.Write((c & 0x08) != 0);
                LCD_D6.Write((c & 0x04) != 0);
                LCD_D5.Write((c & 0x02) != 0);
                LCD_D4.Write((c & 0x01) != 0);
                LCD_E.Write(true); LCD_E.Write(false); //Toggle the Enable Pin
                Thread.Sleep(1);
                LCD_RS.Write(true); //set LCD to data mode
            }

            public static void Print(string str, bool ClearDisplay)
            {
                if (ClearDisplay)
                {
                    Clear();
                }
                Print(str);
            }

            public static void Print(string str)
            {
                for (int i = 0; i < str.Length; i++)
                    Putc((byte)str[i]);
            }

            public static void Clear()
            {
                SendCmd(CLR_DISP);
            }

            public static void CursorHome()
            {
                SendCmd(CUR_HOME);
            }

            public static void SetCursor(byte row, byte col)
            {
                SendCmd((byte)(SET_CURSOR | row << 6 | col));
            }

            public static Keys GetKey()
            {
                int PressedButton = AButton.Read();
                // use this to read values to calibrate
                /*while (true)
                {
                    PressedButton = AButton.Read();
                    Debug.Print(PressedButton.ToString());
                    Thread.Sleep(300);
                }*/
                const int ERROR = 50;

                if (PressedButton > 1024)// - ERROR)
                    return Keys.None;

                if (PressedButton < 0 + ERROR)
                    return Keys.Right;

                if (PressedButton < 180 + ERROR && PressedButton > 180 - ERROR) // 173
                    return Keys.Up;

                if (PressedButton < 390 + ERROR && PressedButton > 390 - ERROR) // 404
                    return Keys.Down;

                if (PressedButton < 650 + ERROR && PressedButton > 650 - ERROR)  // 627
                    return Keys.Left;

                if (PressedButton < 960 + ERROR && PressedButton > 960 - ERROR)  // 945
                    return Keys.Select;

                return Keys.None;
            }

            public static void TurnBacklightOn()
            {
                BackLight.Write(true);
            }

            public static void TurnBacklightOn(int OnTime)
            {
                // Create an instance of the BacklightTimer class, passing the period to it.
                BacklightTimer DisplayTimer = new BacklightTimer(OnTime);

                // create new thread that runs the ThreadStart method
                Thread TimerThread = new Thread(new ThreadStart(DisplayTimer.MomentaryOn));

                // Start the Thread
                TimerThread.Start();
            }

            public static void TurnBacklightOff()
            {
                BackLight.Write(false);
            }

            private class BacklightTimer
            {
                // Storage
                private int _Interval;

                // Constructor
                public BacklightTimer(int Interval)
                {
                    _Interval = Interval;
                }

                // Function for ThreadStart
                public void MomentaryOn()
                {
                    // Turn on backlight
                    BackLight.Write(true);

                    // Pause
                    Thread.Sleep(_Interval);

                    // Turn off backlight
                    BackLight.Write(false);
                }
            }
        }
    }
}