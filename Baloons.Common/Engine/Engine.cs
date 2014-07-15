using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.Common.Engine
{
    public class Engine
    {
        private readonly CommandInterpreter interpreter;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            
            string command = "init";
            while (true)
            {          
                interpreter.ExecuteComand(command);
                command = Console.ReadLine();      
            }
        }
    }
}