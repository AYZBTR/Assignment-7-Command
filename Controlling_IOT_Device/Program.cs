using Controlling_IOT_Device;
using Controlling_IOT_Device.Program;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;


namespace Controlling_Device
{
    public class Program
    {
        public static void Main(String[] args)
        {

            //Initiating light object and ThermoStatObject.
            Light light = new Light();
            Thermostat thermostat = new Thermostat();

            
            LightTurningOn lightOn = new LightTurningOn(light);
            LightTurningOff lightOff = new LightTurningOff(light);
            IncreaseThermoStatTemp increaseTemp = new IncreaseThermoStatTemp(thermostat);
            DecreaseThermoStatTemp decreaseTemp = new DecreaseThermoStatTemp(thermostat);


            //Displaying status of the light and thermostat
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Default Status of Light and thermostat:");
            Console.WriteLine(light.GetStatus() + "\n" + thermostat.GetStatus() + "\n");
            Console.ResetColor();
            Remote remote = new Remote();

            Dictionary <int, Icommand> remoteKeysMap = new Dictionary <int, Icommand>
            {
                {1,lightOn },
                {2,lightOff },
                {3, increaseTemp },
                {4, decreaseTemp },

            };
            Console.WriteLine("Commands are as follow:" + "\n1: Turn on the light" + "\n2: Turn off the light"
                + "\n3: Increase Temperature of ThermoStat" + "\n4: Decrease Temperature of Thermostat \n Press ESC or Enter to exit program\n");



            while (true)
            {
                Console.Write("Press button (1-4): ");
                // Reads the user input and returns info on key pressed
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //Prevents program from ending 
                Console.TreatControlCAsInput = true;



                //If pressed <Enter> or Esc it exits the program.
                if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                // Convert the KeyChar to a string and attempt to parse it into an integer. If the parsing is successful, assign the parsed integer to the variable key; otherwise, execute the code within the else condition.
                if (int.TryParse(keyInfo.KeyChar.ToString(), out int key))
                {
                    // Retrieve the command from the remoteKeysMap dictionary based on the parsed key.

                    
                 // If the key exists in the dictionary, retrieve the associated command and store it in the variable key; otherwise, execute the code within the else condition.
                    if (remoteKeysMap.TryGetValue(key, out var command))
                    {
                        remote.SetCommand(command);
                        Console.WriteLine("\nYou pressed button {0}.", key);
                        remote.ButtonPressed();
                        // Light and thermostat status after each iteration of changes.
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CURRENT STATUS:\n" + light.GetStatus() + "\n" + thermostat.GetStatus() + "\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\nThe key doesn't exist in remote. Please input a valid key.");
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease input a valid integer.");
                }

            }


        }
    }
}