﻿using System;
using System.Linq;

namespace Baloons.Common.Engine
{
    public class Engine
    {
        private readonly CommandInterpreter interpreter;
        private static Engine instance = null;

        private Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        public void Run()
        {
            string command = string.Empty;

            while (true)
            { 
                interpreter.ValidateAndDispatch(command);
                command = Console.ReadLine();      
            }
        }
    }
}