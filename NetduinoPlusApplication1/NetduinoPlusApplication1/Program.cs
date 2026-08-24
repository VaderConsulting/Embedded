using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace NetduinoPlusApplication1
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            //OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);

            while (true)
            {
                led.Write(true); // turn on the LED
                //Thread.Sleep(500); // sleep for 500ms
                led.Write(false); // turn off the LED
                //Thread.Sleep(500); // sleep for 500ms
            }
        }
    }
}