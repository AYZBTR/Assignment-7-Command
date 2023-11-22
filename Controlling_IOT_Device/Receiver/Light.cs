using Controlling_IOT_Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlling_IOT_Device.Program
{
    public class Light
    {
        private bool IsLightON = false;
        public void TurnOn()
        {
            IsLightON = true;
            Console.WriteLine("Light is turned on.");
        }
        public void TurnOff()
        {
            IsLightON = false;
            Console.WriteLine("Light is turned off");
        }
        public string GetStatus()
        {
            return IsLightON ? "***LIGHT IS ON***" : "***Light is OFF***";
        }
    }
    public class LightTurningOn : Icommand
    {
        Light light;

        public LightTurningOn(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOn();
        }
    }
    public class LightTurningOff : Icommand
    {
        Light light;
        public LightTurningOff(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOff();
        }
    }
}

