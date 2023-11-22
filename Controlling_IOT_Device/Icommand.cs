using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlling_IOT_Device;

//This is the shared interface utilized by all receiver classes for their commands.
internal interface Icommand
{
    public void Execute();
}
