using System.IO;
using System.Threading;
using GHIElectronics.NETMF.FEZ;
using GHIElectronics.NETMF.IO;
using Microsoft.SPOT;
using Microsoft.SPOT.IO;

public class Program
{
    static Thread WDTCounterReset;
    static Thread ReadButton;
    static Thread CheckForHits;
    static int DisplayTimeout;
    static int ThreadTimeout;
    static string SystemName = "Realtag";
    static string SystemVersion = "0.1";
    static string ConfigFileName = @"\SD\Storage.txt";

    public static void Main()
    {
        // Timeouts
        DisplayTimeout = 2000;
        ThreadTimeout = 150;
        uint WatchdogTimeout = 5000;

        //int LEDTimeOn = 500;
        //int LEDTimeOff = 500;

        // Blink LED to indicate activity
        //FEZ_Components.LED led = new FEZ_Components.LED(FEZ_Pin.Digital.LED);
        //led.StartBlinking(LEDTimeOn, LEDTimeOff);

        // Enable Watchdog
        GHIElectronics.NETMF.Hardware.LowLevel.Watchdog.Enable(WatchdogTimeout);

        // Start a Watchdog reset thread
        WDTCounterReset = new Thread(WDTCounterResetLoop);
        WDTCounterReset.Start();

        // Initialise display
        FEZ_Shields.KeypadLCD.Initialize();

        FEZ_Shields.KeypadLCD.Print(SystemName + " V" + SystemVersion, true);
        FEZ_Shields.KeypadLCD.TurnBacklightOn(2000);

        //Pause long enough to give the Player time to push the button
        Thread.Sleep(2000);

        FEZ_Shields.KeypadLCD.TurnBacklightOff();

        // Check for initial button presses
        switch (FEZ_Shields.KeypadLCD.GetKey())
        {
            case FEZ_Shields.KeypadLCD.Keys.Select:
                FEZ_Shields.KeypadLCD.Print("Config", true);
                FEZ_Shields.KeypadLCD.TurnBacklightOn();
                break;
        }

        LoadConfig();

        StartGameLoop();
    }

    private static void LoadConfig()
    {
        // Create a new storage device
        PersistentStorage SDCard = new PersistentStorage("SD");

        // Mount the file system
        SDCard.MountFileSystem();

        // If the SD card can be read...
        if (VolumeInfo.GetVolumes()[0].IsFormatted)
        {
            if (File.Exists(ConfigFileName))
            {
                ReadConfigFile();
            }
            else
            {
                Debug.Print("Config file not found");

                CreateNewConfigFile();
            }
        }
        else
        {
            Debug.Print("SD card not formatted");

            // Format the card
            //VolumeInfo.GetVolumes()[0].Format("FAT", 0);
        }
    }

    private static void CreateNewConfigFile()
    {
        // Create and add default values to the file

        FileStream Stream = new FileStream(ConfigFileName, FileMode.Create);
        {
            StreamWriter writer = new StreamWriter(Stream);
            writer.WriteLine("1");
            writer.Flush();
            writer.Close();
        }
        Stream.Dispose();
        Stream = null;
    }

    private static void ReadConfigFile()
    {
        using (StreamReader reader = new StreamReader(ConfigFileName))
        {
            if (reader.BaseStream.Length > 0)
            {
                do
                {
                    string line = reader.ReadLine();
                    Debug.Print("Read:" + line);
                }
                while (!reader.EndOfStream);
            }
            else
            {
                Debug.Print("File length = 0 bytes");

                CreateNewConfigFile();
            }
        }
    }

    private static void StartGameLoop()
    {
        // Start a button reading thread
        ReadButton = new Thread(ReadButtonLoop);
        ReadButton.Start();

        // Start a check for hits thread
        CheckForHits = new Thread(CheckForHitsLoop);
        CheckForHits.Start();
    }

    private static void WDTCounterResetLoop()
    {
        while (true)
        {
            // reset time counter every 3 seconds
            Thread.Sleep(3000);

            GHIElectronics.NETMF.Hardware.LowLevel.Watchdog.ResetCounter();
        }
    }

    private static void ReadButtonLoop()
    {
        //int LoopCounter = 0;

        while (true)
        {
            FEZ_Shields.KeypadLCD.CursorHome();
            //FEZ_Shields.KeypadLCD.Print("Count " + LoopCounter++);
            //FEZ_Shields.KeypadLCD.SetCursor(1, 2);
            Debug.Print("Buttons?");

            switch (FEZ_Shields.KeypadLCD.GetKey())
            {
                case FEZ_Shields.KeypadLCD.Keys.Up:
                    FEZ_Shields.KeypadLCD.Print("Up    ");
                    FEZ_Shields.KeypadLCD.TurnBacklightOn(DisplayTimeout);
                    break;
                case FEZ_Shields.KeypadLCD.Keys.Down:
                    FEZ_Shields.KeypadLCD.Print("Down  ");
                    FEZ_Shields.KeypadLCD.TurnBacklightOn(DisplayTimeout);
                    break;
                case FEZ_Shields.KeypadLCD.Keys.Left:
                    FEZ_Shields.KeypadLCD.Print("Left  ");
                    FEZ_Shields.KeypadLCD.TurnBacklightOn(DisplayTimeout);
                    break;
                case FEZ_Shields.KeypadLCD.Keys.Right:
                    FEZ_Shields.KeypadLCD.Print("Right ");
                    FEZ_Shields.KeypadLCD.TurnBacklightOn(DisplayTimeout);
                    break;
                case FEZ_Shields.KeypadLCD.Keys.Select:
                    FEZ_Shields.KeypadLCD.Print("Select");
                    FEZ_Shields.KeypadLCD.TurnBacklightOn(DisplayTimeout);
                    break;
                case FEZ_Shields.KeypadLCD.Keys.None:
                    FEZ_Shields.KeypadLCD.Print("");
                    break;
            }
            Thread.Sleep(ThreadTimeout);
        }
    }

    private static void CheckForHitsLoop()
    {
        while (true)
        {
            Debug.Print("Hits?");

            Thread.Sleep(ThreadTimeout);
        }
    }
}