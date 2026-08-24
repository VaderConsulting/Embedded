using System.Threading;
using Toolbox.NETMF.Hardware;

public class Servo_API
{
    public void main()
    {
        MicroSerialServoController Servos = new MicroSerialServoController("COM1", MicroSerialServoController.Modes.Pololu);

        // (Re)sets the speed of the first two servos to 0, see the pololu-manual for details about this
        Servos.SetSpeed(0, 0);
        Servos.SetSpeed(1, 0);

        // Wait for 4 seconds
        Thread.Sleep(4000);

        while (true)
        {
            // Set the position of the first two servos
            Servos.SetPosition(0, 0);
            Servos.SetPosition(1, 254);

            // Wait for 2 seconds
            Thread.Sleep(2000);

            // Set the position of the first two servos again to something else
            Servos.SetPosition(0, 254);
            Servos.SetPosition(1, 0);

            // Wait for 2 seconds
            Thread.Sleep(2000);
        }
    }
}