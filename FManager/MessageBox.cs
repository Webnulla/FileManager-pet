using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FManager
{
    public abstract class MessageBox
    {
        public abstract void Info(string message);
    }
    public sealed class ConsoleLogger : MessageBox
    {
        public override void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
