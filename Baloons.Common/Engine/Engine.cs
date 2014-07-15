using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    public class Engine
    {
        private CommandInterpreter interpreter;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (true)
            {
                string command = "init";
                interpreter.ExecuteComand(command);
                //Console.Write("Command: ");
                command = Console.ReadLine();      
            }
        }
    }
}