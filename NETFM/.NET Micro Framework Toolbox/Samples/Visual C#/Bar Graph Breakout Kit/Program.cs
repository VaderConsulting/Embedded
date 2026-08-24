using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Toolbox.NETMF.Hardware;

/*
 * Copyright 2011-2012 Stefan Thoolen (http://netmftoolbox.codeplex.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Bar_Graph_Breakout_Kit
{
    public class Program
    {
        public static void Main()
        {
            // We got 4 74HC595's in a chain
            Ic74HC595Chain IcChain = new Ic74HC595Chain(SPI_Devices.SPI1, Pins.GPIO_PIN_D10, 4);

            // We define every IC
            Ic74HC595 Ic1 = new Ic74HC595(IcChain, 0);
            Ic74HC595 Ic2 = new Ic74HC595(IcChain, 1);
            Ic74HC595 Ic3 = new Ic74HC595(IcChain, 2);
            Ic74HC595 Ic4 = new Ic74HC595(IcChain, 3);

            // Create 32 output ports
            OutputPortShift[] Leds = new OutputPortShift[32];
            
            // Addresses all 32 output ports
            for (int Counter = 0; Counter < 8; ++Counter)
            {
                Leds[Counter + (0 * 8)] = new OutputPortShift(Ic1, (Ic74HC595.Pins)Counter, false);
                Leds[Counter + (1 * 8)] = new OutputPortShift(Ic2, (Ic74HC595.Pins)Counter, false);
                Leds[Counter + (2 * 8)] = new OutputPortShift(Ic3, (Ic74HC595.Pins)Counter, false);
                Leds[Counter + (3 * 8)] = new OutputPortShift(Ic4, (Ic74HC595.Pins)Counter, false);
            }

            // Led loop back and forward
            while (true)
            {
                for (int Counter = 0; Counter < 30; ++Counter)
                {
                    Leds[Counter].Write(true);
                    Thread.Sleep(50);
                    Leds[Counter].Write(false);
                }
                for (int Counter = 28; Counter > 0; --Counter)
                {
                    Leds[Counter].Write(true);
                    Thread.Sleep(50);
                    Leds[Counter].Write(false);
                }
            }
        }

    }
}
