using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.FEZ;
using Toolbox.NETMF.Hardware;

namespace Panda_Encoder
{
    public class Program
    {
        static int KnobValue = 0;

        public static void Main()
        {
            // Initializes a new rotary encoder object
            RotaryEncoder Knob = new RotaryEncoder(FEZ_Pin.Interrupt.An0, FEZ_Pin.Interrupt.An1, FEZ_Pin.Interrupt.An2);
            
            // Bounds the events to the rotary encoder
            Knob.Rotated += new NativeEventHandler(Knob_Rotated);
            Knob.Pressed += new NativeEventHandler(Knob_Pressed);
            
            // Wait infinitely
            Thread.Sleep(Timeout.Infinite);

        }

        /// <summary>
        /// The value has been changed
        /// </summary>
        /// <param name="Unused">Not used</param>
        /// <param name="Value">The new value</param>
        /// <param name="Time">Time of the event</param>
        static void Knob_Rotated(uint Unused, uint Value, DateTime Time)
        {
            switch (Value)
            {
                case 0:
                    Debug.Print("Counter Clockwise");
                    KnobValue -= 1;
                    if (KnobValue < 0) KnobValue = 0;
                    break;
                case 1:
                    Debug.Print("Clockwise");
                    KnobValue += 1;
                    if (KnobValue == int.MaxValue - 1) KnobValue = int.MaxValue - 1;
                    break;
            }
            Debug.Print(KnobValue.ToString());
        }

        /// <summary>
        /// The value has been changed
        /// </summary>
        /// <param name="Unused">Not used</param>
        /// <param name="Value">The new value</param>
        /// <param name="Time">Time of the event</param>
        static void Knob_Pressed(uint Unused, uint Value, DateTime Time)
        {
            switch (Value)
            {
                case 0:
                    Debug.Print("Pressed");
                    break;
                case 1:
                    Debug.Print("Released");
                    break;
            }
        }
    }
}
