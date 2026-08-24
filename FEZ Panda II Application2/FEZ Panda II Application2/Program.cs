using System.Threading;
using GHIElectronics.NETMF.FEZ;
using Microsoft.SPOT.Hardware;

namespace FEZ_Panda_II_Application2
{
    public class Program
    {
        public static void Main()
        {
            // Blink board LED

            bool ledState = false;

            OutputPort led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, ledState);

            while (true)
            {
                // Sleep for 500 milliseconds
                Thread.Sleep(500);

                // toggle LED state
                ledState = !ledState;
                led.Write(ledState);
            }
        }
    }
}