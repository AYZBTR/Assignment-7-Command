using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlling_IOT_Device.Program
{
    public class Thermostat
    {
        private int temperature = 20;
        public void setTemperature(int temperature)
        {
            this.temperature = temperature;
        }
        public void Increase()
        {
            temperature++;
            Console.WriteLine("The temperature is increased to {0}", temperature);
        }
        public void Decrease()
        {
            temperature--;
            Console.WriteLine("The temperature is decreased to {0}", temperature);
        }
        public string GetStatus()
        {
            return $"***THERMOSTAT TEMPERATURE: {temperature}***";
        }
    }

    // Increase the thermostat temperature.
    public class IncreaseThermoStatTemp : Icommand
    {
        Thermostat thermostat;

        public IncreaseThermoStatTemp(Thermostat th)
        {
            thermostat = th;
        }
        public void Execute()
        {
            thermostat.Increase();
        }
    }

    // decrease the ThermoStat Temperature.
    public class DecreaseThermoStatTemp : Icommand
    {
        Thermostat thermostat;
        public DecreaseThermoStatTemp(Thermostat th)
        {
            thermostat = th;
        }
        public void Execute()
        {
            thermostat.Decrease();
        }
    }
}

