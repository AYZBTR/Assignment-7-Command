using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlling_IOT_Device
{
    internal class Remote
    {
        Icommand command;
        public Remote()
        {

        }
        public void SetCommand(Icommand command)
        {
            this.command = command;
        }
        public void ButtonPressed()
        {
            {
                command.Execute();
            }
        }
    }
}